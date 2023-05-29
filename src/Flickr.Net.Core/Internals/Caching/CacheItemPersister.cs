namespace FlickrNet.Core.Internals.Caching;

/// <summary>
/// An interface that knows how to read/write subclasses
/// of ICacheItem.  Obviously there will be a tight
/// coupling between concrete implementations of ICacheItem
/// and concrete implementations of ICacheItemPersister.
/// </summary>
public abstract class CacheItemPersister
{
    /// <summary>
    /// Read a single cache item from the input stream.
    /// </summary>
    public abstract ICacheItem Read(Stream inputStream);

    /// <summary>
    /// Write a single cache item to the output stream.
    /// </summary>
    public abstract void Write(Stream outputStream, ICacheItem cacheItem);
}
