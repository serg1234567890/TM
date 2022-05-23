using Microsoft.Extensions.DependencyInjection;
using Presentation;
using TemperatureMonitor.Application.Auth.Interfaces;

namespace TemperatureMonitor.Tests.UnitTests
{
    [TestClass]
    public class AuthServiceTest
    {
        readonly IServiceProvider _services =
            Program.CreateHostBuilder(new string[] { }).Build().Services;

        [TestInitialize]
        public void Init()
        {

        }
        [TestMethod]
        public void TestLogin()
        {
            var authService = _services.GetRequiredService<IAuthService>();
        }
    }
}