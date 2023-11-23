using System.Net;
using System.Net.Http.Headers;
using Flickr.Net.Exceptions;

namespace Flickr.Net.Internals;

/// <summary>
/// The flickr responder.
/// </summary>
public static partial class FlickrResponder
{
    /// <summary>
    /// Gets a data response for the given base url and parameters, either using OAuth or not
    /// depending on which parameters were passed in.
    /// </summary>
    /// <param name="flickr">The current instance of the <see cref="Flickr"/> class.</param>
    /// <param name="baseUrl">The base url to be called.</param>
    /// <param name="parameters">A dictionary of parameters.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<byte[]> GetDataResponseAsync(Flickr flickr, string baseUrl, Dictionary<string, string> parameters, CancellationToken cancellationToken = default)
    {
        var oAuth = parameters.ContainsKey("oauth_consumer_key");

        parameters.TryAdd("format", "json");

        if (oAuth)
        {
            return await GetDataResponseOAuthAsync(flickr, baseUrl, parameters, cancellationToken);
        }
        else
        {
            return await GetDataResponseNormalAsync(flickr, baseUrl, parameters, cancellationToken);
        }
    }

    private static async Task<byte[]> GetDataResponseNormalAsync(Flickr flickr, string baseUrl, Dictionary<string, string> parameters, CancellationToken cancellationToken = default)
    {
        return await DownloadDataAsync(baseUrl, new FormUrlEncodedContent(parameters), null, cancellationToken);
    }

    private static async Task<byte[]> GetDataResponseOAuthAsync(Flickr flickr, string baseUrl, Dictionary<string, string> parameters, CancellationToken cancellationToken = default)
    {
        // Remove api key if it exists.
        parameters.Remove("api_key");

        parameters.Remove("api_sig");

        // If OAuth Access Token is set then add token and generate signature.
        if (!string.IsNullOrEmpty(flickr.FlickrSettings.OAuthAccessToken) && !parameters.ContainsKey("oauth_token"))
        {
            parameters.Add("oauth_token", flickr.FlickrSettings.OAuthAccessToken);
        }

        if (!string.IsNullOrEmpty(flickr.FlickrSettings.OAuthAccessTokenSecret) && !parameters.ContainsKey("oauth_signature"))
        {
            var sig = ((IFlickrOAuth)flickr).CalculateSignature("POST", baseUrl, parameters, flickr.FlickrSettings.OAuthAccessTokenSecret);
            parameters.Add("oauth_signature", sig);
        }

        // Calculate post data, content header and auth header
        var data = new FormUrlEncodedContent(parameters.Where((pair) => !pair.Key.StartsWith("oauth", StringComparison.Ordinal)));
        var authHeader = OAuthCalculateAuthHeader(parameters);

        // Download data.
        try
        {
            return await DownloadDataAsync(baseUrl, data, authHeader, cancellationToken);
        }
        catch (HttpRequestException ex)
        {
            if (ex == null)
            {
                throw;
            }

            if (ex.StatusCode != HttpStatusCode.BadRequest && ex.StatusCode != HttpStatusCode.Unauthorized)
            {
                throw;
            }

            throw new OAuthException(ex.Message, ex);
        }
    }

    private static async Task<byte[]> DownloadDataAsync(string baseUrl, FormUrlEncodedContent data, string authHeader, CancellationToken cancellationToken = default)
    {
        using HttpClient client = new();

        HttpRequestMessage message = new()
        {
            RequestUri = new Uri(baseUrl)
        };

        if (!string.IsNullOrEmpty(authHeader))
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("OAuth", authHeader.Replace("OAuth ", ""));
        }

        message.Method = HttpMethod.Post;
        message.Content = data;

        var response = await client.SendAsync(message, cancellationToken);
        try
        {
            response = response.EnsureSuccessStatusCode();
        }
        catch (Exception)
        {
            throw;
        }

        return await response.Content.ReadAsByteArrayAsync(cancellationToken);
    }
}