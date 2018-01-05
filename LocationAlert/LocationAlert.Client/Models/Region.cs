using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocationAlert.Client.Models
{
    public class Region
    {
        public int ID { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Radius { get; set; }


        public Region(string id, string lat, string lng, string radius)
        {
            ID = Convert.ToInt32(id);
            Latitude = Convert.ToDouble(lat);
            Longitude = Convert.ToDouble(lng);
            Radius = Convert.ToDouble(radius);
        }

    }
}
