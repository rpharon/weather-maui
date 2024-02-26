using NUnit.Framework;
using Shouldly;

namespace WeatherApp.UnitTests.Models
{
    [TestFixture]
    public class Location
    {
        private WeatherApp.Models.Location CreateModel()
        {
            return new WeatherApp.Models.Location();
        }

        [Test]
        public void Ctor()
        {
            var model = CreateModel();

            model.ShouldBeOfType<WeatherApp.Models.Location>();
        }

        [TestCase(0.00, 0.00)]
        [TestCase(10.00, 10.00)]
        public void Location_ShouldReturnExpectedLatLongOnCall(double input, double expectedResult)
        {
            var model = CreateModel();

            model.Latitude = input;
            model.Longitude = input;

            model.Latitude.ShouldBe(expectedResult);
            model.Longitude.ShouldBe(expectedResult);
        }

        [TestCase(0.00, 1.00)]
        [TestCase(10.00, 20.00)]
        public void Location_ShouldNotReturnExpectedLatLongOnCall(double input, double expectedResult)
        {
            var model = CreateModel();

            model.Latitude = input;
            model.Longitude = input;

            model.Latitude.ShouldNotBe(expectedResult);
            model.Longitude.ShouldNotBe(expectedResult);
        }
    }
}
