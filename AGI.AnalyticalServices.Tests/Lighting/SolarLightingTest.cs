using System;
using System.Configuration;
using AGI.AnalyticalServices.Inputs.Lighting;
using AGI.AnalyticalServices.Outputs.Lighting;
using NUnit.Framework;

namespace AGI.AnalyticalServices.Tests.SDK.Lighting
{
    [TestFixture]
    public class SolarLightingTest
    {
        public string ApiKey { get; set; }

        [OneTimeSetUp]
        public void Init()
        {
            ApiKey = ConfigurationManager.AppSettings.Get("ApiKey");
        }

        [Test]
        public void TestSolarLighting()
        {
            var request = new SolarLightingRequest();
            request.Path = new PathLocation();
            request.Path.Location.Latitude = 39.0;
            request.Path.Location.Longitude = -104.77;
            request.Path.Location.Altitude = 1910;
            request.AnalysisStart = new DateTime(2018,5,5);
            request.AnalysisStop = new DateTime(2018,5,5);
            var uri = new Uri("https://saas.agi.com/v1/lighting/site?u=" + ApiKey);

            // TODO, implement the networking interface for these calls.
            SolarLightingResponse lightingResult = null; //Networking.HttpPostCall<SolarLightingRequest,SolarLightingResponse>(uri, request).Result;
            Assert.That(lightingResult != null);
            Assert.That(lightingResult.Lighting.Count == 1);
            Assert.That(lightingResult.Lighting[0].Sunrise.Hour == 5);
            Assert.That(lightingResult.Lighting[0].Sunrise.Minute == 56);
            Assert.That(lightingResult.Lighting[0].Sunrise.Second == 20);
            Assert.That(lightingResult.Lighting[0].Sunset.Hour == 19);
            Assert.That(lightingResult.Lighting[0].Sunset.Minute == 55);
            Assert.That(lightingResult.Lighting[0].Sunset.Second == 49);

        }
    }
}
