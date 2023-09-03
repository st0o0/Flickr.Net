using System.Net;
using System.Net.Http.Headers;
using Flickr.Net.Core.Exceptions;
using Flickr.Net.Core.Internals.Extensions;

namespace Flickr.Net.Core.Internals;

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
    /// <param name="uri">The url to be called.</param>
    /// <param name="parameters">A dictionary of parameters.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<Stream> GetDataResponseAsync(Flickr flickr, Uri uri, Dictionary<string, string> parameters, CancellationToken cancellationToken = default)
    {
        var oAuth = parameters.ContainsKey("oauth_consumer_key");

        parameters.TryAdd("format", "json");

        if (oAuth)
        {
            return await GetDataResponseOAuthAsync(flickr, uri, parameters, cancellationToken);
        }
        else
        {
            return await GetDataResponseNormalAsync(flickr, uri, parameters, cancellationToken);
        }
    }

    private static async Task<Stream> GetDataResponseNormalAsync(Flickr flickr, Uri uri, Dictionary<string, string> parameters, CancellationToken cancellationToken = default)
    {
        return await DownloadDataAsync(uri, new FormUrlEncodedContent(parameters), null, cancellationToken);
    }

    private static async Task<Stream> GetDataResponseOAuthAsync(Flickr flickr, Uri uri, Dictionary<string, string> parameters, CancellationToken cancellationToken = default)
    {
        // Remove api key if it exists.
        parameters.Remove("api_key");

        parameters.Remove("api_sig");

        // If OAuth Access Token is set then add token and generate signature.

        parameters.AppendIf(
            "oauth_token",
            flickr.FlickrSettings.OAuthAccessToken,
            x => !string.IsNullOrEmpty(x) && !parameters.ContainsKey("oauth_token")
            );

        parameters.AppendIf(
            "oauth_signature",
            flickr.FlickrSettings.OAuthAccessTokenSecret,
            x => !string.IsNullOrEmpty(x) && !parameters.ContainsKey("oauth_signature"),
            x => flickr.OAuth.CalculateSignature("POST", uri.AbsoluteUri, parameters, x)
            );

        // Calculate post data, content header and auth header
        var data = new FormUrlEncodedContent(parameters.Where((pair) => !pair.Key.StartsWith("oauth", StringComparison.Ordinal)));
        var authHeader = OAuthCalculateAuthHeader(parameters);

        // Download data.
        try
        {
            return await DownloadDataAsync(uri, data, authHeader, cancellationToken);
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

    private static async Task<Stream> DownloadDataAsync(Uri uri, FormUrlEncodedContent data, string authHeader, CancellationToken cancellationToken = default)
    {
        using HttpClient client = new();

        HttpRequestMessage message = new()
        {
            RequestUri = uri
        };

        if (!string.IsNullOrEmpty(authHeader))
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("OAuth", authHeader.Replace("OAuth ", ""));
        }

        message.Method = HttpMethod.Post;
        message.Content = data;

        var response = await client.SendAsync(message, cancellationToken);
        response = response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStreamAsync(cancellationToken);
    }
}