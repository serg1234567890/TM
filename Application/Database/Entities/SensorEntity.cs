using System;
using System.ComponentModel.DataAnnotations;

namespace TemperatureMonitor.Application.Database.Entities
{
    /// <summary>
    /// Датчик температуры
    /// </summary>
    public class SensorEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Type { get; set; }
    }
}
