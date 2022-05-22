using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TemperatureMonitor.Application.Database.Entities
{
    public class CottagePlacementEntity
    {
        [Key]
        public Guid Id { get; set; }
        public Guid CottageId { get; set; }
        [ForeignKey("CottageId")]
        public CottageEntity Cottage { get; set; }
        public Guid PlacementId { get; set; }
        [ForeignKey("PlacementId")]
        public PlacementEntity Placement { get; set; }
    }
}
