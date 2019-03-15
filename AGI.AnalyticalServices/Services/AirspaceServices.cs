using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AGI.AnalyticalServices.Inputs;
using AGI.AnalyticalServices.Inputs.Airspace;
using AGI.AnalyticalServices.Outputs.Airspace;
using AGI.AnalyticalServices.Inputs.Routing;
using AGI.AnalyticalServices.Util;

namespace AGI.AnalyticalServices.Services.Airspace
{
    /// <summary>
    /// Airspace methods.  See the service documentation for 
    /// notes on the different airspace call types: https://saas.agi.com/V1/Documentation/Airspace.
    /// </summary>
    public class AirspaceServices
    {
        public static async Task<StaticAirspaceAccessResult<AirspaceCrossingResult<IPathResult>>> 
            GetAirspaceCrossingsForARoute<R>(StaticAirspaceRouteData<IVerifiable> airspaceRouteData){
            string relativeUri = string.Empty;
            
            airspaceRouteData.Verify();
            
            if((Type)airspaceRouteData.Path == typeof(PointToPointRouteData)){
                relativeUri = ServiceUris.AccessSatellitePassesPointToPointUri;
            }
            else if((Type)airspaceRouteData.Path == typeof(SimpleFlightRouteData)){
                relativeUri = ServiceUris.AccessSatellitePassesSimpleFlightUri;
            }
            else if((Type)airspaceRouteData.Path == typeof(GreatArcRouteData)){
                relativeUri = ServiceUris.AccessSatellitePassesGreatArcUri;
            }
            
            if(string.IsNullOrEmpty(relativeUri)){
                throw new ArgumentOutOfRangeException("airspaceRouteData",(Type)airspaceRouteData.Path, 
                            (Type)airspaceRouteData.Path  + " is not a valid type for airspace crossings");
            }
            
            var uri = Networking.GetFullUri(relativeUri);
            
            return await 
            Networking.HttpPostCall<StaticAirspaceRouteData<IVerifiable>, 
                            StaticAirspaceAccessResult<AirspaceCrossingResult<IPathResult>>>(uri, airspaceRouteData);
        }        
    }

}