using Flickr.Net.Enums;
using Flickr.Net.Internals;

namespace Flickr.Net.Extensions;
/// <summary>Extension methods for constructing large square (150x150) image URLs.</summary>
public static class ILargeSquareUrlExtensions
{
    public static string ToLargeSquareUrl(this ILargeSquareUrl value) => value switch
    {
        PhotoInfo photoInfo => UtilityMethods.UrlFormat(photoInfo, SizeType.LargeSquare, "jpg"),
        _ => string.Empty
    };
}
