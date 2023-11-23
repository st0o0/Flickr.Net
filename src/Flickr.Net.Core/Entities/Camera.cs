using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

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