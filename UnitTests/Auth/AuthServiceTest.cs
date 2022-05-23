using Microsoft.Extensions.DependencyInjection;
using TemperatureMonitor.Application.Auth.Interfaces;
using TemperatureMonitor.Application.Auth.Models;
using TemperatureMonitor.Application.Database;
using Presentation;
using Microsoft.EntityFrameworkCore;

namespace TemperatureMonitor.UnitTests.Auth
{
    [TestClass]
    public class AuthServiceTest
    {
        readonly IServiceProvider _services =
            Program.CreateHostBuilder(new string[] { }).Build().Services;

        [TestMethod]
        public void TestLoginAdmin()
        {
            var authService = _services.GetRequiredService<IAuthService>();

            var admin = new AuthenticatingUser()
            {
                Name = "admin",
                Password = "admin"
            };

            var authenticatedAdmin = authService.Login(admin).Result;

            Assert.AreEqual("admin", authenticatedAdmin.Name);
            Assert.AreEqual("admin", authenticatedAdmin.Role);

            var appDbContext = _services.GetRequiredService<ApplicationDbContext>();

            var user = appDbContext.Users.FirstOrDefault(a => a.Id == Guid.Parse(authenticatedAdmin.Id));
            Assert.IsNotNull(user);

            Assert.IsTrue(!string.IsNullOrWhiteSpace(authenticatedAdmin.Token));
        }

        [TestMethod]
        public void TestLoginPerson()
        {
            var authService = _services.GetRequiredService<IAuthService>();

            for (var i = 1; i <= 100; i++)
            {
                var admin = new AuthenticatingUser()
                {
                    Name = "person" + i,
                    Password = "person" + i
                };

                var authenticatedPerson = authService.Login(admin).Result;

                Assert.AreEqual("person" + i, authenticatedPerson.Name);
                Assert.AreEqual("person", authenticatedPerson.Role);

                var appDbContext = _services.GetRequiredService<ApplicationDbContext>();

                var user = appDbContext.Users.FirstOrDefault(a => a.Id == Guid.Parse(authenticatedPerson.Id));
                Assert.IsNotNull(user);

                Assert.IsTrue(!string.IsNullOrWhiteSpace(authenticatedPerson.Token));
            }
        }
    }
}