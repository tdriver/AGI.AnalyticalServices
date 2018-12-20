using System;
using System.Configuration;
using NUnit.Framework;

namespace AGI.AnalyticalServices.Tests
{
    public abstract class TestBase
    {
        public string ApiKey { get; set; }
        public Uri BaseUri { get; set; }

        [OneTimeSetUp]
        public void Init()
        {
            try
            {
                var efm = new ExeConfigurationFileMap { ExeConfigFilename = "AGI.AnalyticalServices.config" };
                var configuration = ConfigurationManager.OpenMappedExeConfiguration(efm, ConfigurationUserLevel.None);
                AppSettingsSection asc = (AppSettingsSection)configuration.GetSection("appSettings");
                ApiKey = asc.Settings["ApiKey"].Value;
                if (string.IsNullOrEmpty(ApiKey))
                {
                    throw new ArgumentNullException("The ApiKey is not defined in the configuration file.");
                }
                var url = asc.Settings["BaseUrl"].Value;
                if (string.IsNullOrEmpty(url))
                {
                    throw new ArgumentNullException("The BaseUrl is not defined in the configuration file.");
                }
                BaseUri = new Uri(url);
            }catch(Exception e){
                throw new ConfigurationErrorsException("There is an error with the configuration file: " + e.Message);
            }
        }

        public Uri GetFullUri(string relativeUri) => new Uri(BaseUri, relativeUri + "?u=" + ApiKey);
    }
}