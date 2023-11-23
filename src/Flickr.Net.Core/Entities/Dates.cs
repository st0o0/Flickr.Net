using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.JsonConverters;

namespace Flickr.Net.Core;

/// <summary>
/// </summary>
public record Dates : FlickrEntityBase
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("posted")]
    public DateTime Posted { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("taken")]
    [JsonConverter(typeof(DateTimeGranularityConverter))]
    public DateTime Taken { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("takengranularity")]
    public DateGranularity TakenGranularity { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("takenunknown")]
    public bool TakenUnknown { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("lastupdate")]
    public DateTime LastUpdate { get; set; }
}
