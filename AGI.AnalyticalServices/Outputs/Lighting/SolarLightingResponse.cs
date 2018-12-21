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
        public DateTimeOffset AstronomicalTwilightAmStart { get; set; }
        public DateTimeOffset AstronomicalTwilightAmStop { get; set; }
        public DateTimeOffset AstronomicalTwilightPmStart { get; set; }
        public DateTimeOffset AstronomicalTwilightPmStop { get; set; }
        public DateTimeOffset NauticalTwilightAmStart { get; set; }
        public DateTimeOffset NauticalTwilightAmStop { get; set; }
        public DateTimeOffset NauticalTwilightPmStart { get; set; }
        public DateTimeOffset NauticalTwilightPmStop { get; set; }
        public DateTimeOffset CivilTwilightAmStart { get; set; }
        public DateTimeOffset CivilTwilightAmStop { get; set; }
        public DateTimeOffset CivilTwilightPmStart { get; set; }
        public DateTimeOffset CivilTwilightPmStop { get; set; }
        public DateTimeOffset Sunrise { get; set; }
        public DateTimeOffset Sunset { get; set; }
        public bool ContinuouslyBelowHorizon { get; set; }
        public bool ContinuouslyAboveHorizon { get; set; }
        public bool IsRiseDefined { get; set; }
        public bool IsSetDefined { get; set; }
    }
}


