using TemperatureMonitor.Application.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TemperatureMonitor.Application.Common;

namespace TemperatureMonitor.Application.Database.Seed
{
    public static class SeedSensor
    {
        public static IList<SensorEntity> SeedDatabase(ModelBuilder modelBuilder,
            IList<PlacementEntity> placements)
        {
            var sensors = new List<SensorEntity>();
            foreach (var placement in placements)
            {
                sensors.Add(new SensorEntity
                {
                    Id = Guid.NewGuid(),
                    Type = Constants.SensorTypeTemperature,
                    PlacementId = placement.Id
                });
            }

            sensors.ToList().ForEach(e => modelBuilder.Entity<SensorEntity>().HasData(e));

            return sensors;
        }
    }
}