using System.Net;
using System.Net.Http.Headers;
using Flickr.Net.Exceptions;

namespace Flickr.Net.Internals;

internal partial class FlickrResponder
{
    internal async Task<byte[]> GetDataResponseAsync(FlickrClient flickr, string baseUrl, Dictionary<string, string> parameters, CancellationToken cancellationToken = default)
    {
        var oAuth = parameters.ContainsKey("oauth_consumer_key");

        if (!parameters.ContainsKey("oauth_signature"))
        {
            parameters.TryAdd("format", "json");
            parameters.TryAdd("nojsoncallback", "1");
        }

        if (oAuth)
        {
            return await GetDataResponseOAuthAsync(flickr, baseUrl, parameters, cancellationToken).ConfigureAwait(false);
        }

        return await GetDataResponseNormalAsync(flickr, baseUrl, parameters, cancellationToken).ConfigureAwait(false);
    }

    private async Task<byte[]> GetDataResponseNormalAsync(FlickrClient flickr, string baseUrl, Dictionary<string, string> parameters, CancellationToken cancellationToken = default)
    {
        return await DownloadDataAsync(baseUrl, new FormUrlEncodedContent(parameters), null, isOAuth: false, cancellationToken).ConfigureAwait(false);
    }

    private async Task<byte[]> GetDataResponseOAuthAsync(FlickrClient flickr, string baseUrl, Dictionary<string, string> parameters, CancellationToken cancellationToken = default)
    {
        parameters.Remove("api_key");
        parameters.Remove("api_sig");

        if (!string.IsNullOrEmpty(flickr.FlickrSettings.OAuthAccessToken) && !parameters.ContainsKey("oauth_token"))
        {
            parameters.Add("oauth_token", flickr.FlickrSettings.OAuthAccessToken);
        }

        if (!string.IsNullOrEmpty(flickr.FlickrSettings.OAuthAccessTokenSecret) && !parameters.ContainsKey("oauth_signature"))
        {
            var sig = ((IFlickrOAuth)flickr).CalculateSignature("POST", baseUrl, parameters, flickr.FlickrSettings.OAuthAccessTokenSecret);
            parameters.Add("oauth_signature", sig);
        }

        var data = new FormUrlEncodedContent(parameters.Where(pair => !pair.Key.StartsWith("oauth", StringComparison.Ordinal)));
        var authHeader = OAuthCalculateAuthHeader(parameters);

        return await DownloadDataAsync(baseUrl, data, authHeader, isOAuth: true, cancellationToken).ConfigureAwait(false);
    }

    private async Task<byte[]> DownloadDataAsync(string baseUrl, FormUrlEncodedContent data, string? authHeader, bool isOAuth, CancellationToken cancellationToken = default)
    {
        HttpRequestMessage message = new()
        {
            RequestUri = new Uri(baseUrl),
            Method = HttpMethod.Post,
            Content = data
        };

        if (!string.IsNullOrEmpty(authHeader))
        {
            message.Headers.Authorization = new AuthenticationHeaderValue("OAuth", authHeader.Replace("OAuth ", ""));
        }

        var response = await _httpClient.SendAsync(message, cancellationToken).ConfigureAwait(false);

        if (!response.IsSuccessStatusCode)
        {
            var body = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);

            if (isOAuth && response.StatusCode is HttpStatusCode.BadRequest or HttpStatusCode.Unauthorized)
            {
                throw new OAuthException(body, new HttpRequestException(
                    $"Response status code does not indicate success: {(int)response.StatusCode} ({response.StatusCode}).",
                    inner: null,
                    response.StatusCode));
            }

            throw new HttpRequestException(
                $"Response status code does not indicate success: {(int)response.StatusCode} ({response.StatusCode}).",
                inner: null,
                response.StatusCode);
        }

        return await response.Content.ReadAsByteArrayAsync(cancellationToken).ConfigureAwait(false);
    }

    internal async Task<Stream> GetDataResponseStreamAsync(FlickrClient flickr, string baseUrl, Dictionary<string, string> parameters, CancellationToken cancellationToken = default)
    {
        var oAuth = parameters.ContainsKey("oauth_consumer_key");

        if (!parameters.ContainsKey("oauth_signature"))
        {
            parameters.TryAdd("format", "json");
            parameters.TryAdd("nojsoncallback", "1");
        }

        if (oAuth)
        {
            return await GetDataResponseOAuthStreamAsync(flickr, baseUrl, parameters, cancellationToken).ConfigureAwait(false);
        }

        return await GetDataResponseNormalStreamAsync(flickr, baseUrl, parameters, cancellationToken).ConfigureAwait(false);
    }

    private async Task<Stream> GetDataResponseNormalStreamAsync(FlickrClient flickr, string baseUrl, Dictionary<string, string> parameters, CancellationToken cancellationToken = default)
    {
        return await DownloadDataStreamAsync(baseUrl, new FormUrlEncodedContent(parameters), null, isOAuth: false, cancellationToken).ConfigureAwait(false);
    }

    private async Task<Stream> GetDataResponseOAuthStreamAsync(FlickrClient flickr, string baseUrl, Dictionary<string, string> parameters, CancellationToken cancellationToken = default)
    {
        parameters.Remove("api_key");
        parameters.Remove("api_sig");

        if (!string.IsNullOrEmpty(flickr.FlickrSettings.OAuthAccessToken) && !parameters.ContainsKey("oauth_token"))
        {
            parameters.Add("oauth_token", flickr.FlickrSettings.OAuthAccessToken);
        }

        if (!string.IsNullOrEmpty(flickr.FlickrSettings.OAuthAccessTokenSecret) && !parameters.ContainsKey("oauth_signature"))
        {
            var sig = ((IFlickrOAuth)flickr).CalculateSignature("POST", baseUrl, parameters, flickr.FlickrSettings.OAuthAccessTokenSecret);
            parameters.Add("oauth_signature", sig);
        }

        var data = new FormUrlEncodedContent(parameters.Where(pair => !pair.Key.StartsWith("oauth", StringComparison.Ordinal)));
        var authHeader = OAuthCalculateAuthHeader(parameters);

        return await DownloadDataStreamAsync(baseUrl, data, authHeader, isOAuth: true, cancellationToken).ConfigureAwait(false);
    }

    private async Task<Stream> DownloadDataStreamAsync(string baseUrl, FormUrlEncodedContent data, string? authHeader, bool isOAuth, CancellationToken cancellationToken = default)
    {
        HttpRequestMessage message = new()
        {
            RequestUri = new Uri(baseUrl),
            Method = HttpMethod.Post,
            Content = data
        };

        if (!string.IsNullOrEmpty(authHeader))
        {
            message.Headers.Authorization = new AuthenticationHeaderValue("OAuth", authHeader.Replace("OAuth ", ""));
        }

        var response = await _httpClient.SendAsync(message, cancellationToken).ConfigureAwait(false);

        if (!response.IsSuccessStatusCode)
        {
            var body = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);

            if (isOAuth && response.StatusCode is HttpStatusCode.BadRequest or HttpStatusCode.Unauthorized)
            {
                throw new OAuthException(body, new HttpRequestException(
                    $"Response status code does not indicate success: {(int)response.StatusCode} ({response.StatusCode}).",
                    inner: null,
                    response.StatusCode));
            }

            throw new HttpRequestException(
                $"Response status code does not indicate success: {(int)response.StatusCode} ({response.StatusCode}).",
                inner: null,
                response.StatusCode);
        }

        return await response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);
    }
}
