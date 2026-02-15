using System.Text.Json;
using System.Text.Json.Serialization;

namespace Flickr.Net.Internals.JsonConverters;

/// <summary>
/// </summary>
public class AutoNumberToStringConverter : JsonConverter<string>
{
    /// <summary>
    /// </summary>
    public static AutoNumberToStringConverter Instance { get; } = new();

    /// <summary>
    /// </summary>
    public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.Number) return reader.GetString()!;
        var value = reader.TryGetInt64(out var l) ? l : reader.GetDouble();
        return value.ToString();
    }

    /// <summary>
    /// </summary>
    public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
    {
        if (int.TryParse(value, out var i))
        {
            writer.WriteNumberValue(i);
        }
        else if (double.TryParse(value, out var d))
        {
            writer.WriteNumberValue(d);
        }
        else
        {
            throw new Exception($"unable to parse {value} to number");
        }
    }
}