using System.Text.Json;

namespace Flickr.Net.Core.Internals.JsonConverters;
public class AutoNumberToStringConverter : System.Text.Json.Serialization.JsonConverter<string>
{
    public AutoNumberToStringConverter() : base() { }
    public static AutoNumberToStringConverter Instance { get; } = new();
    public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Number)
        {
            var value = reader.TryGetInt64(out long l) ?
                l :
                reader.GetDouble();
            return value.ToString();
        }
        return reader.GetString();
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
            throw new Exception($"unable to parse {value} to number");
        }
    }
}