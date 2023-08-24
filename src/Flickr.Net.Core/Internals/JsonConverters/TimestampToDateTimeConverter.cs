namespace Flickr.Net.Core.Internals.JsonConverters;

/// <summary>
/// </summary>
public class TimestampToDateTimeConverter : System.Text.Json.Serialization.JsonConverter<DateTime>
{
    public static TimestampToDateTimeConverter Instance { get; } = new();

    private static readonly DateTime UnixStartDate = new(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

    private static DateTime UnixTimestampToDate(long timestamp)
    {
        return UnixStartDate.AddSeconds(timestamp);
    }


    /// <summary>
    /// </summary>
    public override DateTime Read(ref System.Text.Json.Utf8JsonReader reader, Type typeToConvert, System.Text.Json.JsonSerializerOptions options)
    {
        var value = reader.GetString();
        if (value == null)
        {
            return DateTime.MinValue;
        }

        try
        {
            return UnixTimestampToDate(long.Parse(value, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo));
        }
        catch (FormatException)
        {
            return DateTime.MinValue;
        }
    }

    /// <summary>
    /// </summary>
    public override void Write(System.Text.Json.Utf8JsonWriter writer, DateTime value, System.Text.Json.JsonSerializerOptions options)
    {
        var content = UtilityMethods.DateToUnixTimestamp(value);
        writer.WriteRawValue(content);
    }
}