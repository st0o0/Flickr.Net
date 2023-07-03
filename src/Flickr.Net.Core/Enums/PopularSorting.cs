namespace Flickr.Net.Core.Enums;

/// <summary>
/// The popular sorting.
/// </summary>
public enum PopularSorting
{
    /// <summary>
    /// </summary>
    [EnumMember(Value = "")]
    None,

    /// <summary>
    /// </summary>
    [EnumMember(Value = "faves")]
    Faves,

    /// <summary>
    /// </summary>
    [EnumMember(Value = "views")]
    Views,

    /// <summary>
    /// </summary>
    [EnumMember(Value = "comments")]
    Comments,

    /// <summary>
    /// </summary>
    [EnumMember(Value = "interesting")]
    Interesting
}