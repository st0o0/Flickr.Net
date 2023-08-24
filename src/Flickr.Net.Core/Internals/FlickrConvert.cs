using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using System.Xml.Linq;
using Flickr.Net.Core.Internals.Attributes;
using Flickr.Net.Core.Internals.ContractResolver;
using Flickr.Net.Core.Internals.JsonConverters;

namespace Flickr.Net.Core.Internals;

public static class FlickrConvert
{
    public static T DeserializeObject<T>(Utf8JsonReader jsonTextReader)
    {
        var options = new JsonSerializerOptions()
        {
            TypeInfoResolver = DefaultJsonTypeInfoResolver.WithAddedModifier(static typeInfo =>
            {
                JsonTypeInfo typeInfo2 = new JsonTypeInfo(); //TOOD: delete when extension method is recognized; then change all references tp typeInfo

                foreach (JsonPropertyInfo property in typeInfo.Properties)
                {
                    var attributes = property.AttributeProvider.GetCustomAttributes(typeof(JsonPropertyGenericTypeNameAttribute), false);
                    if (attributes.Length != 0 && attributes is JsonPropertyGenericTypeNameAttribute[] jsonAttributes)
                    {
                        if(jsonAttributes.Length > 1)
                        {
                            //TODO: what to do then?
                            throw new InvalidOperationException($"Property can't have more than one {typeof(JsonPropertyGenericTypeNameAttribute)}");
                        }
                        JsonPropertyGenericTypeNameAttribute attr = jsonAttributes[0];
                        Type type = typeInfo2.Type; //TODO: does this get the correct type? 
                        if (!type.IsGenericType)
                        {
                            throw new InvalidOperationException($"{type} is not a generic type");
                        }
                        if (type.IsGenericTypeDefinition)
                        {
                            throw new InvalidOperationException($"{type} is a generic type definition, it must be a constructed generic type");
                        }

                        Type[] typeArgs = type.GetGenericArguments();
                        if(attr.TypeParameterPosition >= typeArgs.Length)
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
                }
            })
        };

        options.Converters.Add(BoolConverter.Instance);
        options.Converters.Add(TimestampToDateTimeConverter.Instance);

        return System.Text.Json.JsonSerializer.Deserialize<T>(ref jsonTextReader, options);
    }

    public static string XmlToJson(string xml)
    {
        var doc = XDocument.Parse(xml);
        return JsonConvert.SerializeXNode(doc, Formatting.None, omitRootObject: true);
    }
}