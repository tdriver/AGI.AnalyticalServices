using System;
using AGI.AnalyticalServices.Inputs;
using Newtonsoft.Json;

namespace AGI.AnalyticalServices.Outputs.Communications
{
    public class LinkBudgetResultStandardWithLocation : LinkBudgetResultStandard
    {
        public ServiceCartographic Location { get; set; }
        public LinkBudgetResultStandardWithLocation(LinkBudgetResultAll fullResults, 
                                                    ServiceCartographic location) : base(fullResults)
        {
            Location = location;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
