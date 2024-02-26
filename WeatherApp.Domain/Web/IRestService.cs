using System.Threading.Tasks;

namespace WeatherApp.Domain.Web
{
    public interface IRestService
    {
        public Task<string> CallWeatherApi(string url);
    }
}
