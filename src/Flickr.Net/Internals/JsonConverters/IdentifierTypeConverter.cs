using System.Text.Json;
using System.Text.Json.Serialization;
using Flickr.Net.Bases;

namespace Flickr.Net.Internals.JsonConverters.IdentifierConverters;
/// <summary>Converts Flickr identifier strings to strongly-typed <see cref="IdentifierType"/> records.</summary>
public sealed class IdentifierTypeConverter : JsonConverter<IdentifierType>
{
    /// <summary>Gets the singleton instance.</summary>
    public static IdentifierTypeConverter Instance { get; } = new();
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
    public override IdentifierType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        => typeToConvert switch
        {
            var value when value == typeof(Id) => (Id)reader.GetString()!,
            var value when value == typeof(NsId) => (NsId)reader.GetString()!,
            var value when value == typeof(PhotoId) => (PhotoId)reader.GetString()!,
            var value when value == typeof(PhotosetId) => (PhotosetId)reader.GetString()!,
            _ => default!
        };
    public override void Write(Utf8JsonWriter writer, IdentifierType value, JsonSerializerOptions options)
        => writer.WriteRawValue((string)value);
}
