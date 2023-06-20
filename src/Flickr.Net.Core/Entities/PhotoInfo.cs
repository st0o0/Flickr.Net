﻿namespace Flickr.Net.Core.Entities;

/// <summary>
/// Detailed information returned by <see cref="IFlickrPhotos.GetInfoAsync(string, string,
/// CancellationToken)"/> or <see cref="IFlickrPhotos.GetInfoAsync(string, string,
/// CancellationToken)"/> methods.
/// </summary>
public sealed class PhotoInfo : IFlickrParsable
{
    /// <summary>
    /// Default constructor.
    /// </summary>
    public PhotoInfo()
    {
        Notes = new Collection<PhotoInfoNote>();
        Tags = new Collection<PhotoInfoTag>();
        Urls = new Collection<PhotoInfoUrl>();
    }

    /// <summary>
    /// The id of the photo.
    /// </summary>
    public string PhotoId { get; set; }

    /// <summary>
    /// The secret of the photo. Used to calculate the URL (amongst other things).
    /// </summary>
    public string Secret { get; set; }

    /// <summary>
    /// The server on which the photo resides.
    /// </summary>
    public string Server { get; set; }

    /// <summary>
    /// The server farm on which the photo resides.
    /// </summary>
    public string Farm { get; set; }

    /// <summary>
    /// The path alias for this user, if set.
    /// </summary>
    public string PathAlias { get; set; }

    /// <summary>
    /// The original format of the image (e.g. jpg, png etc).
    /// </summary>
    public string OriginalFormat { get; set; }

    /// <summary>
    /// Optional extra field containing the original 'secret' of the photo used for forming the Url.
    /// </summary>
    public string OriginalSecret { get; set; }

    /// <summary>
    /// The date the photo was uploaded (or 'posted').
    /// </summary>
    public DateTime DateUploaded { get; set; }

    /// <summary>
    /// Is the photo a favorite of the current authorised user. Will be 0 if the user is not authorised.
    /// </summary>
    public bool IsFavorite { get; set; }

    /// <summary>
    /// The license of the photo.
    /// </summary>
    public LicenseType License { get; set; }

    /// <summary>
    /// The number of views the photo has.
    /// </summary>
    public int ViewCount { get; set; }

    /// <summary>
    /// The rotational information for this photo - in degrees.
    /// </summary>
    public int Rotation { get; set; }

    /// <summary>
    /// The media type for this item.
    /// </summary>
    public MediaType Media { get; set; }

    /// <summary>
    /// The safety level of the photo (safe, moderated or restricted).
    /// </summary>
    public SafetyLevel SafetyLevel { get; set; }

    /// <summary>
    /// The NSID of the owner of this item.
    /// </summary>
    public string OwnerUserId { get; set; }

    /// <summary>
    /// The username of the owner of this item.
    /// </summary>
    public string OwnerUserName { get; set; }

    /// <summary>
    /// The real name of the owner of this item.
    /// </summary>
    public string OwnerRealName { get; set; }

    /// <summary>
    /// The location of the owner of this photo.
    /// </summary>
    public string OwnerLocation { get; set; }

    /// <summary>
    /// The server for the owners buddy icon.
    /// </summary>
    public string OwnerIconServer { get; set; }

    /// <summary>
    /// The farm for the owners buddy icon.
    /// </summary>
    public string OwnerIconFarm { get; set; }

    /// <summary>
    /// The owners buddy icon, or the default buddy icon it no icon is set.
    /// </summary>
    public string OwnerBuddyIcon
    {
        get
        {
            return UtilityMethods.BuddyIcon(OwnerIconServer, OwnerIconFarm, OwnerUserId);
        }
    }

    /// <summary>
    /// The title of the photo.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// The description of the photo.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Is the photo visible to the public.
    /// </summary>
    public bool IsPublic { get; set; }

    /// <summary>
    /// Is the photo visible to contacts marked as friends.
    /// </summary>
    public bool IsFriend { get; set; }

    /// <summary>
    /// Is the photo visible to contacts marked as family.
    /// </summary>
    public bool IsFamily { get; set; }

    /// <summary>
    /// Can the authorized user add new comments.
    /// </summary>
    /// <remarks>"1" = true, "0" = false.</remarks>
    public bool CanComment { get; set; }

