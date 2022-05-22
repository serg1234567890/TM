using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TemperatureMonitor.Application.Database.Entities
{
    /// <summary>
    /// Показания датчика
    /// </summary>
    public class PlacementSensorEntity
    {
        [Key]
        public Guid Id { get; set; }
        public float SensorValue { get; set; }
        public DateTime ChangeTime { get; set; }
        public Guid SensorId { get; set; }
        [ForeignKey("SensorId")]
        public SensorEntity Sensor { get; set; }
        public Guid PlacementId { get; set; }
        [ForeignKey("PlacementId")]
        public PlacementEntity Placement { get; set; }
    }
}
