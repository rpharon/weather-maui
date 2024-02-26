using WeatherApp.Models.Dtos;

namespace WeatherApp.Adapters.ItemModels
{
    public class WeatherItemModel
    {
        public WeatherItemModel(WeatherDto dto)
        {
            Title = dto.Title;
            Weather = dto.Weather != null ? dto.Weather[0] : new Weather();
            Clouds = dto.Clouds;
            Sys = dto.Sys;
            Lat = dto.Coordinates?.Lat;
            Lon = dto.Coordinates?.Lon;
            Temperature = dto.Main?.Temperature;
            Pressure = dto.Main?.Pressure;
            Humidity = dto.Main?.Humidity;
            TempMin = dto.Main?.TempMin;
            TempMax = dto.Main?.TempMax;
            Visibility = dto.Visibility;
            Speed = dto.Wind?.Speed;
            Deg = dto.Wind?.Deg;
        }

        public string? Title { get; set; }
        public Weather? Weather { get; set; }
        public Clouds? Clouds { get; set; }
        public Sys? Sys { get; set; }
        public double? Lon { get; set; }
        public double? Lat { get; set; }
        public double? Temperature { get; set; }
        public long? Pressure { get; set; }
        public long? Humidity { get; set; }
        public double? TempMin { get; set; }
        public double? TempMax { get; set; }
        public long? Visibility { get; set; }
        public double? Speed { get; set; }
        public long? Deg { get; set; }
    }
}
