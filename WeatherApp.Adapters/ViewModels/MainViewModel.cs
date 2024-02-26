using System;
using System.Threading.Tasks;
using WeatherApp.Adapters.ItemModels;
using WeatherApp.Adapters.ViewModels.Base;
using WeatherApp.Domain.Services;

namespace WeatherApp.Adapters.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IWeatherService _weatherService;
        private readonly ILocationService _locationService;

        public MainViewModel(IWeatherService weatherService, ILocationService locationService)
        {
            _weatherService = weatherService;
            _locationService = locationService;
        }

        private WeatherItemModel? _currentWeather;
        public WeatherItemModel? CurrentWeather 
        { 
            get => _currentWeather; 
            set => SetProperty(ref _currentWeather, value); 
        }

        public async Task GetCurrentWeather()
        {
            try
            {
                IsBusy = true;

                var location = await _locationService.GetGeolocation();

                var weatherDto = await _weatherService.GetCurrentWeather(location.Latitude, location.Longitude);

                CurrentWeather = new WeatherItemModel(weatherDto);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
