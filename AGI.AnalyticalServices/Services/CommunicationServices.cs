using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AGI.AnalyticalServices.Inputs;
using AGI.AnalyticalServices.Inputs.Communications;
using AGI.AnalyticalServices.Outputs.Communications;
using AGI.AnalyticalServices.Util;

namespace AGI.AnalyticalServices.Services.Communications
{
    /// <summary>
    /// Communication methods.  See the service documentation for 
    /// notes this service: https://saas.agi.com/V1/Documentation/Communication.
    /// </summary>
    public class CommunicationServices
    {
        public static async Task<CommunicationsResults> GetLinkBudget(CommunicationData commData){
            string relativeUri = ServiceUris.CommunicationsLinkBudgetUri;
            
            commData.Verify();                        
                      
            var uri = Networking.GetFullUri(relativeUri);
            return await Networking.HttpPostCall<CommunicationData, CommunicationsResults>(uri, commData);
        }        
    }
}