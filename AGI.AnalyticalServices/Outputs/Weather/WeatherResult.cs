using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;

namespace AGI.AnalyticalServices.Outputs.Weather
{
    public class WeatherResult
    {
        public DateTimeOffset ResultTime { get; set; }
        public float AtmosphericPressure { get; set; }
        public string CloudCeiling { get; set; }       
        public float CloudCover { get; set; }        
        public float DewPoint { get; set; }        
        public float RelativeHumidity { get; set; }        
        public string Icon { get; set; }        
        public float PrecipitationRate { get; set; }       
        public string PrecipitationType { get; set; }        
        public float PrecipitationProbability { get; set; }        
        public float Temperature { get; set; }
        public string TextSummary { get; set; }
        public float Visibility { get; set; }
        public float WindGust { get; set; }
        public float WindSpeed { get; set; }
        public float WindDirection { get; set; }
        public string Notes { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
