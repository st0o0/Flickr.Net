using System.Diagnostics;
using Flickr.Net.Core.Exceptions.Handlers;
using Flickr.Net.Core.Flickrs.Results;
using Flickr.Net.Core.Internals.Caching;
using Flickr.Net.Core.Internals.ContractResolver;
using Newtonsoft.Json;

namespace Flickr.Net.Core;

/// <summary>
/// The flickr.
/// </summary>
public partial class Flickr
{
    private Task<FlickrContextResult<TNextPhoto, TPrevPhoto>> GetContextResponseAsync<TNextPhoto, TPrevPhoto>(Dictionary<string, string> parameters, CancellationToken cancellationToken = default) => GetGenericResponseAsync<FlickrContextResult<TNextPhoto, TPrevPhoto>, TNextPhoto, TPrevPhoto>(parameters, cancellationToken);

    private Task GetResponseAsync(Dictionary<string, string> parameters, CancellationToken cancellationToken = default) => GetGenericResponseAsync<FlickrResult, string>(parameters, cancellationToken);

    private Task<T> GetResponseAsync<T>(Dictionary<string, string> parameters, CancellationToken cancellationToken = default) => GetGenericResponseAsync<FlickrResult<T>, T>(parameters, cancellationToken);

    private async Task<TResponse> GetGenericResponseAsync<T, TResponse>(Dictionary<string, string> parameters, CancellationToken cancellationToken = default)
    {
        var result = await GetGenericResponseAsync<FlickrResult<TResponse>, TResponse>(parameters, cancellationToken);
        if (result is FlickrResult<TResponse> value)
        {
            return value.Content;
        }

        return default;
    }

    private async Task<T> GetGenericResponseAsync<T, TPrimaryResponse, TSecondResponse>(Dictionary<string, string> parameters, CancellationToken cancellationToken = default) where T : FlickrResult
    {
        CheckApiKey();

        parameters.Add("api_key", FlickrSettings.ApiKey);

        // If OAuth Token exists or no authentication required then use new OAuth
        if (!string.IsNullOrEmpty(FlickrSettings.OAuthAccessToken))
        {
            OAuthGetBasicParameters(parameters);
            if (!string.IsNullOrEmpty(FlickrSettings.OAuthAccessToken))
            {
                parameters["oauth_token"] = FlickrSettings.OAuthAccessToken;
            }
        }

        var url = CalculateUri(parameters, !string.IsNullOrEmpty(FlickrSettings.ApiSecret));

        _lastRequest = url;

        string result;

        if (FlickrCachingSettings.InstanceCacheDisabled)
        {
            result = await FlickrResponder.GetDataResponseAsync(this, BaseUri.AbsoluteUri, parameters, cancellationToken);
        }
        else
        {
            var urlComplete = url;

            var cached = (ResponseCacheItem)Cache.Responses.Get(urlComplete, Cache.CacheTimeout, true);
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

        try
        {
            LastResponse = result;

            var flickrResults = JsonConvert.DeserializeObject<T>(result, new JsonSerializerSettings
            {
                ContractResolver = new GenericJsonPropertyNameContractResolver()
            });

            if (flickrResults.HasError)
            {
                throw ExceptionHandler.CreateResponseException(flickrResults);
            }

            return flickrResults;
        }
        catch (Exception)
        {
            throw;
        }
    }
}