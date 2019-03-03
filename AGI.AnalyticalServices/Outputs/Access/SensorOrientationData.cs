using System.Collections.Generic;
using AGI.AnalyticalServices.Inputs;
using Newtonsoft.Json;

namespace AGI.AnalyticalServices.Outputs.Access
{
    public class SensorOrientationData
    {
        public SensorOrientationData()
        {
            SensorOrientations = new List<ServiceUnitQuaternion>();
        }

        public SensorOrientationData(string name, List<ServiceUnitQuaternion> sensorOrientations)
        {
            SensorName = name;
            SensorOrientations = new List<ServiceUnitQuaternion>(sensorOrientations);
        }

        public List<ServiceUnitQuaternion> SensorOrientations { get; set; }
        public string SensorName { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
