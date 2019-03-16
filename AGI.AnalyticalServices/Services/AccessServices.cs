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
            
            if((Type)accessData.FromObjectPath == typeof(PointToPointRouteData)){
                relativeUri = ServiceUris.AccessSatellitePassesPointToPointUri;
            }
            else if((Type)accessData.FromObjectPath == typeof(SiteData)){
                relativeUri = ServiceUris.AccessSatellitePassesSiteUri;
            }
            else if((Type)accessData.FromObjectPath == typeof(Sgp4RouteData)){
                relativeUri = ServiceUris.AccessSatellitePassesSgp4Uri;
            }
            else if((Type)accessData.FromObjectPath == typeof(SimpleFlightRouteData)){
                relativeUri = ServiceUris.AccessSatellitePassesSimpleFlightUri;
            }
            else if((Type)accessData.FromObjectPath == typeof(TolRouteData)){
                relativeUri = ServiceUris.AccessSatellitePassesTolUri;
            }
            else if((Type)accessData.FromObjectPath == typeof(RasterRouteData)){
                relativeUri = ServiceUris.AccessSatellitePassesRasterUri;
            }
            else if((Type)accessData.FromObjectPath == typeof(GreatArcRouteData)){
                relativeUri = ServiceUris.AccessSatellitePassesGreatArcUri;
            }
            else if((Type)accessData.FromObjectPath == typeof(CatalogRouteData)){
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