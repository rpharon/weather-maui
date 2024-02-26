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
                .ReturnsAsync(It.IsAny<WeatherDto>());

            var viewModel = CreateViewModel();

            await viewModel.GetCurrentWeather();

            viewModel.CurrentWeather.ShouldBeAssignableTo<WeatherItemModel>();
            viewModel.IsBusy.ShouldBeFalse();
        }

        [Test]
        public async Task GetCurrentWeather_ShouldReturnWeatherIfNotNull_OnCall()
        {
            _locationServiceMock.Setup(x => x.GetGeolocation())
                .ReturnsAsync(CreateDummyLocation());

            _weatherServiceMock.Setup(x => x.GetCurrentWeather(It.IsAny<double>(), It.IsAny<double>()))
                .ReturnsAsync(new WeatherDto());

            var viewModel = CreateViewModel();

            await viewModel.GetCurrentWeather();

            viewModel.CurrentWeather.ShouldNotBeNull();
            viewModel.IsBusy.ShouldBeFalse();
        }
    }
}
