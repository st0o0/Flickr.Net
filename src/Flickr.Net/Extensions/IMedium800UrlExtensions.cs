using Flickr.Net.Enums;
using Flickr.Net.Internals;

namespace Flickr.Net.Extensions;
/// <summary>Extension methods for constructing medium 800px image URLs.</summary>
public static class IMedium800UrlExtensions
{
    public static string ToMedium800Url(this IMedium800Url value) => value switch
    {
        PhotoInfo photoInfo => UtilityMethods.UrlFormat(photoInfo, SizeType.Medium800, "jpg"),
        _ => string.Empty
    };
}
