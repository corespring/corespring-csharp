using System;
using Corespring.Rest;
using System.Collections.Generic;
using Corespring.Resources;

namespace Corespring
{
    public class CorespringClient : CorespringRestClient
    {
        public CorespringClient(string clientId, string clientSecret) : base(clientId, clientSecret)
        {
        }

        public ICollection<Organization> getOrganizations()
        {
            CorespringRestResponse response = base.get(Organization.getResourceRoute(this));
            return response.GetAll<Organization>();
        }

    }
}

