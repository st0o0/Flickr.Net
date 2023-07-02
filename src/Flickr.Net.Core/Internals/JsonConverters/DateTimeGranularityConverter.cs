namespace Flickr.Net.Core.Internals.JsonConverters;

public class DateTimeGranularityConverter : DateTimeConverterBase
{
    private static readonly DateTime UnixStartDate = new(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

    /// <summary>
    /// </summary>
    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        var content = "";
        if (value is DateTime dateTime)
            content = dateTime.ToString("yyyy-MM-dd HH:mm:ss", System.Globalization.DateTimeFormatInfo.InvariantInfo);
        writer.WriteRawValue(content);
    }

    /// <summary>
    /// </summary>
    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        var date = reader.Value.ToString();
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
            output = new DateTime(int.Parse(date.AsSpan(0, 4), System.Globalization.NumberFormatInfo.InvariantInfo), 1, 1);
            return output;
        }

        var format = "yyyy-MM-dd HH:mm:ss";
        try
        {
            output = DateTime.ParseExact(date, format, System.Globalization.DateTimeFormatInfo.InvariantInfo, System.Globalization.DateTimeStyles.None);
        }
        catch { }
        return output;
    }
}
