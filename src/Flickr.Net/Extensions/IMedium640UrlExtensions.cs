using Flickr.Net.Enums;
using Flickr.Net.Internals;

namespace Flickr.Net.Extensions;

/// <summary>
/// </summary>
public static class IMedium640UrlExtensions
{
    /// <summary>
    /// </summary>
    public static string ToMedium640Url(this IMedium640Url value) => value switch
    {
        PhotoInfo photoInfo => UtilityMethods.UrlFormat(photoInfo, SizeType.Medium640, "jpg"),
        _ => string.Empty
    };
}
