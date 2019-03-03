using System.Collections.Generic;
using Newtonsoft.Json;

namespace AGI.AnalyticalServices.Outputs.Airspace
{
    public class AirspaceIdentifier
    {
        public string AirspaceId {get; set;}
        public string Name { get; set; }
        public Dictionary<string,string> Properties { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}