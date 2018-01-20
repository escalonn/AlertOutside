using System;
using System.Collections.Generic;

namespace LocationAlert.Data.Models
{
    public partial class SubAlert
    {
        public int SubAlertId { get; set; }
        public string SubAlertType { get; set; }
        public int? BaseAlertId { get; set; }

        public BaseAlert BaseAlert { get; set; }
    }
}
