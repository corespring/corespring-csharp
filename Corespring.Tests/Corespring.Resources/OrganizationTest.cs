using System;
using System.IO;
using System.Runtime.Serialization.Json;
using Corespring.Resources;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text;

namespace Corespring.Resources.Tests
{
    [TestFixture]
    public class OrganizationTest
    {
        [Test]
        public void testOrganizationSerialization()
        {
            Organization organization = new Organization("id", "name", new List<string>(), false);
            MemoryStream stream = new MemoryStream();
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Organization));
            serializer.WriteObject(stream, organization);

            stream.Position = 0;
            StreamReader streamReader = new StreamReader(stream);
            Assert.AreEqual("{\"id\":\"id\",\"isRoot\":false,\"name\":\"name\",\"path\":[]}", streamReader.ReadToEnd());
            stream.Close();
        }

        [Test]
        public void testOrganizationDeserialization()
        {
            string json = "{\"id\":\"id\",\"isRoot\":false,\"name\":\"name\",\"path\":[]}";
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Organization));
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(json));
            Organization fromJson = (Organization)serializer.ReadObject(stream);
            stream.Close();

            Organization organization = new Organization("id", "name", new List<string>(), false);

            Assert.AreEqual(organization.id, fromJson.id);
            Assert.AreEqual(organization.name, fromJson.name);
            Assert.AreEqual(organization.root, fromJson.root);
        }
    }
}