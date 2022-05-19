using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherServiceApp.Domain
{
    internal class WeatherForecast
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public int TimezoneSec { get; set; }
        public string Country { get; set; }
        public string PlaceName { get; set; }
        public List<WeatherForecastTimestamp> WeatherForecastTimestamps { get; set; } 
    }

    internal class WeatherForecastTimestamp
    {
        public DateTime DateTime { get; set; }
        

        public double Temperature { get; set; }
        public double TemperatureFeelsLike { get; set; }
        public double TemperatureMin { get; set; }
        public double TemperatureMax { get; set; }

        //https://openweathermap.org/weather-conditions
        public int WeatherId { get; set; }
        public string WeatherName { get; set; }
        public string WeatherDescription { get; set; }
        public string WeatherIcon { get; set; }
    }
}
