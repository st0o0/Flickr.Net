using Flickr.Net.Core.Bases;
using Newtonsoft.Json;

namespace Flickr.Net.Core;

public record Camera : FlickrEntityBase<Id>
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("details")]
    public Details Details { get; set; }

    [JsonProperty("images")]
    public Image Image { get; set; }
}