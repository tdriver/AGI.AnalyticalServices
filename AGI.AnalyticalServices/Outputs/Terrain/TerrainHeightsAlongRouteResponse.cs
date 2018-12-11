using System;
using AGI.AnalyticalServices.Inputs;

namespace AGI.AnalyticalServices.Outputs.Terrain
{
 
    /// <summary>
    /// When using this response type, use it in a list, like: List<TerrainHeightAtLocation>
    /// </summary>
    public class TerrainHeightAtLocation
    {
        public Location Location { get; set; }
        public float TerrainHeightFromWgs84 { get; set; }
        public float MeanSeaLevelHeightFromWgs84 { get; set; }
        public float TerrainHeightFromMeanSeaLevel { get; set; }
    }

    public class Location
    {
        public ServiceCartographic Position { get; set; }
        public object[] SensorStates { get; set; }
        public DateTime Time { get; set; }
    }
}