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
        public int PushHours { get; set; }
        public int PushMinutes { get; set; }
        public bool AlwaysTemp { get; set; }
        public int TempMin { get; set; }
        public int TempMax { get; set; }
        public bool AlwaysRain { get; set; }
        public int RainMin { get; set; }
        public int RainMax { get; set; }
        public bool AlwaysSnow { get; set; }
        public int SnowMin { get; set; }
        public int SnowMax { get; set; }
        public bool AlwaysCloud { get; set; }
        public int CloudMin { get; set; }
        public int CloudMax { get; set; }
        public bool AlwaysWind { get; set; }
        public int WindMin { get; set; }
        public int WindMax { get; set; }
        public bool AlwaysHumidity { get; set; }
        public int HumidityMin { get; set; }
        public int HumidityMax { get; set; }

        public ICollection<Preference> Preference { get; set; }
    }
}
