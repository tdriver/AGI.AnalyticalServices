using System.Text;

namespace AGI.AnalyticalServices.Inputs
{
    public class ServiceCartographic2D
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"Lat: {Latitude:F6}, Lon: {Longitude:F6}");
            return sb.ToString();
        }
    }
}
