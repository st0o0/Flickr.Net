using Flickr.Net.Enums;
using Flickr.Net.Internals;

namespace Flickr.Net.Extensions;
/// <summary>Extension methods for constructing thumbnail image URLs.</summary>
public static class IThumbnailUrlExtensions
{    public static string ToThumbnailUrl(this IThumbnailUrl value)
    {
        return value switch
        {
            Gallery gallery => UtilityMethods.UrlFormat(gallery.PrimaryPhotoFarm, gallery.PrimaryPhotoServer, gallery.PrimaryPhotoId, gallery.PrimaryPhotoSecret, SizeType.Thumbnail, "jpg"),
            Photoset photoset => UtilityMethods.UrlFormat(photoset, SizeType.Thumbnail, "jpg"),
            _ => string.Empty
        };
    }
}
