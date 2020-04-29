using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Eiip.Api.Common.Extensions
{
    public static class JsonExtensions
    {
        public static T FromJson<T>(this string source)
        {
            if (string.IsNullOrWhiteSpace(source))
            {
                return default(T);
            }

            return JsonConvert.DeserializeObject<T>(source);
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