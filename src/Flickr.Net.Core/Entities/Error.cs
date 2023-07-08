using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

[FlickrJsonPropertyName("error")]
public record Error
{
    [JsonProperty("code")]
    public int Code { get; set; }

    [JsonProperty("message")]
    public string Message { get; set; }

    [JsonProperty("_content")]
    public string Content { get; set; }
}
