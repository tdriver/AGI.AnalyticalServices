using System;
using AGI.AnalyticalServices.Inputs;
using Newtonsoft.Json;

namespace AGI.AnalyticalServices.Outputs
{
    public class ExtremesInfo : BasicExtremesInfo<double>
    {
        public ServiceCartographic LocationOfMax { get; set; }
        public ServiceCartographic LocationOfMin { get; set; }
        public DateTime TimeOfMax { get; set; }
        public DateTime TimeOfMin { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
