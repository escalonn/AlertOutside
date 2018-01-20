using System;
using System.Collections.Generic;

namespace LocationAlert.Data.Models
{
    public partial class NewsPreference
    {
        public NewsPreference()
        {
            Preference = new HashSet<Preference>();
        }

        public int NewsPreferenceId { get; set; }

        public ICollection<Preference> Preference { get; set; }
    }
}
