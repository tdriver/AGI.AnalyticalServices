using System;
using System.Collections.Generic;
using System.Configuration;
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
            passRequest.SSCs.Add(25544);
            passRequest.Start = new DateTime(2019,5,27,12,0,0,DateTimeKind.Utc);
            passRequest.Stop = passRequest.Start.AddDays(7);
            var sd = new SiteData();
            sd.Location = new ServiceCartographic(40.0,-75.0,0.0);
            passRequest.FromObjectPath = sd;
            passRequest.ToObjectLit = true;
            passRequest.FromObjectDark = true;
            passRequest.Verify();

            // call the service
            var passResults = AccessServices.GetSatellitePasses<SatellitePassResults<ServiceCartographic>>(passRequest).Result;
            Assert.That(passResults.Count > 0);
            // if(passResults.Count > 0){
            //     // parse results and output
            //     foreach (var SSC in passResults)
            //     {
            //         Console.WriteLine($"There are {SSC.Passes.Count} passes for {SSC.Passes[0].SSC}..");
            //         int passNumber = 1;
            //         foreach (var pass in SSC.Passes)
            //         {
            //             Console.WriteLine($"------- Pass number {passNumber} ---------");
            //             Console.WriteLine(pass.ToString());
            //             passNumber++;
            //         }
            //     }
            // }
            // else{
            //     Console.WriteLine("No pass results for those criteria and time span.");
            // }
        }
    }
}