using System;
using System.Collections.Generic;

namespace LocationAlert.Library.Models
{
    public  class Account
    {
        public string  Email { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string MiddleInitial { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public List<Region> Regions { get; set; } = new List<Region>();

        public const int MaxRegion = 3;

        public WeatherPreference WeatherPref { get; set; } = new WeatherPreference();

        public bool EverPushed { get; set; } = false;

        public DateTime LastPush { get; set; }

        public Account() { }

        public Account(string email)
        {
            Email = email;
        }
    }
}
