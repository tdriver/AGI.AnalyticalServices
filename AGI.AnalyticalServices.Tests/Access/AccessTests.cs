using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using AGI.AnalyticalServices.Inputs;
using AGI.AnalyticalServices.Inputs.Access;
using AGI.AnalyticalServices.Inputs.Routing;
using AGI.AnalyticalServices.Outputs.Access;
using AGI.AnalyticalServices.Services.Access;
using AGI.AnalyticalServices.Util;
using NUnit.Framework;

namespace AGI.AnalyticalServices.Tests.Access
{
    [TestFixture]
    public class AccessTests
    {
        [Test]
        public void TestSatellitePasses()
        {
            var passRequest = new SatelliteAccessPassData<IVerifiable>();
            passRequest.SSCs.Add(25544); // the International Space Station
            passRequest.Start = new DateTime(2019, 5, 27, 12, 0, 0, DateTimeKind.Utc);
            passRequest.Stop = passRequest.Start.AddDays(7);
            var sd = new SiteData();
            sd.Location = new ServiceCartographic(40.0, -75.0, 0.0);
            passRequest.FromObjectPath = sd;
            passRequest.ToObjectLit = true;
            passRequest.FromObjectDark = true;
            passRequest.IncludePathCzml = true;
            passRequest.Verify();

            // call the service
            var passResults = AccessServices.GetSatellitePasses<SatellitePassResults<ServiceCartographicWithTime>>
                                                                                                (passRequest).Result;
            Assert.That(passResults.Passes.Count > 0);
            Assert.That(!string.IsNullOrEmpty(passResults.CzmlForPasses));
            // Head to cesiumjs.org, click the "Tap to Interact" button. Once the globe appears, Drag the file produced 
            // in the next line to the globe.  Use the globe controls to move forward and backward in time, and move the 
            // camera to see the orbit, and highlighted visibility times.
            File.WriteAllText("ISS.czml", passResults.CzmlForPasses);

        }
    }
}