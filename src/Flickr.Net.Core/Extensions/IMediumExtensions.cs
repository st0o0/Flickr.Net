namespace Flickr.Net.Core.Extensions;

public static class IMediumExtensions
{
    public static string ToMediumUrl(this IMediumUrl value)
    {
        return value switch
        {
            Gallery gallery => UtilityMethods.UrlFormat(gallery.PrimaryPhotoFarm, gallery.PrimaryPhotoServer, gallery.PrimaryPhotoId, gallery.PrimaryPhotoSecret, SizeType.Medium, "jpg"),
            _ => string.Empty
        };
    }
}
