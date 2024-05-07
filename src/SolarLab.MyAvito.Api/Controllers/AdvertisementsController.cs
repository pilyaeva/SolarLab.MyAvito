using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SolarLab.MyAvito.Api.Models;
using SolarLab.MyAvito.Application.Repositories;
using SolarLab.MyAvito.Domain;

namespace SolarLab.MyAvito.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdvertisementsController : Controller
    {
        private readonly ILogger<AdvertisementsController> _logger;
        private readonly IAdvertisementRepository _advertisementRepository;
        private readonly IFileRepository _fileRepository;

        public AdvertisementsController(
            ILogger<AdvertisementsController> logger,
            IAdvertisementRepository advertisementRepository,
            IFileRepository fileRepository)
        {
            _logger = logger;
            _advertisementRepository = advertisementRepository;
            _fileRepository = fileRepository;
        }

        /// <summary>
        /// Создаёт объявление.
        /// </summary>
        /// <param name="advertisementsDtoIn"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Add(
            [FromForm] AdvertisementDtoIn advertisementsDtoIn,
            CancellationToken cancellationToken)
        {
            var userIdString = User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier)?.Value;

            if (userIdString == null)
            {
                return BadRequest("Не задан ID пользователя");
            }

            if (!Guid.TryParse(userIdString, out var userId))
            {
                return BadRequest("Невозможно распознать ID пользователя");
            }

            var advertisementByUser = await _advertisementRepository.GetPagedByUserIdAsync(userId, 10, 1, cancellationToken);

            var todayAdvertisementsByUser = advertisementByUser
                .Advertisements
                .Where(advertisementByUser => advertisementByUser.CreatedAt >= DateTime.UtcNow.Date)
                .ToList();

            if (todayAdvertisementsByUser.Count > 10)
            {
                return BadRequest("За сутки можно создавать не больше 10 объявлений.");
            }

            var addedAdvertisement = await _advertisementRepository.AddAsync(
                new Advertisement
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    Title = advertisementsDtoIn.Title,
                    Price = advertisementsDtoIn.Price,
                    Condition = advertisementsDtoIn.Condition,
                    Description = advertisementsDtoIn.Description,
                    CreatedAt = DateTime.UtcNow
                },
                cancellationToken);

            var files = new List<Domain.File>();

            foreach (var photo in advertisementsDtoIn.Photos)
            {
                files.Add(new Domain.File
                {
                    Id = Guid.NewGuid(),
                    AdvertisementId = addedAdvertisement.Id,
                    Name = photo.FileName,
                    Content = await GetBytesAsync(photo, cancellationToken),
                    ContentType = photo.ContentType,
                    Length = photo.Length
                });
            }

            await _fileRepository.AddAsync(files, cancellationToken);

            _logger.LogInformation("Создано объявление с ID {0}", addedAdvertisement.Id);

            return Created(string.Empty, addedAdvertisement.Id);
        }

        /// <summary>
        /// Возвращает постраничный список объявлений пользователя.
        /// </summary>
        /// <returns></returns>
        [HttpGet("ByUserId/{userId}")]
        [ProducesResponseType(typeof(PagedAdvertisementsWithPhotoIdsByUserDtoOut), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetPagedByUserId(Guid userId,
            [FromQuery] PagedAdvertisementsByUserDtoIn pagedAdvertisementsByUserDtoIn,
            CancellationToken cancellationToken)
        {
            var pageSize = 10;

            var pageAdvertisements = await _advertisementRepository
                .GetPagedByUserIdAsync(userId, pageSize, pagedAdvertisementsByUserDtoIn.PageIndex, cancellationToken);

            var advertisementsWithPhotoIds = new List<AdvertisementWithPhotoIdsDtoOut>();

            foreach (var advertisement in pageAdvertisements.Advertisements)
            {
                var photos = await _fileRepository.GetByAdvertisementIdAsync(advertisement.Id, cancellationToken);

                advertisementsWithPhotoIds.Add(new AdvertisementWithPhotoIdsDtoOut
                {
                    Id = advertisement.Id,
                    UserId = advertisement.UserId,
                    Title = advertisement.Title,
                    Price = advertisement.Price,
                    Condition = advertisement.Condition,
                    Description = advertisement.Description,
                    CreateAt = advertisement.CreatedAt,
                    PhotosId = photos.Select(photo => photo.Id).ToList()
                });
            }

            return Ok(new PagedAdvertisementsWithPhotoIdsByUserDtoOut
            {
                Advertisements = advertisementsWithPhotoIds,
                MaxPage = pageAdvertisements.MaxPage
            });
        }

        /// <summary>
        /// Удаляет объявление.
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var advertisement = await _advertisementRepository.GetAsync(id, cancellationToken);

            if (advertisement == null)
            {
                return NotFound($"Объявление с ID {id} не найдено");
            }

            var files = await _fileRepository.GetByAdvertisementIdAsync(advertisement.Id, cancellationToken);

            foreach (var file in files)
            {
                await _fileRepository.DeleteAsync(file.Id, cancellationToken);
            }

            await _advertisementRepository.DeleteAsync(advertisement.Id, cancellationToken);

            return NoContent();
        }

        private async Task<byte[]> GetBytesAsync(IFormFile file, CancellationToken cancellationToken)
        {
            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream, cancellationToken);
            return memoryStream.ToArray();
        }
    }
}
