using TemperatureMonitor.Application.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TemperatureMonitor.Application.Common;

namespace TemperatureMonitor.Application.Database.Seed
{
    public static class SeedСottage
    {
        public static IList<CottageEntity> SeedDatabase(ModelBuilder modelBuilder,
           IList<UserEntity> users)
        {
            var cottages = new List<CottageEntity>();
            foreach (var user in users)
            {
                var rolePerson = user.UserRoles.FirstOrDefault(a => a.Role.Name == Constants.UserRolePerson);
                if (rolePerson != null)
                {
                    string number = user.Name.Replace(Constants.UserRolePerson, string.Empty);
                    cottages.Add(new CottageEntity
                    {
                        Id = Guid.NewGuid(),
                        Number = int.Parse(number),
                        UserId = user.Id
                    });
                }
            }

            cottages.ToList().ForEach(e => modelBuilder.Entity<CottageEntity>().HasData(e));

            return cottages;
        }
    }
}