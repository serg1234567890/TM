using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TemperatureMonitor.Application.Database.Entities
{
    public class PlacementTypeEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Type { get; set; }
    }
}
