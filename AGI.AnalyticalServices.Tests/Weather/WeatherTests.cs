using System;
using System.Configuration;
using AGI.AnalyticalServices.Inputs.Routing;
using AGI.AnalyticalServices.Inputs.Weather;
using AGI.AnalyticalServices.Outputs.Weather;
using AGI.AnalyticalServices.Services.Weather;
using NUnit.Framework;
using AGI.AnalyticalServices.Util;
using AGI.AnalyticalServices.Inputs;

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

        [Test]
        public void TestWeatherAlongARoute()
        {
            var request = new WeatherData<PointToPointRouteData>();
            var route = new PointToPointRouteData(2);
            
            route.Waypoints[0].Position = new ServiceCartographic
            {
                Altitude = 2000,
                Latitude = 39.07096,
                Longitude = -104.78509
            };
            route.Waypoints[0].Time = new DateTimeOffset(2019,4,16,14,30,0,0,new TimeSpan(0));
            route.Waypoints[1].Position = new ServiceCartographic
            {
                Altitude = 1800,
                Latitude = 39.743635,
                Longitude = -104.607925
            };
            route.Waypoints[1].Time = new DateTimeOffset(2019,4,16,16,30,0,0,new TimeSpan(0));
            route.OutputSettings.Step = 900;       
            
            request.Path = route;
            
            var weather = WeatherServices.GetWeatherAlongARoute(request).Result;
            Assert.That(weather != null);
            Assert.That(weather.Count == 5);
        }

        [Test]
        public void TestWeatherAlongARouteWithAviationDotGov()
        {
            var request = new WeatherData<PointToPointRouteData>();
            var route = new PointToPointRouteData(2);
            
            route.Waypoints[0].Position = new ServiceCartographic
            {
                Altitude = 2000,
                Latitude = 39.07096,
                Longitude = -104.78509
            };
            route.Waypoints[0].Time = new DateTimeOffset(2019,4,16,14,30,0,0,new TimeSpan(0));
            route.Waypoints[1].Position = new ServiceCartographic
            {
                Altitude = 1800,
                Latitude = 39.743635,
                Longitude = -104.607925
            };
            route.Waypoints[1].Time = new DateTimeOffset(2019,4,16,16,30,0,0,new TimeSpan(0));
            route.OutputSettings.Step = 900;       
            
            request.Path = route;
            request.Provider = WeatherProviderType.AviationDotGov;
            
            var weather = WeatherServices.GetWeatherAlongARoute(request).Result;
            Assert.That(weather != null);
            Assert.That(weather.Count == 5);
        }

        [Test]
        public void TestWeatherAlongARouteWithSingapore()
        {
            var request = new WeatherData<PointToPointRouteData>();
            var route = new PointToPointRouteData(2);
            
            route.Waypoints[0].Position = new ServiceCartographic
            {
                Altitude = 100,
                Latitude = 1.353811,
                Longitude = 103.659532
            };
            route.Waypoints[0].Time = new DateTimeOffset(2019,4,16,6,30,0,0,new TimeSpan(0));
            route.Waypoints[1].Position = new ServiceCartographic
            {
                Altitude = 100,
                Latitude = 1.291218,
                Longitude = 103.887249
            };
            route.Waypoints[1].Time = new DateTimeOffset(2019,4,16,8,0,0,0,new TimeSpan(0));
            route.OutputSettings.Step = 900;       
            
            request.Path = route;
            request.Provider = WeatherProviderType.AviationDotGov;
            
            var weather = WeatherServices.GetWeatherAlongARoute(request).Result;
            Assert.That(weather != null);
            Assert.That(weather.Count == 4);
        }
    }
}