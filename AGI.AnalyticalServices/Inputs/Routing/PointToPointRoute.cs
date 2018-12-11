using Newtonsoft.Json;

namespace AGI.AnalyticalServices.Inputs.Routing
{
    public class PointToPointRoute
    {
        /// <summary>
        /// The Waypoints that the route follows
        /// </summary>
        public ServiceCartographicWithTime[] Waypoints { get; set; }
        /// <summary>
        /// After route propagation, the points in the <see cref="Waypoints"/> array may not necessarily
        /// be aligned with the propagated route, and may be excluded.  Set this value to true if you would
        /// like them included in the propagated results anyway.  When false, they are not explicitly
        /// included. Default is false.
        /// </summary>
        public bool IncludeWaypointsInRoute { get; set; }
        /// <summary>
        /// The settings defining how the route is propagated.
        /// </summary>
        public OutputSettings OutputSettings { get; set; }

        /// <summary>
        /// Initializes the Waypoints array with <paramref name="numberOfPointsToAdd"/> default
        /// <see cref="ServiceCartographicWithTime"/> objects.  Also sets Output settings to the default.
        /// </summary>
        /// <param name="numberOfPointsToAdd"></param>
        public PointToPointRoute(int numberOfPointsToAdd)
        {
            Waypoints = new ServiceCartographicWithTime[numberOfPointsToAdd];
            for (int i = 0; i < numberOfPointsToAdd; i++)
            {
                Waypoints[i] = new ServiceCartographicWithTime();
            }
            IncludeWaypointsInRoute = false;
            OutputSettings = new OutputSettings();
        }
        /// <summary>
        /// Defines the PointToPointRoute by a Json string returned from the PointToPoint Routing Service
        /// </summary>
        /// <param name="jsonPointToPointRoute"></param>
        public PointToPointRoute(string jsonPointToPointRoute)
        {
        
            var temp = JsonConvert.DeserializeObject<PointToPointRoute>(jsonPointToPointRoute);
            Waypoints = temp.Waypoints;
            IncludeWaypointsInRoute = temp.IncludeWaypointsInRoute;
            OutputSettings = temp.OutputSettings;
            
        }

        public PointToPointRoute()
        {
            IncludeWaypointsInRoute = false;
            OutputSettings = new OutputSettings();
        }
    }
}
