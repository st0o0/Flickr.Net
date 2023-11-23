using System.Text.Json;
using System.Text.Json.Serialization;

namespace Flickr.Net.Internals.JsonConverters;

/// <summary>
/// </summary>
public class BoolConverter : JsonConverter<bool>
{
    /// <summary>
    /// </summary>
    public BoolConverter() : base()
    {
    }

    /// <summary>
    /// </summary>
    public static BoolConverter Instance { get; } = new();

    /// <summary>
    /// </summary>
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(bool);
    }

    /// <summary>
    /// </summary>
    public override bool Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        switch (reader.TokenType)
        {
            case JsonTokenType.String:
                return reader.ValueTextEquals("1");

            case JsonTokenType.Number:
                return reader.TryGetInt64(out long l) ?
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

    /// <summary>
    /// </summary>
    public override void Write(Utf8JsonWriter writer, bool value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue(value ? 1 : 0);
    }
}