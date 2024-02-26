using Moq;
using NUnit.Framework;
using Shouldly;
using WeatherApp.Services;

namespace WeatherApp.UnitTests.Services
{
    [TestFixture]
    public class RestServiceTests
    {
        [Test]
        public async Task CallWeatherApi_ShouldReturnString_OnCall()
        {
            var service = new RestService();

            var result = await service.CallWeatherApi(It.IsAny<string>());

            result.ShouldBeOfType<string>();
        }
    }
}
