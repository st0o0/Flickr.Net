using FlickrNet.Core.Internals.Caching;

namespace FlickrNet.Core.Internals.Extensions;

public static class CacheExtensions
{
    /// <summary>
    /// Clears the cache for a particular URL.
    /// </summary>
    /// <param name="url">The URL to remove from the cache.</param>
    /// <remarks>
    /// The URL can either be an image URL for a downloaded picture, or
    /// a request URL (see <see cref="LastRequest"/> for getting the last URL).
    /// </remarks>
    public static void FlushCache(this Cache cache, string url)
    {
        cache.FlushCache(new Uri(url));
    }
}
