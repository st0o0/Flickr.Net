using System.Text.Json;
using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core.Internals.JsonConverters.IdentifierConverters;

public class NsIdConverter : System.Text.Json.Serialization.JsonConverter<NsId>
{
    public NsIdConverter() : base()
    {
    }

    public static NsIdConverter Instance { get; } = new();

    public override NsId Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return reader.GetString();
    }

    public override void Write(Utf8JsonWriter writer, NsId value, JsonSerializerOptions options)
    {
        writer.WriteRawValue((string)value);
    }
}