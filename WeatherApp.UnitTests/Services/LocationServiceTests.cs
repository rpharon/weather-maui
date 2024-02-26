using Microsoft.Maui.Devices.Sensors;
using Moq;
using NUnit.Framework;
using Shouldly;
using WeatherApp.Domain.Services;
using WeatherApp.Services;

namespace WeatherApp.UnitTests.Services
{
    [TestFixture]
    public class LocationServiceTests
    {
        private Mock<IGeolocationService> _geoLocationServiceMock;
        private Location _location;

        [SetUp]
        public void SetUp()
        {
            _geoLocationServiceMock = new Mock<IGeolocationService>();

            _location = new Location();
        }

        private LocationService CreateService()
        {
            return new LocationService(_geoLocationServiceMock.Object);
        }

        [Test]
        public async Task GetGeolocation_ShouldReturnLocation_OnCall()
        {
            _geoLocationServiceMock.Setup(x => x.GetLocation())
                .ReturnsAsync(_location);

            var service = CreateService();

            var result = await service.GetGeolocation();

            result.Latitude.ShouldBe(It.IsAny<double>());
            result.Longitude.ShouldBe(It.IsAny<double>());
        }
    }
}
