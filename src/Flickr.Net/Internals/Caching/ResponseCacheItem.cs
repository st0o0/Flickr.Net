namespace Flickr.Net.Internals.Caching;

/// <summary>
/// A cache item containing details of a REST response from Flickr.
/// </summary>
/// <remarks>
/// Creates an instance of the <see cref="ResponseCacheItem"/> class.
/// </remarks>
/// <param name="url"></param>
/// <param name="response"></param>
/// <param name="creationTime"></param>
internal sealed class ResponseCacheItem(Uri url, byte[] response, DateTime creationTime) : ICacheItem
{
    /// <summary>
    /// Gets or sets the original URL of the request.
    /// </summary>
    public Uri Url { get; set; } = url;

    /// <summary>
    /// Gets or sets the XML response.
    /// </summary>
    public byte[] Response { get; set; } = response;

    /// <summary>
    /// Gets or sets the time the cache item was created.
    /// </summary>
    public DateTime CreationTime { get; set; } = creationTime;

    /// <summary>
    /// Gets the filesize of the request.
    /// </summary>
    public long FileSize => Response == null ? 0 : Response.Length;

    void ICacheItem.OnItemFlushed()
    {
    }
}