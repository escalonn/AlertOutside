using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocationAlert.Client.Models
{
    public class Region
    {
        public int ID { get; }
        private double Latitude { get; set; }
        private double Longitude { get; set; }
        private double Radius { get; set; }


        public Region(int id, string lat, string lng, string radius)
        {
            ID = id;
            Latitude = Convert.ToDouble(lat);
            Longitude = Convert.ToDouble(lng);
            Radius = Convert.ToDouble(radius);
        }

    }
}
