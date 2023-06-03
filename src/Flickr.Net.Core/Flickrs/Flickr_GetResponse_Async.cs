using Flickr.Net.Core.Internals.Caching;
using System.Diagnostics;

namespace Flickr.Net.Core;

public partial class Flickr
{
    private async Task<T> GetResponseAsync<T>(Dictionary<string, string> parameters, CancellationToken cancellationToken = default) where T : IFlickrParsable, new()
    {
        CheckApiKey();

        parameters.Add("api_key", ApiKey);

        // If OAuth Token exists or no authentication required then use new OAuth
        if (!string.IsNullOrEmpty(OAuthAccessToken))
        {
            OAuthGetBasicParameters(parameters);
            if (!string.IsNullOrEmpty(OAuthAccessToken))
            {
                parameters["oauth_token"] = OAuthAccessToken;
            }
        }

        string url = CalculateUri(parameters, !string.IsNullOrEmpty(_settings.SharedSecret));

        _lastRequest = url;

        byte[] result;

        if (InstanceCacheDisabled)
        {
            result = await FlickrResponder.GetDataResponseAsync(this, BaseUri.AbsoluteUri, parameters, cancellationToken);
        }
        else
        {
            string urlComplete = url;

            ResponseCacheItem cached = (ResponseCacheItem)Cache.Responses.Get(urlComplete, Cache.CacheTimeout, true);
            if (cached != null)
            {
                Debug.WriteLine("Cache hit.");
                result = cached.Response;
            }
            else
            {
                Debug.WriteLine("Cache miss.");
                result = await FlickrResponder.GetDataResponseAsync(this, BaseUri.AbsoluteUri, parameters, cancellationToken);

                ResponseCacheItem resCache = new(new Uri(urlComplete), result, DateTime.UtcNow);

                Cache.Responses.Shrink(Math.Max(0, Cache.CacheSizeLimit - result.Length));
                Cache.Responses[urlComplete] = resCache;
            }
        }

        T resultItem = new();

        try
        {
            LastResponse = result;

            resultItem.Load(result);
        }
        catch (Exception)
        {
            throw;
        }

        return resultItem;
    }
}