using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace LocationAlert.Library.Models
{
    public  class Account
    {

        public MailAddress Email { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string MiddleInitial { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        //public List<Region> RegionList { get; set; } = new List<Region>();

        public const int MaxRegion = 3;

        public WeatherPreference MyWeather { get; set; } = new WeatherPreference();

        public Account()
        {
            Email = new MailAddress("undefined@gmail.com");
        }
    }
}
