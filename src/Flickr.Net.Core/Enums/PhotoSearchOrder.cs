namespace Flickr.Net.Core.Enums;

/// <summary>
/// The sort order for the <see cref="IFlickrPhotos.SearchAsync(PhotoSearchOptions,
/// CancellationToken)"/>, <see cref="IFlickrPhotos.GetWithGeoDataAsync(PartialSearchOptions,
/// CancellationToken)"/>, <see cref="IFlickrPhotos.GetWithoutGeoDataAsync(PartialSearchOptions,
/// CancellationToken)"/> methods.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum PhotoSearchSortOrder
{
    /// <summary>
    /// No sort order.
    /// </summary>
    [EnumMember(Value = "0")]
    None,

    /// <summary>
    /// Sort by date uploaded (posted).
    /// </summary>
    [EnumMember(Value = "date-posted-asc")]
    DatePostedAscending,

    /// <summary>
    /// Sort by date uploaded (posted) in descending order.
    /// </summary>
    [EnumMember(Value = "date-posted-desc")]
    DatePostedDescending,

    /// <summary>
    /// Sort by date taken.
    /// </summary>
    [EnumMember(Value = "date-taken-asc")]
    DateTakenAscending,

    /// <summary>
    /// Sort by date taken in descending order.
    /// </summary>
    [EnumMember(Value = "date-taken-desc")]
    DateTakenDescending,

    /// <summary>
    /// Sort by interestingness (least interesting first)
    /// </summary>
    [EnumMember(Value = "interestingness-asc")]
    InterestingnessAscending,

    /// <summary>
    /// Sort by interestingness in descending order (i.e. most interesting first)
    /// </summary>
    [EnumMember(Value = "interestingness-desc")]
    InterestingnessDescending,

    /// <summary>
    /// Sort by relevance (only applicable to text searches)
    /// </summary>
    [EnumMember(Value = "relevance")]
    Relevance
}