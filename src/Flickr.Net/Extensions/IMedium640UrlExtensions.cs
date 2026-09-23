using Flickr.Net.Enums;
using Flickr.Net.Internals;

namespace Flickr.Net.Extensions;
/// <summary>Extension methods for constructing medium 640px image URLs.</summary>
public static class IMedium640UrlExtensions
{
    public static string ToMedium640Url(this IMedium640Url value) => value switch
    {
        PhotoInfo photoInfo => UtilityMethods.UrlFormat(photoInfo, SizeType.Medium640, "jpg"),
        _ => string.Empty
    };
}
