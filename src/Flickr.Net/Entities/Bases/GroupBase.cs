using System.Text.Json.Serialization;

namespace Flickr.Net.Bases;

/// <inheritdoc/>
public record GroupBase : FlickrEntityBase<NsId>
{    [JsonPropertyName("name")]
    /// <summary>The display name.</summary>
    public string? Name { get; init; }
    [JsonPropertyName("eighteenplus")]
    /// <summary>Whether the group is restricted to 18+ content.</summary>
    public bool EighteenPlus { get; init; }
}
