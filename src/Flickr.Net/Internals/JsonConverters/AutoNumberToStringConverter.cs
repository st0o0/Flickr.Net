using System.Text.Json;
using System.Text.Json.Serialization;

namespace Flickr.Net.Internals.JsonConverters;
/// <summary>Converts JSON numbers to string values during deserialization.</summary>
public sealed class AutoNumberToStringConverter : JsonConverter<string>
{    public static AutoNumberToStringConverter Instance { get; } = new();
    public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.Number) return reader.GetString()!;
        var value = reader.TryGetInt64(out var l) ? l : reader.GetDouble();
        return value.ToString();
    }
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
            throw new JsonException($"unable to parse {value} to number");
        }
    }
}
