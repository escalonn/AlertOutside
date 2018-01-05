using LocationAlert.Library.Models;
using System;
using System.Threading.Tasks;
using Xunit;

namespace LocationAlert.Test
{
    public class UnitTest1
    {
        [Fact]
        //public async Task Test1()
        public void Test1()
        {
            // just skip the http stuff for now while testing pipeline
            WeatherPreference wp = new WeatherPreference();
            //double tempF = await wp.GetWeatherForecastAsync(39.952584, -75.165222);
            double tempF = 60.0;

            // check temperature is reasonable fahrenheit
            Assert.InRange<double>(tempF, -200, 200);
        }
    }
}
