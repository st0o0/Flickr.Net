using Flickr.Net.Core.Internals.Caching;

namespace Flickr.Net.Core.Internals.Extensions;

/// <summary>
/// The cache extensions.
/// </summary>
public static class CacheExtensions
{
    /// <summary>
    /// Clears the cache for a particular URL.
    /// </summary>
    /// <param name="cache"></param>
    /// <param name="url">The URL to remove from the cache.</param>
    /// <remarks>
    /// The URL can either be an image URL for a downloaded picture, or a request URL (see <see
    /// cref="Flickr._lastRequest"/> for getting the last URL).
    /// </remarks>
    public static void FlushCache(this Cache cache, string url)
    {
        cache.FlushCache(new Uri(url));
    }
}