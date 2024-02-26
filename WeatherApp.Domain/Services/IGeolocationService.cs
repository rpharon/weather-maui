using Microsoft.Maui.Devices.Sensors;
using System.Threading.Tasks;

namespace WeatherApp.Domain.Services
{
    public interface IGeolocationService
    {
        public Task<Location> GetLocation();
    }
}
