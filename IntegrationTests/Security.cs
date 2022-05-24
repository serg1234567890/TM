using IdentityModel.Client;
using System.Text;
using System.Text.Json;
using TemperatureMonitor.Application.Auth.Models;

namespace TemperatureMonitor.IntegrationTests
{
    public class Security
    {
        public static async Task SetBearerToken(HttpClient _client, string url, string name, string password)
        {
            var request = new
            {
                Url = url,
                Body = new AuthenticatingUser
                {
                    Name = name,    // _testSettings.Auth.Name,
                    Password = password     //_testSettings.Auth.Password
                }
            };

            var response = await _client.PostAsync(request.Url, GetStringContent(request.Body));

            var responseString = await response.Content.ReadAsStringAsync();
            var authenticatedUser = GetResponseAsObject<AuthenticatedUser>(responseString) as AuthenticatedUser;

            if(authenticatedUser != null) _client.SetBearerToken(authenticatedUser.Token);
        }
        public static StringContent GetStringContent(object obj)
            => new StringContent(JsonSerializer.Serialize(obj), Encoding.Default, "application/json");

        public static object GetResponseAsObject<T>(string responseString)
        {
            var serializeOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            return JsonSerializer.Deserialize<T>(responseString, serializeOptions);
        }
    }
}
