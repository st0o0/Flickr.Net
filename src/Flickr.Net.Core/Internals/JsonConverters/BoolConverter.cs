namespace Flickr.Net.Core.Internals.JsonConverters;

/// <summary>
/// </summary>
public class BoolConverter : JsonConverter
{
    public static BoolConverter Instance { get; } = new();

    /// <summary>
    /// </summary>
    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        writer.WriteValue(((bool)value) ? 1 : 0);
    }

    /// <summary>
    /// </summary>
    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        return reader.Value.ToString() == "1";
    }

    /// <summary>
    /// </summary>
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(bool);
    }
}