using Flickr.Net.Enums;
using Flickr.Net.Internals;

namespace Flickr.Net.Extensions;
/// <summary>Extension methods for constructing small 320px image URLs.</summary>
public static class ISmall320UrlExtensions
{    public static string ToSmall320Url(this ISmall320Url value) => value switch
    {
        PhotoInfo photoInfo => UtilityMethods.UrlFormat(photoInfo, SizeType.Small320, "jpg"),
        _ => string.Empty
    };
}
