
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TemperatureMonitor.Application.Auth.Models;
using TemperatureMonitor.Application.Monitor.Models;

namespace TemperatureMonitor.Application.Monitor.Interfaces
{
    public interface IMonitorService
    {
        Task<IList<CottageData>> List(Guid userId);
    }
}
