using Flickr.Net.Enums;
using Flickr.Net.Internals;

namespace Flickr.Net.Extensions;
/// <summary>Extension methods for constructing large (1024px) image URLs.</summary>
public static class ILargeUrlExtensions
{
    public static string ToLargeUrl(this ILargeUrl value) => value switch
    {
        PhotoInfo photoInfo => UtilityMethods.UrlFormat(photoInfo, SizeType.Large, "jpg"),
        _ => string.Empty
    };
}
