using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocationAlert.Data.Service.Models
{
    public class Account
    {
        public string Email { get; set; }

        public List<Region> Regions { get; set; } = new List<Region>();

        public WeatherPreference WeatherPref { get; set; } = new WeatherPreference();
    }
}
