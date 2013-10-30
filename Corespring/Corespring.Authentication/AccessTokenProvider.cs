using System;
using System.Net;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Json;

namespace Corespring.Authentication
{
    /**
     * A utility class whose getAccessToken method calls the CoreSpring platform with a
     * specified client id and client secret, returning an access token.
     * 
     * Note: You will be issued a client id and client secret when you sign up for a developer account at
     * http://www.corespring.org/signup
     */
    public class AccessTokenProvider : IAccessTokenProvider
    {
        private const string accessTokenRoute = "/auth/access_token";

        public AccessTokenProvider()
        {
        }

        public string getAccessToken(string clientId, string clientSecret, string baseUrl)
        {
            AccessTokenRequest accessTokenRequest = new AccessTokenRequest(clientId, clientSecret);

            ASCIIEncoding encoding = new ASCIIEncoding();

            MemoryStream stream = new MemoryStream();
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(AccessTokenRequest));
            serializer.WriteObject(stream, accessTokenRequest);

            stream.Position = 0;
            StreamReader streamReader = new StreamReader(stream);

            byte[] data = encoding.GetBytes(streamReader.ReadToEnd());
            stream.Close();

            HttpWebRequest post =
                (HttpWebRequest)WebRequest.Create(baseUrl + accessTokenRoute);

            post.Method = "POST";
            post.ContentType = "application/json";
            post.ContentLength = data.Length;

            using (Stream httpStream = post.GetRequestStream())
            {
                httpStream.Write(data, 0, data.Length);
            }

            HttpWebResponse response = (HttpWebResponse)post.GetResponse();
            string responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(AccessTokenResponse));
            MemoryStream responseStream = new MemoryStream(Encoding.UTF8.GetBytes(responseString));
            AccessTokenResponse accessTokenResponse = (AccessTokenResponse)deserializer.ReadObject(responseStream);
            stream.Close();

            return accessTokenResponse.ToString();
        }
    }
}

