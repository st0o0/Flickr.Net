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
    internal static string ToFlickrString(this MediaType mediaType) => mediaType switch
    {
        MediaType.Photos or MediaType.Photo => "photos",
        MediaType.Videos or MediaType.Video => "videos",
        _ or MediaType.All => "all",
    };
}