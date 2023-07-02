namespace Flickr.Net.Core.Internals.Extensions;

/// <summary>
/// </summary>
public static class SortOrderExtensions
{
    [Obsolete("KEKW")]
    public static string ToKEKWFlickrString(this PopularitySort sortOrder) => sortOrder switch
    {
        PopularitySort.Comments => "comments",
        PopularitySort.Favorites => "favorites",
        PopularitySort.Views => "views",
        _ => string.Empty,
    };

    [Obsolete("KEKW")]
    public static string ToKEKWFlickrString(this PhotoSearchSortOrder order) => order switch
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

    /// <summary>
    /// Converts a <see cref="PopularitySort"/> enum to a string.
    /// </summary>
    /// <param name="sort">The value to convert.</param>
    /// <returns></returns>
    public static string ToFlickrString(this PopularitySort sort) => sort.GetEnumMemberValue();

    /// <summary>
    /// Converts a <see cref="PhotoSearchSortOrder"/> into a string for use by the Flickr API.
    /// </summary>
    /// <param name="sortOrder">The sort order to convert.</param>
    /// <returns>The string representative for the sort order.</returns>
    public static string ToFlickrString(this PhotoSearchSortOrder sortOrder) => sortOrder.GetEnumMemberValue();
}