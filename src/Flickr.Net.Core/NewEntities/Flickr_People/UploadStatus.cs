using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;
using Newtonsoft.Json;

namespace Flickr.Net.Core;

[FlickrJsonPropertyName("user")]
public record UploadStatus : FlickrEntityBase<Id>
{
    [JsonProperty("ispro")]
    public bool IsPro { get; set; }

    [JsonProperty("username")]
    public string Username { get; set; }

    [JsonProperty("bandwidth")]
    public BandwidthStatus Bandwidth { get; set; }

    [JsonProperty("filesize")]
    public FileSizeStatus Filesize { get; set; }

    [JsonProperty("sets")]
    public SetsStatus Sets { get; set; }

    [JsonProperty("videos")]
    public VideoStatus Videos { get; set; }
}

public record VideoStatus
{
    [JsonProperty("uploaded")]
    public int Uploaded { get; set; }

    [JsonProperty("remaining")]
    public string Remaining { get; set; }
}

public record SetsStatus
{
    [JsonProperty("created")]
    public int Created { get; set; }

    [JsonProperty("remaining")]
    public string Remaining { get; set; }
}

public record FileSizeStatus
{
    [JsonProperty("maxbytes")]
    public long MaxBytes { get; set; }

    [JsonProperty("maxkb")]
    public long MaxKb { get; set; }
}

public record BandwidthStatus
{
    [JsonProperty("maxbytes")]
    public long MaxBytes { get; set; }

    [JsonProperty("maxkb")]
    public long MaxKb { get; set; }

    [JsonProperty("usedbytes")]
    public long UsedBytes { get; set; }

    [JsonProperty("usedkb")]
    public long UsedKb { get; set; }

    [JsonProperty("remainingbytes")]
    public long RemainingBytes { get; set; }

    [JsonProperty("remainingkb")]
    public long RemainingKb { get; set; }
}