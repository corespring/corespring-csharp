using System;
using System.Net;
using System.IO;

namespace Corespring
{
    public interface ICorespringWebService
    {
        Stream processRequest(HttpWebRequest request);
    }
}

