using System.Text;
using Google.Protobuf;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TopCase.OlivaTaxi.Common.Extensions
{
    public static class JsonExtensions
    {
        public static T FromUtf8BytesJson<T>(this byte[] source)
        {
            return source.FromUtf8Bytes().FromJson<T>();
        }

        public static T FromJson<T>(this string source)
        {
            if (string.IsNullOrWhiteSpace(source))
            {
                return default(T);
            }

            return JsonConvert.DeserializeObject<T>(source);
        }

        public static byte[] ToUtf8BytesJson(this object source)
        {
            return source.ToJson().ToUtf8Bytes();
        }

        public static ByteString ToUtf8ByteStringJson(this object source)
        {
            return ByteString.CopyFrom(source.ToJson(), Encoding.UTF8);
        }

        public static string ToJson(this object source)
        {
            return JsonConvert.SerializeObject(source, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            });
        }
    }
}