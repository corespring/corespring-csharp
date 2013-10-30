using System;

namespace Corespring
{
    public interface IAccessTokenProvider
    {
        string getAccessToken(string clientId, string clientSecret, string baseUrl);
    }
}

