using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using WeatherApp.Domain.Services;
using Xamarin.Essentials;

namespace WeatherApp.Services
{
    [ExcludeFromCodeCoverage] //Exluding this service since it cannot tests instances from Xamarin.Essentials
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
