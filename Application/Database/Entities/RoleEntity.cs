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
        public IList<UserRoleEntity> UserRoles { get; set; }
        public RoleEntity()
        {
            UserRoles = new List<UserRoleEntity>();
        }
    }
}
