using System;
using System.Net;
using System.IO;

namespace Corespring
{
    public class CorespringWebService : ICorespringWebService
    {
        public Stream processRequest(HttpWebRequest request)
        {
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            return response.GetResponseStream();
        }
    }
}

