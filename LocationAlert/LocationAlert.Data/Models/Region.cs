using System;
using System.Collections.Generic;

namespace LocationAlert.Data.Models
{
    public partial class Region
    {
        public int RegionId { get; set; }
        public int? ClientId { get; set; }
        public string RegionName { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public long Radius { get; set; }
        public DateTime? DateModified { get; set; }

        public Client Client { get; set; }
    }
}
