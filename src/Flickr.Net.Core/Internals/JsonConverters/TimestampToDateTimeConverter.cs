namespace Flickr.Net.Core.Internals.JsonConverters;

/// <summary>
/// </summary>
public class TimestampToDateTimeConverter : DateTimeConverterBase
{
    public static TimestampToDateTimeConverter Instance { get; } = new();

    private static readonly DateTime UnixStartDate = new(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

    /// <summary>
    /// </summary>
    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        var content = "";
        if (value is DateTime dateTime)
            content = UtilityMethods.DateToUnixTimestamp(dateTime);
        writer.WriteRawValue(content);
    }

    /// <summary>
    /// </summary>
    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        if (reader.Value == null)
        {
            return DateTime.MinValue;
        }

        try
        {
            return UnixTimestampToDate(long.Parse(reader.Value.ToString(), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo));
        }
        catch (FormatException)
        {
            return DateTime.MinValue;
        }
    }

    private static DateTime UnixTimestampToDate(long timestamp)
    {
        return UnixStartDate.AddSeconds(timestamp);
    }
}