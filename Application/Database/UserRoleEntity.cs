using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TemperatureMonitor.Application.Database
{
    public class UserRoleEntity
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public UserEntity User { get; set; }
        public string Role { get; set; }
    }
}
