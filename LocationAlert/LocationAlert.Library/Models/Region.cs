using System;
using System.Collections.Generic;
using System.Text;

namespace LocationAlert.Library.Models
{
    public class Region
    {

        public int id { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public long Radius { get; set; }

        public string name { get; set; }
    }
}
