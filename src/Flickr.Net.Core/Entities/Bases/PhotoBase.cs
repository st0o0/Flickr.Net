using System.Text.Json.Serialization;

namespace Flickr.Net.Core.Bases;

/// <summary>
/// </summary>
public abstract record PhotoBase : FlickrEntityBase<Id>
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("secret")]
    public string Secret { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("server")]
    public string Server { get; set; }
}

/// <summary>
/// </summary>
public abstract record DeluxePhotoBase : PhotoBase
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("owner")]
    public string Owner { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("farm")]
    public string Farm { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("title")]
    public string Title { get; set; }
}

/// <summary>
/// </summary>
public abstract record UltraDeluxePhotoBase : DeluxePhotoBase
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("ispublic")]
    public bool IsPublic { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("isfriend")]
    public bool IsFriend { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("isfamily")]
    public bool IsFamily { get; set; }
}
