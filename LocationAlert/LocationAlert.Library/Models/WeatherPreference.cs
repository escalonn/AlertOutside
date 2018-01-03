using System;

using System.Collections.Generic;
using System.Net;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LocationAlert.Library.Models
{
    public  class WeatherPreference 
    {
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public float tempInFah { get; set; }

        public WeatherPreference() { }

        public WeatherPreference(decimal longi, decimal latit)
        {
            Longitude = longi;
            Latitude = latit;
        }
        public Object GetWeatherForeCast(double Longitude, double Latitude)
        {
            
            var api = "http://api.openweathermap.org/data/2.5/weather?lat=" + Latitude + "&lon=" + Longitude + "&&APPID=f44745b3b949068be733eb938051eed4";
            var client = new WebClient();
            var content = client.DownloadString(api);
            var jsonContent = JsonConvert.DeserializeObject<Object>(content);
           

            return jsonContent;
        }
       
    }
}
