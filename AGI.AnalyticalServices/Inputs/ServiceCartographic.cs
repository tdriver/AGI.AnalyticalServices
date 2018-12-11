using System.Text;

namespace AGI.AnalyticalServices.Inputs
{
    public class ServiceCartographic
    {
        /// <summary>
        /// The Latitude of the location, in degrees.
        /// </summary>
        public double Latitude { get; set; }
        /// <summary>
        /// The Longitude of the location, in degrees. Longitudes are measured negative west of the Prime Meridian.
        /// </summary>
        public double Longitude { get; set; }
        /// <summary>
        ///  The Altitude of the location, in meters.
        /// </summary>
        public double Altitude { get; set; }

        /// <summary>
        /// Outputs the ServiceCartographic location as: "Lat: x.xx, Lon: x.xx, Alt: x.xx", with full precision.
        /// </summary>
        /// <returns>String representation of the ServiceCartographic.</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"Lat: {Latitude}, Lon: {Longitude}, Alt: {Altitude}");
            return sb.ToString();
        }

        /// <summary>
        /// Sets the ServiceCartographic defaults to 0,0,0.
        /// </summary>
        public ServiceCartographic()
        {
            Latitude = 0.0;
            Longitude = 0.0;
            Altitude = 0.0;
        }
    }
}