    /// <summary>
    /// Can the public add new comments.
    /// </summary>
    /// <remarks>"1" = true, "0" = false.</remarks>
    public bool CanPublicComment { get; set; }

    /// <summary>
    /// Can the authorized user add new meta data (tags and notes).
    /// </summary>
    /// <remarks>"1" = true, "0" = false.</remarks>
    public bool CanAddMeta { get; set; }

    /// <summary>
    /// Can the public add new meta data (tags and notes).
    /// </summary>
    /// <remarks>"1" = true, "0" = false.</remarks>
    public bool CanPublicAddMeta { get; set; }

    /// <summary>
    /// Specifies if the user allows blogging of this photos. 1 = Yes, 0 = No.
    /// </summary>
    public bool CanBlog { get; set; }

    /// <summary>
    /// Specifies if the user allows downloading of this photos. 1 = Yes, 0 = No.
    /// </summary>
    public bool CanDownload { get; set; }

    /// <summary>
    /// Specifies if the user allows printing of this photos. 1 = Yes, 0 = No.
    /// </summary>
    public bool CanPrint { get; set; }

    /// <summary>
    /// Does the user allow sharing of this photo.
    /// </summary>
    public bool CanShare { get; set; }

    /// <summary>
    /// The number of comments the photo has.
    /// </summary>
    public int CommentsCount { get; set; }

    /// <summary>
    /// The notes for the photo.
    /// </summary>
    public Collection<PhotoInfoNote> Notes { get; set; }

    /// <summary>
    /// The tags for the photo.
    /// </summary>
    public Collection<PhotoInfoTag> Tags { get; set; }

    /// <summary>
    /// The urls for this photo.
    /// </summary>
    public Collection<PhotoInfoUrl> Urls { get; set; }

    /// <summary>
    /// The date the photo was posted/uploaded.
    /// </summary>
    public DateTime DatePosted { get; set; }

    /// <summary>
    /// The date the photo was taken.
    /// </summary>
    public DateTime DateTaken { get; set; }

    /// <summary>
    /// The date the photo was last updated.
    /// </summary>
    public DateTime DateLastUpdated { get; set; }

    /// <summary>
    /// The granularity of the date taken data.
    /// </summary>
    public DateGranularity DateTakenGranularity { get; set; }

    /// <summary>
    /// Is the date taken unknown?
    /// </summary>
    public bool DateTakenUnknown { get; set; }

    /// <summary>
    /// Who has permissions to add comments to this photo.
    /// </summary>
    public PermissionComment? PermissionComment { get; set; }

    /// <summary>
    /// Who has permissions to add meta data (tags and notes) to this photo.
    /// </summary>
    public PermissionAddMeta? PermissionAddMeta { get; set; }

    /// <summary>
    /// The location information of this photo, if available.
    /// </summary>
    /// <remarks>Will be null if the photo has no location information stored on Flickr.</remarks>
    public PlaceInfo Location { get; set; }

    /// <summary>
    /// Who has permissions to see the geo-location data for this photo.
    /// </summary>
    public GeoPermissions GeoPermissions { get; set; }

    /// <summary>
    /// If this item is a video this contains information such as if it is ready, its duration etc.
    /// </summary>
    public VideoInfo VideoInfo { get; set; }

    /// <summary>
    /// Does this photo contain tagged people.
    /// </summary>
    /// <remarks>
    /// Call <see cref="IFlickrPhotosPeople.GetListAsync(string, CancellationToken)"/> to get the
    /// people found in this photo.
    /// </remarks>
    public bool HasPeople { get; set; }

    /// <summary>
    /// The Web url for flickr web page for this photo.
    /// </summary>
    public string WebUrl
    {
        get
        {
            return string.Format(System.Globalization.CultureInfo.InvariantCulture, "https://www.flickr.com/photos/{0}/{1}/", string.IsNullOrEmpty(PathAlias) ? OwnerUserId : PathAlias, PhotoId);
        }
    }

    /// <summary>
    /// The URL for the square thumbnail for the photo.
    /// </summary>
    public string SquareThumbnailUrl
    {
        get { return UtilityMethods.UrlFormat(this, "_s", "jpg"); }
    }

