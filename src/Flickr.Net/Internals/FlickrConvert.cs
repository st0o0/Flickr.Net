using System.Text.Json;
using System.Text.Json.Nodes;
using System.Xml.Linq;

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
        return JsonSerializer.Deserialize<T>(bytes, FlickrJsonOptions.Default)!;
    }

    /// <summary>
    /// Deserializes a JSON string into the specified type using the shared <see cref="FlickrJsonOptions"/>.
    /// </summary>
    public static T DeserializeObject<T>(string json)
    {
        return JsonSerializer.Deserialize<T>(json, FlickrJsonOptions.Default)!;
    }

    /// <summary>
    /// Deserializes a stream into the specified type using the shared <see cref="FlickrJsonOptions"/>.
    /// </summary>
    public static async ValueTask<T> DeserializeObjectAsync<T>(Stream stream, CancellationToken cancellationToken = default)
    {
        return (await JsonSerializer.DeserializeAsync<T>(stream, FlickrJsonOptions.Default, cancellationToken).ConfigureAwait(false))!;
    }

    /// <summary>
    /// Converts an XML string to its JSON representation.
    /// </summary>
    public static string XmlToJson(string xml)
    {
        var doc = XDocument.Parse(xml);
        var json = ConvertElement(doc.Root!);
        return json.ToJsonString();
    }

    private static JsonNode ConvertElement(XElement element)
    {
        var obj = new JsonObject();

        foreach (var attr in element.Attributes())
        {
            obj[attr.Name.LocalName] = attr.Value;
        }

        foreach (var group in element.Elements().GroupBy(e => e.Name.LocalName))
        {
            var items = group.ToList();
            if (items.Count == 1)
            {
                var child = items[0];
                if (child.HasElements || child.HasAttributes)
                {
                    obj[group.Key] = ConvertElement(child);
                }
                else
                {
                    obj[group.Key] = child.Value;
                }
            }
            else
            {
                var array = new JsonArray();
                foreach (var child in items)
                {
                    array.Add(child.HasElements || child.HasAttributes
                        ? ConvertElement(child)
                        : JsonValue.Create(child.Value));
                }
                obj[group.Key] = array;
            }
        }

        if (!element.HasElements && !string.IsNullOrEmpty(element.Value) && element.HasAttributes)
        {
            obj["_content"] = element.Value;
        }

        return obj;
    }
}
