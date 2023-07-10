namespace Flickr.Net.Core.Extensions;

public static class ILargeUrlExtensions
{
    public static string ToLargeUrl(this ILargeUrl value) => value switch
    {
        PhotoInfo photoInfo => UtilityMethods.UrlFormat(photoInfo, SizeType.Large, "jpg"),
        _ => string.Empty
    };
}
