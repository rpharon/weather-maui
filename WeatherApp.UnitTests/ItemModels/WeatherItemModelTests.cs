using NUnit.Framework;
using Shouldly;
using WeatherApp.Adapters.ItemModels;
using WeatherApp.Models.Dtos;

namespace WeatherApp.UnitTests.ItemModels
{
    [TestFixture]
    public class WeatherItemModelTests
    {
        private static WeatherItemModel CreateItemModel()
        {
            return new WeatherItemModel(CreateDummyDto());
        }

        private static WeatherDto CreateDummyDto()
        {
            return new WeatherDto()
            {
                Title = "Test",
                Coordinates = new Coord() { Lat = 1.00, Lon = 2.00 },
                Weather = new[] { new Weather() { } },
                Base = "Test",
                Main = new Main() { Temperature = 0, Humidity = 0, Pressure = 0, TempMax = 0, TempMin = 0 },
                Visibility = (long)0.00,
                Wind = new Wind() { Deg = 0, Speed = 0 },
                Clouds = new Clouds() { All = (long?)0.00 },
                Dt = (long)0.00,
                Sys = new Sys() { },
                Id = (long)0.00,
                Cod = (long)0.00,
            };
        }

        [Test]
        public void Ctor_ShouldBeOfTypeWeatherItemModel_OnCall()
        {
            var model = CreateItemModel();

            model.ShouldBeOfType<WeatherItemModel>();
        }
    }
}
