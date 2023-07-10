namespace Flickr.Net.Core.Extensions;

public static class ISmall400Extensions
{
    public static string ToSmall400Url(this ISmall400Url value) => value switch
    {
        PhotoInfo photoInfo => UtilityMethods.UrlFormat(photoInfo, SizeType.Small400, "jpg"),
        _ => string.Empty
    };
}
