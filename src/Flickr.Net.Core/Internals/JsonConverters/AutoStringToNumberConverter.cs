using System.Text.Json;

namespace Flickr.Net.Core.Internals.JsonConverters;

public class AutoStringToNumberConverter : System.Text.Json.Serialization.JsonConverter<object>
{
    public AutoStringToNumberConverter() : base()
    {
    }

    public static AutoStringToNumberConverter Instance { get; } = new ();

    public override bool CanConvert(Type typeToConvert)
    {
        // see https://stackoverflow.com/questions/1749966/c-sharp-how-to-determine-whether-a-type-is-a-number
        switch (Type.GetTypeCode(typeToConvert))
        {
            case TypeCode.Byte:
            case TypeCode.SByte:
            case TypeCode.UInt16:
            case TypeCode.UInt32:
            case TypeCode.UInt64:
            case TypeCode.Int16:
            case TypeCode.Int32:
            case TypeCode.Int64:
            case TypeCode.Decimal:
            case TypeCode.Double:
            case TypeCode.Single:
                return true;

            default:
                return false;
        }
    }

    public override object Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            var s = reader.GetString();
            if (long.TryParse(s, out long l))
            {
                return Convert.ChangeType(l, typeToConvert);
            }
            else if (double.TryParse(s, out double d))
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
        using (JsonDocument document = JsonDocument.ParseValue(ref reader))
        {
            throw new Exception($"unable to parse {document.RootElement.ToString()} to number");
        }
    }

    public override void Write(Utf8JsonWriter writer, object value, JsonSerializerOptions options)
    {
        writer.WriteRawValue(value.ToString());
    }
}