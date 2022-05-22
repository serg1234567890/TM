using TemperatureMonitor.Application.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TemperatureMonitor.Application.Common;

namespace TemperatureMonitor.Application.Database.Seed
{
    public static class SeedPlacement
    {
        public static IList<PlacementEntity> SeedDatabase(ModelBuilder modelBuilder)
        {
            var placements = new PlacementEntity[] {
                new PlacementEntity
                {
                    Id = Guid.NewGuid(),
                    Type=Constants.PlacementTypeKitchen,
                },
                new PlacementEntity
                {
                    Id = Guid.NewGuid(),
                    Type=Constants.PlacementTypeHall,
                },
                new PlacementEntity
                {
                    Id = Guid.NewGuid(),
                    Type=Constants.PlacementTypeHeating,
                }
            }.ToList();

            placements.ToList().ForEach(e => modelBuilder.Entity<PlacementEntity>().HasData(e));

            return placements;
        }
    }
}