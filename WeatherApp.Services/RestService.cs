using System;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherApp.Domain.Web;

namespace WeatherApp.Services
{
    public class RestService : IRestService
    {
        HttpClient _httpClient;

        public RestService()
        {
            _httpClient = new HttpClient();    
        }

        public async Task<string> CallWeatherApi(string url)
        {
            try
            {
                var response = await _httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    return content;
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return await Task.FromResult(string.Empty);
        }
    }
}
