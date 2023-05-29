namespace FlickrNet.Core.Internals.Caching;

/// <summary>
/// A cache item containing details of a REST response from Flickr.
/// </summary>
public sealed class ResponseCacheItem : ICacheItem
{
    /// <summary>
    /// Gets or sets the original URL of the request.
    /// </summary>
    public Uri Url { get; set; }

    /// <summary>
    /// Gets or sets the XML response.
    /// </summary>
    public byte[] Response { get; set; }

    /// <summary>
    /// Gets or sets the time the cache item was created.
    /// </summary>
    public DateTime CreationTime { get; set; }

    /// <summary>
    /// Gets the filesize of the request.
    /// </summary>
    public long FileSize
    {
        get { return Response == null ? 0 : Response.Length; }
    }

    /// <summary>
    /// Creates an instance of the <see cref="ResponseCacheItem"/> class.
    /// </summary>
    /// <param name="url"></param>
    /// <param name="response"></param>
    /// <param name="creationTime"></param>
    public ResponseCacheItem(Uri url, byte[] response, DateTime creationTime)
    {
        Url = url;
        Response = response;
        CreationTime = creationTime;
    }

    void ICacheItem.OnItemFlushed()
    {
    }
}
