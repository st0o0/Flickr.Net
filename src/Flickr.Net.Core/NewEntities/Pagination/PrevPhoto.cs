using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;
using Newtonsoft.Json;

namespace Flickr.Net.Core;

/// <summary>
/// </summary>
[FlickrJsonPropertyName("prevphoto")]
public record PrevPhoto : FlickrEntityBase<Id>
{
    [JsonProperty("secret")]
    public string Secret { get; set; }

    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("url")]
    public string Url { get; set; }
}