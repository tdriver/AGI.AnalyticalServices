﻿using System.Text;
using AGI.AnalyticalServices.Exceptions;
using Newtonsoft.Json;

namespace AGI.AnalyticalServices.Inputs
{
    public class ServiceCartographic2D:IVerifiable
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public override string ToString() => JsonConvert.SerializeObject(this);

        public void Verify()
        {
            if (Latitude < -90 || Latitude > 90)
            {
                throw new AnalyticalServicesException(23600, "Latitude must be between -90 deg and 90 deg.");
            }

            if (Longitude < -360 || Longitude > 360)
            {
                throw new AnalyticalServicesException(23600, "Longitude must be between -360 deg and 360 deg.");
            }
        }
    }
}
