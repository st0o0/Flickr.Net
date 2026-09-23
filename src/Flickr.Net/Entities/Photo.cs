using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Internals.Attributes;

namespace Flickr.Net;

[FlickrJsonPropertyName("photo")]
/// <summary>Represents a photo returned from a Flickr search or listing.</summary>
public record Photo : UltraDeluxePhotoBase
{
    /// <summary>
    /// Dead field: no current Flickr API response that deserializes into
    /// <see cref="Photo"/> includes the "dateadded" attribute
    /// (flickr.photos.search returns dateupload, and the endpoint that does
    /// return dateadded — flickr.photosets.getPhotos — deserializes into
    /// <see cref="PhotosetPhoto"/>, which does not map it). This property
    /// is therefore never populated and always returns
    /// <see langword="default"/>(<see cref="DateTime"/>). Use
    /// <see cref="DateUploaded"/> (via PhotoSearchExtras.DateUploaded)
    /// instead.
    /// </summary>
    [JsonPropertyName("dateadded")]
    [Obsolete("Photo.AddedDate is never populated by any current Flickr API response and always returns default(DateTime). Use Photo.DateUploaded (PhotoSearchExtras.DateUploaded) instead.")]
    public DateTime AddedDate { get; init; }
    [JsonPropertyName("datetaken")]
    /// <summary>The date the photo was taken.</summary>
    public DateTime DateTaken { get; init; }

    /// <summary>
    /// The date the photo was uploaded (posted) to Flickr, as a unix
    /// timestamp in seconds. Only populated when
    /// PhotoSearchExtras.DateUploaded is included in the search's Extras.
    /// The shared TimestampToDateTimeConverter handles the conversion to
    /// DateTime (UTC). Unlike "datetaken", this attribute is only emitted
    /// for flickr.photos.search results when the extra is requested.
    /// </summary>
    [JsonPropertyName("dateupload")]
    public DateTime DateUploaded { get; init; }

    /// <summary>
    /// The description of the photo.
    /// </summary>
    [JsonPropertyName("description")]
    public Description Description { get; init; }

    /// <summary>
    /// A space-delimited list of all tags on the photo. Only populated
    /// when PhotoSearchExtras.Tags is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("tags")]
    public string? Tags { get; init; }

    /// <summary>
    /// The width of the original image, as a string. Only populated when
    /// PhotoSearchExtras.OriginalDimensions is included in the search's Extras.
    /// Note: Flickr returns this value as a string, unlike the size-specific
    /// width/height fields which are numbers.
    /// </summary>
    [JsonPropertyName("o_width")]
    public string? OriginalWidth { get; init; }

    /// <summary>
    /// The height of the original image, as a string. Only populated when
    /// PhotoSearchExtras.OriginalDimensions is included in the search's Extras.
    /// Note: Flickr returns this value as a string, unlike the size-specific
    /// width/height fields which are numbers.
    /// </summary>
    [JsonPropertyName("o_height")]
    public string? OriginalHeight { get; init; }

    /// <summary>
    /// The URL of the square (75x75) version of the photo. Only populated when
    /// PhotoSearchExtras.SquareUrl is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("url_sq")]
    public string? SquareUrl { get; init; }

    /// <summary>
    /// The width of the square version of the photo. Only populated when
    /// PhotoSearchExtras.SquareUrl is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("width_sq")]
    public int? SquareWidth { get; init; }

    /// <summary>
    /// The height of the square version of the photo. Only populated when
    /// PhotoSearchExtras.SquareUrl is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("height_sq")]
    public int? SquareHeight { get; init; }

    /// <summary>
    /// The URL of the large square (150x150) version of the photo. Only populated when
    /// PhotoSearchExtras.LargeSquareUrl is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("url_q")]
    public string? LargeSquareUrl { get; init; }

    /// <summary>
    /// The width of the large square version of the photo. Only populated when
    /// PhotoSearchExtras.LargeSquareUrl is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("width_q")]
    public int? LargeSquareWidth { get; init; }

