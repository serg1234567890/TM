using TemperatureMonitor.Application.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TemperatureMonitor.Application.Common;

namespace TemperatureMonitor.Application.Database.Seed
{
    public static class SeedUserRoles
    {
        public static IList<UserRoleEntity> SeedDatabase(ModelBuilder modelBuilder,
           IList<RoleEntity> roles, IList<UserEntity> users)
        {
            var roleAdmin = roles.FirstOrDefault(a => a.Name == Constants.UserRoleAdmin);
            var rolePerson = roles.FirstOrDefault(a => a.Name == Constants.UserRolePerson);

            var userRoles = new List<UserRoleEntity>();
            foreach (var user in users)
            {
                var role = user.Name == Constants.UserRoleAdmin ? roleAdmin : rolePerson;
                userRoles.Add(new UserRoleEntity
                {
                    Id = Guid.NewGuid(),
                    UserId = user.Id,
                    RoleId = role.Id
                });
            }

            userRoles.ToList().ForEach(e => modelBuilder.Entity<UserRoleEntity>().HasData(e));

            return userRoles;
        }
    }
}