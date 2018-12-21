using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AGI.AnalyticalServices.Util
{
    public class Networking
    {
        private static HttpClient _client;

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
    }
}
