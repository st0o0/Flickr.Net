namespace Flickr.Net.Extensions;

/// <summary>
/// </summary>
public static class ILargeUrlExtensions
{
    /// <summary>
    /// </summary>
    public static string ToLargeUrl(this ILargeUrl value) => value switch
    {
        PhotoInfo photoInfo => UtilityMethods.UrlFormat(photoInfo, SizeType.Large, "jpg"),
        _ => string.Empty
    };
}
