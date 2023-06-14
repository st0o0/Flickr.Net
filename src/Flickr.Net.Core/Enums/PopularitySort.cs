namespace Flickr.Net.Core.Enums;

/// <summary>
/// Sorting used for <see cref="IFlickrStats.GetPopularPhotosAsync(DateTime, PopularitySort, int,
/// int, CancellationToken)"/>
/// </summary>
public enum PopularitySort
{
    /// <summary>
    /// No sorting performed.
    /// </summary>
    None,

    /// <summary>
    /// Sort by number of views.
    /// </summary>
    Views,

    /// <summary>
    /// Sort by number of comments.
    /// </summary>
    Comments,

    /// <summary>
    /// Sort by number of favorites.
    /// </summary>
    Favorites
}