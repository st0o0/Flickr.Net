using System.Text;

namespace Flickr.Net.Core.Internals.Caching;

internal class ResponseCacheItemPersister : CacheItemPersister
{
    public override ICacheItem Read(Stream inputStream)
    {
        var s = UtilityMethods.ReadString(inputStream);
        var response = UtilityMethods.ReadString(inputStream);

        var chunks = s.Split('\n');

        // Corrupted cache record, so throw IOException which is then handled and returns partial cache.
        if (chunks.Length != 2)
        {
            throw new IOException("Unexpected number of chunks found");
        }

        var url = chunks[0];
        DateTime creationTime = new(long.Parse(chunks[1], System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo));
        ResponseCacheItem item = new(new Uri(url), response, creationTime);
        return item;
    }

    public override void Write(Stream outputStream, ICacheItem cacheItem)
    {
        var item = (ResponseCacheItem)cacheItem;
        StringBuilder result = new();
        result.Append(item.Url.AbsoluteUri + "\n");
        result.Append(item.CreationTime.Ticks.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        UtilityMethods.WriteString(outputStream, result.ToString());
        UtilityMethods.WriteByteArray(outputStream, item.Response);
    }
}