    /// <summary>
    /// The URL for the thumbnail for the photo.
    /// </summary>
    public string ThumbnailUrl
    {
        get { return UtilityMethods.UrlFormat(this, "_t", "jpg"); }
    }

    /// <summary>
    /// The URL for the small version of this photo.
    /// </summary>
    public string SmallUrl
    {
        get { return UtilityMethods.UrlFormat(this, "_m", "jpg"); }
    }

    /// <summary>
    /// The URL for the small 320 version of this photo.
    /// </summary>
    /// <remarks>
    /// There is no guarentee that this size of the image actually exists. Use <see
    /// cref="IFlickrPhotos.GetSizesAsync(string, CancellationToken)"/> to get a list of existing
    /// photo URLs.
    /// </remarks>
    public string Small320Url
    {
        get { return UtilityMethods.UrlFormat(this, "_n", "jpg"); }
    }

    /// <summary>
    /// The URL for the medium version of this photo.
    /// </summary>
    /// <remarks>
    /// There is no guarentee that this size of the image actually exists. Use <see
    /// cref="IFlickrPhotos.GetSizesAsync(string, CancellationToken)"/> to get a list of existing
    /// photo URLs.
    /// </remarks>
    public string MediumUrl
    {
        get { return UtilityMethods.UrlFormat(this, string.Empty, "jpg"); }
    }

    /// <summary>
    /// The URL for the medium 640 version of this photo.
    /// </summary>
    /// <remarks>
    /// There is no guarentee that this size of the image actually exists. Use <see
    /// cref="IFlickrPhotos.GetSizesAsync(string, CancellationToken)"/> to get a list of existing
    /// photo URLs.
    /// </remarks>
    public string Medium640Url
    {
        get { return UtilityMethods.UrlFormat(this, "_z", "jpg"); }
    }

    /// <summary>
    /// The URL for the medium 800 version of this photo.
    /// </summary>
    /// <remarks>
    /// There is no guarentee that this size of the image actually exists. Use <see
    /// cref="IFlickrPhotos.GetSizesAsync(string, CancellationToken)"/> to get a list of existing
    /// photo URLs.
    /// </remarks>
    public string Medium800Url
    {
        get { return UtilityMethods.UrlFormat(this, "_c", "jpg"); }
    }

    /// <summary>
    /// The URL for the large version of this photo.
    /// </summary>
    /// <remarks>
    /// There is no guarentee that this size of the image actually exists. Use <see
    /// cref="IFlickrPhotos.GetSizesAsync(string, CancellationToken)"/> to get a list of existing
    /// photo URLs.
    /// </remarks>
    public string LargeUrl
    {
        get { return UtilityMethods.UrlFormat(this, "_b", "jpg"); }
    }

    /// <summary>
    /// The URL for the large square version of this photo.
    /// </summary>
    /// <remarks>
    /// There is no guarentee that this size of the image actually exists. Use <see
    /// cref="IFlickrPhotos.GetSizesAsync(string, CancellationToken)"/> to get a list of existing
    /// photo URLs.
    /// </remarks>
    public string LargeSquareUrl
    {
        get { return UtilityMethods.UrlFormat(this, "_q", "jpg"); }
    }

    /// <summary>
    /// If <see cref="OriginalFormat"/> was returned then this will contain the url of the original file.
    /// </summary>
    public string OriginalUrl
    {
        get
        {
            if (string.IsNullOrEmpty(OriginalFormat))
            {
                return null;
            }

            return UtilityMethods.UrlFormat(this, "_o", OriginalFormat);
        }
    }

    void IFlickrParsable.Load(System.Xml.XmlReader reader)
    {
        if (reader.LocalName != "photo")
        {
            UtilityMethods.CheckParsingException(reader);
        }

        LoadAttributes(reader);

        LoadElements(reader);
    }

