using System;
using System.Collections.Generic;

namespace AGI.AnalyticalServices.Outputs.Lighting
{
    public class SolarLightingResponse
    {
        public List<LightingResponse> Lighting { get; set; }
    }

    public class LightingResponse
    {
        public DateTime AstronomicalTwilightAmStart { get; set; }
        public DateTime AstronomicalTwilightAmStop { get; set; }
        public DateTime AstronomicalTwilightPmStart { get; set; }
        public DateTime AstronomicalTwilightPmStop { get; set; }
        public DateTime NauticalTwilightAmStart { get; set; }
        public DateTime NauticalTwilightAmStop { get; set; }
        public DateTime NauticalTwilightPmStart { get; set; }
        public DateTime NauticalTwilightPmStop { get; set; }
        public DateTime CivilTwilightAmStart { get; set; }
        public DateTime CivilTwilightAmStop { get; set; }
        public DateTime CivilTwilightPmStart { get; set; }
        public DateTime CivilTwilightPmStop { get; set; }
        public DateTime Sunrise { get; set; }
        public DateTime Sunset { get; set; }
        public bool ContinuouslyBelowHorizon { get; set; }
        public bool ContinuouslyAboveHorizon { get; set; }
        public bool IsRiseDefined { get; set; }
        public bool IsSetDefined { get; set; }
    }
}


