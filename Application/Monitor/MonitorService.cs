using TemperatureMonitor.Application.Database.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TemperatureMonitor.Application.Auth.Models;
using TemperatureMonitor.Application.Database;
using Microsoft.EntityFrameworkCore;
using TemperatureMonitor.Application.Monitor.Interfaces;
using Microsoft.AspNetCore.Http;

namespace TemperatureMonitor.Application.Monitor
{
    public class MonitorService : IMonitorService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly AppSettings _appSettings;
        private readonly ApplicationDbContext _context;

        public MonitorService(IOptions<AppSettings> appSettings, ApplicationDbContext context,
            IHttpContextAccessor httpContextAccessor)
        {
            _appSettings = appSettings.Value;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task List()
        {
            var username = _httpContextAccessor.HttpContext.User.Identity.Name;

            var idClaim = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            if (idClaim == null) return;

            var user = await _context.Users.Where(u => u.Id == Guid.Parse(idClaim.Value)).FirstOrDefaultAsync();

        }
    }
}
