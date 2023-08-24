using System.Text.Json;
using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core.Internals.JsonConverters.IdentifierConverters;

public class PhotoIdConverter : System.Text.Json.Serialization.JsonConverter<PhotoId>
{
    public override PhotoId Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return reader.GetString();
    }

    public override void Write(Utf8JsonWriter writer, PhotoId value, JsonSerializerOptions options)
    {
        writer.WriteRawValue((string)value);
    }
}