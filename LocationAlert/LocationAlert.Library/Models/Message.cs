using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace LocationAlert.Library.Models
{
    public class Message
    {
        public string email { get; set; }
        public WeatherPreference preferences { get; set; }
        public List<string> RegionMessage { get; set; }
        public string BodyText { get; set; }

        public Message(WeatherPreference preferences, string email)
        {
            this.preferences = preferences;
            this.email = email;
            RegionMessage = new List<string>();
            BodyText = "";
        }

        public void ComposeMessage(List<Region> regions, WeatherApi ApiCall)
        {
            string regString = "";

            foreach (var region in regions)
            {
                regString += ("Update for Region" + region.name + "<br>");

                //****Change 1 to severity enum or switch string case based on severity int
                if (preferences.alwaysTemp || (CheckRange(Convert.ToInt32(ApiCall.TempInFah), preferences.temp[0], preferences.temp[1])))
                {
                    regString += ("Temperature: " + ApiCall.TempInFah + "<br>");
                }

                if (preferences.alwaysRain || (CheckRange(ApiCall.RainVolume, preferences.rain[0],preferences.rain[1])))
                {
                    regString += ("Rain Volume: " + ApiCall.RainVolume + "<br>");
                }

                if (preferences.alwaysSnow || (CheckRange(ApiCall.SnowVolume, preferences.snow[0], preferences.snow[1])))
                {
                    regString += ("Snow Volume: " + ApiCall.SnowVolume + "<br>");
                }

                if (preferences.alwaysWind || (CheckRange(ApiCall.Wind, preferences.wind[0], preferences.wind[1])))
                {
                    regString += ("Wind Speed: " + ApiCall.Wind + "<br>");
                }

                if (preferences.alwaysCloud || (CheckRange(ApiCall.Clouds, preferences.cloud[0], preferences.cloud[1])))
                {
                    regString += ("Cloud Severity: " + ApiCall.Clouds + "<br>");
                }

                if (preferences.alwaysHumidity || (CheckRange(ApiCall.Humidity, preferences.humidity[0], preferences.humidity[1])))
                {
                    regString += ("Humidity Severity: " + ApiCall.Humidity + "<br>");
                }

                BodyText = regString;
            }
        }

        public void SendMessage()
        {
            var message = new MailMessage();
            message.To.Add(new MailAddress(email));
            message.From = new MailAddress("sofanib@outlook.com");
            message.Subject = "Location Alert Notification!";
            message.Body = string.Format(BodyText);
            message.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "sofanib@outlook.com",  // replace with valid value
                    Password = "sami114173"  // replace with valid value(password for real email
                };
                smtp.Credentials = credential;
                smtp.Host = "smtp-mail.outlook.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Send(message);
            }
        }

        private bool CheckRange(int value, int min, int max)
        {
            return (value >= min && value <= max);
        }
    }
}
