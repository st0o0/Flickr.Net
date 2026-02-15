using Flickr.Net.Enums;
using Flickr.Net.Internals;

namespace Flickr.Net.Extensions;

/// <summary>
/// </summary>
public static class ILarge2048UrlExtensions
{
    /// <summary>
    /// </summary>
    public static string ToLarge2048Url(this ILarge2048Url value) => value switch
    {
        PhotoInfo photoInfo => UtilityMethods.UrlFormat(photoInfo, SizeType.Large2048, "jpg"),
        _ => string.Empty
    };
}