    /// <summary>
    /// The height of the large square version of the photo. Only populated when
    /// PhotoSearchExtras.LargeSquareUrl is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("height_q")]
    public int? LargeSquareHeight { get; init; }

    /// <summary>
    /// The URL of the thumbnail (100 on longest side) version of the photo. Only populated when
    /// PhotoSearchExtras.ThumbnailUrl is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("url_t")]
    public string? ThumbnailUrl { get; init; }

    /// <summary>
    /// The width of the thumbnail version of the photo. Only populated when
    /// PhotoSearchExtras.ThumbnailUrl is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("width_t")]
    public int? ThumbnailWidth { get; init; }

    /// <summary>
    /// The height of the thumbnail version of the photo. Only populated when
    /// PhotoSearchExtras.ThumbnailUrl is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("height_t")]
    public int? ThumbnailHeight { get; init; }

    /// <summary>
    /// The URL of the small (240 on longest side) version of the photo. Only populated when
    /// PhotoSearchExtras.SmallUrl is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("url_s")]
    public string? SmallUrl { get; init; }

    /// <summary>
    /// The width of the small version of the photo. Only populated when
    /// PhotoSearchExtras.SmallUrl is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("width_s")]
    public int? SmallWidth { get; init; }

    /// <summary>
    /// The height of the small version of the photo. Only populated when
    /// PhotoSearchExtras.SmallUrl is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("height_s")]
    public int? SmallHeight { get; init; }

    /// <summary>
    /// The URL of the small 320 (320 on longest side) version of the photo. Only populated when
    /// PhotoSearchExtras.Small320Url is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("url_n")]
    public string? Small320Url { get; init; }

    /// <summary>
    /// The width of the small 320 version of the photo. Only populated when
    /// PhotoSearchExtras.Small320Url is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("width_n")]
    public int? Small320Width { get; init; }

    /// <summary>
    /// The height of the small 320 version of the photo. Only populated when
    /// PhotoSearchExtras.Small320Url is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("height_n")]
    public int? Small320Height { get; init; }

    /// <summary>
    /// The URL of the medium (500 on longest side) version of the photo. Only populated when
    /// PhotoSearchExtras.MediumUrl is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("url_m")]
    public string? MediumUrl { get; init; }

    /// <summary>
    /// The width of the medium version of the photo. Only populated when
    /// PhotoSearchExtras.MediumUrl is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("width_m")]
    public int? MediumWidth { get; init; }

    /// <summary>
    /// The height of the medium version of the photo. Only populated when
    /// PhotoSearchExtras.MediumUrl is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("height_m")]
    public int? MediumHeight { get; init; }

    /// <summary>
    /// The URL of the medium 640 (640 on longest side) version of the photo. Only populated when
    /// PhotoSearchExtras.Medium640Url is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("url_z")]
    public string? Medium640Url { get; init; }

    /// <summary>
    /// The width of the medium 640 version of the photo. Only populated when
    /// PhotoSearchExtras.Medium640Url is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("width_z")]
    public int? Medium640Width { get; init; }

    /// <summary>
    /// The height of the medium 640 version of the photo. Only populated when
    /// PhotoSearchExtras.Medium640Url is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("height_z")]
    public int? Medium640Height { get; init; }

    /// <summary>
    /// The URL of the medium 800 (800 on longest side) version of the photo. Only populated when
    /// PhotoSearchExtras.Medium800Url is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("url_c")]
    public string? Medium800Url { get; init; }

    /// <summary>
    /// The width of the medium 800 version of the photo. Only populated when
    /// PhotoSearchExtras.Medium800Url is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("width_c")]
    public int? Medium800Width { get; init; }

    /// <summary>
    /// The height of the medium 800 version of the photo. Only populated when
    /// PhotoSearchExtras.Medium800Url is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("height_c")]
    public int? Medium800Height { get; init; }

    /// <summary>
    /// The URL of the large (1024 on longest side) version of the photo. Only populated when
    /// PhotoSearchExtras.LargeUrl is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("url_l")]
    public string? LargeUrl { get; init; }

