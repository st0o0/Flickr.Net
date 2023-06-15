namespace Flickr.Net.Core.Internals.Extensions;

/// <summary>
/// </summary>
public static class SortOrderExtensions
{
    /// <summary>
    /// Converts a <see cref="PopularitySort"/> enum to a string.
    /// </summary>
    /// <param name="sortOrder">The value to convert.</param>
    /// <returns></returns>
    public static string ToFlickrString(this PopularitySort sortOrder) => sortOrder switch
    {
        PopularitySort.Comments => "comments",
        PopularitySort.Favorites => "favorites",
        PopularitySort.Views => "views",
        _ => string.Empty,
    };

    /// <summary>
    /// Converts a <see cref="PhotoSearchSortOrder"/> into a string for use by the Flickr API.
    /// </summary>
    /// <param name="order">The sort order to convert.</param>
    /// <returns>The string representative for the sort order.</returns>
    public static string ToFlickrString(this PhotoSearchSortOrder order) => order switch
    {
        PhotoSearchSortOrder.DatePostedAscending => "date-posted-asc",
        PhotoSearchSortOrder.DatePostedDescending => "date-posted-desc",
        PhotoSearchSortOrder.DateTakenAscending => "date-taken-asc",
        PhotoSearchSortOrder.DateTakenDescending => "date-taken-desc",
        PhotoSearchSortOrder.InterestingnessAscending => "interestingness-asc",
        PhotoSearchSortOrder.InterestingnessDescending => "interestingness-desc",
        PhotoSearchSortOrder.Relevance => "relevance",
        _ => string.Empty,
    };
}
