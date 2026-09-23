using System.Reflection;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Flickr.Net.Internals.JsonConverters;
/// <summary>Enum converter that respects <see cref="System.Runtime.Serialization.EnumMemberAttribute"/> values.</summary>
public class CustomJsonStringEnumConverter(JsonNamingPolicy? namingPolicy = null, bool allowIntegerValues = true) : JsonConverterFactory
{
    private readonly JsonNamingPolicy? namingPolicy = namingPolicy;
    private readonly bool allowIntegerValues = allowIntegerValues;
    private readonly JsonStringEnumConverter baseConverter = new(namingPolicy, allowIntegerValues);
    /// <summary>Gets the singleton instance.</summary>
    public static CustomJsonStringEnumConverter Instance { get; } = new();
    public override bool CanConvert(Type typeToConvert)
        => baseConverter.CanConvert(typeToConvert);
    public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        var dictionary = typeToConvert
                    .GetFields(BindingFlags.Public | BindingFlags.Static)
                    .Select(x => (attr: x.GetCustomAttribute<EnumMemberAttribute>(), field: x))
                    .Where(x => x.attr != null && !string.IsNullOrEmpty(x.attr!.Value))
                    .Select(x => (x.field.Name, Value: x.attr!.Value!))
                    .ToDictionary(p => p.Name, p => p.Value);

        if (dictionary.Count > 0)
        {
            return new JsonStringEnumConverter(new DictionaryLookupNamingPolicy(dictionary, namingPolicy), allowIntegerValues).CreateConverter(typeToConvert, options);
        }

        return baseConverter.CreateConverter(typeToConvert, options);
    }
}
internal class JsonNamingPolicyDecorator(JsonNamingPolicy? underlyingNamingPolicy) : JsonNamingPolicy
{
    private readonly JsonNamingPolicy? underlyingNamingPolicy = underlyingNamingPolicy;
    public override string ConvertName(string name) => underlyingNamingPolicy == null ? name : underlyingNamingPolicy.ConvertName(name);
}

internal class DictionaryLookupNamingPolicy(Dictionary<string, string> dictionary, JsonNamingPolicy? underlyingNamingPolicy) : JsonNamingPolicyDecorator(underlyingNamingPolicy)
{
    private readonly Dictionary<string, string> dictionary = dictionary ?? throw new ArgumentNullException();

    public override string ConvertName(string name) => dictionary.TryGetValue(name, out var value) ? value : base.ConvertName(name);
}
