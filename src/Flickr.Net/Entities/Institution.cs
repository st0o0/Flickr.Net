using System.Text.Json.Serialization;
using Flickr.Net.Bases;

namespace Flickr.Net;
/// <summary>Represents a Flickr Commons institution (library, museum, archive).</summary>
public record Institution : FlickrEntityBase<NsId>
{    [JsonPropertyName("date_launch")]
    /// <summary>The launch date.</summary>
    public DateTime LaunchDate { get; init; }
    [JsonPropertyName("name")]
    /// <summary>The display name.</summary>
    public string? Name { get; init; }
    [JsonPropertyName("urls")]
    public Urls? Urls { get; init; }
}
