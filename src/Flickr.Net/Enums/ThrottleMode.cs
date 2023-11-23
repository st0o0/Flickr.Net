namespace Flickr.Net.Enums;

/// <summary>
/// The posting limit most for a group.
/// </summary>
public enum ThrottleMode
{
    /// <summary>
    /// Per day posting limit.
    /// </summary>
    [EnumMember(Value = "day")]
    PerDay,

    /// <summary>
    /// Per week posting limit.
    /// </summary>
    [EnumMember(Value = "week")]
    PerWeek,

    /// <summary>
    /// Per month posting limit.
    /// </summary>
    [EnumMember(Value = "month")]
    PerMonth,

    /// <summary>
    /// No posting limit.
    /// </summary>
    [EnumMember(Value = "none")]
    NoLimit,

    /// <summary>
    /// Posting limit is total number of photos in the group.
    /// </summary>
    [EnumMember(Value = "ever")]
    Ever,

    /// <summary>
    /// Posting is disabled to this group.
    /// </summary>
    [EnumMember(Value = "disabled")]
    Disabled
}