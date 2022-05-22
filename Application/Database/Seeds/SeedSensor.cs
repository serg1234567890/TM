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
            IList<SensorTypeEntity> sensorTypes,
            IList<PlacementTypeEntity> placementTypes,
            IList<PlacementEntity> placements)
        {
            var sensor = sensorTypes.FirstOrDefault(a => a.Type == Constants.SensorTypeTemperature);

            var kitchenType = placementTypes.FirstOrDefault(a => a.Type == Constants.PlacementTypeKitchen);
            var hallType = placementTypes.FirstOrDefault(a => a.Type == Constants.PlacementTypeHall);
            var heatingType = placementTypes.FirstOrDefault(a => a.Type == Constants.PlacementTypeHeating);

            var kitchenTemp = 22.0f;
            var hallTemp = 25.0f;
            var heatingTemp = 50.0f;
            var random = new Random();
            var date = DateTime.Today;

            var sensors = new List<SensorEntity>();
            foreach (var placement in placements)
            {
                for (var i = 0; i < 20; i++)
                {
                    var shift = random.Next(-1000, 1000) / 1000.0f;
                    date = date.AddMinutes(5);
                    sensors.Add(new SensorEntity
                    {
                        Id = Guid.NewGuid(),
                        SensorTypeId = sensor.Id,
                        PlacementId = placement.Id,
                        SensorValue = placement.PlacementTypeId == kitchenType.Id ? kitchenTemp + shift :
                                      placement.PlacementTypeId == hallType.Id ? hallTemp + shift :
                                      heatingTemp + shift,
                        ChangeTime = date

                    });
                }
            }

            sensors.ToList().ForEach(e => modelBuilder.Entity<SensorEntity>().HasData(e));

            return sensors;
        }
    }
}