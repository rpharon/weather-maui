using System.Threading.Tasks;
using WeatherApp.Models.Dtos;

namespace WeatherApp.Domain.Services
{
    public interface IWeatherService
    {
        public Task<WeatherDto> GetCurrentWeather();
    }
}
