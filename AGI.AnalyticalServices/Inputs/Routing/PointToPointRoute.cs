﻿using AGI.AnalyticalServices.Exceptions;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace AGI.AnalyticalServices.Inputs.Routing
{
    public class PointToPointRoute:IVerifiable
    {
        /// <summary>
        /// The Waypoints defining the route
        /// </summary>
        public List<ServiceCartographicWithTime> Waypoints { get; set; }
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
        /// Initializes Waypoints list with <paramref name="numberOfPointsToAdd"/> default
        /// <see cref="ServiceCartographicWithTime"/> objects.  Also sets other defaults.
        /// </summary>
        /// <param name="numberOfPointsToAdd"></param>
        public PointToPointRoute(int numberOfPointsToAdd)
        {
            Waypoints = new List<ServiceCartographicWithTime>();
            for (int i = 0; i < numberOfPointsToAdd; i++)
            {
                Waypoints.Add(new ServiceCartographicWithTime());
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
            Waypoints = new List<ServiceCartographicWithTime>();
            IncludeWaypointsInRoute = false;
            OutputSettings = new OutputSettings();
        }

        public void Verify()
        {
            OutputSettings.Verify();

            if (Waypoints == null)
            {
                throw new AnalyticalServicesException(24000, "Waypoints must be supplied to this service.");
            }

            if (Waypoints.Count < 2)
            {
                throw new AnalyticalServicesException(23600, "There must be at least two waypoints to define a route.");
            }

            Waypoints.ForEach(n => n.Verify());
        }
    }
}
