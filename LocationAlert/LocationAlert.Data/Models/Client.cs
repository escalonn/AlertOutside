using System;
using System.Collections.Generic;

namespace LocationAlert.Data.Models
{
    public partial class Client
    {
        public int ClientId { get; set; }
        public string FirstName { get; set; }
        public string MiddleInit { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public int? PreferenceId { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
