using System;
using System.Runtime.Serialization;

namespace Corespring.Authentication
{
    /**
     * Represents a request to the CoreSpring API to generate an authentication token for signing subsequent requests to the
     * CoreSpring API.
     */
    [DataContract]
    public class AccessTokenRequest
    {

        [DataMember(Name = "client_id")]
        private string clientId { get; set; }

        [DataMember(Name = "client_secret")]
        private string clientSecret { get; set; }

        public AccessTokenRequest(string clientId, string clientSecret)
        {
            this.clientId = clientId;
            this.clientSecret = clientSecret;
        }

    }
}

