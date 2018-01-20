using System;
using System.Collections.Generic;

namespace LocationAlert.Data.Models
{
    public partial class BaseAlert
    {
        public BaseAlert()
        {
            SubAlert = new HashSet<SubAlert>();
        }

        public int BaseAlertId { get; set; }
        public string BaseAlertType { get; set; }

        public ICollection<SubAlert> SubAlert { get; set; }
    }
}
