using Moq;
using NUnit.Framework;
using Shouldly;
using WeatherApp.Adapters.ItemModels;
using WeatherApp.Adapters.ViewModels;
using WeatherApp.Domain.Services;
using WeatherApp.Models.Dtos;

namespace WeatherApp.UnitTests.ViewModels
{
    public class MainViewModelTests
    {
        private Mock<IWeatherService> _weatherServiceMock;

        [SetUp]
        public void SetUp()
        {
            _weatherServiceMock = new Mock<IWeatherService>();
        }

        private MainViewModel CreateViewModel()
        {
            return new MainViewModel(_weatherServiceMock.Object);
        }

        [Test]
        public async Task GetCurrentWeather_ShouldBeOfTypeWeatherItemModel_OnCall()
        {
            _weatherServiceMock.Setup(x => x.GetCurrentWeather())
                .ReturnsAsync(It.IsAny<WeatherDto>());

            var viewModel = CreateViewModel();

            await viewModel.GetCurrentWeather();

            viewModel.CurrentWeather.ShouldBeOfType<WeatherItemModel>();
        }

        [Test]
        public async Task GetCurrentWeather_ShouldReturnWeatherIfNotNull_OnCall()
        {
            _weatherServiceMock.Setup(x => x.GetCurrentWeather())
                .ReturnsAsync(new WeatherDto());

            var viewModel = CreateViewModel();

            await viewModel.GetCurrentWeather();

            viewModel.CurrentWeather.ShouldNotBeNull();
        }
    }
}
