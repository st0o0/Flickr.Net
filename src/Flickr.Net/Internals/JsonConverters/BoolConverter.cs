using System.Text.Json;
using System.Text.Json.Serialization;

namespace Flickr.Net.Internals.JsonConverters;
/// <summary>Converts Flickr's numeric boolean values (0/1) to <see langword="bool"/>.</summary>
public sealed class BoolConverter : JsonConverter<bool>
{
    /// <summary>Gets the singleton instance.</summary>
    public static BoolConverter Instance { get; } = new();
    public override bool Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        switch (reader.TokenType)
        {
            case JsonTokenType.String:
                return reader.ValueTextEquals("1");

            case JsonTokenType.Number:
                return reader.TryGetInt64(out var l) ?
                l == 1 :
                reader.GetDouble() == 1d;

            case JsonTokenType.True:
                return true;
            case JsonTokenType.False:
                return false;

            default:
                throw new InvalidOperationException("Can only convert number or string to boolean");
        }
    }
    public override void Write(Utf8JsonWriter writer, bool value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue(value ? 1 : 0);
    }
}
