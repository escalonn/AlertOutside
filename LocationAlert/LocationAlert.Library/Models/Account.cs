using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

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

        public WeatherPreference weatherPref { get; set; } = new WeatherPreference();

        public DateTime LastPush { get; set; }

        public Account()
        {
           // Email = new MailAddress("undefined@gmail.com");
        }

        public Account(string email)
        {
            Email = email;
        }

        public static void SendAlertMessage(string body)
        {


            var message = new MailMessage();
            message.To.Add(new MailAddress("sofanibm@gmail.com"));
            message.To.Add(new MailAddress("bran.frankenfield@gmail.com"));
            message.From = new MailAddress("sofanib@outlook.com");
            message.Subject = "Your email subject";
            message.Body = string.Format(body);
            message.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "sofanib@outlook.com",  // replace with valid value
                    Password = "password"  // replace with valid value(password for real email
                };
                smtp.Credentials = credential;
                smtp.Host = "smtp-mail.outlook.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Send(message);
            }
        }
    }
}
