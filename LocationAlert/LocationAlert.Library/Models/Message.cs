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

                regString = "";

                regString += ("<b>Update for Region</b>&nbsp;" + ApiCall.Name + "<br>");

                //****Change 1 to severity enum or switch string case based on severity int
                if (preferences.alwaysTemp || (CheckRange(Convert.ToInt32(ApiCall.TempInFah), preferences.temp[0], preferences.temp[1])))
                {
                    regString += ("Temperature:&nbsp;" + ApiCall.TempInFah + "<br>");
                }

                if (preferences.alwaysRain || (CheckRange(ApiCall.RainVolume, preferences.rain[0],preferences.rain[1])))
                {
                    regString += ("Rain Volume:&nbsp;" + ApiCall.RainVolume + "<br>");
                }

                if (preferences.alwaysSnow || (CheckRange(ApiCall.SnowVolume, preferences.snow[0], preferences.snow[1])))
                {
                    regString += ("Snow Volume:&nbsp;" + ApiCall.SnowVolume + "<br>");
                }

                if (preferences.alwaysWind || (CheckRange(Convert.ToInt32(ApiCall.Wind), preferences.wind[0], preferences.wind[1])))
                {
                    regString += ("Wind Speed:&nbsp;" + ApiCall.Wind + "<br>");
                }

                if (preferences.alwaysCloud || (CheckRange(ApiCall.Clouds, preferences.cloud[0], preferences.cloud[1])))
                {
                    regString += ("Cloud Severity:&nbsp;" + ApiCall.Clouds + "<br>");
                }

                if (preferences.alwaysHumidity || (CheckRange(ApiCall.Humidity, preferences.humidity[0], preferences.humidity[1])))
                {
                    regString += ("Humidity Severity:&nbsp;" + ApiCall.Humidity + "<br>");
                }

                
            }

            BodyText += regString;
        }

        public void SendMessage()
        {
            // Replace smtp_username with your Amazon SES SMTP user name.
            const String SMTP_USERNAME = "AKIAIAY5OFPQZKFIP5RA";

            // Replace smtp_password with your Amazon SES SMTP user name.
            const String SMTP_PASSWORD = "Am3pzxpoJF8RPIE50u71O4whO8WekAZRb1aKCX3/DVan";

            var message = new MailMessage();
            message.To.Add(new MailAddress(email));
            message.From = new MailAddress("bran.frankenfield@gmail.com");
            message.Subject = "Location Alert Notification!";
            message.Body = string.Format(BodyText);
            message.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential(SMTP_USERNAME, SMTP_PASSWORD);

                smtp.Credentials = credential;
                smtp.Host = "email-smtp.us-east-1.amazonaws.com";
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
