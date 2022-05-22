using TemperatureMonitor.Application.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TemperatureMonitor.Application.Common;

namespace TemperatureMonitor.Application.Database.Seed
{
    public static class SeedPlacementType
    {
        public static IList<PlacementTypeEntity> SeedDatabase(ModelBuilder modelBuilder)
        {
            var placementTypes = new PlacementTypeEntity[] {
                new PlacementTypeEntity
                {
                    Id = Guid.NewGuid(),
                    Type=Constants.PlacementTypeKitchen,
                },
                new PlacementTypeEntity
                {
                    Id = Guid.NewGuid(),
                    Type=Constants.PlacementTypeHall,
                },
                new PlacementTypeEntity
                {
                    Id = Guid.NewGuid(),
                    Type=Constants.PlacementTypeHeating,
                }
            }.ToList();

            placementTypes.ToList().ForEach(e => modelBuilder.Entity<PlacementTypeEntity>().HasData(e));

            return placementTypes;
        }
    }
}