namespace LocationAlert.Data.Service.Models
{
    public class WeatherPreference
    {
        public int pushHours { get; set; }
        public int pushMinutes { get; set; }
        public bool alwaysTemp { get; set; }
        public int[] temp { get; set; }
        public bool alwaysRain { get; set; }
        public int[] rain { get; set; }
        public bool alwaysSnow { get; set; }
        public int[] snow { get; set; }
        public bool alwaysCloud { get; set; }
        public int[] cloud { get; set; }
        public bool alwaysWind { get; set; }
        public int[] wind { get; set; }
        public bool alwaysHumidity { get; set; }
        public int[] humidity { get; set; }
    }
}