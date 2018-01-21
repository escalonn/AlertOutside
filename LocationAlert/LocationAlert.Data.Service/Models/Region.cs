namespace LocationAlert.Data.Service.Models
{
    public class Region
    {
        public int id { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public long Radius { get; set; }
    }
}