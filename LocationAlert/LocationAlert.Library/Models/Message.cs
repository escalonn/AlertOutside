using System;
using System.Collections.Generic;
using System.Text;

namespace LocationAlert.Library.Models
{
    public class Message
    {
        public string email { get; set; }

        public WeatherPreference preferences { get; set; }

        public List<string> RegionMessage { get; set; }

        public string Text { get; set; }

        public Message(WeatherPreference preferences, string email)
        {
            this.preferences = preferences;
            this.email = email;
            RegionMessage = new List<string>();
        }

        public void ComposeMessage(List<Region> regions)
        {
            string regString = "";

            foreach (var region in regions)
            {
                regString += ("Update for Region" + region.name + "/n");

                if (preferences.alwaysRain || (CheckRange(1,preferences.rain[0],preferences.rain[1])))
                {
                    regString += ("Rain Severity: " + 1);
                }
            }
            
            
        }

        private bool CheckRange(int value, int min, int max)
        {
            return (value >= min && value <= max);
        }
    }
}
