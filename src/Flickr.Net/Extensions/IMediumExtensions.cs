using Flickr.Net.Enums;
using Flickr.Net.Internals;

namespace Flickr.Net.Extensions;

/// <summary>
/// </summary>
public static class IMediumExtensions
{
    /// <summary>
    /// </summary>
    public static string ToMediumUrl(this IMediumUrl value)
    {
        return value switch
        {
            Gallery gallery => UtilityMethods.UrlFormat(gallery.PrimaryPhotoFarm, gallery.PrimaryPhotoServer, gallery.PrimaryPhotoId, gallery.PrimaryPhotoSecret, SizeType.Medium, "jpg"),
            _ => string.Empty
        };
    }
}
