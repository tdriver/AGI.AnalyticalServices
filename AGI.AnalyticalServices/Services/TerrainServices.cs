using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AGI.AnalyticalServices.Inputs;
using AGI.AnalyticalServices.Inputs.Routing;
using AGI.AnalyticalServices.Outputs.Terrain;
using AGI.AnalyticalServices.Util;

namespace AGI.AnalyticalServices.Services.Terrain
{
    /// <summary>
    /// Terrain methods.  See the service documentation for 
    /// notes on the different Terrain call types: https://saas.agi.com/V1/Documentation/Terrain.
    /// </summary>
    public class TerrainServices
    {
        /// <summary>
        /// Gets terrain heights at a site to visualize.
        /// </summary>
        /// <param name="terrainData">Data defining the routes to visualize.</param>
        /// <typeparam name="T">The input route data type. Only PointToPoint and GreatArc routes are allowed.
        /// or Sgp4Data.</typeparam>
        /// <returns>A Czml string.</returns>
        public static async Task<List<TerrainHeightAtLocationResponse>> GetTerrainHeightsAlongARoute<T>(T terrainRouteData) where T: IVerifiable{

            terrainRouteData.Verify();      

            string relativeUri = string.Empty;
            if(typeof(T) == typeof(PointToPointRouteData)){
                relativeUri = ServiceUris.PointToPointRouteUri;
            }          
            else if(typeof(T) == typeof(GreatArcRouteData)){
                relativeUri = ServiceUris.GreatArcRouteUri;
            }
            if(string.IsNullOrEmpty(relativeUri)){
                throw new ArgumentOutOfRangeException("terrainRouteData",typeof(T), 
                            typeof(T) + " is not a valid type for terrain route generation");
            }

            var uri = Networking.GetFullUri(relativeUri);            
            return await Networking.HttpPostCall<T,List<TerrainHeightAtLocationResponse>>(uri, terrainRouteData);
        }     

         public static async Task<Heights> GetTerrainHeightsAtASite(double latitude, double longitude){                                
            
            var uri = Networking.GetFullUri(ServiceUris.TerrainHeightsSiteUri); 

            uri = new Uri(uri,$"&latitude={latitude}");
            uri = new Uri(uri,$"&longitude={longitude}");    
                                       
            return await Networking.HttpGetCall<Heights>(uri);
        }  
    }
}