using System.Text.Json;

namespace Flickr.Net.Core.Internals.JsonConverters;

/// <summary>
/// </summary>
public class BoolConverter : System.Text.Json.Serialization.JsonConverter<bool>
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
        return reader.TokenType switch
        {
            JsonTokenType.String => reader.ValueTextEquals("1"),
            JsonTokenType.Number => reader.TryGetInt64(out var l) ?
                            l == 1 :
                            reader.GetDouble() == 1d,
            JsonTokenType.True => true,
            JsonTokenType.False => false,
            _ => throw new InvalidOperationException("Can only convert number or string to boolean"),
        };

    }

    /// <summary>
    /// </summary>
    public override void Write(Utf8JsonWriter writer, bool value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue(value ? 1 : 0);
    }
}