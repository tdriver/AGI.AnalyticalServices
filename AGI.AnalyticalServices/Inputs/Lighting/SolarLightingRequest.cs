using System;

namespace AGI.AnalyticalServices.Inputs.Lighting
{
    /// <summary>
    /// A Request for the Solar Lighting Service
    /// </summary>
    public class SolarLightingRequest
    {
        /// <summary>
        /// The path along which Solar lighting will be calculated.  The path can be either a <see cref="Routing.PointToPointRoute"/> or a <see cref="Site"/>.
        /// The start and stop times of the path dictate the analysis start and stop times when Path is a <see cref="Routing.PointToPointRoute"/>. If Path is
        /// set to a <see cref="Site"/>, both <see cref="AnalysisStart"/> and <see cref="AnalysisStop"/> must be set.
        /// </summary>
        public PathLocation Path { get; set; }
        /// <summary>
        /// The start time for the analysis.  This is only used if the PathLocation is a <see cref="Site"/>.
        /// </summary>
        public DateTime AnalysisStart { get; set; }
        /// <summary>
        /// The stop time for the analysis.  This is only used if the PathLocation is a <see cref="Site"/>.
        /// </summary>
        public DateTime AnalysisStop { get; set; }
        public float OutputTimeOffset { get; set; }

    }

    public class PathLocation
    {
        public PathLocation()
        {
            Location = new ServiceCartographic();
        }
        public ServiceCartographic Location { get; set; }
    }
}


