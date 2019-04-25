using System;
using AGI.AnalyticalServices.Inputs.Routing;
using AGI.AnalyticalServices.Inputs.Weather;
using AGI.AnalyticalServices.Services.Weather;
using AGI.AnalyticalServices.Util;

namespace WeatherGetter
{
    class Program
    {
        static void Main(string[] args)
        {
             var request = new WeatherData<SiteData>();
            request.Path = new SiteData();
            request.Path.Location.Latitude = 40.0;
            request.Path.Location.Longitude = -75.77;
            request.Path.Location.Altitude = 10;
            request.AnalysisStart = DateTime.UtcNow.AddHours(-3);
            request.AnalysisStop = DateTime.UtcNow;
           
            var weather = WeatherServices.GetWeatherAtASite(request).Result;

            // Take a look at the full URI (warning - this will display your API key)
            //System.Console.WriteLine(Networking.GetFullUri(ServiceUris.WeatherSiteUri));

            System.Console.WriteLine("Temperatures for the last 3 hours");
            foreach (var wx in weather)
            {
                System.Console.WriteLine($"{wx.ResultTime.ToLocalTime().TimeOfDay}: {wx.Temperature:F0}");
            }
        }
    }
}
