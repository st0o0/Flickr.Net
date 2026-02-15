using System.Text.Json;
using System.Text.Json.Serialization;

namespace Flickr.Net.Internals.JsonConverters;

/// <summary>
/// </summary>
public class AutoStringToNumberConverter : JsonConverter<object>
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
            TypeCode.Byte or TypeCode.SByte or TypeCode.UInt16 or TypeCode.UInt32 or TypeCode.UInt64 or TypeCode.Int16
                or TypeCode.Int32 or TypeCode.Int64 or TypeCode.Decimal or TypeCode.Double or TypeCode.Single => true,
            _ => false,
        };
    }

    /// <summary>
    /// </summary>
    public override object Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        switch (reader.TokenType)
        {
            case JsonTokenType.String:
            {
                var s = reader.GetString();
                if (long.TryParse(s, out var l))
                {
                    return Convert.ChangeType(l, typeToConvert);
                }

                return double.TryParse(s, out var d) ? d : throw new Exception($"unable to parse {s} to number");
            }
            case JsonTokenType.Number:
            {
                return reader.TryGetInt64(out var l) ? Convert.ChangeType(l, typeToConvert) : reader.GetDouble();
            }
            default:
            {
                using var document = JsonDocument.ParseValue(ref reader);
                throw new Exception($"unable to parse {document.RootElement} to number");
            }
        }
    }

    /// <summary>
    /// </summary>
    public override void Write(Utf8JsonWriter writer, object value, JsonSerializerOptions options)
    {
        writer.WriteRawValue(value.ToString());
    }
}