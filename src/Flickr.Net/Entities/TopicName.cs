using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Internals.Attributes;

namespace Flickr.Net;
[FlickrJsonPropertyName("topic")]
/// <summary>Wraps a topic name text value.</summary>
public record TopicName : FlickrEntityBase
{    [JsonPropertyName("name")]
    /// <summary>The display name.</summary>
    public string? Name { get; init; }
    [JsonPropertyName("display_name")]
    public string? DisplayName { get; init; }
}
