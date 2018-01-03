using LocationAlert.Library.Models;
using System;
using Xunit;

namespace LocationAlert.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            WeatherPreference wp = new WeatherPreference();
            Object x = wp.GetWeatherForecastAsync(39.952584, -75.165222);

            // Assert.Equal("", "");
        }
    }
}
