namespace Flickr.Net.Core.Internals.Extensions;

/// <summary>
/// </summary>
public static class MediaTypeExtensions
{
    /// <summary>
    /// Converts a <see cref="MediaType"/> enumeration into a string used by Flickr.
    /// </summary>
    /// <param name="mediaType">The <see cref="MediaType"/> value to convert.</param>
    /// <returns></returns>
    public static string ToFlickrString(this MediaType mediaType) => mediaType switch
    {
        MediaType.All => "all",
        MediaType.Photos => "photos",
        MediaType.Videos => "videos",
        _ => string.Empty,
    };
}
