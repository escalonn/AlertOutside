﻿using System;
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

        public void ComposeMessage(List<Region> regions, WeatherApi ApiCall)
        {
            string regString = "";

            foreach (var region in regions)
            {
                regString += ("Update for Region" + region.name + "/n");

                //****Change 1 to severity enum or switch string case based on severity int
                if (preferences.alwaysTemp || (CheckRange(Convert.ToInt32(ApiCall.TempInFah), preferences.temp[0], preferences.temp[1])))
                {
                    regString += ("Temperature: " + ApiCall.TempInFah + "/n");
                }

                if (preferences.alwaysRain || (CheckRange(ApiCall.RainVolume, preferences.rain[0],preferences.rain[1])))
                {
                    regString += ("Rain Volume: " + ApiCall.RainVolume + "/n");
                }

                if (preferences.alwaysSnow || (CheckRange(ApiCall.SnowVolume, preferences.snow[0], preferences.snow[1])))
                {
                    regString += ("Snow Volume: " + ApiCall.SnowVolume + "/n");
                }

                if (preferences.alwaysWind || (CheckRange(ApiCall.Wind, preferences.wind[0], preferences.wind[1])))
                {
                    regString += ("Wind Speed: " + ApiCall.Wind + "/n");
                }

                if (preferences.alwaysCloud || (CheckRange(ApiCall.Clouds, preferences.cloud[0], preferences.cloud[1])))
                {
                    regString += ("Cloud Severity: " + ApiCall.Clouds + "/n");
                }

                if (preferences.alwaysHumidity || (CheckRange(ApiCall.Humidity, preferences.humidity[0], preferences.humidity[1])))
                {
                    regString += ("Humidity Severity: " + ApiCall.Humidity + "/n");
                }
            }
        }

        private bool CheckRange(int value, int min, int max)
        {
            return (value >= min && value <= max);
        }
    }
}