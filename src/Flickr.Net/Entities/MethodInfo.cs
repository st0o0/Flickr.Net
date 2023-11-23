using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Internals.Attributes;

namespace Flickr.Net;

/// <summary>
/// </summary>
[FlickrJsonPropertyName("method")]
public record MethodInfo : FlickrEntityBase
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("needslogin")]
    public bool NeedsLogin { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("description")]
    public string Description { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("response")]
    public string Response { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("explanation")]
    public string Explanation { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("arguments")]
    public List<Argument> Arguments { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("errors")]
    public List<Error> Errors { get; set; }
}
