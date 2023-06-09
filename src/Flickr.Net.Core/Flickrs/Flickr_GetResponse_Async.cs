﻿using System.Diagnostics;
using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Exceptions.Handlers;
using Flickr.Net.Core.Flickrs.Results;
using Flickr.Net.Core.Internals.Caching;
using Flickr.Net.Core.Internals.Extensions;

namespace Flickr.Net.Core;

/// <summary>
/// The flickr.
/// </summary>
public partial class Flickr
{
    private Task<FlickrContextResult<TNextPhoto, TPrevPhoto>> GetContextResponseAsync<TNextPhoto, TPrevPhoto>(Dictionary<string, string> parameters, CancellationToken cancellationToken = default) where TNextPhoto : IFlickrEntity where TPrevPhoto : IFlickrEntity => GetGenericResponseAsync<FlickrContextResult<TNextPhoto, TPrevPhoto>>(parameters, cancellationToken);

    private Task GetResponseAsync(Dictionary<string, string> parameters, CancellationToken cancellationToken = default) => GetGenericResponseAsync<FlickrExtendedDataResult>(parameters, cancellationToken);

    private Task<T> GetResponseAsync<T>(Dictionary<string, string> parameters, CancellationToken cancellationToken = default) where T : IFlickrEntity => GetGenericResponseAsync<FlickrResult<T>, T>(parameters, cancellationToken);

    private async Task<TResponse> GetGenericResponseAsync<T, TResponse>(Dictionary<string, string> parameters, CancellationToken cancellationToken = default) where T : FlickrResult<TResponse> where TResponse : IFlickrEntity
    {
        var result = await GetGenericResponseAsync<T>(parameters, cancellationToken);

        if (result.Content is TResponse value)
        {
            return value;
        }

        return default;
    }

    private async Task<T> GetGenericResponseAsync<T>(Dictionary<string, string> parameters, CancellationToken cancellationToken = default) where T : FlickrResult
    {
        CheckApiKey();

        parameters.Add("api_key", FlickrSettings.ApiKey);

        // If OAuth Token exists or no authentication required then use new OAuth
        if (!string.IsNullOrEmpty(FlickrSettings.OAuthAccessToken))

        {
            OAuthGetBasicParameters(parameters);

            parameters.AppendIf("oauth_token", FlickrSettings.OAuthAccessToken, x => !string.IsNullOrEmpty(x), x => x);
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

            var flickrResults = FlickrConvert.DeserializeObject<T>(result);

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