namespace Flickr.Net.Internals.Caching;

/// <summary>
/// An item that can be stored in a cache.
/// </summary>
public interface ICacheItem
{
    /// <summary>
    /// The time this cache item was created.
    /// </summary>
    DateTime CreationTime { get; }

    /// <summary>
    /// Gets called back when the item gets flushed from the cache.
    /// </summary>
    void OnItemFlushed();

    /// <summary>
    /// The size of this item, in bytes. Return 0 if size management is not important.
    /// </summary>
    long FileSize { get; }
}