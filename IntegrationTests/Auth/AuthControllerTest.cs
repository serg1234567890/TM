using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Presentation;
using System.Text.Json;
using TemperatureMonitor.Application.Auth.Interfaces;
using TemperatureMonitor.Application.Auth.Models;
using TemperatureMonitor.Application.Database;

namespace TemperatureMonitor.IntegrationTests.Auth
{
    [TestClass]
    public class AuthControllerTest
    {
        [TestMethod]
        public async Task Heartbeat()
        {
            // Arrange
            await Security.SetBearerToken(InitServer.Client, "http://localhost:5000/auth/login", "admin", "admin");

            // Act

            HttpResponseMessage response = await InitServer.Client.GetAsync("auth/heartbeat");

            // Assert
            //response.EnsureSuccessStatusCode();

            Assert.AreEqual(System.Net.HttpStatusCode.NoContent, response.StatusCode);
        }
    }
}