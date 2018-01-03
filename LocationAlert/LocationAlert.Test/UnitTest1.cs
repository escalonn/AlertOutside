using LocationAlert.Library.Models;
using System;
using Xunit;
using Microsoft.AspNetCore.Mvc;

namespace LocationAlert.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            WeatherPreference wp = new WeatherPreference();
            Object x  =  wp.GetWeatherForeCast(39.952584, -75.165222);
          
            
           // Assert.Equal("", "");

        }
    }
}
