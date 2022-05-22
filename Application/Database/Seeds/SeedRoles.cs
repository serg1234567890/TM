using TemperatureMonitor.Application.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TemperatureMonitor.Application.Common;

namespace TemperatureMonitor.Application.Database.Seed
{
    public static class SeedRoles
    {
        public static IList<RoleEntity> SeedDatabase(ModelBuilder modelBuilder)
        {
            var roles = new RoleEntity[] {
                new RoleEntity
                {
                    Id = Guid.NewGuid(),
                    Name=Constants.UserRoleAdmin,
                },
                new RoleEntity
                {
                    Id = Guid.NewGuid(),
                    Name=Constants.UserRolePerson,
                }
            }.ToList();

            roles.ToList().ForEach(e => modelBuilder.Entity<RoleEntity>().HasData(e));

            return roles;
        }
    }
}