    /// <summary>
    /// The width of the large version of the photo. Only populated when
    /// PhotoSearchExtras.LargeUrl is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("width_l")]
    public int? LargeWidth { get; init; }

    /// <summary>
    /// The height of the large version of the photo. Only populated when
    /// PhotoSearchExtras.LargeUrl is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("height_l")]
    public int? LargeHeight { get; init; }

    /// <summary>
    /// The URL of the large 1600 (1600 on longest side) version of the photo. Only populated when
    /// PhotoSearchExtras.Large1600Url is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("url_h")]
    public string? Large1600Url { get; init; }

    /// <summary>
    /// The width of the large 1600 version of the photo. Only populated when
    /// PhotoSearchExtras.Large1600Url is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("width_h")]
    public int? Large1600Width { get; init; }

    /// <summary>
    /// The height of the large 1600 version of the photo. Only populated when
    /// PhotoSearchExtras.Large1600Url is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("height_h")]
    public int? Large1600Height { get; init; }

    /// <summary>
    /// The URL of the large 2048 (2048 on longest side) version of the photo. Only populated when
    /// PhotoSearchExtras.Large2048Url is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("url_k")]
    public string? Large2048Url { get; init; }

    /// <summary>
    /// The width of the large 2048 version of the photo. Only populated when
    /// PhotoSearchExtras.Large2048Url is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("width_k")]
    public int? Large2048Width { get; init; }

    /// <summary>
    /// The height of the large 2048 version of the photo. Only populated when
    /// PhotoSearchExtras.Large2048Url is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("height_k")]
    public int? Large2048Height { get; init; }

    /// <summary>
    /// The URL of the original version of the photo. Only populated when
    /// PhotoSearchExtras.OriginalUrl is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("url_o")]
    public string? OriginalUrl { get; init; }

    /// <summary>
    /// The width of the original version of the photo. Only populated when
    /// PhotoSearchExtras.OriginalUrl is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("width_o")]
    public int? OriginalUrlWidth { get; init; }

    /// <summary>
    /// The height of the original version of the photo. Only populated when
    /// PhotoSearchExtras.OriginalUrl is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("height_o")]
    public int? OriginalUrlHeight { get; init; }

    /// <summary>
    /// The latitude of the photo's geolocation. Only populated when
    /// PhotoSearchExtras.Geo is included in the search's Extras and the
    /// photo carries geo data. Flickr returns the value as a string
    /// (e.g. "48.858370"); the shared AutoStringToNumberConverter handles
    /// the conversion to double.
    /// </summary>
    [JsonPropertyName("latitude")]
    public double? Latitude { get; init; }

    /// <summary>
    /// The longitude of the photo's geolocation. Only populated when
    /// PhotoSearchExtras.Geo is included in the search's Extras and the
    /// photo carries geo data. Flickr returns the value as a string
    /// (e.g. "2.294485"); the shared AutoStringToNumberConverter handles
    /// the conversion to double.
    /// </summary>
    [JsonPropertyName("longitude")]
    public double? Longitude { get; init; }

    /// <summary>
    /// The number of times this photo has been favorited. Only populated
    /// when PhotoSearchExtras.CountFaves is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("count_faves")]
    public int? CountFaves { get; init; }

    /// <summary>
    /// The number of comments on this photo. Only populated when
    /// PhotoSearchExtras.CountComments is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("count_comments")]
    public int? CountComments { get; init; }

    /// <summary>
    /// The media type, currently either "photo" or "video". Only populated
    /// when PhotoSearchExtras.Media is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("media")]
    public string? Media { get; init; }

    /// <summary>
    /// The media processing status. Only populated when
    /// PhotoSearchExtras.Media is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("media_status")]
    public string? MediaStatus { get; init; }

    /// <summary>
    /// The path alias defined by the user, replacing the NSID in
    /// the photostream URL. Only populated when
    /// PhotoSearchExtras.PathAlias is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("pathalias")]
    public string? PathAlias { get; init; }

