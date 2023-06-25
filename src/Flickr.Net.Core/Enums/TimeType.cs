namespace Flickr.Net.Core.Enums;

/// <summary>
/// The time type.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum TimeType
{
    /// <summary>
    /// </summary>
    [EnumMember(Value = "h")]
    Hours,

    /// <summary>
    /// </summary>
    [EnumMember(Value = "d")]
    Days
}