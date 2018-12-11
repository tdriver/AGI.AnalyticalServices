using System;

namespace AGI.AnalyticalServices.Inputs
{
    public class ServiceCartographicWithTime
    {
        
        public ServiceCartographic Position { get; set; }
        public DateTime Time { get; set; }

        public ServiceCartographicWithTime()
        {
            Position = new ServiceCartographic();
        }

        public override string ToString()
        {
            return string.Join(", ", Position.ToString(), Time.ToString("O"));
        }
    }
}
