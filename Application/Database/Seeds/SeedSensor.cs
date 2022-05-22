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
        public static IList<SensorEntity> SeedDatabase(ModelBuilder modelBuilder)
        {
            var sensors = new SensorEntity[] {
                new SensorEntity
                {
                    Id = Guid.NewGuid(),
                    Type=Constants.SensorTypeTemperature,
                }
            }.ToList();

            sensors.ToList().ForEach(e => modelBuilder.Entity<SensorEntity>().HasData(e));

            return sensors;
        }
    }
}