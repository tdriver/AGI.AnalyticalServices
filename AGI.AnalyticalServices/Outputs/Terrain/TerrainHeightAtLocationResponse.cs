﻿using System;
using AGI.AnalyticalServices.Inputs;

namespace AGI.AnalyticalServices.Outputs.Terrain
{ 
    /// <summary>
    /// When using this response type, use it in a list, like: List<TerrainHeightAtLocationResponse>
    /// </summary>
    public class TerrainHeightAtLocationResponse
    {
        public ServiceCartographicWithTime Location { get; set; }
        public float TerrainHeightFromWgs84 { get; set; }
        public float MeanSeaLevelHeightFromWgs84 { get; set; }
        public float TerrainHeightFromMeanSeaLevel { get; set; }
    }
}