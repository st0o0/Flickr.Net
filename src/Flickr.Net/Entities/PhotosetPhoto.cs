﻿using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Internals.Attributes;

namespace Flickr.Net;

/// <summary>
/// </summary>
[FlickrJsonPropertyName("photo")]
public record PhotosetPhoto : PhotoBase
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("farm")]
    public int Farm { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("title")]
    public string Title { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("isprimary")]
    public bool IsPrimary { get; set; }

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
