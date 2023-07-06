using Flickr.Net.Core.Internals.Extensions;

namespace Flickr.Net.Core;

/// <summary>
/// Summary description for PhotoSearchOptions.
/// </summary>
public record PhotoSearchOptions
{
    /// <summary>
    /// Creates a new instance of the search options.
    /// </summary>
    public PhotoSearchOptions()
    {
        ColorCodes = new Collection<string>();
    }

    /// <summary>
    /// Creates a new instance of the search options, setting the UserId property to the parameter
    /// passed in.
    /// </summary>
    /// <param name="userId">The ID of the User to search for.</param>
    public PhotoSearchOptions(string userId) : this(userId, null, TagMode.AllTags, null)
    { }

    /// <summary>
    /// Create an instance of the <see cref="PhotoSearchOptions"/> for a given user ID and tag list.
    /// </summary>
    /// <param name="userId">The ID of the User to search for.</param>
    /// <param name="tags">The tags (comma delimited) to search for. Will match all tags.</param>
    public PhotoSearchOptions(string userId, string tags) : this(userId, tags, TagMode.AllTags, null)
    { }

    /// <summary>
    /// Create an instance of the <see cref="PhotoSearchOptions"/> for a given user ID and tag list,
    /// with the selected tag mode.
    /// </summary>
    /// <param name="userId">The ID of the User to search for.</param>
    /// <param name="tags">The tags (comma delimited) to search for.</param>
    /// <param name="tagMode">The <see cref="TagMode"/> to use to search.</param>
    public PhotoSearchOptions(string userId, string tags, TagMode tagMode) : this(userId, tags, tagMode, null)
    { }

    /// <summary>
    /// Create an instance of the <see cref="PhotoSearchOptions"/> for a given user ID and tag list,
    /// with the selected tag mode, and containing the selected text.
    /// </summary>
    /// <param name="userId">The ID of the User to search for.</param>
    /// <param name="tags">The tags (comma delimited) to search for.</param>
    /// <param name="tagMode">The <see cref="TagMode"/> to use to search.</param>
    /// <param name="text">The text to search for in photo title and descriptions.</param>
    public PhotoSearchOptions(string userId, string tags, TagMode tagMode, string text)
    {
        UserId = userId;
        Tags = tags;
        TagMode = tagMode;
        Text = text;
    }

    /// <summary>
    /// The user Id of the user to search on. Defaults to null for no specific user.
    /// </summary>
    public string UserId { get; init; }

    /// <summary>
    /// The geocontext for the resulting photos.
    /// </summary>
    public GeoContext GeoContext { get; init; }

    /// <summary>
    /// The group id of the group to search within.
    /// </summary>
    public string GroupId { get; init; }

    /// <summary>
    /// A comma delimited list of tags
    /// </summary>
    public string Tags { get; init; }

    /// <summary>
    /// Tag mode can either be 'all', or 'any'. Defaults to <see cref="TagMode.AllTags"/>
    /// </summary>
    public TagMode TagMode { get; init; }

    /// <summary>
    /// Search for the given machine tags.
    /// </summary>
    /// <remarks>
    /// See https://www.flickr.com/services/api/flickr.photos.search.html for details on how to
    /// search for machine tags.
    /// </remarks>
    public string MachineTags { get; init; }

    /// <summary>
    /// The machine tag mode.
    /// </summary>
    /// <remarks>Allowed values are any and all. It defaults to any if none specified.</remarks>
    public MachineTagMode MachineTagMode { get; init; }

    /// <summary>
    /// Search for the given text in photo titles and descriptions.
    /// </summary>
    public string Text { get; init; }

    /// <summary>
    /// Minimum date uploaded. Defaults to <see cref="DateTime.MinValue"/> which signifies that the
    /// value is not to be used.
    /// </summary>
    public DateTime MinUploadDate { get; init; }

    /// <summary>
    /// Maximum date uploaded. Defaults to <see cref="DateTime.MinValue"/> which signifies that the
    /// value is not to be used.
    /// </summary>
    public DateTime MaxUploadDate { get; init; }

    /// <summary>
    /// Minimum date taken. Defaults to <see cref="DateTime.MinValue"/> which signifies that the
    /// value is not to be used.
    /// </summary>
    public DateTime MinTakenDate { get; init; }

    /// <summary>
    /// Maximum date taken. Defaults to <see cref="DateTime.MinValue"/> which signifies that the
    /// value is not to be used.
    /// </summary>
    public DateTime MaxTakenDate { get; init; }

