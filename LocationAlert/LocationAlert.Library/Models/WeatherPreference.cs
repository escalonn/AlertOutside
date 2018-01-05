using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace LocationAlert.Library.Models
{
    public class WeatherPreference
    {
        // see api at http://openweathermap.org/current
        internal class WeatherResponse
        {
            [JsonProperty("main")]
            internal WeatherResponseMain Main { get; set; }
        }

        internal class WeatherResponseMain
        {
            [JsonProperty("temp")]
            internal double Temperature { get; set; }
        }

        private static string OpenWeatherMapApiKey = "f44745b3b949068be733eb938051eed4";

        public decimal Longitude { get; set; }

        public decimal Latitude { get; set; }

        public float TempInFah { get; set; }

        public WeatherPreference() { }

        public WeatherPreference(decimal latitude, decimal longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        // do not run more than once per 10 minutes!
        // see: https://www.openweathermap.org/appid
        public async Task<double> GetWeatherForecastAsync(double latitude, double longitude)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var baseApiUri = "http://api.openweathermap.org/data/2.5/weather";
                    var queryString = new Dictionary<string, string>()
                    {
                        ["lat"] = latitude.ToString(),
                        ["long"] = longitude.ToString(),
                        ["APPID"] = OpenWeatherMapApiKey
                    };
                    string fullApiUri = QueryHelpers.AddQueryString(baseApiUri, queryString);
                    HttpResponseMessage response = await client.GetAsync(fullApiUri);
                    response.EnsureSuccessStatusCode();

                    string stringResult = await response.Content.ReadAsStringAsync();
                    var rawWeather = JsonConvert.DeserializeObject<WeatherResponse>(stringResult);
                    double temperatureK = rawWeather.Main.Temperature;
                    double temperatureF = KelvinToFahrenheit(temperatureK);
                    return temperatureF;
                }
                catch (HttpRequestException)
                {
                    throw;
                }
            }
        }

        private static double KelvinToFahrenheit(double tempKelvin)
        {
            return tempKelvin * 9 / 5 - 459.67;
        }
    }
}
