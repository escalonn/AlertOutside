using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace LocationAlert.Client.Models
{
    public class Register
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        [EmailAddress]
        public MailAddress Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
