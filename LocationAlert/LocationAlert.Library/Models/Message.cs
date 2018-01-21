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

                //****Change 1 to severity enum or switch string case based on severity int
                if (preferences.alwaysTemp || (CheckRange(1, preferences.temp[0], preferences.temp[1])))
                {
                    regString += ("Temperature: " + 1 + "/n");
                }

                if (preferences.alwaysRain || (CheckRange(1,preferences.rain[0],preferences.rain[1])))
                {
                    regString += ("Rain Severity: " + 1 + "/n");
                }

                if (preferences.alwaysSnow || (CheckRange(1, preferences.snow[0], preferences.snow[1])))
                {
                    regString += ("Snow Severity: " + 1 + "/n");
                }

                if (preferences.alwaysWind || (CheckRange(1, preferences.wind[0], preferences.wind[1])))
                {
                    regString += ("Wind Severity: " + 1 + "/n");
                }

                if (preferences.alwaysCloud || (CheckRange(1, preferences.cloud[0], preferences.cloud[1])))
                {
                    regString += ("Cloud Severity: " + 1 + "/n");
                }

                if (preferences.alwaysHumidity || (CheckRange(1, preferences.humidity[0], preferences.humidity[1])))
                {
                    regString += ("Humidity Severity: " + 1 + "/n");
                }
            }
        }

        private bool CheckRange(int value, int min, int max)
        {
            return (value >= min && value <= max);
        }
    }
}
