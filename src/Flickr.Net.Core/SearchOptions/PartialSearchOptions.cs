using System.Collections;
using Flickr.Net.Core.Internals.Extensions;

namespace Flickr.Net.Core;

/// <summary>
/// Summary description for PartialSearchOptions.
/// </summary>
public record PartialSearchOptions
{
    /// <summary>
    /// Minimum date uploaded. Defaults to <see cref="DateTime.MinValue"/> which signifies that the
    /// value is not to be used.
    /// </summary>
    public DateTime MinUploadDate { get; init; } = DateTime.MinValue;

    /// <summary>
    /// Maximum date uploaded. Defaults to <see cref="DateTime.MinValue"/> which signifies that the
    /// value is not to be used.
    /// </summary>
    public DateTime MaxUploadDate { get; init; } = DateTime.MinValue;

    /// <summary>
    /// Minimum date taken. Defaults to <see cref="DateTime.MinValue"/> which signifies that the
    /// value is not to be used.
    /// </summary>
    public DateTime MinTakenDate { get; init; } = DateTime.MinValue;

    /// <summary>
    /// Maximum date taken. Defaults to <see cref="DateTime.MinValue"/> which signifies that the
    /// value is not to be used.
    /// </summary>
    public DateTime MaxTakenDate { get; init; } = DateTime.MinValue;

    /// <summary>
    /// Optional extras to return, defaults to all. See <see cref="PhotoSearchExtras"/> for more details.
    /// </summary>
    public PhotoSearchExtras Extras { get; init; } = PhotoSearchExtras.None;

    /// <summary>
    /// Number of photos to return per page. Defaults to 100.
    /// </summary>
    public int PerPage { get; init; }

    /// <summary>
    /// The page to return. Defaults to page 1.
    /// </summary>
    public int Page { get; init; }

    /// <summary>
    /// The sort order of the returned list. Default is <see cref="PhotoSearchSortOrder.None"/>.
    /// </summary>
    public PhotoSearchSortOrder SortOrder { get; init; } = PhotoSearchSortOrder.None;

    /// <summary>
    /// The privacy fitler to filter the search on.
    /// </summary>
    public PrivacyFilter PrivacyFilter { get; init; } = PrivacyFilter.None;

    /// <summary>
    /// Default constructor.
    /// </summary>
    public PartialSearchOptions()
    { }

    /// <summary>
    /// Constructor taking a default <see cref="PhotoSearchExtras"/> parameter.
    /// </summary>
    /// <param name="extras">See <see cref="PhotoSearchExtras"/> for more details.</param>
    public PartialSearchOptions(PhotoSearchExtras extras)
    {
        Extras = extras;
    }

    /// <summary>
    /// Constructor taking a perPage and page parameter.
    /// </summary>
    /// <param name="perPage">The number of photos to return per page (maximum).</param>
    /// <param name="page">The page number to return.</param>
    public PartialSearchOptions(int perPage, int page)
    {
        PerPage = perPage;
        Page = page;
    }

    /// <summary>
    /// Constructor taking a perPage and page parameter and a default <see
    /// cref="PhotoSearchExtras"/> parameter.
    /// </summary>
    /// <param name="perPage">The number of photos to return per page (maximum).</param>
    /// <param name="page">The page number to return.</param>
    /// <param name="extras">See <see cref="PhotoSearchExtras"/> for more details.</param>
    public PartialSearchOptions(int perPage, int page, PhotoSearchExtras extras)
    {
        PerPage = perPage;
        Page = page;
        Extras = extras;
    }

    internal PartialSearchOptions(PhotoSearchOptions options)
    {
        Extras = options.Extras;
        MaxTakenDate = options.MaxTakenDate;
        MinTakenDate = options.MinTakenDate;
        MaxUploadDate = options.MaxUploadDate;
        MinUploadDate = options.MinUploadDate;
        Page = options.Page;
        PerPage = options.PerPage;
        PrivacyFilter = options.PrivacyFilter;
    }
}