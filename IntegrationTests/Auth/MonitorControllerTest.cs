using TemperatureMonitor.Application.Monitor.Models;

namespace TemperatureMonitor.IntegrationTests.Auth
{
    [TestClass]
    public class MonitorControllerTest
    {
        [TestMethod]
        public async Task Get()
        {
            // Arrange
            await Security.SetBearerToken(InitServer.Client, "http://localhost:5000/auth/login", "admin", "admin");

            // Act

            HttpResponseMessage response = await InitServer.Client.GetAsync("monitor");

            // Assert
            //response.EnsureSuccessStatusCode();

            var responseDataAsString = await response.Content.ReadAsStringAsync();
            var monitorData = Security.GetResponseAsObject<IList<CottageData>>(responseDataAsString) as IList<CottageData>;

            Assert.IsNotNull(monitorData);
            Assert.AreEqual(100, monitorData.Count);
        }

        [TestMethod]
        public async Task GetKitchenHistory()
        {
            // Arrange
            var cottage = InitServer.DbContext.Ñottages.FirstOrDefault();
            Assert.IsNotNull(cottage);

            await Security.SetBearerToken(InitServer.Client, "http://localhost:5000/auth/login", "admin", "admin");

            // Act

            HttpResponseMessage response = await InitServer.Client.GetAsync($"monitor/kitchen/{cottage.Id}");

            // Assert
            //response.EnsureSuccessStatusCode();

            var responseDataAsString = await response.Content.ReadAsStringAsync();
            var historyData = Security.GetResponseAsObject<IList<HistoryData>>(responseDataAsString) as IList<HistoryData>;

            Assert.IsNotNull(historyData);
            Assert.AreEqual(20, historyData.Count);
        }
    }
}