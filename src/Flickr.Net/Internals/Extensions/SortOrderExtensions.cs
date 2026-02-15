using Flickr.Net.Enums;

namespace Flickr.Net.Internals.Extensions;

/// <summary>
/// </summary>
internal static class SortOrderExtensions
{
    /// <summary>
    /// Converts a <see cref="PopularitySort"/> enum to a string.
    /// </summary>
    /// <param name="sort">The value to convert.</param>
    /// <returns></returns>
    internal static string ToFlickrString(this PopularitySort sort) => sort.GetEnumMemberValue();

    /// <summary>
    /// Converts a <see cref="PhotoSearchSortOrder"/> into a string for use by the Flickr API.
    /// </summary>
    /// <param name="sortOrder">The sort order to convert.</param>
    /// <returns>The string representative for the sort order.</returns>
    internal static string ToFlickrString(this PhotoSearchSortOrder sortOrder) => sortOrder.GetEnumMemberValue();
}