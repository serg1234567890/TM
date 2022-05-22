using TemperatureMonitor.Application.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TemperatureMonitor.Application.Common;

namespace TemperatureMonitor.Application.Database.Seed
{
    public static class SeedSensorType
    {
        public static IList<SensorTypeEntity> SeedDatabase(ModelBuilder modelBuilder)
        {
            var sensorTypes = new SensorTypeEntity[] {
                new SensorTypeEntity
                {
                    Id = Guid.NewGuid(),
                    Type=Constants.SensorTypeTemperature,
                }
            }.ToList();

            sensorTypes.ToList().ForEach(e => modelBuilder.Entity<SensorTypeEntity>().HasData(e));

            return sensorTypes;
        }
    }
}