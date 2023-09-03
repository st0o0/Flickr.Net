using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Flickr.Net.Core.Internals.JsonConverters;

public class CustomJsonStringEnumConverter : JsonConverterFactory
{
    private readonly JsonNamingPolicy namingPolicy;
    private readonly bool allowIntegerValues;
    private readonly JsonStringEnumConverter baseConverter;

    public CustomJsonStringEnumConverter(JsonNamingPolicy namingPolicy = null, bool allowIntegerValues = true)
    {
        this.namingPolicy = namingPolicy;
        this.allowIntegerValues = allowIntegerValues;
        this.baseConverter = new JsonStringEnumConverter(namingPolicy, allowIntegerValues);
    }

    public static CustomJsonStringEnumConverter Instance { get; } = new();

    public override bool CanConvert(Type typeToConvert)
    {
        return baseConverter.CanConvert(typeToConvert);
    }

    public override System.Text.Json.Serialization.JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        var dictionary = typeToConvert
                    .GetFields(BindingFlags.Public | BindingFlags.Static)
                    .Select(x => (attr:x.GetCustomAttribute<EnumMemberAttribute>(), field:x))
                    .Where(x => x.attr != null)
                    .Select(x => (x.field.Name, x.attr.Value))
                    .ToDictionary(p => p.Item1, p => p.Item2);

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

public class JsonNamingPolicyDecorator : JsonNamingPolicy
{
    private readonly JsonNamingPolicy underlyingNamingPolicy;

    public JsonNamingPolicyDecorator(JsonNamingPolicy underlyingNamingPolicy) => this.underlyingNamingPolicy = underlyingNamingPolicy;

    public override string ConvertName(string name) => underlyingNamingPolicy == null ? name : underlyingNamingPolicy.ConvertName(name);
}

internal class DictionaryLookupNamingPolicy : JsonNamingPolicyDecorator
{
    private readonly Dictionary<string, string> dictionary;

    public DictionaryLookupNamingPolicy(Dictionary<string, string> dictionary, JsonNamingPolicy underlyingNamingPolicy) : base(underlyingNamingPolicy) => this.dictionary = dictionary ?? throw new ArgumentNullException();

    public override string ConvertName(string name) => dictionary.TryGetValue(name, out var value) ? value : base.ConvertName(name);
}