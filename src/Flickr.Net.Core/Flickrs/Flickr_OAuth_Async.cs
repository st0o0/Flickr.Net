using System.Security.Cryptography;
using System.Text;
using Flickr.Net.Core.Internals.Extensions;

namespace Flickr.Net.Core;

/// <summary>
/// The flickr.
/// </summary>
public partial class Flickr : IFlickrOAuth
{
    async Task<OAuth> IFlickrOAuth.CheckTokenAsync(CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        var parameters = new Dictionary<string, string>
        {
            { "method", "flickr.auth.oauth.checkToken" }
        };

        return await GetResponseAsync<OAuth>(parameters, cancellationToken);
    }

    async Task<OAuthRequestToken> IFlickrOAuth.GetRequestTokenAsync(string callbackUrl, CancellationToken cancellationToken)
    {
        CheckApiKey();

        var url = "https://www.flickr.com/services/oauth/request_token";

        var parameters = OAuthGetBasicParameters();

        parameters.Add("oauth_callback", callbackUrl);

        var sig = ((IFlickrOAuth)this).CalculateSignature("POST", url, parameters, null);

        parameters.Add("oauth_signature", sig);

        var result = await FlickrResponder.GetDataResponseAsync(this, url, parameters, cancellationToken);

        return OAuthRequestToken.ParseResponse(result);
    }

    async Task<OAuthAccessToken> IFlickrOAuth.GetAccessTokenAsync(OAuthRequestToken requestToken, string verifier, CancellationToken cancellationToken)
    {
        CheckApiKey();

        var url = "https://www.flickr.com/services/oauth/access_token";

        var parameters = OAuthGetBasicParameters();

        parameters.Add("oauth_verifier", verifier);
        parameters.Add("oauth_token", requestToken.TokenSecret);

        var sig = ((IFlickrOAuth)this).CalculateSignature("POST", url, parameters, requestToken.TokenSecret);

        parameters.Add("oauth_signature", sig);

        var result = await FlickrResponder.GetDataResponseAsync(this, url, parameters, cancellationToken);

        return OAuthAccessToken.ParseResponse(result);
    }

    string IFlickrOAuth.CalculateSignature(string method, string url, Dictionary<string, string> parameters, string tokenSecret)
    {
        var key = FlickrSettings.ApiSecret + "&" + tokenSecret;
        var keyBytes = Encoding.UTF8.GetBytes(key);

        SortedList<string, string> sorted = new();
        foreach (var pair in parameters)
        {
            sorted.Add(pair.Key, pair.Value);
        }

        StringBuilder sb = new();
        foreach (var pair in sorted)
        {
            sb.Append(pair.Key);
            sb.Append('=');
            sb.Append(UtilityMethods.EscapeOAuthString(pair.Value));
            sb.Append('&');
        }

        sb.Remove(sb.Length - 1, 1);

        var baseString = method + "&" + UtilityMethods.EscapeOAuthString(url) + "&" + UtilityMethods.EscapeOAuthString(sb.ToString());

        HMACSHA1 sha1 = new(keyBytes);

        var hashBytes = sha1.ComputeHash(Encoding.UTF8.GetBytes(baseString));

        return Convert.ToBase64String(hashBytes);
    }

    string IFlickrOAuth.CalculateAuthorizationUrl(string requestToken, AuthLevel perms, bool mobile)
    {
        var permsString = (perms == AuthLevel.None) ? "" : "&perms=" + perms.ToFlickrString();

        return "https://" + (mobile ? "m" : "www") + ".flickr.com/services/oauth/authorize?oauth_token=" + requestToken + permsString;
    }

    /// <summary>
    /// Populates the given dictionary with the basic OAuth parameters, oauth_timestamp,
    /// oauth_noonce etc.
    /// </summary>
    /// <param name="parameters">Dictionary to be populated with the OAuth parameters.</param>
    private void OAuthGetBasicParameters(Dictionary<string, string> parameters)
    {
        var oAuthParameters = OAuthGetBasicParameters();
        foreach (var k in oAuthParameters)
        {
            parameters.Add(k.Key, k.Value);
        }
    }

    /// <summary>
    /// Returns a new dictionary containing the basic OAuth parameters.
    /// </summary>
    /// <returns></returns>
    private Dictionary<string, string> OAuthGetBasicParameters()
    {
        var oauthtimestamp = UtilityMethods.DateToUnixTimestamp(DateTime.UtcNow);
        var oauthnonce = Guid.NewGuid().ToString("N");

        Dictionary<string, string> parameters = new()
        {
            { "oauth_nonce", oauthnonce },
            { "oauth_timestamp", oauthtimestamp },
            { "oauth_version", "1.0" },
            { "oauth_signature_method", "HMAC-SHA1" },
            { "oauth_consumer_key", FlickrSettings.ApiKey }
        };
        return parameters;
    }
}

/// <summary>
/// The flickr o auth.
/// </summary>
public interface IFlickrOAuth
{
    /// <summary>
    /// Checks the OAuth token, returns user information and permissions if valid.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<OAuth> CheckTokenAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Get an <see cref="OAuthRequestToken"/> for the given callback URL.
    /// </summary>
    /// <remarks>Specify 'oob' as the callback url for no callback to be performed.</remarks>
    /// <param name="callbackUrl">The callback Uri, or 'oob' if no callback is to be performed.</param>
    /// <param name="cancellationToken"></param>
    Task<OAuthRequestToken> GetRequestTokenAsync(string callbackUrl, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns an access token for the given request token, secret and authorization verifier.
    /// </summary>
    /// <param name="requestToken"></param>
    /// <param name="verifier"></param>
    /// <param name="cancellationToken"></param>
    Task<OAuthAccessToken> GetAccessTokenAsync(OAuthRequestToken requestToken, string verifier, CancellationToken cancellationToken = default);

    /// <summary>
    /// Calculates the signature for an OAuth call.
    /// </summary>
    /// <param name="method">POST or GET method.</param>
    /// <param name="url">The URL the request will be sent to.</param>
    /// <param name="parameters">Parameters to be added to the signature.</param>
    /// <param name="tokenSecret">
    /// The token secret (either request or access) for generating the SHA-1 key.
    /// </param>
    /// <returns>Base64 encoded SHA-1 hash.</returns>
    string CalculateSignature(string method, string url, Dictionary<string, string> parameters, string tokenSecret);

    /// <summary>
    /// Returns the authorization URL for OAuth authorization, based off the request token and
    /// permissions provided.
    /// </summary>
    /// <param name="requestToken">The request token to include in the authorization url.</param>
    /// <param name="perms">The permissions being requested.</param>
    /// <param name="mobile">Should the url be generated be the mobile one or not.</param>
    /// <returns></returns>
    string CalculateAuthorizationUrl(string requestToken, AuthLevel perms, bool mobile);
}