using System;
using NUnit.Framework;
using Corespring.Resources;

namespace Corespring.Rest.Tests
{
    [TestFixture]
    public class CorespringRestClientTest
    {
        [Test]
        public void testGetOrganizations()
        {
            string clientId = "???";
            string clientSecret = "???";
            CorespringClient client = new CorespringClient(clientId, clientSecret);
            foreach (Organization organization in client.getOrganizations()) {
                System.Console.WriteLine(organization.name);
            }
        }
    }
}

