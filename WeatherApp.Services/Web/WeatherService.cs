using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using WeatherApp.Common;
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

        public async Task<WeatherDto> GetCurrentWeather(double latitude, double longitude)
        {
            _weatherDto = new WeatherDto();

            try
            {
                var currentWeatherResult = await _restService.CallWeatherApi(WeatherURI(latitude, longitude));

                _weatherDto = JsonConvert.DeserializeObject<WeatherDto>(currentWeatherResult);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return _weatherDto;
        }

        private string WeatherURI(double latitude, double longitude)
        {
            string requestUri = Configs.BASE_URL;
            requestUri += $"?lat={latitude}";
            requestUri += $"&lon={longitude}";
            requestUri += $"&appid={Configs.API_KEY}";
            return requestUri;
        }
    }
}
