namespace Flickr.Net.Core.Entities;

/// <summary>
/// The restrictions that apply to a group's pool.
/// </summary>
public sealed class GroupInfoRestrictions : IFlickrParsable
{
    /// <summary>
    /// Are photos allowed to be added to this pool.
    /// </summary>
    public bool PhotosAccepted { get; set; }

    /// <summary>
    /// Are videos allowed to be added to this pool.
    /// </summary>
    public bool VideosAccepted { get; set; }

    /// <summary>
    /// Are Photo/Video images allowed to be added to this pool.
    /// </summary>
    public bool ImagesAccepted { get; set; }

    /// <summary>
    /// Are Screenshots/Screencasts allowed to be added to this pool.
    /// </summary>
    public bool ScreenshotsAccepted { get; set; }

    /// <summary>
    /// Are Illustrations/Art/Animation/CGI allowed to be added to this pool.
    /// </summary>
    public bool ArtIllustrationsAccepted { get; set; }

    /// <summary>
    /// Are safe items allowed to be added to this pool.
    /// </summary>
    public bool SafeItemsAccepted { get; set; }

    /// <summary>
    /// Are moderated items allowed to be added to this pool.
    /// </summary>
    public bool ModeratedItemsAccepted { get; set; }

    /// <summary>
    /// Are restricted items allowed to be added to this pool.
    /// </summary>
    public bool RestrictedItemsAccepted { get; set; }

    /// <summary>
    /// Must the item have geo information.
    /// </summary>
    public bool GeoInfoRequired { get; set; }

    void IFlickrParsable.Load(XmlReader reader)
    {
        while (reader.MoveToNextAttribute())
        {
            switch (reader.LocalName)
            {
                case "photos_ok":
                    PhotosAccepted = reader.Value == "1";
                    break;

                case "videos_ok":
                    VideosAccepted = reader.Value == "1";
                    break;

                case "images_ok":
                    ImagesAccepted = reader.Value == "1";
                    break;

                case "screens_ok":
                    ScreenshotsAccepted = reader.Value == "1";
                    break;

                case "art_ok":
                    ArtIllustrationsAccepted = reader.Value == "1";
                    break;

                case "safe_ok":
                    SafeItemsAccepted = reader.Value == "1";
                    break;

                case "moderate_ok":
                    ModeratedItemsAccepted = reader.Value == "1";
                    break;

                case "resitricted_ok":
                    RestrictedItemsAccepted = reader.Value == "1";
                    break;

                case "has_geo":
                    GeoInfoRequired = reader.Value == "1";
                    break;
            }
        }

        reader.Read();
    }
}