using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;
using Newtonsoft.Json;

namespace Flickr.Net.Core;

[FlickrJsonPropertyName("collection")]
public record Collection : FlickrEntityBase<Id>
{
    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("child_count")]
    public int ChildCount { get; set; }

    [JsonProperty("datecreate")]
    public DateTime CreateDate { get; set; }

    [JsonProperty("iconlarge")]
    public string LargeIcon { get; set; }

    [JsonProperty("iconsmall")]
    public string SmallIcon { get; set; }

    [JsonProperty("server")]
    public string Server { get; set; }

    [JsonProperty("secret")]
    public string Secret { get; set; }

    [JsonProperty("iconphotos")]
    public Photos IconPhotos { get; set; }

    [JsonProperty("set")]
    public List<CollectionSet> Sets { get; set; }
}