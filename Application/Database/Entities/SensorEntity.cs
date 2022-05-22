using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public float SensorValue { get; set; }
        public DateTime ChangeTime { get; set; }
        public Guid PlacementId { get; set; }
        [ForeignKey("PlacementId")]
        public PlacementEntity Placement { get; set; }
    }
}
