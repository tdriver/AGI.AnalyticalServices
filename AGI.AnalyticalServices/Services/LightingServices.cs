using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AGI.AnalyticalServices.Inputs;
using AGI.AnalyticalServices.Inputs.Routing;
using AGI.AnalyticalServices.Inputs.Lighting;
using AGI.AnalyticalServices.Outputs.Lighting;
using AGI.AnalyticalServices.Util;

namespace AGI.AnalyticalServices.Services.Lighting
{
    /// <summary>
    /// Lighting service methods.  See the service documentation for 
    /// notes on the different lighting service types: https://saas.agi.com/V1/Documentation/Lighting.
    /// </summary>
    public class LightingServices
    {
        public static async Task<FlightLightingConditions> GetLightingAtASite(
                                                                    SolarLightingData<SiteData> siteLightingData){
            siteLightingData.Verify();
        
            var uri = Networking.GetFullUri(ServiceUris.LightingSiteUri);
            return await Networking.HttpPostCall<SolarLightingData<SiteData>,
                                                            FlightLightingConditions>(uri, siteLightingData);
        }        

        public static async Task<PathFlightLightingConditions> GetLightingAlongARoute(
                                                            SolarLightingData<PointToPointRouteData> routeLightingData){
            routeLightingData.Verify();
        
            var uri = Networking.GetFullUri(ServiceUris.LightingPointToPointUri);
            return await Networking.HttpPostCall<SolarLightingData<PointToPointRouteData>,
                                                            PathFlightLightingConditions>(uri, routeLightingData);
        }   

        public static async Task<List<SolarAngles>> GetSolarAnglesAtASite(
                                                                    SolarLightingData<SiteData> siteSolarAnglesData){
            siteSolarAnglesData.Verify();
        
            var uri = Networking.GetFullUri(ServiceUris.LightingAnglesSiteUri);
            return await Networking.HttpPostCall<SolarLightingData<SiteData>,
                                                            List<SolarAngles>>(uri, siteSolarAnglesData);
        }    

        public static async Task<List<SolarAngles>> GetSolarAnglesAlongARoute(
                                                        SolarLightingData<PointToPointRouteData> routeSolarAngleData){
            routeSolarAngleData.Verify();
        
            var uri = Networking.GetFullUri(ServiceUris.LightingAnglesPointToPointUri);
            return await Networking.HttpPostCall<SolarLightingData<PointToPointRouteData>,
                                                            List<SolarAngles>>(uri, routeSolarAngleData);
        }  

        public static async Task<List<SolarAngles>> GetSolarTransit(
                                                                SolarLightingData<SiteData> solarTransitSiteData){
        
            var uri = Networking.GetFullUri(ServiceUris.LightingSolarTransitSiteUri);
            return await Networking.HttpPostCall<SolarLightingData<SiteData>,
                                                            List<SolarAngles>>(uri, solarTransitSiteData);
        }  
    }

}