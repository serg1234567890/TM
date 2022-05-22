using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        public IList<UserRoleEntity> UserRoles { get; set; }
        public UserEntity()
        {
            UserRoles = new List<UserRoleEntity>();
        }
    }
}
