using System;
using System.Collections.Generic;
using AGI.AnalyticalServices.Inputs.Communications;
using Newtonsoft.Json;

namespace AGI.AnalyticalServices.Outputs.Communications
{
    public class CommunicationsResults: CommunicationsExtremes
    {
        public List<LinkBudgetResultAllWithLocation> LinkBudgets { get; }
        
        public CommunicationsResults()
        {
            LinkBudgets = new List<LinkBudgetResultAllWithLocation>();
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this,new Newtonsoft.Json.Converters.StringEnumConverter());
        }
    }
}
