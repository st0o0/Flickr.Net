using System.Diagnostics.CodeAnalysis;
using Flickr.Net.Settings;

namespace Flickr.Net.Internals.Caching;

/// <summary>
/// Provides thread-safe caching functionality for Flickr API responses with configurable timeout and size limits.
/// </summary>
/// <remarks>
/// This cache uses a persistent storage mechanism to maintain API responses across application restarts.
/// All cache operations are thread-safe through the use of internal locking.
/// </remarks>
/// <param name="settings">The caching configuration settings.</param>
internal sealed class Cache(FlickrCachingSettings settings) : IDisposable
{
    private static PersistentCache? _responses;
    private readonly object _lockObject = new();
    private bool _disposed;

    /// <summary>
    /// Gets the persistent cache instance containing cached Flickr API responses.
    /// </summary>
    /// <remarks>
    /// The cache is lazily initialized on first access and stored at the configured <see cref="CacheLocation"/>.
    /// Access to this property is thread-safe.
    /// </remarks>
    public PersistentCache Responses
    {
        get
        {
            ObjectDisposedException.ThrowIf(_disposed, this);

            lock (_lockObject)
            {
                _responses ??= new PersistentCache(
                    Path.Combine(CacheLocation, "responseCache.dat"),
                    new ResponseCacheItemPersister());

                return _responses;
            }
        }
    }

    /// <summary>
    /// Gets a value indicating whether caching is currently disabled.
    /// </summary>
    /// <value>
    /// <see langword="true"/> if caching is disabled; otherwise, <see langword="false"/>.
    /// </value>
    public bool CacheDisabled => settings.CacheDisabled;

    /// <summary>
    /// Gets the file system location where cached responses are stored.
    /// </summary>
    /// <value>
    /// The absolute path to the cache directory. This value is never <see langword="null"/>.
    /// </value>
    [DisallowNull]
    public string CacheLocation => settings.CacheLocation;

    /// <summary>
    /// Gets the maximum size limit for the cache in bytes.
    /// </summary>
    /// <value>
    /// The maximum number of bytes the cache is allowed to consume on disk.
    /// </value>
    internal long CacheSizeLimit => settings.CacheSizeLimit;

    /// <summary>
    /// Gets the default timeout duration for cached items.
    /// </summary>
    /// <value>
    /// The <see cref="TimeSpan"/> after which cached responses are considered stale and will be refreshed.
    /// </value>
    public TimeSpan CacheTimeout => settings.CacheTimeout;

    /// <summary>
    /// Removes a specific URL's cached response from the cache.
    /// </summary>
    /// <param name="url">The <see cref="Uri"/> of the API endpoint whose response should be removed from cache.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="url"/> is <see langword="null"/>.</exception>
    /// <exception cref="ObjectDisposedException">Thrown when the cache has been disposed.</exception>
    public void FlushCache(Uri url)
    {
        ArgumentNullException.ThrowIfNull(url);
        ObjectDisposedException.ThrowIf(_disposed, this);

        Responses[url.AbsoluteUri] = null;
    }

    /// <summary>
    /// Removes all cached responses from the cache.
    /// </summary>
    /// <exception cref="ObjectDisposedException">Thrown when the cache has been disposed.</exception>
    /// <remarks>
    /// This operation clears both in-memory and persistent storage.
    /// Use with caution as this will force all subsequent API requests to retrieve fresh data.
    /// </remarks>
    public void FlushCache()
    {
        ObjectDisposedException.ThrowIf(_disposed, this);
        Responses.Flush();
    }

    /// <summary>
    /// Releases all resources used by the cache.
    /// </summary>
    public void Dispose()
    {
        if (_disposed)
        {
            return;
        }

        lock (_lockObject)
        {
            _responses?.Dispose();
            _responses = null;
        }

        _disposed = true;
    }
}