    /// <summary>
    /// The display name of the photo owner. Only populated when
    /// PhotoSearchExtras.OwnerName is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("ownername")]
    public string? OwnerName { get; init; }

    /// <summary>
    /// The number of times this photo has been viewed. Only populated
    /// when PhotoSearchExtras.Views is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("views")]
    public int? Views { get; init; }

    /// <summary>
    /// The license type identifier. Only populated when
    /// PhotoSearchExtras.License is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("license")]
    public int? License { get; init; }

    /// <summary>
    /// A space-delimited list of machine tags. Only populated when
    /// PhotoSearchExtras.MachineTags is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("machine_tags")]
    public string? MachineTags { get; init; }

    /// <summary>
    /// The file extension of the original image (e.g. "jpg", "png").
    /// Only populated when PhotoSearchExtras.OriginalFormat is included
    /// in the search's Extras.
    /// </summary>
    [JsonPropertyName("originalformat")]
    public string? OriginalFormat { get; init; }

    /// <summary>
    /// The secret required to construct the original image URL.
    /// Only populated when PhotoSearchExtras.OriginalFormat is included
    /// in the search's Extras.
    /// </summary>
    [JsonPropertyName("originalsecret")]
    public string? OriginalSecret { get; init; }

    /// <summary>
    /// The rotation applied to this photo compared to the original.
    /// Only populated when PhotoSearchExtras.Rotation is included
    /// in the search's Extras.
    /// </summary>
    [JsonPropertyName("rotation")]
    public int? Rotation { get; init; }

    /// <summary>
    /// The date the photo was last updated. Only populated when
    /// PhotoSearchExtras.LastUpdated is included in the search's Extras.
    /// Value is a unix timestamp converted to DateTime.
    /// </summary>
    [JsonPropertyName("lastupdate")]
    public DateTime? LastUpdate { get; init; }

    /// <summary>
    /// The accuracy of the geolocation (1-16, world-street level).
    /// Only populated when PhotoSearchExtras.Geo is included in the
    /// search's Extras.
    /// </summary>
    [JsonPropertyName("accuracy")]
    public int? Accuracy { get; init; }

    /// <summary>
    /// The photo context (0 = not in a set, 1 = in a set, 2 = in a pool).
    /// </summary>
    [JsonPropertyName("context")]
    public int? Context { get; init; }

    /// <summary>
    /// The Flickr Places identifier for the photo's location. Only
    /// populated when PhotoSearchExtras.Geo is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("place_id")]
    public string? PlaceId { get; init; }

    /// <summary>
    /// The Where On Earth identifier for the photo's location. Only
    /// populated when PhotoSearchExtras.Geo is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("woeid")]
    public string? WoeId { get; init; }

    /// <summary>
    /// Whether family can see the photo's geolocation. Only populated
    /// when PhotoSearchExtras.Geo is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("geo_is_family")]
    public bool? GeoIsFamily { get; init; }

    /// <summary>
    /// Whether friends can see the photo's geolocation. Only populated
    /// when PhotoSearchExtras.Geo is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("geo_is_friend")]
    public bool? GeoIsFriend { get; init; }

    /// <summary>
    /// Whether contacts can see the photo's geolocation. Only populated
    /// when PhotoSearchExtras.Geo is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("geo_is_contact")]
    public bool? GeoIsContact { get; init; }

    /// <summary>
    /// Whether the photo's geolocation is public. Only populated when
    /// PhotoSearchExtras.Geo is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("geo_is_public")]
    public bool? GeoIsPublic { get; init; }

    /// <summary>
    /// The server for the owner's buddy icon. Only populated when
    /// PhotoSearchExtras.IconServer is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("iconserver")]
    public string? IconServer { get; init; }

    /// <summary>
    /// The farm for the owner's buddy icon. Only populated when
    /// PhotoSearchExtras.IconServer is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("iconfarm")]
    public int? IconFarm { get; init; }
}
