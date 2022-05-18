
using System;
using System.Collections.Specialized;
using System.IO;
using System.Net.Http.Headers;
using System.Web;
using WeatherServiceApp.Extensions;

namespace WeatherServiceApp.Services
{



    internal class WeatherService : IWeatherService
    {
        private readonly HttpClient _client;
        private readonly string _apiKey;
        private readonly string _baseUrl;

        public WeatherService(string apiKey, string baseAddress)
        {
            _client = new HttpClient();
            //var uriBuilder = new UriBuilder(baseAddress);
            //var baseQuery = HttpUtility.ParseQueryString(uriBuilder.Query);
            //_client.BaseAddress = new Uri(baseAddress);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            _apiKey = apiKey;
            _baseUrl = baseAddress;
        }

        //private string AddApiIdParameter(Uri uri)
        //{

        //}

        public async Task<string> GetWeatherAsync(double lat, double lon)
        {
            NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["appid"] = _apiKey;
            queryString["lat"]= lat.ToString();
            queryString["lon"]= lon.ToString();

            var uriBuilder = new UriBuilder(_baseUrl);
            uriBuilder.Query = queryString.ToString();
            uriBuilder.Append("data/2.5/forecast");
            var url = uriBuilder.Uri;

            HttpResponseMessage response = await _client.GetAsync(url);
            string responseString="";
            if (response.IsSuccessStatusCode)
            {
                responseString = await response.Content.ReadAsStringAsync();
            }

            return responseString;
        }

    }
}
