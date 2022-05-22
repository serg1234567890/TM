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
                    FirstName = "Admin first name",
                    LastName = "Admin last name",
                    RoleId = roleAdmin.Id
                }
            }.ToList();

            for (var i = 1; i <= 100; i++)
            {
                users.Add(new UserEntity
                {
                    Id = Guid.NewGuid(),
                    Name = Constants.UserRolePerson + i,
                    Password = Constants.UserRolePerson + i,
                    FirstName = "First name " + i,
                    LastName = "Last name",
                    RoleId = rolePerson.Id
                });
            }

            users.ToList().ForEach(e => modelBuilder.Entity<UserEntity>().HasData(e));

            return users;
        }
    }
}