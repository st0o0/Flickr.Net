using System.Text.Json.Serialization;
using Flickr.Net.Bases;

namespace Flickr.Net;

/// <summary>
/// </summary>
public record Brand : FlickrEntityBase<Id>
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("_content")]
    public string Content { get; set; }
}