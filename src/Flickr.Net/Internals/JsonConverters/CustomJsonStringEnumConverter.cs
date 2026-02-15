using System.Reflection;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Flickr.Net.Internals.JsonConverters;

/// <summary>
/// </summary>
/// <remarks>
/// </remarks>
public class CustomJsonStringEnumConverter(JsonNamingPolicy namingPolicy = null, bool allowIntegerValues = true) : JsonConverterFactory
{
    private readonly JsonNamingPolicy namingPolicy = namingPolicy;
    private readonly bool allowIntegerValues = allowIntegerValues;
    private readonly JsonStringEnumConverter baseConverter = new(namingPolicy, allowIntegerValues);

    /// <summary>
    /// </summary>
    public static CustomJsonStringEnumConverter Instance { get; } = new();

    /// <summary>
    /// </summary>
    public override bool CanConvert(Type typeToConvert)
        => baseConverter.CanConvert(typeToConvert);

    /// <summary>
    /// </summary>
    public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        var dictionary = typeToConvert
                    .GetFields(BindingFlags.Public | BindingFlags.Static)
                    .Select(x => (attr: x.GetCustomAttribute<EnumMemberAttribute>(), field: x))
                    .Where(x => x.attr != null)
                    .Select(x => (x.field.Name, x.attr.Value))
                    .ToDictionary(p => p.Name, p => p.Value);

        if (dictionary.Count > 0)
        {
            return new JsonStringEnumConverter(new DictionaryLookupNamingPolicy(dictionary, namingPolicy), allowIntegerValues).CreateConverter(typeToConvert, options);
        }
        else
        {
            return baseConverter.CreateConverter(typeToConvert, options);
        }
    }
}

/// <summary>
/// </summary>
internal class JsonNamingPolicyDecorator(JsonNamingPolicy underlyingNamingPolicy) : JsonNamingPolicy
{
    private readonly JsonNamingPolicy underlyingNamingPolicy = underlyingNamingPolicy;

    /// <summary>
    /// </summary>
    public override string ConvertName(string name) => underlyingNamingPolicy == null ? name : underlyingNamingPolicy.ConvertName(name);
}

internal class DictionaryLookupNamingPolicy(Dictionary<string, string> dictionary, JsonNamingPolicy underlyingNamingPolicy) : JsonNamingPolicyDecorator(underlyingNamingPolicy)
{
    private readonly Dictionary<string, string> dictionary = dictionary ?? throw new ArgumentNullException();

    public override string ConvertName(string name) => dictionary.TryGetValue(name, out var value) ? value : base.ConvertName(name);
}