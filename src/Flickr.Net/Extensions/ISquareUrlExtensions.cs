using Flickr.Net.Enums;
using Flickr.Net.Internals;

namespace Flickr.Net.Extensions;

/// <summary>Extension methods for constructing square (75x75) image URLs.</summary>
public static class ISquareUrlExtensions
{
    public static string ToSquareUrl(this ISquareUrl value)
    {
        return value switch
        {
            Item item => ConvertItemToUrl(item),
            Gallery gallery => UtilityMethods.UrlFormat(gallery.PrimaryPhotoFarm, gallery.PrimaryPhotoServer!,
                gallery.PrimaryPhotoId!, gallery.PrimaryPhotoSecret!, SizeType.Square, "jpg"),
            PhotoInfo photoInfo => UtilityMethods.UrlFormat(photoInfo, SizeType.Square, "jpg"),
            Photoset photoset => UtilityMethods.UrlFormat(photoset, SizeType.Square, "jpg"),
            _ => string.Empty
        };
    }

    private static string ConvertItemToUrl(Item item)
    {
        return item.Type switch
        {
            ItemType.Photo when item is { Server: not null, Secret: not null } => UtilityMethods.UrlFormat(item.Farm,
                item.Server, item.Id, item.Secret, SizeType.Square, "jpg"),
            ItemType.Photoset or ItemType.Gallery when item is { Server: not null, Primary: not null, Secret: not null }
                => UtilityMethods.UrlFormat(item.Farm, item.Server, item.Primary,
                    item.Secret, SizeType.Square, "jpg"),
            _ => string.Empty
        };
    }
}