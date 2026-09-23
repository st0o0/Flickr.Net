using System.Text.Json.Serialization;
using Flickr.Net.Bases;

namespace Flickr.Net;

/// <inheritdoc/>
public record TagBase : FlickrEntityBase
{
    [JsonPropertyName("_content")]
    /// <summary>The text content.</summary>
    public string? Content { get; init; }
}
