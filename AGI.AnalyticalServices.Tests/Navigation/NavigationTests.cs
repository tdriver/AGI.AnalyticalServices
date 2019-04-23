﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using AGI.AnalyticalServices.Inputs;
using AGI.AnalyticalServices.Inputs.Navigation;
using AGI.AnalyticalServices.Inputs.Routing;
using AGI.AnalyticalServices.Outputs.Navigation;
using AGI.AnalyticalServices.Services.Navigation;
using AGI.AnalyticalServices.Util;
using NUnit.Framework;

namespace AGI.AnalyticalServices.Tests.Navigation
{
    [TestFixture]
    public class NavigationTests
    {       
        [Test]
        public void TestPsfDataWithdate()
        {
            var psf = NavigationServices.GetPsfData(new DateTime(2019,01,01)).Result;
            Assert.That(!string.IsNullOrEmpty(psf));
        }
        [Test]
        public void TestPsfDataWithoutdate()
        {
            var psf = NavigationServices.GetPsfData().Result;
            Assert.That(!string.IsNullOrEmpty(psf));
        }
        [Test]
        public void TestPafWithoutDate()
        {
            var paf = NavigationServices.GetPafData().Result;
            Assert.That(!string.IsNullOrEmpty(paf));
        }
         [Test]
        public void TestPafWithDate()
        {
            var paf = NavigationServices.GetPafData(new DateTime(2019,01,01)).Result;
            Assert.That(!string.IsNullOrEmpty(paf));
        }
        [Test]
        public void TestSofWithoutDate()
        {
            var sof = NavigationServices.GetSofData().Result;
            Assert.That(!string.IsNullOrEmpty(sof));
        }
         [Test]
        public void TestSofWithDate()
        {
            var sof = NavigationServices.GetSofData(new DateTime(2019,01,01)).Result;
            Assert.That(!string.IsNullOrEmpty(sof));
        }
        [Test]
        public void TestAlmanacWithoutDate()
        {
            var alm = NavigationServices.GetAlmanacData().Result;
            Assert.That(!string.IsNullOrEmpty(alm));
        }
         [Test]
        public void TestAlmanacWithDate()
        {
            var alm = NavigationServices.GetAlmanacData(new DateTime(2019,01,04)).Result;
            Assert.That(!string.IsNullOrEmpty(alm));
        }

        [Test]
        public void TestGpsOutagesDatesAndPrn()
        {
            var outages = NavigationServices.GetGpsOutages(
                new DateTime(2019,01,01),new DateTime(2019,03,22)).Result;
            Assert.That(!string.IsNullOrEmpty(outages));
        }

        [Test]
        public void TestPredictedErrorsOnSimpleFlightRoute()
        {
            var input = new NavigationPredictionData<IVerifiable> ();
            var path = new SimpleFlightRouteData();
            path.Start = new DateTimeOffset(2014,5,3,0,0,0,0,new TimeSpan(0));
            path.Waypoints.Add(new ServiceCartographic2D(39.0,-104.77));
            path.Waypoints.Add(new ServiceCartographic2D(30.0,-98.0));
            path.Waypoints.Add(new ServiceCartographic2D(40.0,-77.0));
            path.TurningRadius = 1000.0;
            path.Speed = 111.76;
            path.Altitude = 9144.0;
            path.MeanSeaLevel = true;
            input.Path = path;
            var result = NavigationServices.GetPredictedNavigationErrorsOnARoute(input).Result;
            Assert.That(result.Errors.Length > 0);
        }
    }
}
