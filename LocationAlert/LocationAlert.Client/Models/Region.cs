using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocationAlert.Client.Models
{
    public class Region
    {
        public int ID { get; }
        public double Latitude { get; }
        public double Longitude { get;  }
        public double Radius { get;  }


        public Region(int id, string lat, string lng, string radius)
        {
            ID = id;
            Latitude = Convert.ToDouble(lat);
            Longitude = Convert.ToDouble(lng);
            Radius = Convert.ToDouble(radius);
        }

    }
}
