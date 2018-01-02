using System;
using System.Collections.Generic;
using System.Text;

namespace LocationAlert.Library.Models
{
    public class   Preferences
    {
        public int PreferenceId { get; set; } //PK
        public int WeatherPreferenceId { get; set; } //FK
        public int TrafficPreferenceId { get; set; } //FK
        public int NewsPreferenceId { get; set; } //FK
        public DateTime DateModified { get; set; }

        public string ChoosePreference() {
            return "news";
        }

    }
}
