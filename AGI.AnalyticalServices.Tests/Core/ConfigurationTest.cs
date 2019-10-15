using System;
using System.Configuration;
using AGI.AnalyticalServices.Inputs.Routing;
using AGI.AnalyticalServices.Inputs.Lighting;
using AGI.AnalyticalServices.Outputs.Lighting;
using NUnit.Framework;
using AGI.AnalyticalServices.Util;
using System.IO;
using System.Text;

namespace AGI.AnalyticalServices.Tests.Configuration
{
    [TestFixture, Explicit]
    public class ConfigurationTest
    {
        [Test]
        public void TestConfigurationFileNotPresent()
        {
            if (File.Exists("AGI.AnalyticalServices.config.test"))
            {
                File.Delete("AGI.AnalyticalServices.config.test");
            }

            if (File.Exists("AGI.AnalyticalServices.config"))
            {
                File.Move("AGI.AnalyticalServices.config", "AGI.AnalyticalServices.config.test");
            }

            Assert.Throws<TypeInitializationException>(() => Networking.Init());

            if (File.Exists("AGI.AnalyticalServices.config.test"))
            {
                File.Move("AGI.AnalyticalServices.config.test", "AGI.AnalyticalServices.config");
            }

        }

        [Test]
        public void TestConfigurationFileApiKeyNotPresent()
        {
            StringBuilder configFile = new StringBuilder();
            configFile.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
            configFile.AppendLine("<configuration>");
            configFile.AppendLine("<appSettings>");
            configFile.AppendLine("<add key=\"BaseUrl\" value=\"https://saas.agi.com\"/>");
            configFile.AppendLine("</appSettings>");
            configFile.AppendLine("</configuration>");

            if (File.Exists("AGI.AnalyticalServices.config.test"))
            {
                File.Delete("AGI.AnalyticalServices.config.test");
            }

            if (File.Exists("AGI.AnalyticalServices.config"))
            {
                File.Move("AGI.AnalyticalServices.config", "AGI.AnalyticalServices.config.test");
                File.WriteAllText("AGI.AnalyticalServices.config", configFile.ToString());
            }

            Assert.Throws<TypeInitializationException>(Networking.Init);

            if (File.Exists("AGI.AnalyticalServices.config.test") &&
                File.Exists("AGI.AnalyticalServices.config"))
            {
                File.Delete("AGI.AnalyticalServices.config");
                File.Move("AGI.AnalyticalServices.config.test", "AGI.AnalyticalServices.config");
            }
        }

        [Test]
        public void TestConfigurationFileBaseUrlNotPresent()
        {
            StringBuilder configFile = new StringBuilder();
            configFile.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
            configFile.AppendLine("<configuration>");
            configFile.AppendLine("<appSettings>");
            configFile.AppendLine("<add key=\"ApiKey\" value=\"12345\"/>");
            configFile.AppendLine("</appSettings>");
            configFile.AppendLine("</configuration>");

            if (File.Exists("AGI.AnalyticalServices.config.test"))
            {
                File.Delete("AGI.AnalyticalServices.config.test");
            }

            if (File.Exists("AGI.AnalyticalServices.config"))
            {
                File.Move("AGI.AnalyticalServices.config", "AGI.AnalyticalServices.config.test");
                File.WriteAllText("AGI.AnalyticalServices.config", configFile.ToString());
            }

            Assert.Throws<TypeInitializationException>(() => Networking.Init());

            if (File.Exists("AGI.AnalyticalServices.config.test") &&
                File.Exists("AGI.AnalyticalServices.config"))
            {
                File.Delete("AGI.AnalyticalServices.config");
                File.Move("AGI.AnalyticalServices.config.test", "AGI.AnalyticalServices.config");
            }
        }

        [Test]
        public void TestConfigurationFileNoSettingsPresent()
        {
            StringBuilder configFile = new StringBuilder();
            configFile.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
            configFile.AppendLine("<configuration>");
            configFile.AppendLine("</configuration>");

            if (File.Exists("AGI.AnalyticalServices.config.test"))
            {
                File.Delete("AGI.AnalyticalServices.config.test");
            }

            if (File.Exists("AGI.AnalyticalServices.config"))
            {
                File.Move("AGI.AnalyticalServices.config", "AGI.AnalyticalServices.config.test");
                File.WriteAllText("AGI.AnalyticalServices.config", configFile.ToString());
            }

            Assert.Throws<TypeInitializationException>(() => Networking.Init());

            if (File.Exists("AGI.AnalyticalServices.config.test") &&
                File.Exists("AGI.AnalyticalServices.config"))
            {
                File.Delete("AGI.AnalyticalServices.config");
                File.Move("AGI.AnalyticalServices.config.test", "AGI.AnalyticalServices.config");
            }
        }
    }
}