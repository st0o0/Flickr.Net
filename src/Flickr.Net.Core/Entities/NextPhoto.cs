using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

/// <summary>
/// </summary>
[FlickrJsonPropertyName("nextphoto")]
public record NextPhoto : FlickrEntityBase<Id>
{
    [JsonPropertyName("owner")]
    public string Owner { get; set; }

    [JsonPropertyName("secret")]
    public string Secret { get; set; }

    [JsonPropertyName("server")]
    public string Server { get; set; }

    [JsonPropertyName("farm")]
    public int Farm { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("thumb")]
    public string Thumb { get; set; }

    [JsonPropertyName("license")]
    public LicenseType License { get; set; }

    [JsonPropertyName("media")]
    public MediaType Media { get; set; }

    [JsonPropertyName("is_faved")]
    public bool IsFaved { get; set; }
}