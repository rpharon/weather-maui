using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using WeatherApp.Domain.Services;
using WeatherApp.Domain.Web;
using WeatherApp.Models.Dtos;

namespace WeatherApp.Services.Web
{
    public class WeatherService : IWeatherService
    {
        private readonly IRestService _restService;
        private WeatherDto _weatherDto;

        public WeatherService(IRestService restService)
        {
            _restService = restService;
        }

        public async Task<WeatherDto> GetCurrentWeather()
        {
            _weatherDto = new WeatherDto();

            try
            {
                var currentWeatherResult = await _restService.CallWeatherApi("");

                _weatherDto = JsonConvert.DeserializeObject<WeatherDto>(currentWeatherResult);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return _weatherDto;
        }
    }
}
