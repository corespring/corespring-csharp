using System;
using NUnit.Framework;

namespace Corespring.Authentication.Tests
{
    [TestFixture]
    public class AccessTokenProviderTest
    {

        [Test]
        public void test() {
            string clientId = "???";
            string clientSecret = "???";
            AccessTokenProvider accessTokenProvider = new AccessTokenProvider();
            System.Console.WriteLine(accessTokenProvider.getAccessToken(clientId, clientSecret, "http://www.corespring.org"));
        }

    }
}

