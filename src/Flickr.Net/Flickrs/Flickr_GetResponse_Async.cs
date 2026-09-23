using Flickr.Net.Bases;
using Flickr.Net.Flickrs.Results;
using Flickr.Net.Internals;
using Flickr.Net.Internals.Extensions;
using Microsoft.Extensions.Caching.Hybrid;

namespace Flickr.Net;

public sealed partial class FlickrClient
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

        if (!string.IsNullOrEmpty(FlickrSettings.OAuthAccessToken))
        {
            OAuthGetBasicParameters(parameters);

            parameters.AppendIf("oauth_token", FlickrSettings.OAuthAccessToken, x => !string.IsNullOrEmpty(x), x => x);
        }

        var url = CalculateUri(parameters, !string.IsNullOrEmpty(FlickrSettings.ApiSecret));

        byte[] resultArray;

        if (_cache is not null)
        {
            resultArray = await _cache.GetOrCreateAsync(
                url,
                async cancel => await _responder.GetDataResponseAsync(this, BaseUri.AbsoluteUri, parameters, cancel),
                cancellationToken: cancellationToken);
        }
        else
        {
            resultArray = await _responder.GetDataResponseAsync(this, BaseUri.AbsoluteUri, parameters, cancellationToken);
        }

        var flickrResults = FlickrConvert.DeserializeObject<T>(resultArray);
        return flickrResults.EnsureSuccessStatusCode();
    }
}
