using LocationAlert.Library.Models;
using System;
using System.Threading.Tasks;
using Xunit;

namespace LocationAlert.Test
{
    public class UnitTest1
    {
        [Fact]
        public async Task Test1()
        {
            WeatherPreference wp = new WeatherPreference();
            double tempF = await wp.GetWeatherForecastAsync(39.952584, -75.165222);

            // check temperature is reasonable fahrenheit
            Assert.InRange<double>(tempF, -200, 200);
        }
    }
}
