using WeatherServiceApp.Domain;

namespace WeatherServiceApp.Services
{
    internal interface IWeatherService
    {
        Task<WeatherForecastDto> GetWeatherForecastAsync(double lat, double lon);
    }
}