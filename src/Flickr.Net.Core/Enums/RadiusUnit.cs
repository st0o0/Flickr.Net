namespace Flickr.Net.Core.Enums;

/// <summary>
/// The units of a radius search
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum RadiusUnit
{
    /// <summary>
    /// The radius units are unspecified.
    /// </summary>
    [EnumMember(Value = "")]
    None = 0,

    /// <summary>
    /// The radius is in Kilometers.
    /// </summary>
    [EnumMember(Value = "km")]
    Kilometers = 1,

    /// <summary>
    /// The radius is in Miles.
    /// </summary>
    [EnumMember(Value = "mi")]
    Miles = 0
}