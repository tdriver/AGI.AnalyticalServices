using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using AGI.AnalyticalServices.Inputs;
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
    }
}
