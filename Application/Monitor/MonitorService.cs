using Microsoft.Extensions.Options;
using System.Linq;
using System.Threading.Tasks;
using TemperatureMonitor.Application.Database;
using Microsoft.EntityFrameworkCore;
using TemperatureMonitor.Application.Monitor.Interfaces;
using System.Collections.Generic;
using TemperatureMonitor.Application.Monitor.Models;
using TemperatureMonitor.Application.Common;
using System;

namespace TemperatureMonitor.Application.Monitor
{
    public class MonitorService : IMonitorService
    {
        private readonly AppSettings _appSettings;
        private readonly ApplicationDbContext _context;

        public MonitorService(IOptions<AppSettings> appSettings, ApplicationDbContext context)
        {
            _appSettings = appSettings.Value;
            _context = context;
        }

        public async Task<IList<CottageData>> List(Guid userId)
        {
            var user = await _context.Users
                .Include(a => a.Role).Where(u => u.Id == userId).FirstOrDefaultAsync();

            var lastValues = await _context.Sensors
                .Include(a => a.SensorType)
                .Include(a => a.Placement).ThenInclude(a => a.PlacementType)
                .Include(a => a.Placement).ThenInclude(a => a.Cottage)
                .Where(a => user.CottageNumber == 0 || user.CottageNumber != 0 && a.Placement.Cottage.Number == user.CottageNumber)
                .OrderByDescending(a => a.ChangeTime)
                .Take(_appSettings.Monitor.TotalSensors).ToListAsync();

            var cottageIds = lastValues.GroupBy(a => a.Placement.CottageId).Select(a => a.Key);
            var cottages = _context.Сottages.Where(a => cottageIds.Contains(a.Id));

            var result = new List<CottageData>();
            foreach (var cottage in cottages)
            {
                var kitchenTemperature = lastValues.FirstOrDefault(a => 
                    a.Placement.Cottage.Number == cottage.Number &&
                    a.Placement.PlacementType.Type == Constants.PlacementTypeKitchen);

                var hallTemperature = lastValues.FirstOrDefault(a =>
                    a.Placement.Cottage.Number == cottage.Number &&
                    a.Placement.PlacementType.Type == Constants.PlacementTypeHall);

                var heatingTemperature = lastValues.FirstOrDefault(a =>
                    a.Placement.Cottage.Number == cottage.Number &&
                    a.Placement.PlacementType.Type == Constants.PlacementTypeHeating);

                result.Add(
                    new CottageData()
                    {
                        Id = cottage.Id.ToString(),
                        CottageNumber = cottage.Number,
                        KitchenTemperature = kitchenTemperature.SensorValue,
                        HallTemperature = hallTemperature.SensorValue,
                        HeatingTemperature = heatingTemperature.SensorValue
                    }
                );
            }
            return result;
        }

        public async Task<IList<HistoryData>> History(Guid userId, Guid cottageId, string type)
        {
            var user = await _context.Users
                .Include(a => a.Role).Where(u => u.Id == userId).FirstOrDefaultAsync();

            var historyValues = await _context.Sensors
                .Include(a => a.SensorType)
                .Include(a => a.Placement).ThenInclude(a => a.PlacementType)
                .Include(a => a.Placement).ThenInclude(a => a.Cottage)
                .Where(a => a.Placement.CottageId == cottageId && a.Placement.PlacementType.Type == type)
                .OrderByDescending(a => a.ChangeTime)
                .Take(_appSettings.Monitor.TotalSensors).ToListAsync();

            var result = new List<HistoryData>();
            foreach (var history in historyValues)
            {
                result.Add(
                    new HistoryData()
                    {
                        Id = history.Id.ToString(),
                        ChangeTime = history.ChangeTime.ToString("dd/MM/yyyy  HH:mm:ss"),
                        SensorValue = history.SensorValue
                    }
                );
            }
            return result;
        }
    }
}
