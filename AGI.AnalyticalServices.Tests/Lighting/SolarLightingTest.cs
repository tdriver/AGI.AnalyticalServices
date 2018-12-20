﻿using System;
using System.Configuration;
using AGI.AnalyticalServices.Inputs.Routing;
using AGI.AnalyticalServices.Inputs.Lighting;
using AGI.AnalyticalServices.Outputs.Lighting;
using NUnit.Framework;

namespace AGI.AnalyticalServices.Tests.Lighting
{
    [TestFixture]
    public class SolarLightingTest:TestBase
    {
        [Test]
        public void TestSolarLighting()
        {
            var request = new SolarLighting<Site>();
            request.Path = new Site();
            request.Path.Location.Latitude = 39.0;
            request.Path.Location.Longitude = -104.77;
            request.Path.Location.Altitude = 1910;
            request.AnalysisStart = new DateTime(2018,5,5);
            request.AnalysisStop = new DateTime(2018,5,5);

            var uri = GetFullUri("/V1/lighting/site");

            var lightingResult = 
            Networking.HttpPostCall<SolarLighting<Site>,SolarLightingResponse>(uri, request).Result;
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
