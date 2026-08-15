using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Internals.Attributes;

namespace Flickr.Net;

/// <summary>
/// </summary>
[FlickrJsonPropertyName("photo")]
public record Photo : UltraDeluxePhotoBase
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("dateadded")]
    public DateTime AddedDate { get; set; }
    /// <summary>
    /// </summary>
    [JsonPropertyName("datetaken")]
    public DateTime DateTaken { get; set; }

    /// <summary>
    /// The description of the photo.
    /// </summary>
    [JsonPropertyName("description")]
    public Description Description { get; set; }

    /// <summary>
    /// A space-delimited list of all tags on the photo. Only populated
    /// when PhotoSearchExtras.Tags is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("tags")]
    public string? Tags { get; set; }

    /// <summary>
    /// The width of the original image, as a string. Only populated when
    /// PhotoSearchExtras.OriginalDimensions is included in the search's Extras.
    /// Note: Flickr returns this value as a string, unlike the size-specific
    /// width/height fields which are numbers.
    /// </summary>
    [JsonPropertyName("o_width")]
    public string? OriginalWidth { get; set; }

    /// <summary>
    /// The height of the original image, as a string. Only populated when
    /// PhotoSearchExtras.OriginalDimensions is included in the search's Extras.
    /// Note: Flickr returns this value as a string, unlike the size-specific
    /// width/height fields which are numbers.
    /// </summary>
    [JsonPropertyName("o_height")]
    public string? OriginalHeight { get; set; }

    /// <summary>
    /// The URL of the square (75x75) version of the photo. Only populated when
    /// PhotoSearchExtras.SquareUrl is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("url_sq")]
    public string? SquareUrl { get; set; }

    /// <summary>
    /// The width of the square version of the photo. Only populated when
    /// PhotoSearchExtras.SquareUrl is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("width_sq")]
    public int? SquareWidth { get; set; }

    /// <summary>
    /// The height of the square version of the photo. Only populated when
    /// PhotoSearchExtras.SquareUrl is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("height_sq")]
    public int? SquareHeight { get; set; }

    /// <summary>
    /// The URL of the large square (150x150) version of the photo. Only populated when
    /// PhotoSearchExtras.LargeSquareUrl is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("url_q")]
    public string? LargeSquareUrl { get; set; }

    /// <summary>
    /// The width of the large square version of the photo. Only populated when
    /// PhotoSearchExtras.LargeSquareUrl is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("width_q")]
    public int? LargeSquareWidth { get; set; }

    /// <summary>
    /// The height of the large square version of the photo. Only populated when
    /// PhotoSearchExtras.LargeSquareUrl is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("height_q")]
    public int? LargeSquareHeight { get; set; }

    /// <summary>
    /// The URL of the thumbnail (100 on longest side) version of the photo. Only populated when
    /// PhotoSearchExtras.ThumbnailUrl is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("url_t")]
    public string? ThumbnailUrl { get; set; }

    /// <summary>
    /// The width of the thumbnail version of the photo. Only populated when
    /// PhotoSearchExtras.ThumbnailUrl is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("width_t")]
    public int? ThumbnailWidth { get; set; }

    /// <summary>
    /// The height of the thumbnail version of the photo. Only populated when
    /// PhotoSearchExtras.ThumbnailUrl is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("height_t")]
    public int? ThumbnailHeight { get; set; }

    /// <summary>
    /// The URL of the small (240 on longest side) version of the photo. Only populated when
    /// PhotoSearchExtras.SmallUrl is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("url_s")]
    public string? SmallUrl { get; set; }

    /// <summary>
    /// The width of the small version of the photo. Only populated when
    /// PhotoSearchExtras.SmallUrl is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("width_s")]
    public int? SmallWidth { get; set; }

    /// <summary>
    /// The height of the small version of the photo. Only populated when
    /// PhotoSearchExtras.SmallUrl is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("height_s")]
    public int? SmallHeight { get; set; }

    /// <summary>
    /// The URL of the small 320 (320 on longest side) version of the photo. Only populated when
    /// PhotoSearchExtras.Small320Url is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("url_n")]
    public string? Small320Url { get; set; }

    /// <summary>
    /// The width of the small 320 version of the photo. Only populated when
    /// PhotoSearchExtras.Small320Url is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("width_n")]
    public int? Small320Width { get; set; }

    /// <summary>
    /// The height of the small 320 version of the photo. Only populated when
    /// PhotoSearchExtras.Small320Url is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("height_n")]
    public int? Small320Height { get; set; }

    /// <summary>
    /// The URL of the medium (500 on longest side) version of the photo. Only populated when
    /// PhotoSearchExtras.MediumUrl is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("url_m")]
    public string? MediumUrl { get; set; }

    /// <summary>
    /// The width of the medium version of the photo. Only populated when
    /// PhotoSearchExtras.MediumUrl is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("width_m")]
    public int? MediumWidth { get; set; }

    /// <summary>
    /// The height of the medium version of the photo. Only populated when
    /// PhotoSearchExtras.MediumUrl is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("height_m")]
    public int? MediumHeight { get; set; }

    /// <summary>
    /// The URL of the medium 640 (640 on longest side) version of the photo. Only populated when
    /// PhotoSearchExtras.Medium640Url is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("url_z")]
    public string? Medium640Url { get; set; }

    /// <summary>
    /// The width of the medium 640 version of the photo. Only populated when
    /// PhotoSearchExtras.Medium640Url is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("width_z")]
    public int? Medium640Width { get; set; }

    /// <summary>
    /// The height of the medium 640 version of the photo. Only populated when
    /// PhotoSearchExtras.Medium640Url is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("height_z")]
    public int? Medium640Height { get; set; }

    /// <summary>
    /// The URL of the medium 800 (800 on longest side) version of the photo. Only populated when
    /// PhotoSearchExtras.Medium800Url is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("url_c")]
    public string? Medium800Url { get; set; }

    /// <summary>
    /// The width of the medium 800 version of the photo. Only populated when
    /// PhotoSearchExtras.Medium800Url is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("width_c")]
    public int? Medium800Width { get; set; }

    /// <summary>
    /// The height of the medium 800 version of the photo. Only populated when
    /// PhotoSearchExtras.Medium800Url is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("height_c")]
    public int? Medium800Height { get; set; }

    /// <summary>
    /// The URL of the large (1024 on longest side) version of the photo. Only populated when
    /// PhotoSearchExtras.LargeUrl is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("url_l")]
    public string? LargeUrl { get; set; }

    /// <summary>
    /// The width of the large version of the photo. Only populated when
    /// PhotoSearchExtras.LargeUrl is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("width_l")]
    public int? LargeWidth { get; set; }

    /// <summary>
    /// The height of the large version of the photo. Only populated when
    /// PhotoSearchExtras.LargeUrl is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("height_l")]
    public int? LargeHeight { get; set; }

    /// <summary>
    /// The URL of the large 1600 (1600 on longest side) version of the photo. Only populated when
    /// PhotoSearchExtras.Large1600Url is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("url_h")]
    public string? Large1600Url { get; set; }

    /// <summary>
    /// The width of the large 1600 version of the photo. Only populated when
    /// PhotoSearchExtras.Large1600Url is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("width_h")]
    public int? Large1600Width { get; set; }

    /// <summary>
    /// The height of the large 1600 version of the photo. Only populated when
    /// PhotoSearchExtras.Large1600Url is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("height_h")]
    public int? Large1600Height { get; set; }

    /// <summary>
    /// The URL of the large 2048 (2048 on longest side) version of the photo. Only populated when
    /// PhotoSearchExtras.Large2048Url is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("url_k")]
    public string? Large2048Url { get; set; }

    /// <summary>
    /// The width of the large 2048 version of the photo. Only populated when
    /// PhotoSearchExtras.Large2048Url is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("width_k")]
    public int? Large2048Width { get; set; }

    /// <summary>
    /// The height of the large 2048 version of the photo. Only populated when
    /// PhotoSearchExtras.Large2048Url is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("height_k")]
    public int? Large2048Height { get; set; }

    /// <summary>
    /// The URL of the original version of the photo. Only populated when
    /// PhotoSearchExtras.OriginalUrl is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("url_o")]
    public string? OriginalUrl { get; set; }

    /// <summary>
    /// The width of the original version of the photo. Only populated when
    /// PhotoSearchExtras.OriginalUrl is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("width_o")]
    public int? OriginalUrlWidth { get; set; }

    /// <summary>
    /// The height of the original version of the photo. Only populated when
    /// PhotoSearchExtras.OriginalUrl is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("height_o")]
    public int? OriginalUrlHeight { get; set; }
}