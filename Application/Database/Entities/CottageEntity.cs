using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TemperatureMonitor.Application.Database.Entities
{
    public class CottageEntity
    {
        [Key]
        public Guid Id { get; set; }
        public int Number { get; set; }
        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public UserEntity User { get; set; }
        public IList<PlacementEntity> Placements { get; set; }
        public CottageEntity()
        {
            Placements = new List<PlacementEntity>();
        }
    }
}
