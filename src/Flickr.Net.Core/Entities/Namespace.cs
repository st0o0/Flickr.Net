using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

/// <summary>
/// </summary>
public record Namespace : FlickrEntityBase
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("usage")]
    public string Usage { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("predicates")]
    public string Predicates { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("_content")]
    public string Content { get; set; }
}