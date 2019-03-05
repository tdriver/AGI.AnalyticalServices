using System.Collections.Generic;
using System.Threading.Tasks;
using AGI.AnalyticalServices.Inputs;
using AGI.AnalyticalServices.Inputs.Routing;
using AGI.AnalyticalServices.Util;

namespace AGI.AnalyticalServices.Services.Routing
{
    /// <summary>
    /// A propagated route, defined by a few waypoints.  See the service documentation for 
    /// notes on the different route types: https://saas.agi.com/V1/Documentation/Routing.
    /// </summary>
    public class RouteGenerator
    {
        const string pointToPointRouteUri = "/V1/vehiclePath/pointToPoint";
        const string sgp4RouteUri = "/V1/vehiclePath/sgp4";
        /// <summary>
        /// Gets a propagated route.
        /// </summary>
        /// <param name="routeData">The data defining the route.</param>
        /// <typeparam name="T">The input route data type. Examples might be PointToPointRouteData
        /// or Sgp4Data.</typeparam>
        /// <typeparam name="R">The output type. This must be consistent with <see cref="CoordinateFormat"/></typeparam>
        /// in <see cref="OutputSettings"/>
        /// <returns>A Task containing a List of type R results. R is typically 
        /// <see cref="ServiceCartographicWithTime"/> or a similar type.
        /// </returns>
        public static async Task<List<R>> GetRoute<T,R>(T routeData)
        {
            string relativeUri = string.Empty;
            if(typeof(T) == typeof(PointToPointRouteData)){
                relativeUri = pointToPointRouteUri;
            }
            var uri = Networking.GetFullUri(relativeUri);
            return await Networking.HttpPostCall<T, List<R>>(uri, routeData);
        }
    }

}