using Microsoft.Extensions.DependencyInjection;
using TemperatureMonitor.Application.Auth.Interfaces;
using TemperatureMonitor.Application.Auth.Models;
using TemperatureMonitor.Application.Database;
using Presentation;
using TemperatureMonitor.Application.Monitor.Interfaces;
using TemperatureMonitor.Application.Common;

namespace TemperatureMonitor.UnitTests.Monitor
{
    [TestClass]
    public class MonitorServiceTest
    {
        readonly IServiceProvider _services =
            Program.CreateHostBuilder(new string[] { }).Build().Services;

        [TestMethod]
        public void TestLoginAdmin()
        {
            var monitorService = _services.GetRequiredService<IMonitorService>();
            var appDbContext = _services.GetRequiredService<ApplicationDbContext>();

            var user = appDbContext.Users.FirstOrDefault(a => a.Name == Constants.UserRoleAdmin);
            Assert.IsNotNull(user);

            var list = monitorService.List(user.Id);
        }
    }
}