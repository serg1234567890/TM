
using System.Threading.Tasks;
using TemperatureMonitor.Application.Auth.Models;

namespace TemperatureMonitor.Application.Monitor.Interfaces
{
    public interface IMonitorService
    {
        Task List();
    }
}
