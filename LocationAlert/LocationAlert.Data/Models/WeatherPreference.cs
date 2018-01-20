using System;
using System.Collections.Generic;

namespace LocationAlert.Data.Models
{
    public partial class WeatherPreference
    {
        public WeatherPreference()
        {
            Preference = new HashSet<Preference>();
        }

        public int WeatherPreferenceId { get; set; }

        public ICollection<Preference> Preference { get; set; }
    }
}
