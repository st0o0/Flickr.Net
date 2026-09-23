using Flickr.Net.Enums;
using Flickr.Net.Internals;

namespace Flickr.Net.Extensions;
/// <summary>Extension methods for constructing large 1600px image URLs.</summary>
public static class ILarge1600UrlExtensions
{    public static string ToLarge1600Url(this ILarge1600Url value) => value switch
    {
        PhotoInfo photoInfo => UtilityMethods.UrlFormat(photoInfo, SizeType.Large1600, "jpg"),
        _ => string.Empty
    };
}
