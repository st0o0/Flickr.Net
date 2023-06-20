using Flickr.Net.Core.Internals.Attributes;
using Newtonsoft.Json;

namespace Flickr.Net.Core.NewEntities;

[FlickrJsonPropertyName("photo")]
public class PandaPhoto
{
    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("secret")]
    public string Secret { get; set; }

    [JsonProperty("server")]
    public string Server { get; set; }

    [JsonProperty("farm")]
    public string Farm { get; set; }

    [JsonProperty("owner")]
    public string Owner { get; set; }

    [JsonProperty("ownername")]
    public string OwnerName { get; set; }
}