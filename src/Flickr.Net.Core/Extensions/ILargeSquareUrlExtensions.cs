namespace Flickr.Net.Core.Extensions;

/// <summary>
/// </summary>
public static class ILargeSquareUrlExtensions
{
    /// <summary>
    /// </summary>
    public static string ToLargeSquareUrl(this ILargeSquareUrl value) => value switch
    {
        PhotoInfo photoInfo => UtilityMethods.UrlFormat(photoInfo, SizeType.LargeSquare, "jpg"),
        _ => string.Empty
    };
}
