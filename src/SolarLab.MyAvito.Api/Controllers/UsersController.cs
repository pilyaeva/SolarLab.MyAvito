using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SolarLab.MyAvito.Api.Models;
using SolarLab.MyAvito.Application;
using SolarLab.MyAvito.Domain;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace SolarLab.MyAvito.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUserRepository _userRepository;

        public UsersController(ILogger<UsersController> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        /// <summary>
        /// Регистрирует пользователя.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Add([FromBody] UserDtoIn userDtoIn, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByLoginAsync(userDtoIn.Login, cancellationToken);
            if (user != null)
            {
                return BadRequest("Пользователь с таким логином уже существует.");
            }

            var createdUser = await _userRepository.AddAsync(
                new User
                {
                    Id = Guid.NewGuid(),
                    Login = userDtoIn.Login,
                    Password = userDtoIn.Password
                },
                cancellationToken);

            _logger.LogInformation("Создан пользователь с ID {0}", createdUser.Id);

            return Created(string.Empty, createdUser.Id);
        }
    }
}
