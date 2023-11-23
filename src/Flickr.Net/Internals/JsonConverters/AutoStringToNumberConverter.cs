using System.Text.Json;

namespace Flickr.Net.Internals.JsonConverters;

/// <summary>
/// </summary>
public class AutoStringToNumberConverter : System.Text.Json.Serialization.JsonConverter<object>
{
    /// <summary>
    /// </summary>
    public static AutoStringToNumberConverter Instance { get; } = new();

    /// <summary>
    /// </summary>
    public override bool CanConvert(Type typeToConvert)
    {
        // see https://stackoverflow.com/questions/1749966/c-sharp-how-to-determine-whether-a-type-is-a-number
        return Type.GetTypeCode(typeToConvert) switch
        {
            TypeCode.Byte or TypeCode.SByte or TypeCode.UInt16 or TypeCode.UInt32 or TypeCode.UInt64 or TypeCode.Int16 or TypeCode.Int32 or TypeCode.Int64 or TypeCode.Decimal or TypeCode.Double or TypeCode.Single => true,
            _ => false,
        };
    }

    /// <summary>
    /// </summary>
    public override object Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            var s = reader.GetString();
            if (long.TryParse(s, out var l))
            {
                return Convert.ChangeType(l, typeToConvert);
            }
            else if (double.TryParse(s, out var d))
            {
                return d;
            }
            else
            {
                throw new Exception($"unable to parse {s} to number");
            }
        }
        if (reader.TokenType == JsonTokenType.Number)
        {
            if (reader.TryGetInt64(out var l))
            {
                return Convert.ChangeType(l, typeToConvert);
            }
            else
            {
                return reader.GetDouble();
            }
        }
        using var document = JsonDocument.ParseValue(ref reader);
        throw new Exception($"unable to parse {document.RootElement} to number");
    }

    /// <summary>
    /// </summary>
    public override void Write(Utf8JsonWriter writer, object value, JsonSerializerOptions options)
    {
        writer.WriteRawValue(value.ToString());
    }
}