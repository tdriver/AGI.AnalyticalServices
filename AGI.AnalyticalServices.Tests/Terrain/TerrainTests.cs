using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using AGI.AnalyticalServices.Inputs;
using AGI.AnalyticalServices.Inputs.Routing;
using AGI.AnalyticalServices.Outputs.Terrain;
using NUnit.Framework;

namespace AGI.AnalyticalServices.Tests.SDK.Terrain
{
    [TestFixture]
    public class TerrainTests
    {
        public string ApiKey { get; set; }

        [OneTimeSetUp]
        public void Init()
        {
            ApiKey = ConfigurationManager.AppSettings.Get("ApiKey");
        }

        [Test]
        public void TestTerrainAlongPointToPointRoute()
        {
            var request = new PointToPointRoute(2);
            
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
            

            var uri = new Uri("https://saas.agi.com/v1/terrain/pointtopoint?u=" + ApiKey);

            // TODO, implement the networking intgerface for these calls.
            List<TerrainHeightAtLocation> terrainHeightResult = null; //Networking.HttpPostCall<PointToPointRoute,List<TerrainHeightAtLocation>>(uri, request).Result;
            Assert.That(terrainHeightResult != null);
            Assert.That(terrainHeightResult.Count > 0);
            var sb = new StringBuilder();
            foreach (var r in terrainHeightResult)
            {
                sb.AppendLine(r.Location.Position.Longitude + "," + r.TerrainHeightFromMeanSeaLevel);
            }
        }
    }
}
