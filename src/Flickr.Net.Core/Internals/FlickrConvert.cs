using System.Xml.Linq;
using Flickr.Net.Core.Internals.ContractResolver;
using Flickr.Net.Core.Internals.JsonConverters;

namespace Flickr.Net.Core.Internals;

public static class FlickrConvert
{
    public static T DeserializeObject<T>(JsonTextReader jsonTextReader)
    {
        return Instance.Deserialize<T>(jsonTextReader);
    }

    public static string XmlToJson(string xml)
    {
        var doc = XDocument.Parse(xml);
        return JsonConvert.SerializeXNode(doc, Formatting.None, omitRootObject: true);
    }

    private static JsonSerializer Instance { get; } = new JsonSerializer()
    {
        ContractResolver = GenericJsonPropertyNameContractResolver.Instance,
        Converters =
            {
                BoolConverter.Instance,
                TimestampToDateTimeConverter.Instance
            },
    };
}