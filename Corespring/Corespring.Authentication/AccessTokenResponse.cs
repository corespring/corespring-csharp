using System;
using System.Runtime.Serialization;

namespace Corespring.Authentication
{
    [DataContract]
    public class AccessTokenResponse
    {
        [DataMember(Name = "access_token")]
        public string accessToken { get; set; }

        public AccessTokenResponse(string accessToken)
        {
            this.accessToken = accessToken;
        }

        public override string ToString()
        {
            return accessToken;
        }
    }
}

