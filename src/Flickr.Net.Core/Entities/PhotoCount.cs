using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

/// <summary>
/// </summary>
public record PhotoCount : FlickrEntityBase
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("count")]
    public int Count { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("fromdate")]
    public DateTime FromDate { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("todate")]
    public DateTime ToDate { get; set; }
}
