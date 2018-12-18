using Newtonsoft.Json;

namespace AGI.AnalyticalServices.Inputs
{
    public class SensorState
    {
        public SensorState()
        {
            Orientation = new ServiceUnitQuaternion();
            Name = string.Empty;
        }
        public SensorState(string name, ServiceUnitQuaternion orientation)
        {
            Name = name;
            Orientation = orientation;
        }
        public ServiceUnitQuaternion Orientation { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
