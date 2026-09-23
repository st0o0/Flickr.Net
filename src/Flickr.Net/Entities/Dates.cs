using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Enums;
using Flickr.Net.Internals.JsonConverters;

namespace Flickr.Net;
/// <summary>Represents the various dates associated with a photo.</summary>
public record Dates : FlickrEntityBase
{
    [JsonPropertyName("posted")]
    /// <summary>The date the photo was posted (uploaded).</summary>
    public DateTime Posted { get; init; }
    [JsonPropertyName("taken")]
    [JsonConverter(typeof(DateTimeGranularityConverter))]
    /// <summary>The date the photo was taken.</summary>
    public DateTime Taken { get; init; }
    [JsonPropertyName("takengranularity")]
    /// <summary>The granularity of the taken date (exact, month, or year).</summary>
    public DateGranularity TakenGranularity { get; init; }
    [JsonPropertyName("takenunknown")]
    /// <summary>Whether the taken date is unknown.</summary>
    public bool TakenUnknown { get; init; }
    [JsonPropertyName("lastupdate")]
    /// <summary>The date of the last metadata update.</summary>
    public DateTime LastUpdate { get; init; }
}
