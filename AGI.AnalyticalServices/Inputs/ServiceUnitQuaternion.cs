using Newtonsoft.Json;

namespace AGI.AnalyticalServices.Inputs
{
    public class ServiceUnitQuaternion
    {
        public ServiceUnitQuaternion()
        {
            // identity UnitQuaternion
            W = 1.0;
            X = Y = Z = 0.0;
        }

        public ServiceUnitQuaternion(double w, double x, double y, double z)
        {
            W = w;
            X = x;
            Y = y;
            Z = z;
        }

        public double W { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
