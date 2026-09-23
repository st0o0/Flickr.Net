using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Flickr.Net.Internals.JsonConverters;
/// <summary>Converts Unix timestamps (as strings) to <see cref="DateTime"/>.</summary>
public sealed class TimestampToDateTimeConverter : JsonConverter<DateTime>
{    public static TimestampToDateTimeConverter Instance { get; } = new();

    private static DateTime UnixTimestampToDate(long timestamp) =>
        DateTimeOffset.FromUnixTimeSeconds(timestamp).UtcDateTime;
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        if (value == null)
        {
            return DateTime.MinValue;
        }

        try
        {
            return UnixTimestampToDate(long.Parse(value, NumberStyles.Any, NumberFormatInfo.InvariantInfo));
        }
        catch (FormatException)
        {
            if (DateTime.TryParseExact(value, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsed))
            {
                return parsed;
            }

            return DateTime.MinValue;
        }
    }
    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        var content = UtilityMethods.DateToUnixTimestamp(value);
        writer.WriteRawValue(content);
    }
}
