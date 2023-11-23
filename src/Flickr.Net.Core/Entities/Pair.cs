using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

/// <summary>
/// </summary>
public record Pair : FlickrEntityBase
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("namespace")]
    public string Namespace { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("predicate")]
    public string Predicate { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("usage")]
    public string Usage { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("_content")]
    public string Content { get; set; }
}