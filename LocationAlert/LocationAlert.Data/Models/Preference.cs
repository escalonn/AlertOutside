using System;
using System.Collections.Generic;

namespace LocationAlert.Data.Models
{
    public partial class Preference
    {
        public Preference()
        {
            Client = new HashSet<Client>();
        }

        public int PreferenceId { get; set; }
        public int WeatherPreferenceId { get; set; }
        public int? TrafficPreferenceId { get; set; }
        public int? NewsPreferenceId { get; set; }
        public DateTime? DateModified { get; set; }

        public NewsPreference NewsPreference { get; set; }
        public TrafficPreference TrafficPreference { get; set; }
        public WeatherPreference WeatherPreference { get; set; }
        public ICollection<Client> Client { get; set; }
    }
}
