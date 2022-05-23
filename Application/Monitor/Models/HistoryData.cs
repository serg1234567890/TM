using System;

namespace TemperatureMonitor.Application.Monitor.Models
{
    public class HistoryData
    {
        public string Id { get; set; }
        public float SensorValue { get; set; }
        public string ChangeTime { get; set; }
    }
}
