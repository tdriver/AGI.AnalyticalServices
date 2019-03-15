using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AGI.AnalyticalServices.Inputs;
using AGI.AnalyticalServices.Inputs.Airspace;
using AGI.AnalyticalServices.Outputs.Airspace;
using AGI.AnalyticalServices.Inputs.Navigation;
using AGI.AnalyticalServices.Outputs.Navigation;
using AGI.AnalyticalServices.Inputs.Routing;

using AGI.AnalyticalServices.Util;

namespace AGI.AnalyticalServices.Services.Airspace
{
    /// <summary>
    /// Czml methods.  See the service documentation for 
    /// notes on the different Czml call types: https://saas.agi.com/V1/Documentation/Czml.
    /// </summary>
    public class CzmlServices
    {
        public static async Task<string> GetSgp4Czml(Sgp4CzmlRouteData czmlRouteData){
            czmlRouteData.Verify();                                   
            var uri = Networking.GetFullUri(ServiceUris.VehiclePathCzmlSgp4Uri);            
            return await Networking.HttpPostCall<Sgp4CzmlRouteData,string>(uri, czmlRouteData);
        }     

        public static async Task<AirspaceCzml> GetAirspaceCzml(AirspaceCzmlData czmlAirspaceData){
            czmlAirspaceData.Verify();                                   
            var uri = Networking.GetFullUri(ServiceUris.AirspaceCzmlUri);            
            return await Networking.HttpPostCall<AirspaceCzmlData,AirspaceCzml>(uri, czmlAirspaceData);
        }  
       
       public static async Task<string> GetGpsOrbitsCzml(CzmlGpsOrbit czmlGpsData, DateTime start, DateTime stop, 
                                                        bool highlightOutages = true, Color outageColor = Color.White,
                                                        bool useInertial = true){
            czmlGpsData.Verify();                                   
            var uri = Networking.GetFullUri(ServiceUris.VehiclePathCzmlGpsUri);      
            uri = new Uri(uri, $"&start={start.ToString("YYYY-MM-DDTHH:mm:ss")}");
            uri = new Uri(uri,$"&stop={stop.ToString("YYYY-MM-DDTHH:mm:ss")}");
            uri = new Uri(uri,$"&highlightOutages={highlightOutages}");
            uri = new Uri(uri,$"&outageColor={outageColor}");
            uri = new Uri(uri,$"&inertial={useInertial}");    
                                       
            return await Networking.HttpGetCall(uri);
        }  

        /// <summary>
        /// Gets Czml data representing global GPS acuracy for a given date
        /// </summary>
        /// <param name="date">the date the global Gps accuracy is desired</param>
        /// <param name="animated">When true, the results will animate for the 24 hour period</param>
        /// <param name="useSmallGrid">When true, the data is plotted on a smaller grid.</param>
        /// <returns>A string of Czml data</returns>
         public static async Task<string> GetGpsGlobalAccuracyCzml(DateTime date, 
                                                                   bool animated = false,
                                                                   bool useSmallGrid = false){                                
            var uri = Networking.GetFullUri(ServiceUris.VehiclePathCzmlGpsUri); 
            uri = Networking.AppendDateToUri(uri,date);

            uri = new Uri(uri,$"&animated={animated}");
            uri = new Uri(uri,$"&useSmallGrid={useSmallGrid}");    
                                       
            return await Networking.HttpGetCall(uri);
        }  
    }
}