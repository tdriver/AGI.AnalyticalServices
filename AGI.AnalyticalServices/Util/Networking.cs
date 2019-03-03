﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AGI.AnalyticalServices.Util
{
    /// <summary>
    /// Utilities to help create the service call.
    /// </summary>
    public static class Networking
    {
        private static HttpClient _client;
        public static string ApiKey { get; set; }
        public static Uri BaseUri { get; set; }

        static Networking()
        {
            Init();
        }

        /// A method that posts <T> Json data to a Uri and returns <R> result or throws with http error code.
        /// <summary>
        /// Posts data of type T to a web service defined by address.  The web service returns data defined by R.
        /// </summary>
        /// <typeparam name="T">Type of data to post to the web service</typeparam>
        /// <typeparam name="R">Type of data returned by the web service</typeparam>
        /// <param name="address">The Uri of the web service, including all query parameters</param>
        /// <param name="postData">The post data to provide to the web service.</param>
        /// <exception cref="WebException">Thrown if response code is anything other than OK.</exception>
        /// <returns>Result from the Web service, as R.</returns>
        public static async Task<R> HttpPostCall<T, R>(Uri address, T postData)
        {
            if (_client == null)
            {
                _client = new HttpClient();
                _client.DefaultRequestHeaders.Accept.Clear();
                _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }

            var postDataS = JsonConvert.SerializeObject(postData);
            HttpContent postContent = new StringContent(postDataS,Encoding.UTF8,"application/json");

            var response = await _client.PostAsync(address, postContent);
            if (!response.IsSuccessStatusCode) throw new WebException("Error code: " + response.StatusCode);

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<R>(jsonResponse);
            return result;

        }

        /// <summary>
        /// Initializes the apikey and base url from the config file.abstract  If there are issues with
        ///  the config file, a TypeInitializationException will be thrown, with the InnerException
        ///  describing the problem.
        /// </summary>
         public static void Init()
        {

            var efm = new ExeConfigurationFileMap { ExeConfigFilename = "AGI.AnalyticalServices.config" };
            var configuration = ConfigurationManager.OpenMappedExeConfiguration(efm, ConfigurationUserLevel.None);
            AppSettingsSection asc = (AppSettingsSection)configuration.GetSection("appSettings");
            if (asc.Settings.Count == 0)
            {
                throw new ConfigurationErrorsException("The configuration file is missing or empty.");
            }
            ApiKey = asc.Settings["ApiKey"].Value;
            if (string.IsNullOrEmpty(ApiKey))
            {
                throw new ConfigurationErrorsException("The ApiKey is not defined in the configuration file.");
            }
            var url = asc.Settings["BaseUrl"].Value;
            if (string.IsNullOrEmpty(url))
            {
                throw new ConfigurationErrorsException("The BaseUrl is not defined in the configuration file.");
            }
            BaseUri = new Uri(url);            
        }

        public static Uri GetFullUri(string relativeUri) => new Uri(BaseUri, relativeUri + "?u=" + ApiKey);
    }
}