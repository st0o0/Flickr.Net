using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

[FlickrJsonPropertyName("user")]
public record UploadStatus : FlickrEntityBase<Id>
{
    [JsonPropertyName("ispro")]
    public bool IsPro { get; set; }

    [JsonPropertyName("username")]
    public string Username { get; set; }

    [JsonPropertyName("bandwidth")]
    public BandwidthStatus Bandwidth { get; set; }

    [JsonPropertyName("filesize")]
    public FileSizeStatus Filesize { get; set; }

    [JsonPropertyName("sets")]
    public SetsStatus Sets { get; set; }

    [JsonPropertyName("videos")]
    public VideoStatus Videos { get; set; }
}

public record VideoStatus
{
    [JsonPropertyName("uploaded")]
    public int Uploaded { get; set; }

    [JsonPropertyName("remaining")]
    public string Remaining { get; set; }
}

public record SetsStatus
{
    [JsonPropertyName("created")]
    public int Created { get; set; }

    [JsonPropertyName("remaining")]
    public string Remaining { get; set; }
}

public record FileSizeStatus
{
    [JsonPropertyName("maxbytes")]
    public long MaxBytes { get; set; }

    [JsonPropertyName("maxkb")]
    public long MaxKb { get; set; }
}

public record BandwidthStatus
{
    [JsonPropertyName("maxbytes")]
    public long MaxBytes { get; set; }

    [JsonPropertyName("maxkb")]
    public long MaxKb { get; set; }

    [JsonPropertyName("usedbytes")]
    public long UsedBytes { get; set; }

    [JsonPropertyName("usedkb")]
    public long UsedKb { get; set; }

    [JsonPropertyName("remainingbytes")]
    public long RemainingBytes { get; set; }

    [JsonPropertyName("remainingkb")]
    public long RemainingKb { get; set; }
}