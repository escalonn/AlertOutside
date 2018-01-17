using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace LocationAlert.Client.Models
{
    public class Account
    {
        [Required]
        [EmailAddress]
        public MailAddress Email { get; set; } = new MailAddress("undefined@gmail.com");

        [Required]
        public string Password { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string MiddleInitial { get; set; }
        
        public string LastName { get; set; }

        [Phone]
        public string Phone { get; set; }

        public List<Region> RegionList { get; set; } = new List<Region>();

        public const int MaxRegion = 3;

        public WeatherPreference MyWeather { get; set; } = new WeatherPreference();
    }
}
