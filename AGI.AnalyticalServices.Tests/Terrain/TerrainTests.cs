﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using AGI.AnalyticalServices.Inputs;
using AGI.AnalyticalServices.Inputs.Routing;
using AGI.AnalyticalServices.Outputs.Terrain;
using AGI.AnalyticalServices.Util;
using NUnit.Framework;

namespace AGI.AnalyticalServices.Tests.Terrain
{
    [TestFixture]
    public class TerrainTests
    {       
        [Test]
        public void TestTerrainAlongPointToPointRoute()
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

            var uri = Networking.GetFullUri("/V1/terrain/pointtopoint");

            var terrainHeightResult =  
            Networking.HttpPostCall<PointToPointRouteData,List<TerrainHeightAtLocationResponse>>(uri, request).Result;

            Assert.That(terrainHeightResult != null);
            Assert.That(terrainHeightResult.Count == 181);
            Assert.AreEqual(2091.64136f,terrainHeightResult[0].TerrainHeightFromMeanSeaLevel);
        }
    }
}
