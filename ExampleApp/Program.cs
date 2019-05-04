using System;
using System.IO;
using AGI.AnalyticalServices.Inputs.Routing;
using AGI.AnalyticalServices.Inputs.Weather;
using AGI.AnalyticalServices.Services.Weather;
using AGI.AnalyticalServices.Util;

namespace ExampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // define a site and a route
            var site = new SiteData();
            site.Location.Latitude = 39.0;
            site.Location.Longitude = -104.77;
            site.Location.Altitude = 1910;

            var jsonRoute = File.ReadAllText("Route.json");
            var route = new PointToPointRouteData(jsonRoute);
            
            // get weather at a site
            var siteRequest = new WeatherData<SiteData>();
            siteRequest.Path = site;
            siteRequest.AnalysisStart = DateTime.UtcNow.AddHours(-3);
            siteRequest.AnalysisStop = DateTime.UtcNow;           
            var siteWeather = WeatherServices.GetWeatherAtASite(siteRequest).Result;

            // Take a look at the full URI (warning - this will display your API key)
            //System.Console.WriteLine(Networking.GetFullUri(ServiceUris.WeatherSiteUri));

            System.Console.WriteLine("Temperatures for the last 3 hours");
            foreach (var wx in siteWeather)
            {
                System.Console.WriteLine($"{wx.ResultTime.ToLocalTime().TimeOfDay}: {wx.Temperature:F0}");
            }

            // get weather along a route
            var routeRequest = new WeatherData<PointToPointRouteData>();
            routeRequest.Path = route;
            var routeWeather = WeatherServices.GetWeatherAlongARoute(routeRequest).Result;

            System.Console.WriteLine("Temperatures along a route");
            foreach (var wx in routeWeather)
            {
                System.Console.WriteLine($"{wx.ResultTime.ToLocalTime().TimeOfDay} - {wx.Location}: {wx.Temperature:F0}");
            }
        }
    }
}
