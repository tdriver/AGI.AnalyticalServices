using System.Collections.Generic;
using System.Threading.Tasks;
using AGI.AnalyticalServices.Inputs;
using AGI.AnalyticalServices.Inputs.Routing;
using AGI.AnalyticalServices.Util;

namespace AGI.AnalyticalServices.Services.Routing
{
    /// <summary>
    /// A propagated point to point route, defined by a few waypoints.  Point to point routes do not take terrain
    /// into account. If your waypoints lead to a path that intersects terrain, no adjustments are
    /// made by this route type.
    /// </summary>
    public class PointToPointRoute
    {
        /// <summary>
        /// Gets a propagated point to point route.
        /// </summary>
        /// <param name="routeData">The data defining the route</param>
        /// <typeparam name="T">The output type. This must be consistent with <see cref="CoordinateFormat"/>
        /// in <see cref="OutputSettings"/> 
        /// </typeparam>
        /// <returns>A Task containing a List of type T results. T is typically 
        /// <see cref="ServiceCartographicWithTime"/> or a similar type.
        /// </returns>
        public static async Task<List<T>> GetPointToPointRoute<T>(PointToPointRouteData routeData)
        {
            var uri = Networking.GetFullUri("/V1/vehiclePath/pointToPoint");
            return await Networking.HttpPostCall<PointToPointRouteData, List<T>>(uri, routeData);
        }
    }

}