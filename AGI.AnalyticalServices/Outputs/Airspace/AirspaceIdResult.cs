
using System.Collections.Generic;
using Newtonsoft.Json;

namespace AGI.AnalyticalServices.Outputs.Airspace
{
    public class AirspaceIdResult
    {
        public List<AirspaceIdentifier> AirspaceIds {get; set;}

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}