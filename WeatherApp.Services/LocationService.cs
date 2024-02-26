using System.Threading.Tasks;
using WeatherApp.Domain.Services;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public class LocationService : ILocationService
    {
        private readonly IGeolocationService _geolocationService;

        public LocationService(IGeolocationService geolocationService)
        {
            _geolocationService = geolocationService;
        }

        public async Task<Location> GetGeolocation()
        {
            var location = await _geolocationService.GetLocation();

            return location != null
                ? new Location()
                {
                    Latitude = location.Latitude,
                    Longitude = location.Longitude
                }
                : new Location()
                {
                    Latitude = 0.00,
                    Longitude = 0.00
                };
        }
    }
}
