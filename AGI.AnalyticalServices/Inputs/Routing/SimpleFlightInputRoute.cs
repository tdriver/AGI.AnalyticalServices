using System;

namespace AGI.AnalyticalServices.Inputs.Routing
{
    /// <summary>
    /// Simple flight routes are defined by a few waypoints, with the vehicle making smooth turns around each waypoint, all at a constant altitude.
    /// </summary>
    public class SimpleFlightRoute
    {
        /// <summary>
        /// the start time of the route.
        /// </summary>
        public DateTime Start { get; set; }
        /// <summary>
        /// The set of waypoints the route will follow
        /// </summary>
        public ServiceCartographic2D[] Waypoints { get; set; }
        /// <summary>
        /// The radius of the turn around a waypoint, in meters.
        /// </summary>
        public int TurningRadius { get; set; }
        /// <summary>
        /// The constant speed at which the vehicle travels along the route, in meters/second.
        /// </summary>
        public int Speed { get; set; }
        /// <summary>
        /// The constant altitude the vehicle flies at along the route, in meters.
        /// </summary>
        public int Altitude { get; set; }
        /// <summary>
        /// Set this to true if <see cref="Altitude"/> is referenced to Mean Sea Level.
        /// Set this to false if <see cref="Altitude"/> is referenced to WGS-84.
        /// </summary>
        public bool MeanSeaLevel { get; set; }
        /// <summary>
        /// The <see cref="OutputSettings"/> the route will be propagated with.
        /// </summary>
        public OutputSettings OutputSettings { get; set; }
    }
    
}
