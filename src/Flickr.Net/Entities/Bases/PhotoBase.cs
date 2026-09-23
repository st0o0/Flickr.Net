using System.Text.Json.Serialization;

namespace Flickr.Net.Bases;

/// <inheritdoc/>
public abstract record PhotoBase : FlickrEntityBase<Id>
{    [JsonPropertyName("secret")]
    /// <summary>The photo secret used in URL construction.</summary>
    public string? Secret { get; init; }
    [JsonPropertyName("server")]
    /// <summary>The server identifier used in URL construction.</summary>
    public string? Server { get; init; }
}

/// <inheritdoc/>
public abstract record DeluxePhotoBase : PhotoBase
{    [JsonPropertyName("owner")]
    /// <summary>The NSID of the owner.</summary>
    public string? Owner { get; init; }
    [JsonPropertyName("farm")]
    /// <summary>The farm identifier used in URL construction.</summary>
    public string? Farm { get; init; }
    [JsonPropertyName("title")]
    /// <summary>The title.</summary>
    public string? Title { get; init; }
}

/// <inheritdoc/>
public abstract record UltraDeluxePhotoBase : DeluxePhotoBase
{    [JsonPropertyName("ispublic")]
    /// <summary>Whether the content is publicly visible.</summary>
    public bool IsPublic { get; init; }
    [JsonPropertyName("isfriend")]
    /// <summary>Whether the content is visible to friends.</summary>
    public bool IsFriend { get; init; }
    [JsonPropertyName("isfamily")]
    /// <summary>Whether the content is visible to family.</summary>
    public bool IsFamily { get; init; }
}
