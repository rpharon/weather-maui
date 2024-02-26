using System.Threading.Tasks;
using WeatherApp.Adapters.ItemModels;
using WeatherApp.Adapters.ViewModels.Base;
using WeatherApp.Domain.Services;

namespace WeatherApp.Adapters.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IWeatherService _weatherService;

        public MainViewModel(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        private WeatherItemModel? _currentWeather;
        public WeatherItemModel? CurrentWeather 
        { 
            get => _currentWeather; 
            set => SetProperty(ref _currentWeather, value); 
        }

        public async Task GetCurrentWeather()
        {
            var weatherDto = await _weatherService.GetCurrentWeather();

            CurrentWeather = new WeatherItemModel(weatherDto);
        }
    }
}
