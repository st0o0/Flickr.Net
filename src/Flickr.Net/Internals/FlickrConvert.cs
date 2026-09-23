using System.Text.Json;
using System.Xml.Linq;
using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Flickr.Net.Internals;

/// <summary>
/// Handles deserialization of Flickr API responses and XML-to-JSON conversion.
/// </summary>
public static class FlickrConvert
{
    /// <summary>
    /// Deserializes a byte array into the specified type using the shared <see cref="FlickrJsonOptions"/>.
    /// </summary>
    public static T DeserializeObject<T>(byte[] bytes)
    {
        return JsonSerializer.Deserialize<T>(bytes, FlickrJsonOptions.Default);
    }

    /// <summary>
    /// Converts an XML string to its JSON representation.
    /// </summary>
    public static string XmlToJson(string xml)
    {
        var doc = XDocument.Parse(xml);
        return JsonConvert.SerializeXNode(doc, Formatting.None, omitRootObject: true);
    }
}
