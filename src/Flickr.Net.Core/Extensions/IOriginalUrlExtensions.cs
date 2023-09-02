namespace Flickr.Net.Core.Extensions;

/// <summary>
/// </summary>
public static class IOriginalUrlExtensions
{
    /// <summary>
    /// </summary>
    public static string ToOriginalUrl(this IOriginalUrl value) => value switch
    {
        PhotoInfo photoInfo => UtilityMethods.UrlFormat(photoInfo, SizeType.Original, "jpg"),
        _ => string.Empty
    };
}
