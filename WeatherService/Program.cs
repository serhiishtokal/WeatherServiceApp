using WeatherServiceApp.Services;

IWeatherService service = new WeatherService();

var lat = 51.25356379207989;
var lon = 22.495928247154122;

var weatherForecastDto = await service.GetWeatherForecastAsync(lat, lon);

Console.WriteLine(weatherForecastDto);
Console.ReadLine();