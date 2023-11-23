using System.Text.Json.Serialization;

namespace Flickr.Net.Bases;

/// <inheritdoc/>
public record GroupBase : FlickrEntityBase<NsId>
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("eighteenplus")]
    public bool EighteenPlus { get; set; }
}
