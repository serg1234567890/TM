using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TemperatureMonitor.Application.Auth.Interfaces;
using TemperatureMonitor.Application.Auth.Models;

namespace TemperatureMonitor.Presentation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [Authorize]
        [Route("heartbeat")]
        [HttpGet]
        public IActionResult Heartbeat()
        {
	        return NoContent();
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticatingUser authenticatingUser)
        {
            var result = await _authService.Login(authenticatingUser);

            if (result != null) 
            {
                return Ok(result);
            }

            return Unauthorized();
        }
    }
}
