using System.Text.Json;
using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core.Internals.JsonConverters.IdentifierConverters;

public class IdConverter : System.Text.Json.Serialization.JsonConverter<Id>
{
    public IdConverter() : base() { }

    public static IdConverter Instance { get; } = new();
    public override Id Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return reader.GetString();
    }

    public override void Write(Utf8JsonWriter writer, Id value, JsonSerializerOptions options)
    {
        writer.WriteRawValue((string)value);
    }
}