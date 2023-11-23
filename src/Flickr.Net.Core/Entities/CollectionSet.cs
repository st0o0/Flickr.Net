using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

/// <summary>
/// </summary>
public record CollectionSet : FlickrEntityBase<Id>
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("title")]
    public string Title { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("description")]
    public string Description { get; set; }
}