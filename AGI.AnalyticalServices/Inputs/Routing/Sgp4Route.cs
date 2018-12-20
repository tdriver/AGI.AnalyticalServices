using System;
using System.Collections.Generic;
using AGI.AnalyticalServices.Exceptions;
using AGI.AnalyticalServices.Inputs;
using Newtonsoft.Json;

namespace AGI.AnalyticalServices.Inputs.Routing
{
    /// <summary>
    /// An orbit route based on a Two Line Element (TLE) set.
    /// </summary>
    public class Sgp4Route : IVerifiable
    {
        /// <summary>
        /// The start time for the vehicle following the orbital path.
        /// </summary>
        public DateTimeOffset Start {get; set;}
        /// <summary>
        /// The stop time for the vehicle following the orbital path.
        /// </summary>
        public DateTimeOffset Stop { get; set; }
        /// <summary>
        /// The NORAD catalog number for the space object.
        /// </summary>
        public int SSC { get; set; }
        /// <summary>
        /// A set of TLEs representing the same vehicle.
        /// </summary>
        public List<string> TLEs { get; set; }
        public OutputSettings OutputSettings { get; set; }

        public Sgp4Route()
        {
            OutputSettings = new OutputSettings();
        }

        public void Verify()
        {
            OutputSettings.Verify();

            if (TLEs == null || TLEs.Count == 0)
            {
                if (SSC == 0)
                {
                    throw new AnalyticalServicesException(24150, 
                    "Either the TLE or the SSC must be specified for this service.");
                }
            }
            if (Start > Stop)
            {
                throw new AnalyticalServicesException(21800, "Sgp4 Start time must be earlier that Sgp4 Stop time.");
            }
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}