namespace FlickrNet.Core.Enums;

/// <summary>
/// The posting limit most for a group.
/// </summary>
public enum GroupThrottleMode
{
    /// <summary>
    /// Per day posting limit.
    /// </summary>
    PerDay,

    /// <summary>
    /// Per week posting limit.
    /// </summary>
    PerWeek,

    /// <summary>
    /// Per month posting limit.
    /// </summary>
    PerMonth,

    /// <summary>
    /// No posting limit.
    /// </summary>
    NoLimit,

    /// <summary>
    /// Posting limit is total number of photos in the group.
    /// </summary>
    Ever,

    /// <summary>
    /// Posting is disabled to this group.
    /// </summary>
    Disabled
}