using System.Threading.Tasks;
using Xamarin.Essentials;

namespace WeatherApp.Domain.Services
{
    public interface IGeolocationService
    {
        public Task<Location> GetLocation();
    }
}
