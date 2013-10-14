using System;
using System.Runtime.Serialization;

namespace Corespring.Resources
{
    [DataContract]
    public class Error
    {
        [DataMember(Name = "code")]
        public int code { get; set; }

        [DataMember(Name = "message")]
        public string message { get; set; }

        public Error(int code, string message)
        {
            this.code = code;
            this.message = message;
        }
    }
}

