namespace WeatherServiceApp.Domain
{
    internal class WeatherForecastDto
    {
        public string Cod { get; set; }
        public int Message { get; set; }
        public int Cnt { get; set; }
        public List<WeatherForecastListItemDto> List { get; set; }
        public WeatherForecastCityDto City { get; set; }
    }

    internal class WeatherForecastCityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public WeatherForecastCoordinatesDto Coord { get; set; }
        public string Country { get; set; }
        public int Population { get; set; }
        //in sec
        public int Timezone { get; set; }
        //datetime ticks
        public long Sunrise { get; set; }
        //datetime ticks
        public long Sunset { get; set; }
    }

    internal class WeatherForecastCoordinatesDto
    {
        public double Lat { get; set; }
        public double Lon { get; set; }
    }
    internal class WeatherForecastListItemDto
    {
        //datetime ticks
        public long Dt { get; set; }
        public WeatherForecastListItemMainInfoDto Main { get; set; }
        public List<WeatherForecastListItemWeatherDto> Weather { get; set; }
        public object Clouds { get; set; }
        public object Wind { get; set; }
        public double Visibility { get; set; }
        public double Pop { get; set; }
        public object Sys { get; set; }
        public string DtTxt { get; set; }
    }


    internal class WeatherForecastListItemMainInfoDto
    {
        public double Temp { get; set; }
        public double FeelsLike { get; set; }
        public double TempMin { get; set; }
        public double TempMax { get; set; }
        public double Pressure { get; set; }
        public double SeaLevel { get; set; }
        public double GrndLevel { get; set; }
        public double Humidity { get; set; }
        public double TempKf { get; set; }
    }

    internal class WeatherForecastListItemWeatherDto
    {
        public int Id { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }

}
