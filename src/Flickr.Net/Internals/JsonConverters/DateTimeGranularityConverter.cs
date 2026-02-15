using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Flickr.Net.Internals.JsonConverters;

/// <summary>
/// </summary>
public class DateTimeGranularityConverter : JsonConverter<DateTime>
{
    /// <summary>
    /// </summary>
    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        var content = "";
        if (value is DateTime dateTime)
            content = dateTime.ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
        writer.WriteRawValue(content);
    }

    /// <summary>
    /// </summary>
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var date = reader.GetString();
        var output = DateTime.MinValue;

        if (string.IsNullOrEmpty(date))
        {
            return output;
        }

        if (date == "0000-00-00 00:00:00")
        {
            return output;
        }

        if (date.EndsWith("-00-01 00:00:00", StringComparison.Ordinal))
        {
            output = new DateTime(int.Parse(date.AsSpan(0, 4), NumberFormatInfo.InvariantInfo), 1, 1);
            return output;
        }

        var format = "yyyy-MM-dd HH:mm:ss";
        try
        {
            output = DateTime.ParseExact(date, format, DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None);
        }
        catch { }
        return output;
    }
}
