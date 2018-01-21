using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;

namespace LocationAlert.Library.Models
{
    // Used to make API call, and to store returned data
    public class WeatherApi
    {
        // see api at http://openweathermap.org/current
        internal class WeatherResponse
        {
            [JsonProperty("main")]
            internal WeatherResponseMain Main { get; set; }
            [JsonProperty("weather")]
            internal WeatherResponseCode Code { get; set; }
            [JsonProperty("rain")]
            internal WeatherResponseRain RainVolume { get; set; }
            [JsonProperty("snow")]
            internal WeatherResponseSnow SnowVolume { get; set; }
            [JsonProperty("wind")]
            internal WeatherResponseWind WindSpeed { get; set; }
            [JsonProperty("clouds")]
            internal WeatherResponseCloud Cloudiness { get; set; }
        }

        internal class WeatherResponseMain
        {
            [JsonProperty("temp")]
            internal double Temperature { get; set; }

            [JsonProperty("humidity")]
            internal int Humidity { get; set; }
        }
        internal class WeatherResponseCode
        {
            [JsonProperty("id")]
            internal int Code { get; set; }
        }
        internal class WeatherResponseRain
        {
            [JsonProperty("3h")]
            internal int RainVolume { get; set; }
        }
        internal class WeatherResponseSnow
        {
            [JsonProperty("3h")]
            internal int SnowVolume { get; set; }
        }
        internal class WeatherResponseWind
        {
            [JsonProperty("speed")]
            internal int WindSpeed { get; set; }
        }
        internal class WeatherResponseCloud
        {
            [JsonProperty("all ")]
            internal int Cloudiness { get; set; }
        }

        public int WeatherCode { get; set; }
        public int RainVolume { get; set; }
        public int SnowVolume { get; set; }
        public int Humidity { get; set; }
        public int Wind { get; set; }
        public int Clouds { get; set; }

        private static string OpenWeatherMapApiKey = "f44745b3b949068be733eb938051eed4";

        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public double TempInFah { get; set; }

        public WeatherApi() { }

        public WeatherApi(decimal latitude, decimal longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        // do not run more than once per 10 minutes!
        // see: https://www.openweathermap.org/appid
        public async Task GetWeatherForecastAsync(double latitude, double longitude)
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
                    //double temperatureF = KelvinToFahrenheit(temperatureK);
                    TempInFah = KelvinToFahrenheit(temperatureK);

                    //***********
                    WeatherCode = rawWeather.Code.Code;
                    RainVolume = rawWeather.RainVolume.RainVolume;
                    SnowVolume = rawWeather.SnowVolume.SnowVolume;
                    Humidity = rawWeather.Main.Humidity;
                    Wind = rawWeather.WindSpeed.WindSpeed;
                    Clouds = rawWeather.Cloudiness.Cloudiness;
                    //***********

                    //return temperatureF;
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
