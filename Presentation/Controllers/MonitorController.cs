using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TemperatureMonitor.Application.Common;
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

        [Route("kitchen/{cottageId:guid}")]
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetKitchenHistory(Guid cottageId)
        {
            var idClaim = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            if (idClaim == null) return Ok();

            var result = await _monitorService.History(Guid.Parse(idClaim.Value), cottageId, Constants.PlacementTypeKitchen);

            return Ok(result);
        }

        [Route("hall/{cottageId:guid}")]
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetHallHistory(Guid cottageId)
        {
            var idClaim = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            if (idClaim == null) return Ok();

            var result = await _monitorService.History(Guid.Parse(idClaim.Value), cottageId, Constants.PlacementTypeHall);

            return Ok(result);
        }

        [Route("heating/{cottageId:guid}")]
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetHeatingHistory(Guid cottageId)
        {
            var idClaim = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            if (idClaim == null) return Ok();

            var result = await _monitorService.History(Guid.Parse(idClaim.Value), cottageId, Constants.PlacementTypeHeating);

            return Ok(result);
        }
    }
}
