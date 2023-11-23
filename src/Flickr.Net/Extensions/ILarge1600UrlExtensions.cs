namespace Flickr.Net.Extensions;

/// <summary>
/// </summary>
public static class ILarge1600UrlExtensions
{
    /// <summary>
    /// </summary>
    public static string ToLarge1600Url(this ILarge1600Url value) => value switch
    {
        PhotoInfo photoInfo => UtilityMethods.UrlFormat(photoInfo, SizeType.Large1600, "jpg"),
        _ => string.Empty
    };
}
