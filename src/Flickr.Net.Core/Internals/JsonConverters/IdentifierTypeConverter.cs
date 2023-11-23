using System.Text.Json;
using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core.Internals.JsonConverters.IdentifierConverters;

/// <summary>
/// </summary>
public class IdentifierTypeConverter : System.Text.Json.Serialization.JsonConverter<IdentifierType>
{
    /// <summary>
    /// </summary>
    public IdentifierTypeConverter() : base() { }

    /// <summary>
    /// </summary>
    public static IdentifierTypeConverter Instance { get; } = new();

    /// <summary>
    /// </summary>
    public override bool CanConvert(Type typeToConvert)
        => typeToConvert switch
        {
            var value when value == typeof(Id) => true,
            var value when value == typeof(NsId) => true,
            var value when value == typeof(PhotoId) => true,
            var value when value == typeof(PhotosetId) => true,
            var value when value == typeof(IdentifierType) => true,
            _ => false
        };

    /// <summary>
    /// </summary>
    public override IdentifierType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        => typeToConvert switch
        {
            var value when value == typeof(Id) => (Id)reader.GetString(),
            var value when value == typeof(NsId) => (NsId)reader.GetString(),
            var value when value == typeof(PhotoId) => (PhotoId)reader.GetString(),
            var value when value == typeof(PhotosetId) => (PhotosetId)reader.GetString(),
            _ => default
        };

    /// <summary>
    /// </summary>
    public override void Write(Utf8JsonWriter writer, IdentifierType value, JsonSerializerOptions options)
        => writer.WriteRawValue((string)value);
}