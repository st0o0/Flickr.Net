using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

/// <summary>
/// </summary>
public record Value : FlickrEntityBase
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("usage")]
    public string Usage { get; set; }

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
    [JsonPropertyName("first_added")]
    public DateTime FirstAdded { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("last_added")]
    public DateTime LastAdded { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("_content")]
    public string Content { get; set; }
}