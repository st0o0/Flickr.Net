namespace Flickr.Net.Enums;

/// <summary>
/// Which photo search extras to be included. Can be combined to include more than one value.
/// </summary>
/// <example>
/// The following code sets options to return both the license and owner name along with the other
/// search results.
/// <code>
///PhotoSearchOptions options = new PhotoSearchOptions();
///options.Extras = PhotoSearchExtras.License &amp; PhotoSearchExtras.OwnerName
/// </code>
/// </example>
[Flags]
public enum PhotoSearchExtras : long
{
    /// <summary>
    /// No extras selected.
    /// </summary>
    [EnumMember(Value = "")]
    None = 0,

    /// <summary>
    /// Returns a license.
    /// </summary>
    [EnumMember(Value = "license")]
    License = 1 << 0,

    /// <summary>
    /// Returned the date the photos was uploaded.
    /// </summary>
    [EnumMember(Value = "date_upload")]
    DateUploaded = 1 << 1,

    /// <summary>
    /// Returned the date the photo was taken.
    /// </summary>
    [EnumMember(Value = "date_taken")]
    DateTaken = 1 << 2,

    /// <summary>
    /// Returns the name of the owner of the photo.
    /// </summary>
    [EnumMember(Value = "owner_name")]
    OwnerName = 1 << 3,

    /// <summary>
    /// Returns the server for the buddy icon for this user.
    /// </summary>
    [EnumMember(Value = "icon_server")]
    IconServer = 1 << 4,

    /// <summary>
    /// Returns the extension for the original format of this photo.
    /// </summary>
    [EnumMember(Value = "original_format")]
    OriginalFormat = 1 << 5,

    /// <summary>
    /// Returns the date the photo was last updated.
    /// </summary>
    [EnumMember(Value = "last_update")]
    LastUpdated = 1 << 6,

    /// <summary>
    /// Returns Tags attribute
    /// </summary>
    [EnumMember(Value = "tags")]
    Tags = 1 << 7,

    /// <summary>
    /// Geo-location information
    /// </summary>
    [EnumMember(Value = "geo")]
    Geo = 1 << 8,

    /// <summary>
    /// Machine encoded tags
    /// </summary>
    [EnumMember(Value = "machine_tags")]
    MachineTags = 1 << 9,

    /// <summary>
    /// Return the Dimensions of the Original Image.
    /// </summary>
    [EnumMember(Value = "o_dims")]
    OriginalDimensions = 1 << 10,

    /// <summary>
    /// Returns the number of views for a photo.
    /// </summary>
    [EnumMember(Value = "views")]
    Views = 1 << 11,

    /// <summary>
    /// Returns the media type of the photo, currently either 'photo' or 'video'.
    /// </summary>
    [EnumMember(Value = "media")]
    Media = 1 << 12,

    /// <summary>
    /// The path alias, if defined by the user (replaces the users NSID in the flickr URL for their photostream).
    /// </summary>
    [EnumMember(Value = "path_alias")]
    PathAlias = 1 << 13,

    /// <summary>
    /// Returns the URL for the square image, as well as the image size.
    /// </summary>
    [EnumMember(Value = "url_sq")]
    SquareUrl = 1 << 14,

    /// <summary>
    /// Returns the URL for the thumbnail image, as well as the image size.
    /// </summary>
    [EnumMember(Value = "url_t")]
    ThumbnailUrl = 1 << 15,

    /// <summary>
    /// Returns the URL for the small image, as well as the image size.
    /// </summary>
    [EnumMember(Value = "url_s")]
    SmallUrl = 1 << 16,

    /// <summary>
    /// Returns the URL for the medium image, as well as the image size.
    /// </summary>
    [EnumMember(Value = "url_m")]
    MediumUrl = 1 << 17,

    /// <summary>
    /// Returns the URL for the large image, as well as the image size.
    /// </summary>
    [EnumMember(Value = "url_l")]
    LargeUrl = 1 << 18,

    /// <summary>
    /// Returns the URL for the original image, as well as the image size.
    /// </summary>
    [EnumMember(Value = "url_o")]
    OriginalUrl = 1 << 19,

    /// <summary>
    /// Returns the description for the image.
    /// </summary>
    [EnumMember(Value = "description")]
    Description = 1 << 20,

    /// <summary>
    /// Returns the details of CanBlog, CanDownload etc.
    /// </summary>
    [EnumMember(Value = "usage")]
    Usage = 1 << 21,

    /// <summary>
    /// Returns the details for IsPublic, IsFamily and IsFriend.
    /// </summary>
    [EnumMember(Value = "visibility")]
    Visibility = 1 << 22,

    /// <summary>
    /// Large (150x150) square image.
    /// </summary>
    [EnumMember(Value = "url_q")]
    LargeSquareUrl = 1 << 23,

    /// <summary>
    /// Small (320 on longest side) image.
    /// </summary>
    [EnumMember(Value = "url_n")]
    Small320Url = 1 << 24,

    /// <summary>
    /// Returns information on rotation of images compared to original
    /// </summary>
    [EnumMember(Value = "rotation")]
    Rotation = 1 << 25,

    /// <summary>
    /// Large (1600 on largest size) image url.
    /// </summary>
    [EnumMember(Value = "url_h")]
    Large1600Url = 1 << 26,

    /// <summary>
    /// Large (2048 on largest size) image url.
    /// </summary>
    [EnumMember(Value = "url_k")]
    Large2048Url = 1 << 27,

    /// <summary>
    /// Medium (800 on largest size) image url.
    /// </summary>
    [EnumMember(Value = "url_c")]
    Medium800Url = 1 << 28,

    /// <summary>
    /// Returns the URL for the medium 640 image, as well as the image size.
    /// </summary>
    [EnumMember(Value = "url_z")]
    Medium640Url = 1 << 29,

    /// <summary>
    /// The number of favorites for this image.
    /// </summary>
    [EnumMember(Value = "count_faves")]
    CountFaves = 1 << 30,

    /// <summary>
    /// THe number of comments for this image.
    /// </summary>
    [EnumMember(Value = "count_comments")]
    CountComments = 1 << 31,

    /// <summary>
    /// Returns the URL for all the images, as well as the image sizes.
    /// </summary>
    AllUrls = SquareUrl | ThumbnailUrl | SmallUrl | MediumUrl | Medium640Url | Medium800Url | LargeUrl | OriginalUrl |
              LargeSquareUrl | Small320Url | Large1600Url | Large2048Url,

    /// <summary>
    /// Returns all the above information.
    /// </summary>
    All = License | DateUploaded | DateTaken | OwnerName | IconServer | OriginalFormat | LastUpdated | Tags | Geo |
          MachineTags | OriginalDimensions | Views | Media | PathAlias | AllUrls | Description | Usage | Visibility |
          Rotation | CountFaves | CountComments,
}