using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AGI.AnalyticalServices.Inputs;
using AGI.AnalyticalServices.Inputs.Routing;
using AGI.AnalyticalServices.Inputs.Access;
using AGI.AnalyticalServices.Outputs.Access;
using AGI.AnalyticalServices.Util;

namespace AGI.AnalyticalServices.Services.Overflight
{
    /// <summary>
    /// Overflight service methods.  See the service documentation for 
    /// notes on the different overflight service types: https://saas.agi.com/V1/Documentation/Overflight.
    /// </summary>
    public class OverflightServices
    {
        public static async Task<OverflightAccessResult<IPathResult>> GetRegionalOverflight(
                                                                    OverflightAccessData<IVerifiable> overflightData){
            string relativeUri = string.Empty;
            
            overflightData.Verify();
            
            if((Type)overflightData.Path == typeof(PointToPointRouteData)){
                relativeUri = ServiceUris.OverflightPointToPointUri;
            }
            else if((Type)overflightData.Path== typeof(Sgp4RouteData)){
                relativeUri = ServiceUris.OverflightSgp4Uri;
            }
            else if((Type)overflightData.Path == typeof(SimpleFlightRouteData)){
                relativeUri = ServiceUris.OverflightSimpleFlightUri;
            }
            else if((Type)overflightData.Path == typeof(GreatArcRouteData)){
                relativeUri = ServiceUris.OverflightGreatArcUri;
            }
            else if((Type)overflightData.Path == typeof(CatalogRouteData)){
                relativeUri = ServiceUris.OverflightCatalogObjectUri;
            }
            
            if(string.IsNullOrEmpty(relativeUri)){
                throw new ArgumentOutOfRangeException("overflightData",(Type)overflightData.Path, 
                            (Type)overflightData.Path  + " is not a valid type for Overflight Access");
            }
            
            var uri = Networking.GetFullUri(relativeUri);
            return await Networking.HttpPostCall<OverflightAccessData<IVerifiable>,
                                                            OverflightAccessResult<IPathResult>>(uri, overflightData);
        }        
    }

}