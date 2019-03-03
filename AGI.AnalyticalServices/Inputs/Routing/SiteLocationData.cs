using System;
using AGI.AnalyticalServices.Exceptions;
using AGI.AnalyticalServices.Inputs;
using AGI.AnalyticalServices.Inputs.Routing;
using Newtonsoft.Json;

namespace AGI.AnalyticalServices.Inputs.Routing
{
    public class SiteLocationData : IVerifiable, ISiteInput
    {
        public ServiceCartographic Location { get; set; }
        public bool MeanSeaLevel { get; set; }
        public OutputSettings OutputSettings { get; set; }

        public SiteLocationData()
        {
            MeanSeaLevel = true;
            OutputSettings = new OutputSettings();
        }

        public void Verify()
        {
            if(Location != null)
                Location.Verify();
            else
            {
                throw new AnalyticalServicesException(24000,"Location must be set in this service.");
            }
            OutputSettings.Verify();

        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
