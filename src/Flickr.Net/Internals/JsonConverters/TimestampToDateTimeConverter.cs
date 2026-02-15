using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Flickr.Net.Internals.JsonConverters;

/// <summary>
/// </summary>
public class TimestampToDateTimeConverter : JsonConverter<DateTime>
{
    /// <summary>
    /// </summary>
    public static TimestampToDateTimeConverter Instance { get; } = new();

    private static readonly DateTime UnixStartDate = new(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

    private static DateTime UnixTimestampToDate(long timestamp) => UnixStartDate.AddSeconds(timestamp);

    /// <summary>
    /// </summary>
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
            return DateTime.MinValue;
        }
    }

    /// <summary>
    /// </summary>
    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        var content = UtilityMethods.DateToUnixTimestamp(value);
        writer.WriteRawValue(content);
    }
}