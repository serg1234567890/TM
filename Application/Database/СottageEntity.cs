using System;
using System.ComponentModel.DataAnnotations;

namespace TemperatureMonitor.Application.Database
{
    public class СottageEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Number { get; set; }
    }
}
