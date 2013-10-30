using System;
using System.Net;
using NUnit.Framework;
using Moq;
using Corespring.Resources;
using System.IO;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Corespring.Rest.Tests
{
    [TestFixture]
    public class CorespringRestClientTest
    {
        const string clientId = "524c5cb5300401522ab21db1";
        const string clientSecret = "325hm11xiz7ykeen2ibt";

        private Mock<IAccessTokenProvider> mockAccessTokenProvider;
        private Mock<ICorespringWebService> mockWebService = new Mock<ICorespringWebService>();
        private CorespringClient client = new CorespringClient(clientId, clientSecret);

        [SetUp]
        public void Init()
        {
            mockAccessTokenProvider = new Mock<IAccessTokenProvider>();
            mockAccessTokenProvider.Setup(x => x.getAccessToken(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns("access_token");
            client.setAccessTokenProvider(mockAccessTokenProvider.Object);
            client.setCorespringWebService(mockWebService.Object);
        }

        [Test]
        public void testGetOrganizations()
        {
            Stream responseStream = GenerateStreamFromString("[{\"id\":\"51114b307fc1eaa866444648\",\"name\":\"Demo Organization\",\"path\":[\"51114b307fc1eaa866444648\"],\"isRoot\":false}]");
            mockWebService.Setup(x => x.processRequest(It.IsAny<HttpWebRequest>())).Returns(responseStream);

            assertOrganizationsAreCorrect(client.getOrganizations());
        }

        private void assertOrganizationsAreCorrect(List<Organization> organizations)
        {
            Assert.AreEqual(1, organizations.Count);
            Organization organization = organizations[0];
            Assert.AreEqual("Demo Organization", organization.name);
            Assert.AreEqual("51114b307fc1eaa866444648", organization.id);
        }

        private Stream GenerateStreamFromString(string s)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }


}

