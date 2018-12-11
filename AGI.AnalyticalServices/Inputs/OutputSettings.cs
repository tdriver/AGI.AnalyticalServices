namespace AGI.AnalyticalServices.Inputs
{
    public class OutputSettings
    {
        /// <summary>
        /// Step size of the propagated output data, in seconds. Defaults to 60.
        /// </summary>
        public int Step { get; set; }
        /// <summary>
        /// the Time Format for the output.  It can be either "Epoch" or "UTC". Epoch times start at 0, and increment by the Step value for each returned point.
        /// UTC represents each propagated point's time in Universal Time Coordinated, in ISO 8601 format. Defaults to UTC.
        /// </summary>
        public string TimeFormat { get; set; }
        /// <summary>
        /// The Coordinate Format for the Output.
        /// </summary>
        public CoordinateFormat CoordinateFormat { get; set; }

        /// <summary>
        /// Set the defaults for OutputSettings.
        /// </summary>
        public OutputSettings()
        {
            CoordinateFormat = new CoordinateFormat();
            TimeFormat = "UTC";
            Step = 60;
        }
    }
}
