namespace Flickr.Net.Core.Extensions;

public static class IThumbnailUrlExtensions
{
    public static string ToThumbnailUrl(this IThumbnailUrl value)
    {
        return value switch
        {
            Gallery gallery => UtilityMethods.UrlFormat(gallery.PrimaryPhotoFarm, gallery.PrimaryPhotoServer, gallery.PrimaryPhotoId, gallery.PrimaryPhotoSecret, SizeType.Thumbnail, "jpg"),
            Photoset photoset => UtilityMethods.UrlFormat(photoset, SizeType.Thumbnail, "jpg"),
            _ => string.Empty
        };
    }
}
