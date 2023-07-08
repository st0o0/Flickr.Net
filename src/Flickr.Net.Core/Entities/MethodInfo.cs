using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

[FlickrJsonPropertyName("method")]
public record MethodInfo : FlickrEntityBase
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("needslogin")]
    public bool NeedsLogin { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("response")]
    public string Response { get; set; }

    [JsonProperty("explanation")]
    public string Explanation { get; set; }

    [JsonProperty("arguments")]
    public List<Argument> Arguments { get; set; }

    [JsonProperty("errors")]
    public List<Error> Errors { get; set; }
}
