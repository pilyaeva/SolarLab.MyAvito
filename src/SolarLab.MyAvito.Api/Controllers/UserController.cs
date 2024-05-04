using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SolarLab.MyAvito.Application;
using SolarLab.MyAvito.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SolarLab.MyAvito.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserRepository _userRepository;

        public UserController(ILogger<UserController> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] User user, CancellationToken cancellationToken)
        {
            var createdUser = await _userRepository.AddAsync(user, cancellationToken);

            return Created(string.Empty, createdUser.Id);
        }
    }
}
