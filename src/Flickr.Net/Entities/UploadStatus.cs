using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Internals.Attributes;

namespace Flickr.Net;

[FlickrJsonPropertyName("user")]
/// <summary>Represents a user's upload bandwidth and storage status.</summary>
public record UploadStatus : FlickrEntityBase<Id>
{
    [JsonPropertyName("ispro")]
    /// <summary>Whether the user has a Pro account.</summary>
    public bool IsPro { get; init; }
    [JsonPropertyName("username")]
    /// <summary>The username.</summary>
    public string? Username { get; init; }
    [JsonPropertyName("bandwidth")]
    public BandwidthStatus? Bandwidth { get; init; }
    [JsonPropertyName("filesize")]
    public FileSizeStatus? Filesize { get; init; }
    [JsonPropertyName("sets")]
    public SetsStatus? Sets { get; init; }
    [JsonPropertyName("videos")]
    public VideoStatus? Videos { get; init; }
}
public record VideoStatus
{
    [JsonPropertyName("uploaded")]
    /// <summary>The count of uploads.</summary>
    public int Uploaded { get; init; }
    [JsonPropertyName("remaining")]
    /// <summary>The remaining allowance.</summary>
    public string? Remaining { get; init; }
}
public record SetsStatus
{
    [JsonPropertyName("created")]
    public int Created { get; init; }
    [JsonPropertyName("remaining")]
    /// <summary>The remaining allowance.</summary>
    public string? Remaining { get; init; }
}
public record FileSizeStatus
{
    [JsonPropertyName("maxbytes")]
    /// <summary>The maximum size in bytes.</summary>
    public long MaxBytes { get; init; }
    [JsonPropertyName("maxkb")]
    /// <summary>The maximum size in kilobytes.</summary>
    public long MaxKb { get; init; }
}
public record BandwidthStatus
{
    [JsonPropertyName("maxbytes")]
    /// <summary>The maximum size in bytes.</summary>
    public long MaxBytes { get; init; }
    [JsonPropertyName("maxkb")]
    /// <summary>The maximum size in kilobytes.</summary>
    public long MaxKb { get; init; }
    [JsonPropertyName("usedbytes")]
    /// <summary>The used bytes.</summary>
    public long UsedBytes { get; init; }
    [JsonPropertyName("usedkb")]
    /// <summary>The used kilobytes.</summary>
    public long UsedKb { get; init; }
    [JsonPropertyName("remainingbytes")]
    /// <summary>The remaining bytes.</summary>
    public long RemainingBytes { get; init; }
    [JsonPropertyName("remainingkb")]
    /// <summary>The remaining kilobytes.</summary>
    public long RemainingKb { get; init; }
}
