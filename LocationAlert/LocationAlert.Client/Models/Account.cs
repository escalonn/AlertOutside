using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace LocationAlert.Client.Models
{
    public class Account
    {
        public MailAddress Email { get; set; }

        public String Password { get; set; }

        public String FirstName { get; set; }
        public String MiddleInitial { get; set; }
        public String LastName { get; set; }

        public String Phone { get; set; }


        public Account()
        {
            Email = new MailAddress("undefined@gmail.com");
        }

    }
}
