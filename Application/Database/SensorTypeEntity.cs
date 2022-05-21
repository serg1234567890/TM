
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TemperatureMonitor.Application.Database
{
    /// <summary>
    /// Тип датчика
    /// </summary>
    public class SensorTypeEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid SensorId { get; set; }
        [ForeignKey("SensorId")]
        public SensorEntity User { get; set; }
    }
}