    /// <summary>
    /// Filter by media type.
    /// </summary>
    public MediaType MediaType { get; init; }

    /// <summary>
    /// The licenses you wish to search for.
    /// </summary>
    public Collection<LicenseType> Licenses { get; init; } = new();

    /// <summary>
    /// Optional extras to return, defaults to all. See <see cref="PhotoSearchExtras"/> for more details.
    /// </summary>
    public PhotoSearchExtras Extras { get; init; }

    /// <summary>
    /// Number of photos to return per page. Defaults to 100.
    /// </summary>
    public int PerPage { get; init; }

    /// <summary>
    /// The page to return. Defaults to page 1.
    /// </summary>
    public int Page { get; init; }

    /// <summary>
    /// The sort order of the returned list. Default is <see cref="PhotoSearchSortOrder.None"/>.
    /// </summary>
    public PhotoSearchSortOrder SortOrder { get; init; }

    /// <summary>
    /// The privacy fitler to filter the search on.
    /// </summary>
    public PrivacyFilter PrivacyFilter { get; init; }

    /// <summary>
    /// The boundary box for which to search for geo location photos.
    /// </summary>
    public BoundaryBox BoundaryBox { get; init; }

    /// <summary>
    /// Which type of safe search to perform.
    /// </summary>
    /// <remarks>An unauthenticated search will only ever return safe photos.</remarks>
    public SafetyLevel SafeSearch { get; init; }

    /// <summary>
    /// Filter your search on a particular type of content (photo, screenshot or other).
    /// </summary>
    public ContentTypeSearch ContentType { get; init; }

    /// <summary>
    /// Specify the units to use for a Geo location based search. Default is Kilometers.
    /// </summary>
    public RadiusUnit RadiusUnits { get; init; }

    /// <summary>
    /// Specify the radius of a particular geo-location search. Maximum of 20 miles, 32 kilometers.
    /// </summary>
    public float? Radius { get; init; }

    /// <summary>
    /// Specify the longitude center of a geo-location search.
    /// </summary>
    public double? Longitude { get; init; }

    /// <summary>
    /// Specify the latitude center of a geo-location search.
    /// </summary>
    public double? Latitude { get; init; }

    /// <summary>
    /// Filter the search results on those that have Geolocation information.
    /// </summary>
    public bool? HasGeo { get; init; }

    /// <summary>
    /// Fitler the search results on a particular users contacts. You must set UserId for this
    /// option to be honoured.
    /// </summary>
    public ContactSearch Contacts { get; init; }

    /// <summary>
    /// The WOE id to return photos for. This is a spatial reference.
    /// </summary>
    public WoeId WoeId { get; init; }

    /// <summary>
    /// The Flickr Place to return photos for.
    /// </summary>
    public PlaceId PlaceId { get; init; }

    /// <summary>
    /// True if the photo is taken from the Flickr Commons project.
    /// </summary>
    public bool IsCommons { get; init; }

    /// <summary>
    /// Is the image in a gallery.
    /// </summary>
    public bool InGallery { get; init; }

    /// <summary>
    /// Is the photo a part of the getty images collection on Flickr.
    /// </summary>
    public bool IsGetty { get; init; }

    /// <summary>
    /// If true then limit the search to within the current person's favourites.
    /// </summary>
    public bool Faves { get; init; }

    /// <summary>
    /// If set then will return photos tagged as containing the given person.
    /// </summary>
    public string PersonId { get; init; }

    /// <summary>
    /// Search for photos taken with a particular camera.
    /// </summary>
    public string Camera { get; init; }

    /// <summary>
    /// I've no idea what this does. The Flickr API comment is simply: Jump, jump!
    /// </summary>
    public string JumpTo { get; init; }

    /// <summary>
    /// Search for photos by the users 'username'
    /// </summary>
    public string Username { get; init; }

    /// <summary>
    /// The minimum exposure to return photos for.
    /// </summary>
    public double? ExifMinExposure { get; init; }

    /// <summary>
    /// The maximum exposure to return photos for.
    /// </summary>
    public double? ExifMaxExposure { get; init; }

    /// <summary>
    /// The minimum aperture to return photos for.
    /// </summary>
    public double? ExifMinAperture { get; init; }

    /// <summary>
    /// The maximum aperture to return photos for.
    /// </summary>
    public double? ExifMaxAperture { get; init; }

