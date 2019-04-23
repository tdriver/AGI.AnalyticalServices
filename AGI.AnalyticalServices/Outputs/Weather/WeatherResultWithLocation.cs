using System;
using System.Collections.Generic;
using System.Globalization;
using AGI.AnalyticalServices.Inputs;
using Newtonsoft.Json;

namespace AGI.AnalyticalServices.Outputs.Weather
{
    public class WeatherResultWithLocation : WeatherResult
    {
       public ServiceCartographic Location {get; set;}

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
