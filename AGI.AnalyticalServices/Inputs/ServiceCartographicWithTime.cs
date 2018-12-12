using System;
using System.Collections.Generic;

namespace AGI.AnalyticalServices.Inputs
{
    public class ServiceCartographicWithTime: IVerifiable
    {
        
        public ServiceCartographic Position { get; set; }
        //TODO add SensorStates
        //public List<SensorState> SensorStates { get; set; }
        public DateTimeOffset Time { get; set; }

        public ServiceCartographicWithTime()
        {
            Position = new ServiceCartographic();
        }

        public override string ToString()
        {
            return string.Join(", ", Position.ToString(), Time.ToString("O"));
        }

        public void Verify()
        {
            Position.Verify();
        }
    }
}
