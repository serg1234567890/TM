using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TemperatureMonitor.Application.Database.Entities
{
    public class SensorTypeEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Type { get; set; }
        public IList<SensorEntity> Sensors { get; set; }
        public SensorTypeEntity()
        {
            Sensors = new List<SensorEntity>();
        }
    }
}

