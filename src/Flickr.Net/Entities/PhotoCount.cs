using System.Text.Json.Serialization;
using Flickr.Net.Bases;

namespace Flickr.Net;
/// <summary>Represents a count of photos within a date range.</summary>
public record PhotoCount : FlickrEntityBase
{    [JsonPropertyName("count")]
    /// <summary>The count.</summary>
    public int Count { get; init; }
    [JsonPropertyName("fromdate")]
    /// <summary>The start date of the range.</summary>
    public DateTime FromDate { get; init; }
    [JsonPropertyName("todate")]
    /// <summary>The end date of the range.</summary>
    public DateTime ToDate { get; init; }
}
