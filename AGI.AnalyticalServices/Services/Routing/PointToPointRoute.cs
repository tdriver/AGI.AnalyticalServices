using System.Collections.Generic;
using System.Threading.Tasks;
using AGI.AnalyticalServices.Inputs;
using AGI.AnalyticalServices.Inputs.Routing;
using AGI.AnalyticalServices.Util;

namespace AGI.AnalyticalServices.Services.Routing
{
    public class PointToPointRoute
    {
        public static async Task<List<T>> GetPointToPointRoute<T>(PointToPointRouteData routeData)
        {
            var uri = Networking.GetFullUri("/V1/vehiclePath/pointToPoint");
            return await Networking.HttpPostCall<PointToPointRouteData, List<T>>(uri, routeData);
        }
    }

}