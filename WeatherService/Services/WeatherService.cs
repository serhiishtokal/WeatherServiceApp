
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Specialized;
using System.Net.Http.Headers;
using System.Web;
using WeatherServiceApp.Domain;
using WeatherServiceApp.Extensions;

namespace WeatherServiceApp.Services
{



    internal class WeatherService : IWeatherService
    {
        private const string API_KEY = "dd5699bb094c9282d00bb0073abb4e82";
        private const string BASE_API_ADDRESS = "https://api.openweathermap.org";
        private const string FORECAST_API_PATH = "data/2.5/forecast";
        private readonly HttpClient _client;

        public WeatherService()
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private Uri CreateRequestUri(string relatedUrl, Dictionary<string, string> queryParams)
        {
            NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["appid"] = API_KEY;

            foreach (var queryParam in queryParams)
            {
                queryString[queryParam.Key] = queryParam.Value;
            }

            var uriBuilder = new UriBuilder(BASE_API_ADDRESS);
            uriBuilder.Query = queryString.ToString();
            uriBuilder.AppendToPath(relatedUrl);
            var uriReult = uriBuilder.Uri;
            return uriReult;
        }

        private async Task<TResult> GetAsync<TResult>(string url)
        {
            HttpResponseMessage response = await _client.GetAsync(url);
            string responseJSON = "";
            if (response.IsSuccessStatusCode)
            {
                responseJSON = await response.Content.ReadAsStringAsync();
            }

            var settings = new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new SnakeCaseNamingStrategy { ProcessDictionaryKeys = true }
                },
                Formatting = Formatting.Indented
            };

            var result = JsonConvert.DeserializeObject<TResult>(responseJSON, settings);
            return result;
        }

        public async Task<WeatherForecastDto> GetWeatherForecastAsync(double lat, double lon)
        {
            var paramsDict = new Dictionary<string, string>();
            paramsDict["lat"] = lat.ToString();
            paramsDict["lon"] = lon.ToString();

            var url = CreateRequestUri(FORECAST_API_PATH, paramsDict);
            var result = await GetAsync<WeatherForecastDto>(url.ToString());
            return result;
        }


    }

}
