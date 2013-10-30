using System;
using Corespring.Rest;
using Corespring.Resources;
using System.Collections.Generic;

namespace Corespring
{
    public class CorespringClient : CorespringRestClient
    {
        public CorespringClient(string clientId, string clientSecret) : base(clientId, clientSecret)
        {
        }

        public List<Organization> getOrganizations()
        {
            CorespringRestResponse response = base.get(Organization.getResourceRoute(this));
            return response.GetAll<Organization>();
        }

    }
}

