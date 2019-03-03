using System;
using System.Configuration;
using AGI.AnalyticalServices.Inputs.Routing;
using AGI.AnalyticalServices.Inputs.Lighting;
using AGI.AnalyticalServices.Outputs.Lighting;
using NUnit.Framework;
using AGI.AnalyticalServices.Util;

namespace AGI.AnalyticalServices.Tests.Lighting
{
    [TestFixture]
    public class SolarLightingTest
    {
        [Test]
        public void TestSolarLighting()
        {
            var request = new SolarLightingData<SiteData>();
            request.Path = new SiteData();
            request.Path.Location.Latitude = 39.0;
            request.Path.Location.Longitude = -104.77;
            request.Path.Location.Altitude = 1910;
            request.AnalysisStart = new DateTime(2018,5,5);
            request.AnalysisStop = new DateTime(2018,5,5);
            request.OutputTimeOffset = -6.0f;

            var uri = Networking.GetFullUri("/V1/lighting/site");

            var lightingResult = 
            Networking.HttpPostCall<SolarLightingData<SiteData>,FlightLightingConditions>(uri, request).Result;
            Assert.That(lightingResult != null);
            Assert.That(lightingResult.Lighting[0].Sunrise.Hour == 5);
            Assert.That(lightingResult.Lighting[0].Sunrise.Minute == 56);
            Assert.That(lightingResult.Lighting[0].Sunrise.Second == 20);
            Assert.That(lightingResult.Lighting[0].Sunset.Hour == 19);
            Assert.That(lightingResult.Lighting[0].Sunset.Minute == 55);
            Assert.That(lightingResult.Lighting[0].Sunset.Second == 49);

        }
    }
}