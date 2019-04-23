using System;
using System.Configuration;
using AGI.AnalyticalServices.Inputs.Routing;
using AGI.AnalyticalServices.Inputs.Weather;
using AGI.AnalyticalServices.Outputs.Weather;
using AGI.AnalyticalServices.Services.Weather;
using NUnit.Framework;
using AGI.AnalyticalServices.Util;

namespace AGI.AnalyticalServices.Tests.Weather
{
    [TestFixture]
    public class WeatherTests
    {
        [Test]
        public void TestWeatherAtASite()
        {
            var request = new WeatherData<SiteData>();
            request.Path = new SiteData();
            request.Path.Location.Latitude = 39.0;
            request.Path.Location.Longitude = -104.77;
            request.Path.Location.Altitude = 1910;
            request.AnalysisStart = new DateTime(2019,4,22,12,0,0);
            request.AnalysisStop = new DateTime(2019,4,22,13,0,0);
            
            var weather = WeatherServices.GetWeatherAtASite(request).Result;
            Assert.That(weather != null);
            Assert.That(weather.Count == 3);
           
        }
    }
}