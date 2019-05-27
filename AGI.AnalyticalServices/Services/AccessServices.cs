using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AGI.AnalyticalServices.Inputs;
using AGI.AnalyticalServices.Inputs.Access;
using AGI.AnalyticalServices.Inputs.Routing;
using AGI.AnalyticalServices.Util;

namespace AGI.AnalyticalServices.Services.Access
{
    /// <summary>
    /// Access methods.  See the service documentation for 
    /// notes on the different route types: https://saas.agi.com/V1/Documentation/Access.
    /// </summary>
    public class AccessServices
    {
        public static async Task<List<R>> GetSatellitePasses<R>(SatelliteAccessPassData<IVerifiable> accessData){
            string relativeUri = string.Empty;
            
            accessData.Verify();
            
            if(accessData.FromObjectPath as PointToPointRouteData != null){
                relativeUri = ServiceUris.AccessSatellitePassesPointToPointUri;
            }
            else if(accessData.FromObjectPath as SiteData != null){
                relativeUri = ServiceUris.AccessSatellitePassesSiteUri;
            }
            else if(accessData.FromObjectPath as Sgp4RouteData != null){
                relativeUri = ServiceUris.AccessSatellitePassesSgp4Uri;
            }
            else if(accessData.FromObjectPath as SimpleFlightRouteData != null){
                relativeUri = ServiceUris.AccessSatellitePassesSimpleFlightUri;
            }
            else if(accessData.FromObjectPath as TolRouteData != null){
                relativeUri = ServiceUris.AccessSatellitePassesTolUri;
            }
            else if(accessData.FromObjectPath as RasterRouteData != null){
                relativeUri = ServiceUris.AccessSatellitePassesRasterUri;
            }
            else if( accessData.FromObjectPath as GreatArcRouteData != null){
                relativeUri = ServiceUris.AccessSatellitePassesGreatArcUri;
            }
            else if(accessData.FromObjectPath as CatalogRouteData != null){
                relativeUri = ServiceUris.AccessSatellitePassesCatalogObjectUri;
            }
            
            if(string.IsNullOrEmpty(relativeUri)){
                throw new ArgumentOutOfRangeException("accessData",(Type)accessData.FromObjectPath, 
                            (Type)accessData.FromObjectPath  + " is not a valid type for Satellite Passes");
            }
            
            var uri = Networking.GetFullUri(relativeUri);
            return await Networking.HttpPostCall<SatelliteAccessPassData<IVerifiable>, List<R>>(uri, accessData);
        }        
    }

}