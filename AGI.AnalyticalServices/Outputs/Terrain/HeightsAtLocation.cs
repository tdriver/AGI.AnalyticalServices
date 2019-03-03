using System;
using AGI.AnalyticalServices.Inputs;
using Newtonsoft.Json;

namespace AGI.AnalyticalServices.Outputs.Terrain
{
    public class HeightsAtLocation : Heights
    {
       public ServiceCartographicWithTime Location { get; set; }
        public HeightsAtLocation(Tuple<double,double> heights, ServiceCartographicWithTime location): base(heights)
        {
            Location = location;
        }

        public HeightsAtLocation()
        {
            
        }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
