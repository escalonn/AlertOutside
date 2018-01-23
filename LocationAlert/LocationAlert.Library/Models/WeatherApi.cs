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

            [JsonProperty("name")]
            internal string Name { get; set; }

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
            internal double WindSpeed { get; set; }
        }
        internal class WeatherResponseCloud
        {
            [JsonProperty("all ")]
            internal int Cloudiness { get; set; }
        }

        public int RainVolume { get; set; }
        public int SnowVolume { get; set; }
        public int Humidity { get; set; }
        public double Wind { get; set; }
        public int Clouds { get; set; }
        public string Name { get; set; }
        public double TemperatureK { get; set; }

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
                        ["lon"] = longitude.ToString(),
                        ["APPID"] = OpenWeatherMapApiKey
                    };

                    string fullApiUri = QueryHelpers.AddQueryString(baseApiUri, queryString);
                    Console.WriteLine(fullApiUri);
                    //string fullApiUri = "http://api.openweathermap.org/data/2.5/weather?lat=35&lon=139&APPID=f44745b3b949068be733eb938051eed4";
                                           //http://api.openweathermap.org/data/2.5/weather?lat=51.79163&long=6.818848&APPID=f44745b3b949068be733eb938051eed4
                    HttpResponseMessage response = await client.GetAsync(fullApiUri);
                    response.EnsureSuccessStatusCode();

                    string stringResult = await response.Content.ReadAsStringAsync();

                    var rawWeather = JsonConvert.DeserializeObject<WeatherResponse>(stringResult);

                    //double temperatureF = KelvinToFahrenheit(temperatureK);
                    TempInFah = KelvinToFahrenheit(TemperatureK);

                    //***********

                    Name = rawWeather.Name;
                    TempInFah = KelvinToFahrenheit(rawWeather.Main.Temperature);
                    Humidity = rawWeather.Main.Humidity;

                    RainVolume = rawWeather.RainVolume?.RainVolume ?? 0;
                    SnowVolume = rawWeather.SnowVolume?.SnowVolume ?? 0;
                    Wind = rawWeather.WindSpeed?.WindSpeed ?? 0;
                    Clouds = rawWeather.Cloudiness?.Cloudiness ?? 0;
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
