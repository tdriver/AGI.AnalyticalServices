using AGI.AnalyticalServices.Inputs;
using Newtonsoft.Json;

namespace AGI.AnalyticalServices.Outputs.Navigation
{
    /// <summary>
    /// This is used for conditions where the location changes with time
    /// </summary>
    public class NavigationErrorWithLocation : NavigationError
    {
        public ServiceCartographic Location { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}