using System;

namespace AGI.AnalyticalServices.Inputs.Routing
{

    public class SimpleFlightRoute
    {
        public DateTime Start { get; set; }
        public ServiceCartographic2D[] Waypoints { get; set; }
        public int TurningRadius { get; set; }
        public int Speed { get; set; }
        public int Altitude { get; set; }
        public bool MeanSeaLevel { get; set; }
        public OutputSettings OutputSettings { get; set; }
    }
    
}
