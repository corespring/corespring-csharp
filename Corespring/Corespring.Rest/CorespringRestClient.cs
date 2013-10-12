using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using Corespring.Resources;

namespace Corespring.Rest
{
    public class CorespringRestClient
    {
        private const string apiVersion = "api/v1";
        private const string version = "0.1";

        public CorespringRestClient(string clientId, string clientSecret)
        {

        }

        public ICollection<Organization> getOrganizations()
        {
            return null;
        }
    }
}

