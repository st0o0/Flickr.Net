using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

/// <summary>
/// </summary>
[FlickrJsonPropertyName("prevphoto")]
public record PrevPhoto : FlickrEntityBase<Id>
{
    [JsonProperty("owner")]
    public string Owner { get; set; }

    [JsonProperty("secret")]
    public string Secret { get; set; }

    [JsonProperty("server")]
    public string Server { get; set; }

    [JsonProperty("farm")]
    public int Farm { get; set; }

    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("url")]
    public string Url { get; set; }

    [JsonProperty("thumb")]
    public string Thumb { get; set; }

    [JsonProperty("license")]
    public LicenseType License { get; set; }

    [JsonProperty("media")]
    public MediaType Media { get; set; }

    [JsonProperty("is_faved")]
    public bool IsFaved { get; set; }
}