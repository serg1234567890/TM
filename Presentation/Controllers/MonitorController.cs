using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TemperatureMonitor.Application.Monitor.Interfaces;

namespace TemperatureMonitor.Presentation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MonitorController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMonitorService _monitorService;

        public MonitorController(IMonitorService monitorService, IHttpContextAccessor httpContextAccessor)
        {
            _monitorService = monitorService;
            _httpContextAccessor = httpContextAccessor;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var idClaim = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            if (idClaim == null) return Ok();

            var result = await _monitorService.List(Guid.Parse(idClaim.Value));

            return Ok(result);
        }
    }
}
