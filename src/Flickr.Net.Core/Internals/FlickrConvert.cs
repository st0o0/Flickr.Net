using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using System.Xml.Linq;
using Flickr.Net.Core.Internals.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
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
        return System.Text.Json.JsonSerializer.Deserialize<T>(jsonTextStream, Options);
    }

    /// <summary>
    /// </summary>
    public static string XmlToJson(string xml)
    {
        var doc = XDocument.Parse(xml);
        return JsonConvert.SerializeXNode(doc, Formatting.None, omitRootObject: true);
    }

    /// <summary>
    /// </summary>
    private static JsonSerializerOptions Options
    {
        get
        {
            var options = new JsonSerializerOptions()
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
                    foreach (JsonPropertyInfo property in typeInfo.Properties)
                    {
                        property.Name = property.Name.ToLowerInvariant();
                        var attributes = property.AttributeProvider.GetCustomAttributes(typeof(JsonPropertyGenericTypeNameAttribute), false);
                        if (attributes.Length != 0 && attributes is JsonPropertyGenericTypeNameAttribute[] jsonAttributes)
                        {
                            if (jsonAttributes.Length > 1)
                            {
                                throw new InvalidOperationException($"Property can't have more than one {typeof(JsonPropertyGenericTypeNameAttribute)}");
                            }
                            JsonPropertyGenericTypeNameAttribute attr = jsonAttributes[0];
                            if (property.AttributeProvider is PropertyInfo pi)
                            {
                                Type type = pi.DeclaringType;
                                if (!type.IsGenericType)
                                {
                                    throw new InvalidOperationException($"{type} is not a generic type");
                                }
                                if (type.IsGenericTypeDefinition)
                                {
                                    throw new InvalidOperationException($"{type} is a generic type definition, it must be a constructed generic type");
                                }

                                Type[] typeArgs = type.GetGenericArguments();
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

            return options;
        }
    }
}