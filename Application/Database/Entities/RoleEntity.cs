using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TemperatureMonitor.Application.Database.Entities
{
    public class RoleEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IList<UserEntity> Users { get; set; }
        public RoleEntity()
        {
            Users = new List<UserEntity>();
        }
    }
}
