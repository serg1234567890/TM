using TemperatureMonitor.Application.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TemperatureMonitor.Application.Common;

namespace TemperatureMonitor.Application.Database.Seed
{
    public static class SeedUsers
    {
        public static IList<UserEntity> SeedDatabase(ModelBuilder modelBuilder,
            IList<RoleEntity> roles)
        {
            var roleAdmin = roles.FirstOrDefault(a => a.Name == Constants.UserRolePerson);
            var rolePerson = roles.FirstOrDefault(a => a.Name == Constants.UserRolePerson);
            var users = new UserEntity[] {
                new UserEntity
                {
                    Id = Guid.NewGuid(),
                    Name=Constants.UserRoleAdmin,
                    Password = Constants.UserRoleAdmin,
                    RoleId = roleAdmin.Id,
                    CottageNumber = 0
                }
            }.ToList();

            for (var i = 1; i <= 100; i++)
            {
                users.Add(new UserEntity
                {
                    Id = Guid.NewGuid(),
                    Name = Constants.UserRolePerson + i,
                    Password = Constants.UserRolePerson + i,
                    RoleId = rolePerson.Id,
                    CottageNumber = i
                });
            }

            users.ToList().ForEach(e => modelBuilder.Entity<UserEntity>().HasData(e));

            return users;
        }
    }
}