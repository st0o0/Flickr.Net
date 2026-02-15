using Flickr.Net.Enums;
using Flickr.Net.Internals;

namespace Flickr.Net.Extensions;

/// <summary>
/// </summary>
public static class ISquareUrlExtensions
{
    /// <summary>
    /// </summary>
    public static string ToSquareUrl(this ISquareUrl value)
    {
        return value switch
        {
            Item item => ConvertItemToUrl(item),
            Gallery gallery => UtilityMethods.UrlFormat(gallery.PrimaryPhotoFarm, gallery.PrimaryPhotoServer, gallery.PrimaryPhotoId, gallery.PrimaryPhotoSecret, SizeType.Square, "jpg"),
            PhotoInfo photoInfo => UtilityMethods.UrlFormat(photoInfo, SizeType.Square, "jpg"),
            Photoset photoset => UtilityMethods.UrlFormat(photoset, SizeType.Square, "jpg"),
            _ => string.Empty
        };
    }

    private static string ConvertItemToUrl(Item item)
    {
        return item.Type switch
        {
            ItemType.Photo => UtilityMethods.UrlFormat(item.Farm, item.Server, item.Id, item.Secret, SizeType.Square, "jpg"),
            ItemType.Photoset or ItemType.Gallery => UtilityMethods.UrlFormat(item.Farm, item.Server, item.Primary, item.Secret, SizeType.Square, "jpg"),
            _ => string.Empty
        };
    }
}
