using System.Runtime.Serialization;

namespace Flickr.Net.Enums;

/// <summary>
/// The time type.
/// </summary>
public enum TimeType
{    [EnumMember(Value = "h")]
    Hours,
    [EnumMember(Value = "d")]
    Days
}