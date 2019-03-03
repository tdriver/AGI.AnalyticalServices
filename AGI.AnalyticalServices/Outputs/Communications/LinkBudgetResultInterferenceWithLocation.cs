using AGI.AnalyticalServices.Inputs;
using Newtonsoft.Json;

namespace AGI.AnalyticalServices.Outputs.Communications
{
    public class LinkBudgetResultInterferenceWithLocation : LinkBudgetResultInterference
    {
        public ServiceCartographic Location { get; set; }
        public LinkBudgetResultInterferenceWithLocation(LinkBudgetResultAll fullResults, 
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