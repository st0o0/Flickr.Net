namespace Flickr.Net.Core.Extensions;

/// <summary>
/// </summary>
public static class ISmall400Extensions
{
    /// <summary>
    /// </summary>
    public static string ToSmall400Url(this ISmall400Url value) => value switch
    {
        PhotoInfo photoInfo => UtilityMethods.UrlFormat(photoInfo, SizeType.Small400, "jpg"),
        _ => string.Empty
    };
}
