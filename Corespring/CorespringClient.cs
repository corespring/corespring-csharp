using System;
using Corespring.Rest;
using Corespring.Resources;
using System.Collections.Generic;

namespace Corespring
{
    /**
     * CorespringClient serves as the main interface between the API and the CoreSpring platform. You should
     * instantiate CorespringClient with your client ID and client secret (which you will be issued when you sign up as
     * a developer for the CoreSpring platform):
     *
     *     String clientId = "524c5cb5300401522ab21db1";
     *     String clientSecret = "325hm11xiz7ykeen2ibt";
     *     CorespringClient client = new CorespringClient(clientId, clientSecret);
     *
     * You can then use the client object to interface with the various methods made available.
     */
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

