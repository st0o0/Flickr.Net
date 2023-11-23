using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Internals.Attributes;

namespace Flickr.Net;

/// <summary>
/// </summary>
[FlickrJsonPropertyName("collection")]
public record Collection : FlickrEntityBase<Id>
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("title")]
    public string Title { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("description")]
    public string Description { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("child_count")]
    public int ChildCount { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("datecreate")]
    public DateTime CreateDate { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("iconlarge")]
    public string LargeIcon { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("iconsmall")]
    public string SmallIcon { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("server")]
    public string Server { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("secret")]
    public string Secret { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("iconphotos")]
    public Photos IconPhotos { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("set")]
    public List<CollectionSet> Sets { get; set; }
}