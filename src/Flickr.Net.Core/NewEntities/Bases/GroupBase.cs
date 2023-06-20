using Newtonsoft.Json;

namespace Flickr.Net.Core.Bases;

public record GroupBase : FlickrEntityBase<NsId>
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("eighteenplus")]
    public bool EighteenPlus { get; set; }
}
