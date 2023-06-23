using Flickr.Net.Core.Internals.ContractResolver;
using Flickr.Net.Core.Internals.JsonConverters;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Flickr.Net.Core.Internals;

public static class FlickrConvert
{
    public static T DeserializeObject<T>(string json)
    {
        var settings = new JsonSerializerSettings()
        {
            ContractResolver = new GenericJsonPropertyNameContractResolver(),
            Converters = new List<JsonConverter>() { new BoolConverter(), new TimestampToDateTimeConverter() },
        };

        return JsonConvert.DeserializeObject<T>(json, settings);
    }
}