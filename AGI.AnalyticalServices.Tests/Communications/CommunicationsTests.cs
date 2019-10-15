﻿using System;
using System.Configuration;
using System.Collections.Generic;
using AGI.AnalyticalServices.Inputs;
using AGI.AnalyticalServices.Inputs.Routing;
using AGI.AnalyticalServices.Inputs.Communications;
using AGI.AnalyticalServices.Outputs.Communications;
using AGI.AnalyticalServices.Services.Communications;
using NUnit.Framework;
using AGI.AnalyticalServices.Util;
using System.IO;

namespace AGI.AnalyticalServices.Tests.Communications
{
    [TestFixture]
    public class CommunicationsTests
    {
        [Test]
        public void TestLinkBudgetsAlongAPath()
        {
            var Frequency = 14500000000.0;
            var Power = 1000.0;
            var DataRate = 16000000.0;
            var Bandwidth = 20000000.0;

            var request = new CommunicationData();
            request.OutputUnits = OutputUnit.Decibels;
            // Transmitter
            var td = new TransmitterData();
            var sd = new SiteData();
            sd.Location = new ServiceCartographic(42.0, -105.0, 2000.0);
            sd.MeanSeaLevel = true;
            td.Path = sd;
            td.PathRouteType = RouteTypes.FixedSite;
            td.Frequency = Frequency;
            td.Power = Power;
            td.DataRate = DataRate;
            request.Transmitter = td;
            // Interference Sources
            var jammer1 = new TransmitterData();
            var jammer1Path = new SiteData();
            jammer1Path.Location = new ServiceCartographic(42.001, -105.0, 1900);
            jammer1Path.MeanSeaLevel = true;
            jammer1.Path = jammer1Path;
            jammer1.PathRouteType = RouteTypes.FixedSite;
            jammer1.Frequency = Frequency;
            jammer1.Power = Power;
            jammer1.DataRate = DataRate;

            var jammer2 = new TransmitterData();
            var jammer2Path = new SiteData();
            jammer2Path.Location = new ServiceCartographic(41.997, -105.0, 1900);
            jammer2Path.MeanSeaLevel = true;
            jammer2.Path = jammer1Path;
            jammer2.PathRouteType = RouteTypes.FixedSite;
            jammer2.Frequency = Frequency;
            jammer2.Power = Power;
            jammer2.DataRate = DataRate;

            request.InterferenceSources = new List<TransmitterData>();
            request.InterferenceSources.Add(jammer1);
            request.InterferenceSources.Add(jammer2);
            // Receiver
            var receiver = new ReceiverData();
            var receiverPath = new GreatArcRouteData(2);
            receiverPath.Waypoints[0].Position = new ServiceCartographic(41, -105.0, 2000.0);
            receiverPath.Waypoints[0].Time = new DateTimeOffset(2016, 02, 23, 4, 44, 0, new TimeSpan(0));
            receiverPath.Waypoints[1].Position = new ServiceCartographic(43, -104.0, 2000.0);
            receiverPath.Waypoints[1].Time = new DateTimeOffset(2016, 02, 23, 5, 44, 0, new TimeSpan(0));
            receiverPath.OutputSettings.Step = 900;
            receiverPath.OutputSettings.TimeFormat = TimeRepresentation.UTC;
            receiverPath.OutputSettings.CoordinateFormat.Coord = CoordinateRepresentation.LLA;
            receiverPath.OutputSettings.CoordinateFormat.Frame = FrameRepresentation.Fixed;
            receiver.Path = receiverPath;
            receiver.PathRouteType = RouteTypes.GreatArc;
            receiver.TargetFrequency = Frequency;
            receiver.Bandwidth = Bandwidth;
            receiver.AmplifierGain = 100;
            receiver.NoiseFactor = 2.0;
            receiver.ReferenceTemperature = 16.85;
            request.Receiver = receiver;
            // Other settings
            request.UseTirem = true;
            request.TiremSettings.SurfaceHumidity = 10.0;
            request.TiremSettings.SurfaceRefractivity = 200.0;

            // dump the request to see the JSON created
            //File.WriteAllText(@".\CommRequest.json",request.ToString());

            var commResult = CommunicationServices.GetLinkBudget(request).Result;
            Assert.That(commResult != null);
            Assert.That(commResult.LinkBudgets != null);
            Assert.That(commResult.LinkBudgets.Count == 5);
            Assert.AreEqual(0.499, commResult.LinkBudgets[0].BitErrorRate, 1e-3);
        }
    }
}