    private void LoadElements(System.Xml.XmlReader reader)
    {
        while (reader.LocalName != "photo")
        {
            switch (reader.LocalName)
            {
                case "owner":
                    ParseOwner(reader);
                    break;

                case "title":
                    Title = reader.ReadElementContentAsString();
                    break;

                case "description":
                    Description = reader.ReadElementContentAsString();
                    break;

                case "visibility":
                    ParseVisibility(reader);
                    break;

                case "permissions":
                    ParsePermissions(reader);
                    break;

                case "editability":
                    ParseEditability(reader);
                    break;

                case "publiceditability":
                    ParsePublicEditability(reader);
                    break;

                case "dates":
                    ParseDates(reader);
                    break;

                case "usage":
                    ParseUsage(reader);
                    break;

                case "comments":
                    CommentsCount = reader.ReadElementContentAsInt();
                    break;

                case "notes":
                    ParseNotes(reader);
                    break;

                case "tags":
                    ParseTags(reader);
                    break;

                case "urls":
                    ParseUrls(reader);
                    break;

                case "location":
                    Location = new PlaceInfo();
                    ((IFlickrParsable)Location).Load(reader);
                    break;

                case "geoperms":
                    GeoPermissions = new GeoPermissions();
                    ((IFlickrParsable)GeoPermissions).Load(reader);
                    break;

                case "video":
                    VideoInfo = new VideoInfo();
                    ((IFlickrParsable)VideoInfo).Load(reader);
                    break;

                case "people":
                    HasPeople = reader.GetAttribute("haspeople") == "1";
                    reader.Skip();
                    break;

                case "path_alias":
                    PathAlias = reader.Value;
                    break;

                default:
                    UtilityMethods.CheckParsingException(reader);
                    reader.Skip();
                    break;
            }
        }

        reader.Skip();
    }

    private void LoadAttributes(System.Xml.XmlReader reader)
    {
        while (reader.MoveToNextAttribute())
        {
            switch (reader.LocalName)
            {
                case "id":
                    PhotoId = reader.Value;
                    break;

                case "secret":
                    Secret = reader.Value;
                    break;

                case "server":
                    Server = reader.Value;
                    break;

                case "farm":
                    Farm = reader.Value;
                    break;

                case "originalformat":
                    OriginalFormat = reader.Value;
                    break;

                case "originalsecret":
                    OriginalSecret = reader.Value;
                    break;

                case "dateuploaded":
                    DateUploaded = UtilityMethods.UnixTimestampToDate(reader.Value);
                    break;

                case "isfavorite":
                    IsFavorite = reader.Value == "1";
                    break;

                case "license":
                    License = (LicenseType)int.Parse(reader.Value, System.Globalization.NumberFormatInfo.InvariantInfo);
                    break;

                case "views":
                    ViewCount = int.Parse(reader.Value, System.Globalization.NumberFormatInfo.InvariantInfo);
                    break;

                case "rotation":
                    Rotation = int.Parse(reader.Value, System.Globalization.NumberFormatInfo.InvariantInfo);
                    break;

                case "media":
                    Media = reader.Value == "photo" ? MediaType.Photos : MediaType.Videos;
                    break;

                case "safety_level":
                    SafetyLevel = (SafetyLevel)reader.ReadContentAsInt();
                    break;

                default:
                    UtilityMethods.CheckParsingException(reader);
                    break;
            }
        }

        reader.Read();
    }

    private void ParseUrls(System.Xml.XmlReader reader)
    {
        reader.Read();

        while (reader.LocalName == "url")
        {
            PhotoInfoUrl url = new();
            ((IFlickrParsable)url).Load(reader);
            Urls.Add(url);
        }
    }

    private void ParseTags(System.Xml.XmlReader reader)
    {
        reader.Read();

        while (reader.LocalName == "tag")
        {
            PhotoInfoTag tag = new();
            ((IFlickrParsable)tag).Load(reader);
            Tags.Add(tag);
        }
    }

    private void ParseNotes(System.Xml.XmlReader reader)
    {
        reader.Read();

        while (reader.LocalName == "note")
        {
            PhotoInfoNote note = new();
            ((IFlickrParsable)note).Load(reader);
            Notes.Add(note);
        }
    }

    private void ParseUsage(System.Xml.XmlReader reader)
    {
        while (reader.MoveToNextAttribute())
        {
            switch (reader.LocalName)
            {
                case "canblog":
                    CanBlog = reader.Value == "1";
                    break;

                case "candownload":
                    CanDownload = reader.Value == "1";
                    break;

                case "canprint":
                    CanPrint = reader.Value == "1";
                    break;

                case "canshare":
                    CanShare = reader.Value == "1";
                    break;

                default:
                    UtilityMethods.CheckParsingException(reader);
                    break;
            }
        }

        reader.Read();
    }

