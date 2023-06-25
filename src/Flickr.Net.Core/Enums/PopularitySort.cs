namespace Flickr.Net.Core.Enums;

/// <summary>
/// Sorting used for <see cref="IFlickrStats.GetPopularPhotosAsync(DateTime, PopularitySort, int,
/// int, CancellationToken)"/>
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum PopularitySort
{
    /// <summary>
    /// No sorting performed.
    /// </summary>
    [EnumMember(Value = "0")]
    None,

    /// <summary>
    /// Sort by number of views.
    /// </summary>
    [EnumMember(Value = "views")]
    Views,

    /// <summary>
    /// Sort by number of comments.
    /// </summary>
    [EnumMember(Value = "comments")]
    Comments,

    /// <summary>
    /// Sort by number of favorites.
    /// </summary>
    [EnumMember(Value = "favorites")]
    Favorites
}