    /// <summary>
    /// The minimum focal length to return photos for.
    /// </summary>
    public int? ExifMinFocalLength { get; init; }

    /// <summary>
    /// The maximum focal length to return photos for.
    /// </summary>
    public int? ExifMaxFocalLength { get; init; }

    /// <summary>
    /// Exclude a specific user ID from the search results.
    /// </summary>
    public string ExcludeUserID { get; init; }

    /// <summary>
    /// The ID of the Foursquare Venue to return photos for.
    /// </summary>
    public string FoursquareVenueID { get; init; }

    /// <summary>
    /// The WOE ID of the Foursquare Venue to return photos for.
    /// </summary>
    public string FoursquareWoeID { get; init; }

    /// <summary>
    /// The path alias for a group to search.
    /// </summary>
    public string GroupPathAlias { get; init; }

    /// <summary>
    /// A list of the new color codes.
    /// </summary>
    /// <remarks>
    /// Acceptable values are "0"-"9" and "a"-"e". Or you can use a color name such as "yellow",
    /// "blue", "green" etc.
    /// </remarks>
    public ICollection<string> ColorCodes { get; init; }

    /// <summary>
    /// A collection of styles the search results will be filtered against.
    /// </summary>
    public ICollection<Style> Styles { get; init; }

    /// <summary>
    /// Calculates the Uri for a Flash slideshow for the given search options.
    /// </summary>
    /// <returns></returns>
    public string CalculateSlideshowUrl()
    {
        System.Text.StringBuilder sb = new();
        sb.Append("https://www.flickr.com/show.gne");
        sb.Append("?api_method=flickr.photos.search&method_params=");

        Dictionary<string, string> parameters = new();

        AddToDictionary(parameters);

        List<string> parts = new();
        foreach (var pair in parameters)
        {
            parts.Add(Uri.EscapeDataString(pair.Key) + "|" + Uri.EscapeDataString(pair.Value));
        }

        sb.Append(string.Join(";", parts.ToArray()));

        return sb.ToString();
    }

    /// <summary>
    /// Takes the various properties of this instance and adds them to a <see
    /// cref="Dictionary{K,V}"/> instanced passed in, ready for sending to Flickr.
    /// </summary>
    /// <param name="parameters">The <see cref="Dictionary{K,V}"/> to add the options to.</param>
    public void AddToDictionary(IDictionary<string, string> parameters)
    {
        parameters.AppendIf("user_id", UserId, x => !string.IsNullOrEmpty(x), x => x);

        parameters.AppendIf("group_id", GroupId, x => !string.IsNullOrEmpty(x), x => x);

        parameters.AppendIf("text", Text, x => !string.IsNullOrEmpty(x), x => x);

        parameters.AppendIf("tags", Tags, x => !string.IsNullOrEmpty(x), x => x);

        parameters.AppendIf("tag_mode", TagMode, x => x != TagMode.None, x => x.GetEnumMemberValue());

        parameters.AppendIf("machine_tags", MachineTags, x => !string.IsNullOrEmpty(x), x => x);

        parameters.AppendIf("machine_tag_mode", MachineTagMode, x => x != MachineTagMode.None, x => x.GetEnumMemberValue());

        parameters.AppendIf("min_upload_date", MinUploadDate, x => x != DateTime.MinValue, x => x.ToUnixTimestamp());

        parameters.AppendIf("max_upload_date", MaxUploadDate, x => x != DateTime.MinValue, x => x.ToUnixTimestamp());

        parameters.AppendIf("min_taken_date", MinTakenDate, x => x != DateTime.MinValue, x => x.ToMySql());

        parameters.AppendIf("max_taken_date", MaxTakenDate, x => x != DateTime.MinValue, x => x.ToMySql());

        parameters.AppendIf("license", Licenses, x => x.Count != 0, x => string.Join(",", x.Distinct().Select(item => item.GetEnumMemberValue())));

        parameters.AppendIf("per_page", PerPage, x => x > 0, x => x.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));

