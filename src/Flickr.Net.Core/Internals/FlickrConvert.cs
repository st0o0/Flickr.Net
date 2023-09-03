using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using System.Xml.Linq;
using Flickr.Net.Core.Internals.Attributes;
using Flickr.Net.Core.Internals.JsonConverters;
using Flickr.Net.Core.Internals.JsonConverters.IdentifierConverters;

namespace Flickr.Net.Core.Internals;

/// <summary>
/// </summary>
public static class FlickrConvert
{
    /// <summary>
    /// </summary>
    public static T DeserializeObject<T>(Stream jsonTextStream)
    {
        return JsonSerializer.Deserialize<T>(jsonTextStream, Options);
    }

    /// <summary>
    /// </summary>
    public static string XmlToJson(string xml) => JsonSerializer.Serialize(GetXmlData(XElement.Parse(xml)).First().Value);

    private static Dictionary<string, object> GetXmlData(XElement xml)
    {
        var attr = xml.Attributes().ToDictionary(d => $"@{d.Name.LocalName}", d => (object)d.Value);
        if (xml.HasElements)
        {
            xml.Elements().Select(e => GetXmlData(e)).ToList().ForEach(e => attr.Add(e.First().Key, e.First().Value));
        }
        else if (!xml.IsEmpty) attr.Add("_content", xml.Value);

        return new Dictionary<string, object> { { xml.Name.LocalName, attr } };
    }

    /// <summary>
    /// </summary>
    private static JsonSerializerOptions Options => new()
    {
        AllowTrailingCommas = true,
        Converters =
                {
                    CustomJsonStringEnumConverter.Instance,
                    AutoStringToNumberConverter.Instance,
                    AutoNumberToStringConverter.Instance,
                    BoolConverter.Instance,
                    TimestampToDateTimeConverter.Instance,
                    IdentifierTypeConverter.Instance
                },
        TypeInfoResolver = new DefaultJsonTypeInfoResolver().WithAddedModifier(static typeInfo =>
        {
            foreach (var property in typeInfo.Properties)
            {
                property.Name = property.Name.ToLowerInvariant();
                var attributes = property.AttributeProvider.GetCustomAttributes(typeof(JsonPropertyGenericTypeNameAttribute), false);
                if (attributes.Length != 0 && attributes is JsonPropertyGenericTypeNameAttribute[] jsonAttributes)
                {
                    if (jsonAttributes.Length > 1)
                    {
                        throw new InvalidOperationException($"Property can't have more than one {typeof(JsonPropertyGenericTypeNameAttribute)}");
                    }

                    var attr = jsonAttributes[0];
                    if (property.AttributeProvider is PropertyInfo pi)
                    {
                        var type = pi.DeclaringType;
                        if (!type.IsGenericType)
                        {
                            throw new InvalidOperationException($"{type} is not a generic type");
                        }

                        if (type.IsGenericTypeDefinition)
                        {
                            throw new InvalidOperationException($"{type} is a generic type definition, it must be a constructed generic type");
                        }

                        var typeArgs = type.GetGenericArguments();
                        if (attr.TypeParameterPosition >= typeArgs.Length)
                        {
                            throw new ArgumentException($"Can't get type argument at position {attr.TypeParameterPosition}; {type} has only {typeArgs.Length} type arguments");
                        }

                        if (typeArgs[attr.TypeParameterPosition].IsDefined(typeof(FlickrJsonPropertyNameAttribute), true))
                        {
                            property.Name = typeArgs[attr.TypeParameterPosition].GetCustomAttribute<FlickrJsonPropertyNameAttribute>().Name;
                        }
                        else
                        {
                            property.Name = typeArgs[attr.TypeParameterPosition].Name.ToLower();
                        }
                    }
                    else
                    {
                        throw new InvalidOperationException($"Cannot determine declaring type for {property}");
                    }
                }
            }
        })
    };
}