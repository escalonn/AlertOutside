namespace LocationAlert.Data.Service.Models
{
    public class WeatherPreference
    {
        public int PushHours { get; set; }
        public int PushMinutes { get; set; }
        public bool AlwaysTemp { get; set; }
        public int[] Temp { get; set; }
        public bool AlwaysRain { get; set; }
        public int[] Rain { get; set; }
        public bool AlwaysSnow { get; set; }
        public int[] Snow { get; set; }
        public bool AlwaysCloud { get; set; }
        public int[] Cloud { get; set; }
        public bool AlwaysWind { get; set; }
        public int[] Wind { get; set; }
        public bool AlwaysHumidity { get; set; }
        public int[] Humidity { get; set; }
    }
}