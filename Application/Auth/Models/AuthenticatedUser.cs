namespace TemperatureMonitor.Application.Auth.Models
{
    public class AuthenticatedUser
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }
    }
}
