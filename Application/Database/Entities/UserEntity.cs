using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TemperatureMonitor.Application.Database.Entities
{
    public class UserEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CottageNumber { get; set; }
        public Guid RoleId { get; set; }
        [ForeignKey("RoleId")]
        public RoleEntity Role { get; set; }
        public IList<CottageEntity> Cottages { get; set; }
        public UserEntity()
        {
            Cottages = new List<CottageEntity>();
        }
    }
}
