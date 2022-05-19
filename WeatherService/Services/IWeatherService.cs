using WeatherServiceApp.Domain;

namespace WeatherServiceApp.Services
{
    internal interface IWeatherService
    {
        Task<WeatherForecast> GetWeatherForecastAsync(double lat, double lon, string langCode = "EN", string measureUnits = "metric");
        Task<WeatherForecastDto> GetWeatherForecastRawAsync(double lat, double lon, string langCode = "EN", string measureUnits = "metric");
    }
}