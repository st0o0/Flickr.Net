using System.Text.Json;
using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core.Internals.JsonConverters.IdentifierConverters;

public class PhotosetIdConverter : System.Text.Json.Serialization.JsonConverter<PhotosetId>
{
    public override PhotosetId Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return reader.GetString();
    }

    public override void Write(Utf8JsonWriter writer, PhotosetId value, JsonSerializerOptions options)
    {
        writer.WriteRawValue((string)value);
    }
}