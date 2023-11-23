using System.Text.Json.Serialization;
using Flickr.Net.Bases;

namespace Flickr.Net;

/// <summary>
/// </summary>
public record Camera : FlickrEntityBase<Id>
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("details")]
    public Details Details { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("images")]
    public Image Image { get; set; }
}