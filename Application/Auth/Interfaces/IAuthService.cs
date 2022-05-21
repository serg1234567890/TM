
using System.Threading.Tasks;
using TemperatureMonitor.Application.Auth.Models;

namespace TemperatureMonitor.Application.Auth.Interfaces
{
    public interface IAuthService
    {
        Task<AuthenticatedUser> Login(AuthenticatingUser authenticatingUser);
    }
}
