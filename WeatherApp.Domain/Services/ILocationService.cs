using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Domain.Services
{
    public interface ILocationService
    {
        public Task<Location> GetGeolocation();
    }
}
