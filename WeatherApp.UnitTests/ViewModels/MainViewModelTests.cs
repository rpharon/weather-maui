using Moq;
using NUnit.Framework;
using Shouldly;
using WeatherApp.Adapters.ItemModels;
using WeatherApp.Adapters.ViewModels;
using WeatherApp.Domain.Services;
using WeatherApp.Models;
using WeatherApp.Models.Dtos;

namespace WeatherApp.UnitTests.ViewModels
{
    public class MainViewModelTests
    {
        private Mock<IWeatherService> _weatherServiceMock;
        private Mock<ILocationService> _locationServiceMock;

        [SetUp]
        public void SetUp()
        {
            _weatherServiceMock = new Mock<IWeatherService>();
            _locationServiceMock = new Mock<ILocationService>();
        }

        private MainViewModel CreateViewModel()
        {
            return new MainViewModel(_weatherServiceMock.Object,
                                     _locationServiceMock.Object);
        }

        private WeatherDto CreateDummyWeather()
        {
            return new WeatherDto()
            {
                Title = "Test",
                Coordinates = new Coord() { Lat = 1.00, Lon = 2.00 },
                Weather = new[] { new Weather() { } },
                Base = "Test",
                Main = new Main() { Temperature = 0, Humidity = 0, Pressure = 0, TempMax = 0, TempMin = 0},
                Visibility = (long)0.00,
                Wind = new Wind() { Deg = 0, Speed = 0},
                Clouds = new Clouds() { All = (long?)0.00 },
                Dt = (long)0.00,
                Sys = new Sys() { },
                Id = (long)0.00,
                Cod = (long)0.00,
            };
        }

        private Location CreateDummyLocation()
        {
            return new Location()
            {
                Latitude = 1.00,
                Longitude = 10.00
            };
        }

        [Test]
        public async Task GetCurrentWeather_ShouldBeAssignableToWeatherItemModel_OnCall()
        {
            _locationServiceMock.Setup(x => x.GetGeolocation())
                .ReturnsAsync(CreateDummyLocation());

            _weatherServiceMock.Setup(x => x.GetCurrentWeather(It.IsAny<double>(), It.IsAny<double>()))
                .ReturnsAsync(CreateDummyWeather());

            var viewModel = CreateViewModel();

            await viewModel.GetCurrentWeather();

            viewModel.CurrentWeather.ShouldBeAssignableTo<WeatherItemModel>();
            viewModel.IsBusy.ShouldBeFalse();
        }

        [Test]
        public async Task GetCurrentWeather_ShouldReturnWeatherAndSetCurrentWeatherIfNotNull_OnCall()
        {
            var dummyWeather = CreateDummyWeather();

            _locationServiceMock.Setup(x => x.GetGeolocation())
                .ReturnsAsync(CreateDummyLocation());

            _weatherServiceMock.Setup(x => x.GetCurrentWeather(It.IsAny<double>(), It.IsAny<double>()))
                .ReturnsAsync(CreateDummyWeather());

            var viewModel = CreateViewModel();

            await viewModel.GetCurrentWeather();

            viewModel.CurrentWeather.ShouldNotBeNull();

            viewModel.CurrentWeather.Lat.ShouldBe(dummyWeather.Coordinates.Lat);
            viewModel.CurrentWeather.Lon.ShouldBe(dummyWeather.Coordinates.Lon);
            viewModel.CurrentWeather.Temperature.ShouldBe(dummyWeather.Main.Temperature);
            viewModel.CurrentWeather.Pressure.ShouldBe(dummyWeather.Main.Pressure);
            viewModel.CurrentWeather.Humidity.ShouldBe(dummyWeather.Main.Humidity);
            viewModel.CurrentWeather.TempMin.ShouldBe(dummyWeather.Main.TempMin);
            viewModel.CurrentWeather.TempMax.ShouldBe(dummyWeather.Main.TempMax);
            viewModel.CurrentWeather.Visibility.ShouldBe(dummyWeather.Visibility);
            viewModel.CurrentWeather.Speed.ShouldBe(dummyWeather.Wind.Speed);
            viewModel.CurrentWeather.Deg.ShouldBe(dummyWeather.Wind.Deg);

            viewModel.IsBusy.ShouldBeFalse();
        }
    }
}
