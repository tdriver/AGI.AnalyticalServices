namespace AGI.AnalyticalServices.Inputs.Routing
{
    public class PointToPointRoute
    {
        public ServiceCartographicWithTime[] Waypoints { get; set; }
        public OutputSettings OutputSettings { get; set; }

        public PointToPointRoute(int numberOfPointsToAdd)
        {
            Waypoints = new ServiceCartographicWithTime[numberOfPointsToAdd];
            for (int i = 0; i < numberOfPointsToAdd; i++)
            {
                Waypoints[i] = new ServiceCartographicWithTime();
            }
            OutputSettings = new OutputSettings();
        }
    }
}
