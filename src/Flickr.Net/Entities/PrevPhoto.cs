using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Enums;
using Flickr.Net.Internals.Attributes;

namespace Flickr.Net;

/// <summary>
/// </summary>
[FlickrJsonPropertyName("prevphoto")]
public record PrevPhoto : FlickrEntityBase<Id>
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("owner")]
    public string Owner { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("secret")]
    public string Secret { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("server")]
    public string Server { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("farm")]
    public int Farm { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("title")]
    public string Title { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("url")]
    public string Url { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("thumb")]
    public string Thumb { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("license")]
    public LicenseType License { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("media")]
    public MediaType Media { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("is_faved")]
    public bool IsFaved { get; set; }
}