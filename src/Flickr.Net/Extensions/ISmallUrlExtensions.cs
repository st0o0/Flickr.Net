using Flickr.Net.Enums;
using Flickr.Net.Internals;

namespace Flickr.Net.Extensions;

    /// <summary>
    /// </summary>
public static class ISmallUrlExtensions
{
    /// <summary>
    /// </summary>
    public static string ToSmallUrl(this ISmallUrl value) => value switch
    {
        Item item => ConvertItemToUrl(item),
        Gallery gallery => UtilityMethods.UrlFormat(gallery.PrimaryPhotoFarm, gallery.PrimaryPhotoServer, gallery.PrimaryPhotoId, gallery.PrimaryPhotoSecret, SizeType.Small, "jpg"),
        Photoset photoset => UtilityMethods.UrlFormat(photoset, SizeType.Small, "jpg"),
        _ => string.Empty
    };

    private static string ConvertItemToUrl(Item item) => item.Type switch
    {
        ItemType.Photo => UtilityMethods.UrlFormat(item.Farm, item.Server, item.Id, item.Secret, SizeType.Small, "jpg"),
        ItemType.Photoset or ItemType.Gallery => UtilityMethods.UrlFormat(item.Farm, item.Server, item.Primary, item.Secret, SizeType.Small, "jpg"),
        _ => string.Empty
    };
}
