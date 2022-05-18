using WeatherServiceApp.Services;
const string API_KEY = "dd5699bb094c9282d00bb0073abb4e82";
const string BASE_ADDRESS = "https://api.openweathermap.org";



IWeatherService service = new WeatherService(API_KEY, BASE_ADDRESS);


var lat = 51.25356379207989;
var lon = 22.495928247154122;

var json = await service.GetWeatherAsync(lat, lon);

Console.WriteLine(json);

Console.ReadLine();