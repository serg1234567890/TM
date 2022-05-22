using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TemperatureMonitor.Application.Database.Entities
{
    public class UserRoleEntity
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public UserEntity User { get; set; }
        public Guid RoleId { get; set; }
        [ForeignKey("RoleId")]
        public RoleEntity Role { get; set; }
    }
}
