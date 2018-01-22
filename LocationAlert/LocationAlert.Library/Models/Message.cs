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
        public bool ShouldSend = false;

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


                if (preferences.AlwaysTemp || (CheckRange(Convert.ToInt32(ApiCall.TempInFah), preferences.Temp[0], preferences.Temp[1])))
                {
                    regString += ("Temperature:&nbsp;" + ApiCall.TempInFah + "<br>");
                    ShouldSend = true;
                }

                if (preferences.AlwaysRain || (CheckRange(ApiCall.RainVolume, preferences.Rain[0],preferences.Rain[1])))
                {
                    regString += ("Rain Volume:&nbsp;" + ApiCall.RainVolume + "<br>");
                    ShouldSend = true;
                }

                if (preferences.AlwaysSnow || (CheckRange(ApiCall.SnowVolume, preferences.Snow[0], preferences.Snow[1])))
                {
                    regString += ("Snow Volume:&nbsp;" + ApiCall.SnowVolume + "<br>");
                    ShouldSend = true;
                }

                if (preferences.AlwaysWind || (CheckRange(Convert.ToInt32(ApiCall.Wind), preferences.Wind[0], preferences.Wind[1])))
                {
                    regString += ("Wind Speed:&nbsp;" + ApiCall.Wind + "<br>");
                    ShouldSend = true;
                }

                if (preferences.AlwaysCloud || (CheckRange(ApiCall.Clouds, preferences.Cloud[0], preferences.Cloud[1])))
                {
                    regString += ("Cloud Severity:&nbsp;" + ApiCall.Clouds + "<br>");
                    ShouldSend = true;
                }

                if (preferences.AlwaysHumidity || (CheckRange(ApiCall.Humidity, preferences.Humidity[0], preferences.Humidity[1])))
                {
                    regString += ("Humidity Severity:&nbsp;" + ApiCall.Humidity + "<br>");
                    ShouldSend = true;
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
            if (value < min || value > max)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
