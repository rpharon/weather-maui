using Moq;
using NUnit.Framework;
using Shouldly;
using WeatherApp.Domain.Web;
using WeatherApp.Models.Dtos;
using WeatherApp.Services.Web;

namespace WeatherApp.UnitTests.Services.Web
{
    public class WeatherServiceTests
    {
        Mock<IRestService> _restServiceMock;

        [SetUp]
        public void SetUp()
        {
            _restServiceMock = new Mock<IRestService>();
        }

        private WeatherService CreateService()
        {
            return new WeatherService(_restServiceMock.Object);
        }

        [Test]
        public async Task GetCurrentWeather_ShouldBeOfTypeWeatherDto_OnCall()
        {
            _restServiceMock.Setup(x => x.CallWeatherApi(""))
                .ReturnsAsync(It.IsAny<string>());

            var service = CreateService();

            var result = await service.GetCurrentWeather();

            result.ShouldBeOfType<WeatherDto>();
        }
    }
}
