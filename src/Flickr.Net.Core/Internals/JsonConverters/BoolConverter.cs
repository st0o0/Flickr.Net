using System.Text.Json;

namespace Flickr.Net.Core.Internals.JsonConverters;

/// <summary>
/// </summary>
public class BoolConverter : System.Text.Json.Serialization.JsonConverter<bool>
{
    public BoolConverter() : base()
    {
    }

    public static BoolConverter Instance { get; } = new();

    /// <summary>
    /// </summary>
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(bool);
    }

    /// <summary>
    /// </summary>
    public override bool Read(ref System.Text.Json.Utf8JsonReader reader, Type typeToConvert, System.Text.Json.JsonSerializerOptions options)
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
    public override void Write(System.Text.Json.Utf8JsonWriter writer, bool value, System.Text.Json.JsonSerializerOptions options)
    {
        writer.WriteNumberValue(value ? 1 : 0);
    }
}