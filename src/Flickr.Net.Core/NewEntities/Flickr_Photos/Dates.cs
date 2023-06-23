using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.JsonConverters;
using Newtonsoft.Json;

namespace Flickr.Net.Core;

public record Dates : FlickrEntityBase
{
    [JsonProperty("posted")]
    public DateTime Posted { get; set; }

    [JsonProperty("taken")]
    [JsonConverter(typeof(DateTimeGranularityConverter))]
    public DateTime Taken { get; set; }

    [JsonProperty("takengranularity")]
    public DateGranularity TakenGranularity { get; set; }

    [JsonProperty("takenunknown")]
    public bool TakenUnknown { get; set; }

    [JsonProperty("lastupdate")]
    public DateTime LastUpdate { get; set; }
}
