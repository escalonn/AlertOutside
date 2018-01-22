using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace LocationAlert.Library.Models
{
    public class Message
    {
        public string Email { get; set; }
        public WeatherPreference Preferences { get; set; }
        public List<string> RegionMessage { get; set; }
        public string BodyText { get; set; }
        public bool ShouldSend { get; set; } = false;

        public Message(WeatherPreference preferences, string email)
        {
            Preferences = preferences;
            Email = email;
            RegionMessage = new List<string>();
            BodyText = "";
        }

        public void ComposeMessage(List<Region> regions, WeatherApi ApiCall)
        {
            var regString = "";

            foreach (var region in regions)
            {
                regString = "";

                regString += ("<b>Update for Region</b>&nbsp;" + ApiCall.Name + "<br>");

                if (Preferences.AlwaysTemp || Between(ApiCall.TempInFah, Preferences.Temp))
                {
                    regString += ("Temperature:&nbsp;" + ApiCall.TempInFah + "<br>");
                    ShouldSend = true;
                }

                if (Preferences.AlwaysRain || Between(ApiCall.RainVolume, Preferences.Rain))
                {
                    regString += ("Rain Volume:&nbsp;" + ApiCall.RainVolume + "<br>");
                    ShouldSend = true;
                }

                if (Preferences.AlwaysSnow || Between(ApiCall.SnowVolume, Preferences.Snow))
                {
                    regString += ("Snow Volume:&nbsp;" + ApiCall.SnowVolume + "<br>");
                    ShouldSend = true;
                }

                if (Preferences.AlwaysWind || Between(ApiCall.Wind, Preferences.Wind))
                {
                    regString += ("Wind Speed:&nbsp;" + ApiCall.Wind + "<br>");
                    ShouldSend = true;
                }

                if (Preferences.AlwaysCloud || Between(ApiCall.Clouds, Preferences.Cloud))
                {
                    regString += ("Cloud Severity:&nbsp;" + ApiCall.Clouds + "<br>");
                    ShouldSend = true;
                }

                if (Preferences.AlwaysHumidity || Between(ApiCall.Humidity, Preferences.Humidity))
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
            const string SMTP_USERNAME = "AKIAIAY5OFPQZKFIP5RA";

            // Replace smtp_password with your Amazon SES SMTP user name.
            const string SMTP_PASSWORD = "Am3pzxpoJF8RPIE50u71O4whO8WekAZRb1aKCX3/DVan";

            var message = new MailMessage();
            message.To.Add(new MailAddress(Email));
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

        private static bool Between(int value, int[] bounds)
        {
            return value < bounds[0] || value > bounds[1];
        }

        private static bool Between(double value, double[] bounds)
        {
            return value < bounds[0] || value > bounds[1];
        }
    }
}
