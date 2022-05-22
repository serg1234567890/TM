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
        public static IList<PlacementEntity> SeedDatabase(ModelBuilder modelBuilder,
            IList<PlacementTypeEntity> placementTypes, IList<CottageEntity> cottages)
        {
            var kitchenType = placementTypes.FirstOrDefault(a => a.Type == Constants.PlacementTypeKitchen);
            var hallType = placementTypes.FirstOrDefault(a => a.Type == Constants.PlacementTypeHall);
            var heatingType = placementTypes.FirstOrDefault(a => a.Type == Constants.PlacementTypeHeating);

            var placements = new List<PlacementEntity>();
            foreach (var cottage in cottages)
            {
                placements.Add(new PlacementEntity
                {
                    Id = Guid.NewGuid(),
                    Name = Constants.PlacementNameKitchen,
                    PlacementTypeId = kitchenType.Id,
                    CottageId = cottage.Id
                });
                placements.Add(new PlacementEntity
                {
                    Id = Guid.NewGuid(),
                    Name = Constants.PlacementNameHall,
                    PlacementTypeId = hallType.Id,
                    CottageId = cottage.Id
                });
                placements.Add(new PlacementEntity
                {
                    Id = Guid.NewGuid(),
                    Name = Constants.PlacementNameHeating,
                    PlacementTypeId = heatingType.Id,
                    CottageId = cottage.Id
                });
            }

            placements.ToList().ForEach(e => modelBuilder.Entity<PlacementEntity>().HasData(e));

            return placements;
        }
    }
}