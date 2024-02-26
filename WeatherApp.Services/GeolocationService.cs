using Microsoft.Maui.Devices.Sensors;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using WeatherApp.Domain.Services;

namespace WeatherApp.Services
{
    [ExcludeFromCodeCoverage] //Exluding this service since it cannot tests instances from Microsoft.Maui.Devices.Sensors
    public class GeolocationService : IGeolocationService
    {
        public async Task<Location> GetLocation()
        {
            try
            {
                var location = await Geolocation.GetLocationAsync();

                return location;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }
    }
}