    private void ParseVisibility(System.Xml.XmlReader reader)
    {
        while (reader.MoveToNextAttribute())
        {
            switch (reader.LocalName)
            {
                case "isfamily":
                    IsFamily = reader.Value == "1";
                    break;

                case "ispublic":
                    IsPublic = reader.Value == "1";
                    break;

                case "isfriend":
                    IsFriend = reader.Value == "1";
                    break;

                default:
                    UtilityMethods.CheckParsingException(reader);
                    break;
            }
        }

        reader.Read();
    }

    private void ParseEditability(System.Xml.XmlReader reader)
    {
        while (reader.MoveToNextAttribute())
        {
            switch (reader.LocalName)
            {
                case "cancomment":
                    CanComment = reader.Value == "1";
                    break;

                case "canaddmeta":
                    CanAddMeta = reader.Value == "1";
                    break;

                default:
                    UtilityMethods.CheckParsingException(reader);
                    break;
            }
        }

        reader.Read();
    }

    private void ParsePublicEditability(System.Xml.XmlReader reader)
    {
        while (reader.MoveToNextAttribute())
        {
            switch (reader.LocalName)
            {
                case "cancomment":
                    CanPublicComment = reader.Value == "1";
                    break;

                case "canaddmeta":
                    CanPublicAddMeta = reader.Value == "1";
                    break;

                default:
                    UtilityMethods.CheckParsingException(reader);
                    break;
            }
        }

        reader.Read();
    }

    private void ParsePermissions(System.Xml.XmlReader reader)
    {
        while (reader.MoveToNextAttribute())
        {
            switch (reader.LocalName)
            {
                case "permcomment":
                    PermissionComment = (PermissionComment)int.Parse(reader.Value, System.Globalization.NumberFormatInfo.InvariantInfo);
                    break;

                case "permaddmeta":
                    PermissionAddMeta = (PermissionAddMeta)int.Parse(reader.Value, System.Globalization.NumberFormatInfo.InvariantInfo);
                    break;

                default:
                    UtilityMethods.CheckParsingException(reader);
                    break;
            }
        }

        reader.Read();
    }

    private void ParseDates(System.Xml.XmlReader reader)
    {
        while (reader.MoveToNextAttribute())
        {
            switch (reader.LocalName)
            {
                case "posted":
                    DatePosted = UtilityMethods.UnixTimestampToDate(reader.Value);
                    break;

                case "taken":
                    DateTaken = UtilityMethods.ParseDateWithGranularity(reader.Value);
                    break;

                case "takengranularity":
                    DateTakenGranularity = (DateGranularity)int.Parse(reader.Value, System.Globalization.NumberFormatInfo.InvariantInfo);
                    break;

                case "lastupdate":
                    DateLastUpdated = UtilityMethods.UnixTimestampToDate(reader.Value);
                    break;

                case "takenunknown":
                    DateTakenUnknown = reader.Value == "1";
                    break;

                default:
                    UtilityMethods.CheckParsingException(reader);
                    break;
            }
        }

        reader.Read();
    }

    private void ParseOwner(System.Xml.XmlReader reader)
    {
        while (reader.MoveToNextAttribute())
        {
            switch (reader.LocalName)
            {
                case "nsid":
                    OwnerUserId = reader.Value;
                    break;

                case "username":
                    OwnerUserName = reader.Value;
                    break;

                case "realname":
                    OwnerRealName = reader.Value;
                    break;

                case "location":
                    OwnerLocation = reader.Value;
                    break;

                case "iconserver":
                    OwnerIconServer = reader.Value;
                    break;

                case "iconfarm":
                    OwnerIconFarm = reader.Value;
                    break;

                case "path_alias":
                    PathAlias = string.IsNullOrEmpty(reader.Value) ? null : reader.Value;
                    break;

                default:
                    UtilityMethods.CheckParsingException(reader);
                    break;
            }
        }

        reader.Read();
    }
}