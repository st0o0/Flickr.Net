using Flickr.Net.Core.Internals.Attributes;
using Flickr.Net.Core.Internals.JsonConverters;
using Newtonsoft.Json;

namespace Flickr.Net.Core.NewEntities;

[FlickrJsonPropertyName("photo")]
public class Photo
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("owner")]
    public string Owner { get; set; }

    [JsonProperty("secret")]
    public string Secret { get; set; }

    [JsonProperty("server")]
    public string Server { get; set; }

    [JsonProperty("farm")]
    public string Farm { get; set; }

    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("ispublic")]
    [JsonConverter(typeof(BoolConverter))]
    public bool IsPublic { get; set; }

    [JsonProperty("isfriend")]
    [JsonConverter(typeof(BoolConverter))]
    public bool IsFriend { get; set; }

    [JsonProperty("isfamily")]
    [JsonConverter(typeof(BoolConverter))]
    public bool IsFamily { get; set; }
}