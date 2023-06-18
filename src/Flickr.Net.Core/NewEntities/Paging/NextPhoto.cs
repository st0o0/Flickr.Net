using Flickr.Net.Core.Internals.Attributes;
using Newtonsoft.Json;

namespace Flickr.Net.Core.NewEntities.Paging;

/// <summary>
/// </summary>
[FlickrJsonPropertyName("nextphoto")]
public class NextPhoto
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("secret")]
    public string Secret { get; set; }

    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("url")]
    public string Url { get; set; }
}
