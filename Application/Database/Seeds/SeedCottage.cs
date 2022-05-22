using TemperatureMonitor.Application.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TemperatureMonitor.Application.Common;

namespace TemperatureMonitor.Application.Database.Seed
{
    public static class SeedCottage
    {
        public static IList<CottageEntity> SeedDatabase(ModelBuilder modelBuilder,
           IList<UserEntity> users)
        {
            var cottages = new List<CottageEntity>();
            foreach (var user in users)
            {
                if (user.CottageNumber > 0)
                {
                    cottages.Add(new CottageEntity
                    {
                        Id = Guid.NewGuid(),
                        Number = user.CottageNumber,
                        UserId = user.Id
                    });
                }
            }

            cottages.ToList().ForEach(e => modelBuilder.Entity<CottageEntity>().HasData(e));

            return cottages;
        }
    }
}