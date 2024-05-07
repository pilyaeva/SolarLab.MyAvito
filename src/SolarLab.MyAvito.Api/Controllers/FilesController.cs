using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SolarLab.MyAvito.Application.Repositories;

namespace SolarLab.MyAvito.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilesController : Controller
    {
        private readonly ILogger<FilesController> _logger;
        private readonly IFileRepository _fileRepository;

        public FilesController(ILogger<FilesController> logger, IFileRepository fileRepository)
        {
            _logger = logger;
            _fileRepository = fileRepository;
        }

        /// <summary>
        /// Скачивает файл.
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(FileContentResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            var file = await _fileRepository.GetAsync(id, cancellationToken);

            if (file == null)
            {
                return NotFound($"Файл с ID {id} не найден");
            }

            Response.ContentLength = file.Content.Length;
            return File(file.Content, file.ContentType, file.Name);
        }
    }
}
