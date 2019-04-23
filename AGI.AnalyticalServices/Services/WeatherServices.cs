using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AGI.AnalyticalServices.Inputs;
using AGI.AnalyticalServices.Inputs.Routing;
using AGI.AnalyticalServices.Inputs.Weather;
using AGI.AnalyticalServices.Outputs.Weather;
using AGI.AnalyticalServices.Util;

namespace AGI.AnalyticalServices.Services.Weather
{
    /// <summary>
    /// Weather service methods.  See the service documentation for 
    /// notes on the weather service types: https://saas.agi.com/V1/Documentation/Weather.
    /// </summary>
    public class WeatherServices
    {
        public static async Task<List<WeatherResult>> GetWeatherAtASite(WeatherData<SiteData> siteWeatherData){
            siteWeatherData.Verify();
            var uri = Networking.GetFullUri(ServiceUris.WeatherSiteUri);
            return await Networking.HttpPostCall<WeatherData<SiteData>,List<WeatherResult>>(uri, siteWeatherData);
        }  

        public static async Task<List<WeatherResultWithLocation>> GetWeatherAlongARoute(
                                                                WeatherData<PointToPointRouteData> routeWeatherData){
            routeWeatherData.Verify();
            var uri = Networking.GetFullUri(ServiceUris.WeatherPointToPointUri);
            return await Networking.HttpPostCall<WeatherData<PointToPointRouteData>,
                                                                List<WeatherResultWithLocation>>(uri, routeWeatherData);
        }  
    }
}