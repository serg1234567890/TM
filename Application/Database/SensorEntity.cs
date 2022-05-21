using System;
using System.ComponentModel.DataAnnotations;

namespace TemperatureMonitor.Application.Database
{
    /// <summary>
    /// Датчик температуры
    /// </summary>
    public class SensorEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
