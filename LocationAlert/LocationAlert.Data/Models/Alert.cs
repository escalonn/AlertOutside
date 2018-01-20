using System;
using System.Collections.Generic;

namespace LocationAlert.Data.Models
{
    public partial class Alert
    {
        public int AlertId { get; set; }
        public int? ClientId { get; set; }
        public int? AlertTypeId { get; set; }
        public string AlertMessage { get; set; }
        public DateTime? DateIssued { get; set; }

        public Client Client { get; set; }
    }
}
