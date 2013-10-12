using System;
using NUnit.Framework;

namespace Corespring.Authentication.Tests
{
    [TestFixture]
    public class AccessTokenProviderTest
    {

        [Test]
        public void test() {
            string clientId = "524c5cb5300401522ab21db1";
            string clientSecret = "325hm11xiz7ykeen2ibt";
            AccessTokenProvider accessTokenProvider = new AccessTokenProvider();
            System.Console.WriteLine(accessTokenProvider.getAccessToken(clientId, clientSecret, "http://www.corespring.org"));
        }

    }
}

