using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SolarLab.MyAvito.Api.Models;
using SolarLab.MyAvito.Application;
using SolarLab.MyAvito.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

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
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> Add(
            [FromForm] AdvertisementDtoIn advertisementsDtoIn,
            CancellationToken cancellationToken)
        {
            var addedAdvertisement = await _advertisementRepository.AddAsync(
                new Advertisement
                {
                    Id = Guid.NewGuid(),
                    UserId = Guid.Empty,
                    Title = advertisementsDtoIn.Title,
                    Price = advertisementsDtoIn.Price,
                    Condition = advertisementsDtoIn.Condition,
                    Description = advertisementsDtoIn.Description
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

        private async Task<byte[]> GetBytesAsync(IFormFile file, CancellationToken cancellationToken)
        {
            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream, cancellationToken);
            return memoryStream.ToArray();
        }

    }
}
