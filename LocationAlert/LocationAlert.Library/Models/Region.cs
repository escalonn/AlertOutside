using System;
using System.Collections.Generic;
using System.Text;

namespace LocationAlert.Library.Models
{
    public class Region
    {

        public int ID { get; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public long Radius { get; set; }
    }
}
