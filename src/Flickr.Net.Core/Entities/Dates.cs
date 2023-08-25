using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.JsonConverters;

namespace Flickr.Net.Core;

public record Dates : FlickrEntityBase
{
    [JsonPropertyName("posted")]
    public DateTime Posted { get; set; }

    [JsonPropertyName("taken")]
    [System.Text.Json.Serialization.JsonConverter(typeof(DateTimeGranularityConverter))]
    public DateTime Taken { get; set; }

    [JsonPropertyName("takengranularity")]
    public DateGranularity TakenGranularity { get; set; }

    [JsonPropertyName("takenunknown")]
    public bool TakenUnknown { get; set; }

    [JsonPropertyName("lastupdate")]
    public DateTime LastUpdate { get; set; }
}
