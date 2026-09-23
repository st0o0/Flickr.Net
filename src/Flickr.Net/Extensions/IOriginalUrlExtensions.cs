using Flickr.Net.Enums;
using Flickr.Net.Internals;

namespace Flickr.Net.Extensions;
/// <summary>Extension methods for constructing original size image URLs.</summary>
public static class IOriginalUrlExtensions
{    public static string ToOriginalUrl(this IOriginalUrl value) => value switch
    {
        PhotoInfo photoInfo => UtilityMethods.UrlFormat(photoInfo, SizeType.Original, "jpg"),
        _ => string.Empty
    };
}
