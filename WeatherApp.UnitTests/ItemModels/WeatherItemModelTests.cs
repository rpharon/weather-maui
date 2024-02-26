using Moq;
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
            return new WeatherItemModel(CreateDto());
        }

        private static WeatherDto CreateDto()
        {
            return new WeatherDto();
        }

        [Test]
        public void Ctor_ShouldBeOfTypeWeatherItemModel_OnCall()
        {
            var model = CreateItemModel();

            model.ShouldBeOfType<WeatherItemModel>();
        }
    }
}
