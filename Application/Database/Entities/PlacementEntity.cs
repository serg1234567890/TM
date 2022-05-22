using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TemperatureMonitor.Application.Database.Entities
{
    /// <summary>
    /// Помещения
    /// </summary>
    public class PlacementEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CottageId { get; set; }
        [ForeignKey("CottageId")]
        public CottageEntity Cottage { get; set; }
        public Guid PlacementTypeId { get; set; }
        [ForeignKey("PlacementTypeId")]
        public PlacementTypeEntity PlacementType { get; set; }
    }
}
