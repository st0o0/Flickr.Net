using System.Runtime.Serialization;

namespace Flickr.Net.Enums;

/// <summary>
/// The popular sorting.
/// </summary>
public enum PopularSorting
{
    [EnumMember(Value = "")]
    None,
    [EnumMember(Value = "faves")]
    Faves,
    [EnumMember(Value = "views")]
    Views,
    [EnumMember(Value = "comments")]
    Comments,
    [EnumMember(Value = "interesting")]
    Interesting
}