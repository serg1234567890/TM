namespace TemperatureMonitor.Application
{
    public class AppSettings
    {
        public JwtAppSettings Jwt { get; set; }
        public MonitorAppSettings Monitor { get; set; }
    }

    public class JwtAppSettings
    {
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int? ExpiresInMins { get; set; }
        public int? RefreshTokenExpiresInDays { get; set; }
    }

    public class MonitorAppSettings
    {
        public int TotalSensors { get; set; }
    }
}
