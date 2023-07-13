namespace Flickr.Net.Core.Extensions;

public static class ILarge1600UrlExtensions
{
    public static string ToLarge1600Url(this ILarge1600Url value) => value switch
    {
        PhotoInfo photoInfo => UtilityMethods.UrlFormat(photoInfo, SizeType.Large1600, "jpg"),
        _ => string.Empty
    };
}
