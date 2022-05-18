namespace WeatherServiceApp.Services
{
    internal interface IWeatherService
    {
        Task<string> GetWeatherAsync(double lat, double lon);
    }
}