using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocationAlert.Client.Models
{
    public class WeatherPreference
    {
        // How often to push 'Always' values
        public TimeSpan PushAmount{ get; set; }

        // Always push values
        public bool AlwaysTemp { get; set; }
        public bool AlwaysHumidity { get; set; }
        public bool AlwaysWind { get; set; }
        public bool AlwaysSnow { get; set; }

        // Push Temperature when outside this range
        public int TempMin { get; set; }
        public int TempMax { get; set; }

        // Push Humidity when outside this range
        public int HumidityMin { get; set; }
        public int HumidityMax { get; set; }

        // Push Wind speed when outside this range
        public int WindMin { get; set; }
        public int WindMax { get; set; }

        // Push cloudness when outside this range
        public int CloudMin { get; set; }
        public int CloudMax { get; set; }

        // Push rain when outside this range
        public int RainMax { get; set; }
        public int RainMin { get; set; }

        // Push snow when outside this range
        public int SnowMax { get; set; }
        public int SnowMin { get; set; }

    }
}
