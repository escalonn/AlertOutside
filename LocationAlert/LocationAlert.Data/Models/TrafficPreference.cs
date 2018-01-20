using System;
using System.Collections.Generic;

namespace LocationAlert.Data.Models
{
    public partial class TrafficPreference
    {
        public TrafficPreference()
        {
            Preference = new HashSet<Preference>();
        }

        public int TrafficPreferenceId { get; set; }

        public ICollection<Preference> Preference { get; set; }
    }
}
