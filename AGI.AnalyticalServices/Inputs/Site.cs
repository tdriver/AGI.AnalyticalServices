﻿namespace AGI.AnalyticalServices.Inputs
{
    /// <summary>
    /// A static location on the Earth.
    /// </summary>
    public class Site
    {
        /// <summary>
        /// the location of the Site.
        /// </summary>
        public ServiceCartographic Location { get; set; }
        /// <summary>
        /// When true, the Altitude you've specified in Location is referenced to Mean Sea Level.  when false, the Altitude is reference to WGS-84.
        /// </summary>
        public bool MeanSeaLevel { get; set; }
        /// <summary>
        /// The output settings for the Site object.  The OutputSettings variable "Step", is ignored for a Site.
        /// </summary>
        public OutputSettings OutputSettings { get; set; }

        /// <summary>
        /// Sets the defaults for a Site.
        /// </summary>
        public Site()
        {
            Location = new ServiceCartographic();
            MeanSeaLevel = false;
            OutputSettings = new OutputSettings();
        }
    }
}
