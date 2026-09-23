using System.Text.Json.Serialization;
using Flickr.Net.Bases;

namespace Flickr.Net;

/// <summary>Represents a single license change event for a photo.</summary>
public record LicenseHistoryEntry : FlickrEntityBase
{
    /// <summary>The previous license ID before the change.</summary>
    [JsonPropertyName("old_license")]
    public int? OldLicense { get; init; }

    /// <summary>The new license ID after the change.</summary>
    [JsonPropertyName("new_license")]
    public int? NewLicense { get; init; }

    /// <summary>The date the license was changed.</summary>
    [JsonPropertyName("date_change")]
    public string? DateChange { get; init; }
}
