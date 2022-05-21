using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TemperatureMonitor.Application.Database
{
    public class UserEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IList<UserRoleEntity> Roles { get; set; }
        public UserEntity()
        {
            Roles = new List<UserRoleEntity>();
        }
    }
}
