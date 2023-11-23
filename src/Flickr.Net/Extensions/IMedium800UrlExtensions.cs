namespace Flickr.Net.Extensions;

/// <summary>
/// </summary>
public static class IMedium800UrlExtensions
{
    /// <summary>
    /// </summary>
    public static string ToMedium800Url(this IMedium800Url value) => value switch
    {
        PhotoInfo photoInfo => UtilityMethods.UrlFormat(photoInfo, SizeType.Medium800, "jpg"),
        _ => string.Empty
    };
}
