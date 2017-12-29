using System;
using System.Collections.Generic;
using System.Text;

namespace LocationAlert.Library.Models
{
    public class Client
    {
        public int ClientId { get; set; } //PK
        public int NameId { get; set; }   // FK
        public int PreferenceId { get; set; } // FK
        public string Password { get; set; }
        public Email ClientEmail { get; set; } 
        public Phone PhoneNumber { get; set; }
        public DateTime DateModified { get; set; }
        public Client() { }
        public bool signUp()
        {
            return true;
        }

       public bool signIn()
        {
            return true;
        }
    }
}