        parameters.AppendIf("page", Page, x => x > 0, x => x.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));

        parameters.AppendIf("extras", Extras, x => x != PhotoSearchExtras.None, x => x.ToFlickrString());

        parameters.AppendIf("sort", SortOrder, x => x != PhotoSearchSortOrder.None, x => x.ToFlickrString());

        parameters.AppendIf("privacy_filter", PrivacyFilter, x => x != PrivacyFilter.None, x => x.ToString("d"));

        parameters.AppendIf("bbox", BoundaryBox, x => x != null && x.IsSet, x => x.ToString());

        parameters.AppendIf("accuracy", BoundaryBox, x => x != null && x.IsSet && x.Accuracy != GeoAccuracy.None, x => x.Accuracy.ToString("d"));

        parameters.AppendIf("safe_search", SafeSearch, x => x != SafetyLevel.None, x => x.ToString("d"));

        parameters.AppendIf("content_type", ContentType, x => x != ContentTypeSearch.None, x => x.ToString("d"));

        parameters.AppendIf("has_geo", HasGeo, x => x != null, x => x.Value ? "1" : "0");

        parameters.AppendIf("lat", Latitude, x => x != null, x => x.Value.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));

        parameters.AppendIf("lon", Longitude, x => x != null, x => x.Value.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));

        parameters.AppendIf("radius", Radius, x => x != null, x => x.Value.ToString("0.00000", System.Globalization.NumberFormatInfo.InvariantInfo));

        parameters.AppendIf("radius_units", RadiusUnits, x => x != RadiusUnit.None, x => x.GetEnumMemberValue());

        parameters.AppendIf("contacts", Contacts, x => x != ContactSearch.None, x => x.GetEnumMemberValue());

        parameters.AppendIf("woe_id", WoeId, x => x != null, x => x);

        parameters.AppendIf("place_id", PlaceId, x => x != null, x => x);

        parameters.AppendIf("is_commons", IsCommons, x => x, x => "1");

        parameters.AppendIf("in_gallery", InGallery, x => x, x => "1");

        parameters.AppendIf("is_getty", IsGetty, x => x, x => "1");

        parameters.AppendIf("media", MediaType, x => x != MediaType.None, x => x.GetEnumMemberValue());

        parameters.AppendIf("geo_context", GeoContext, x => x != GeoContext.NotDefined, x => x.GetEnumMemberValue());

        parameters.AppendIf("faves", Faves, x => x , x => "1");
        
        parameters.AppendIf("person_id", PersonId, x => !string.IsNullOrEmpty(x), x => x);

        parameters.AppendIf("camera", Camera, x => !string.IsNullOrEmpty(x), x => x);

        parameters.AppendIf("jump_to", JumpTo, x => !string.IsNullOrEmpty(x), x => x);

        parameters.AppendIf("username", Username, x => !string.IsNullOrEmpty(x), x => x);

        parameters.AppendIf("exif_min_exposure", ExifMinExposure, x => x != null, x => x.Value.ToString("0.00000", System.Globalization.NumberFormatInfo.InvariantInfo));

        parameters.AppendIf("exif_max_exposure", ExifMaxExposure, x => x != null, x => x.Value.ToString("0.00000", System.Globalization.NumberFormatInfo.InvariantInfo));

        parameters.AppendIf("exif_min_aperture", ExifMinAperture, x => x != null, x => x.Value.ToString("0.00000", System.Globalization.NumberFormatInfo.InvariantInfo));
        
        parameters.AppendIf("exif_max_aperture", ExifMaxAperture, x => x != null, x => x.Value.ToString("0.00000", System.Globalization.NumberFormatInfo.InvariantInfo));
        
        parameters.AppendIf("exif_min_focallen", ExifMinFocalLength, x => x != null, x => x.Value.ToString("0", System.Globalization.NumberFormatInfo.InvariantInfo));
        
        parameters.AppendIf("exif_max_focallen", ExifMaxFocalLength, x => x != null, x => x.Value.ToString("0", System.Globalization.NumberFormatInfo.InvariantInfo));
        
        parameters.AppendIf("exclude_user_id", ExcludeUserID, x => !string.IsNullOrEmpty(x), x => x);

        parameters.AppendIf("foursquare_venueid", FoursquareVenueID, x => !string.IsNullOrEmpty(x), x => x);

        parameters.AppendIf("foursquare_woeid", FoursquareWoeID, x => !string.IsNullOrEmpty(x), x => x);

        parameters.AppendIf("group_path_alias", GroupPathAlias, x => !string.IsNullOrEmpty(x), x => x);

        parameters.AppendIf("color_codes", ColorCodes, x => x!= null && x.Count != 0, x => x.ToFlickrString());

        parameters.AppendIf("styles", Styles, x => x!= null && x.Count != 0, x => x.ToFlickrString());
    }
}