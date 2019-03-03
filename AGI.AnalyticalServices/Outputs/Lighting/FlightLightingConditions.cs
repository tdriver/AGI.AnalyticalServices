using System.Collections.Generic;

namespace AGI.AnalyticalServices.Outputs.Lighting
{
    /// <summary>
    /// Defines the lighting conditions for a flight
    /// </summary>
    public class FlightLightingConditions
    {
        /// <summary>
        /// Complete Lighting Information
        /// </summary>
        public List<LightingInfo> Lighting { get; set; }

        public FlightLightingConditions()
        {
            Lighting = new List<LightingInfo>();
        }

    }
}
