using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

[FlickrJsonPropertyName("collection")]
public record Collection : FlickrEntityBase<Id>
{
    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("child_count")]
    public int ChildCount { get; set; }

    [JsonPropertyName("datecreate")]
    public DateTime CreateDate { get; set; }

    [JsonPropertyName("iconlarge")]
    public string LargeIcon { get; set; }

    [JsonPropertyName("iconsmall")]
    public string SmallIcon { get; set; }

    [JsonPropertyName("server")]
    public string Server { get; set; }

    [JsonPropertyName("secret")]
    public string Secret { get; set; }

    [JsonPropertyName("iconphotos")]
    public Photos IconPhotos { get; set; }

    [JsonPropertyName("set")]
    public List<CollectionSet> Sets { get; set; }
}