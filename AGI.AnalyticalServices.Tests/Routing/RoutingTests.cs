using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using AGI.AnalyticalServices.Inputs;
using AGI.AnalyticalServices.Inputs.Routing;
using AGI.AnalyticalServices.Outputs.Terrain;
using AGI.AnalyticalServices.Services.Routing;
using AGI.AnalyticalServices.Util;
using NUnit.Framework;

namespace AGI.AnalyticalServices.Tests.Routing
{
    [TestFixture]
    public class RoutingTests
    {       
        [Test]
        public void TestPointToPointRouteCartographic()
        {
            var request = new PointToPointRouteData(2);
            
            request.Waypoints[0].Position = new ServiceCartographic
            {
                Altitude = 1910,
                Latitude = 39.0,
                Longitude = -104.77
            };
            request.Waypoints[0].Time = new DateTime(2018,10,30,0,0,0);
            request.Waypoints[1].Position = new ServiceCartographic
            {
                Altitude = 1910,
                Latitude = 38.794,
                Longitude = -105.217755
            };
            request.Waypoints[1].Time = new DateTime(2018,10,30,1,0,0);
            request.OutputSettings.Step = 20;            

            var result = PointToPointRoute.GetPointToPointRoute<ServiceCartographicWithTime>(request).Result;

            // Tests are here to verify the results are returned and formatted correctly
            Assert.That(result != null);
            Assert.That(result.Count == 181);
            Assert.That(result[1].Time.Second == 20);
            Assert.That(result[1].Position.Latitude == 38.9988603381374);
            Assert.That(result[1].Position.Longitude == -104.77249465959173);
            Assert.That(result[1].Position.Altitude == 1909.1200208723517);
        }

         [Test]
        public void TestPointToPointRouteCartesian()
        {
            var request = new PointToPointRouteData(2);
            
            request.Waypoints[0].Position = new ServiceCartographic
            {
                Altitude = 1910,
                Latitude = 39.0,
                Longitude = -104.77
            };
            request.Waypoints[0].Time = new DateTime(2018,10,30,0,0,0);
            request.Waypoints[1].Position = new ServiceCartographic
            {
                Altitude = 1910,
                Latitude = 38.794,
                Longitude = -105.217755
            };
            request.Waypoints[1].Time = new DateTime(2018,10,30,1,0,0);
            request.OutputSettings.Step = 45;     
            request.OutputSettings.CoordinateFormat.Coord = CoordinateRepresentation.XYZ;       

            var result = PointToPointRoute.GetPointToPointRoute<ServiceCartesianWithTime>(request).Result;

            // Tests are here to verify the results are returned and formatted correctly
            Assert.That(result != null);
            Assert.That(result.Count == 81);
            Assert.AreEqual(45,result[1].Time.Second);
            Assert.AreEqual(-1266242.1907423697, result[1].Position.X);
            Assert.AreEqual(-4800807.2322983844, result[1].Position.Y);
            Assert.AreEqual(3993296.4801795725, result[1].Position.Z);
        }
    }
}