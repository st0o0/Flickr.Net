using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

[FlickrJsonPropertyName("method")]
public record MethodInfo : FlickrEntityBase
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("needslogin")]
    public bool NeedsLogin { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("response")]
    public string Response { get; set; }

    [JsonPropertyName("explanation")]
    public string Explanation { get; set; }

    [JsonPropertyName("arguments")]
    public List<Argument> Arguments { get; set; }

    [JsonPropertyName("errors")]
    public List<Error> Errors { get; set; }
}
