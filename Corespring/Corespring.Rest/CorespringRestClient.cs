using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using Corespring.Resources;
using Corespring.Authentication;
using System.Collections.Specialized;
using System.Text;

namespace Corespring.Rest
{
    /**
     * Contains the REST details of the interface with the CoresSpring platform.
     */
    public class CorespringRestClient
    {
        private const string apiVersion = "api/v1";
        private const string version = "0.1";

        private string clientId;
        private string clientSecret;

        private const string accessTokenKey = "access_token";

        private string endpoint = "http://www.corespring.org";

        private string accessToken;
        private AccessTokenProvider accessTokenProvider = new AccessTokenProvider();

        public CorespringRestClient(string clientId, string clientSecret)
        {
            this.clientId = clientId;
            this.clientSecret = clientSecret;
        }

        private string getAccessToken()
        {
            if (this.accessToken == null) {
                this.accessToken = getAccessTokenProvider().getAccessToken(clientId, clientSecret, getEndpoint());
            }

            return this.accessToken;
        }

        protected CorespringRestResponse get(String path)
        {
            return doRequest(path, "GET", new NameValueCollection(), null);
        }

        private CorespringRestResponse doRequest(string path, string method, NameValueCollection paramList, CorespringResource entity)
        {
            if (getAccessToken() != null) {
                paramList[accessTokenKey] = getAccessToken();
            }
            HttpWebRequest request = setupRequest(path, method, paramList, entity);
            return tryRequest(request);
        }

        private CorespringRestResponse tryRequest(HttpWebRequest request)
        {
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return new CorespringRestResponse(request.RequestUri.ToString(), responseString, 200);
        }

        private HttpWebRequest setupRequest(string path, string method, NameValueCollection parameters, CorespringResource entity)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(path + "?" + asQueryString(parameters));
            request.UserAgent = "corespring-csharp/" + version;
            request.Accept = "application/json";
            request.Headers.Add("Accept-Charset", "utf-8");

            if ((method.Equals("PUT", StringComparison.OrdinalIgnoreCase)) || (method.Equals("POST", StringComparison.OrdinalIgnoreCase))) {
                request.ContentType = "application/json";
            }

            return request;
        }

        /**
         * This should *really* just use System.Net.HttpUtility#UrlEncode, but after asking Mono to let me use it for about an hour,
         * I gave up. Sorry.
         */
        private string asQueryString(NameValueCollection parameters)
        {
            StringBuilder queryBuilder = new StringBuilder();
            for (int i = 0; i < parameters.AllKeys.Length; i++) {
                string key = parameters.AllKeys[i];
                queryBuilder.Append(string.Format("{0}={1}", key, parameters.Get(key)));
                if (i != parameters.AllKeys.Length - 1) {
                    queryBuilder.Append("&");
                }
            }
            return queryBuilder.ToString();
        }

        private AccessTokenProvider getAccessTokenProvider()
        {
            return accessTokenProvider;
        }

        public string baseUrl()
        {
            return getEndpoint() + "/" + apiVersion + "/";
        }

        private string getEndpoint()
        {
            return endpoint;
        }
    }
}

