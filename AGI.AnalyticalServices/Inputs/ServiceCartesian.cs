using Newtonsoft.Json;
using System.Text;

namespace AGI.AnalyticalServices.Inputs
{
    public class ServiceCartesian
    {
        public ServiceCartesian()
        {

        }
        public ServiceCartesian(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        /// <summary>
        /// X position
        /// </summary>
        public double X { get; set; }
        /// <summary>
        /// Y position
        /// </summary>
        public double Y { get; set; }
        /// <summary>
        /// Z position
        /// </summary>
        public double Z { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}

