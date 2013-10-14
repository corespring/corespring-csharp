using System;
using System.Runtime.Serialization.Json;
using Corespring.Resources;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace Corespring.Rest
{
    public class CorespringRestResponse
    {
        private string responseText;
        public readonly int httpStatus;
        public readonly string url;

        public CorespringRestResponse(string url, string text, int status)
        {
            Error error;
            if (status > 400) {
                try {
                    DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Error));
                    MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(text));
                    error = (Error)serializer.ReadObject(stream);
                    stream.Close();
                }
                catch (Exception) {
                    throw new CorespringRestException(text);
                }
                throw new CorespringRestException(error);
            }
            this.url = url;
            this.responseText = text;
            this.httpStatus = status;
        }
        
        public T Get<T>() {
            DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(T));
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(this.responseText));
            T fromJson = (T)deserializer.ReadObject(stream);
            stream.Close();
            return fromJson;
        }

        public ICollection<T> GetAll<T>() {
            DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(List<T>));
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(this.responseText));
            ICollection<T> fromJson = (List<T>)deserializer.ReadObject(stream);
            stream.Close();
            return fromJson;
        }
    }

}

