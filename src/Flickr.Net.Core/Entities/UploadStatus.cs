using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

/// <summary>
/// </summary>
[FlickrJsonPropertyName("user")]
public record UploadStatus : FlickrEntityBase<Id>
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("ispro")]
    public bool IsPro { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("username")]
    public string Username { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("bandwidth")]
    public BandwidthStatus Bandwidth { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("filesize")]
    public FileSizeStatus Filesize { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("sets")]
    public SetsStatus Sets { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("videos")]
    public VideoStatus Videos { get; set; }
}

/// <summary>
/// </summary>
public record VideoStatus
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("uploaded")]
    public int Uploaded { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("remaining")]
    public string Remaining { get; set; }
}

/// <summary>
/// </summary>
public record SetsStatus
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("created")]
    public int Created { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("remaining")]
    public string Remaining { get; set; }
}

/// <summary>
/// </summary>
public record FileSizeStatus
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("maxbytes")]
    public long MaxBytes { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("maxkb")]
    public long MaxKb { get; set; }
}

/// <summary>
/// </summary>
public record BandwidthStatus
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("maxbytes")]
    public long MaxBytes { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("maxkb")]
    public long MaxKb { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("usedbytes")]
    public long UsedBytes { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("usedkb")]
    public long UsedKb { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("remainingbytes")]
    public long RemainingBytes { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("remainingkb")]
    public long RemainingKb { get; set; }
}