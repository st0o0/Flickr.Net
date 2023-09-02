namespace Flickr.Net.Core.Extensions;

/// <summary>
/// </summary>
public static class IWebUrlExtensions
{
    /// <summary>
    /// </summary>
    public static string ToWebUrl(this IWebUrl value)
    {
        return value switch
        {
            PhotoInfo photoInfo => string.Format(System.Globalization.CultureInfo.InvariantCulture, "https://www.flickr.com/photos/{0}/{1}/", string.IsNullOrEmpty(photoInfo.Owner.PathAlias) ? photoInfo.Owner.Id : photoInfo.Owner.PathAlias, photoInfo.Id),
            _ => string.Empty
        };
    }
}
