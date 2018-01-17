using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace LocationAlert.Client.Models
{
    public class WeatherPreference
    {
        // How often to push 'Always' values
        [DisplayName("How often should we push you alerts?")]
        public TimeSpan PushAmount{ get; set; }

        // Always push values
        [DisplayName("Always Push Temperature")]
        public bool AlwaysTemp { get; set; }
        // Push Temperature when outside this range
        public int TempMin { get; set; }
        public int TempMax { get; set; }

        [DisplayName("Always Push Rain")]
        public bool AlwaysRain { get; set; }
        // Push rain when outside this range
        public int RainMin { get; set; }
        public int RainMax { get; set; }

        [DisplayName("Always Push Snow")]
        public bool AlwaysSnow { get; set; }
        public int SnowMin { get; set; }
        public int SnowMax { get; set; }

        [DisplayName("Always Push Cloudiness")]
        public bool AlwaysCloud { get; set; }
        // Push cloudness when outside this range
        public int CloudMin { get; set; }
        public int CloudMax { get; set; }

        [DisplayName("Always Push Wind Speed")]
        public bool AlwaysWind { get; set; }
        // Push Wind speed when outside this range
        public int WindMin { get; set; }
        public int WindMax { get; set; }

        [DisplayName("Always Push Humidity")]
        public bool AlwaysHumidity { get; set; }
        // Push Humidity when outside this range
        public int HumidityMin { get; set; }
        public int HumidityMax { get; set; }






    }
}
