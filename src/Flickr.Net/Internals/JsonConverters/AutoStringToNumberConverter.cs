using System.Globalization;
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
        typeToConvert = Nullable.GetUnderlyingType(typeToConvert) ?? typeToConvert;

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
        typeToConvert = Nullable.GetUnderlyingType(typeToConvert) ?? typeToConvert;

        switch (reader.TokenType)
        {
            case JsonTokenType.String:
            {
                var s = reader.GetString();

                // Flickr emits numbers with a dot decimal separator ("59.928958").
                // Parse invariant: the ambient CurrentCulture may expect a comma
                // (e.g. nb-NO hosts), which made every decimal string throw
                // "unable to parse ... to number" and broke photo search.
                if (long.TryParse(s, NumberStyles.Integer, CultureInfo.InvariantCulture, out var l))
                {
                    return Convert.ChangeType(l, typeToConvert, CultureInfo.InvariantCulture);
                }

                return double.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, out var d)
                    ? Convert.ChangeType(d, typeToConvert, CultureInfo.InvariantCulture)
                    : throw new Exception($"unable to parse {s} to number");
            }
            case JsonTokenType.Number:
            {
                return reader.TryGetInt64(out var l)
                    ? Convert.ChangeType(l, typeToConvert, CultureInfo.InvariantCulture)
                    : Convert.ChangeType(reader.GetDouble(), typeToConvert, CultureInfo.InvariantCulture);
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
        // Invariant so a comma-decimal CurrentCulture never emits "59,928958"
        // (invalid JSON number) when these entities are serialized back out.
        writer.WriteRawValue(Convert.ToString(value, CultureInfo.InvariantCulture)!, skipInputValidation: true);
    }
}