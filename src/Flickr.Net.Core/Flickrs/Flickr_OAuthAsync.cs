namespace FlickrNet.Core;

public partial class Flickr
{
    /// <summary>
    /// Get an <see cref="OAuthRequestToken"/> for the given callback URL.
    /// </summary>
    /// <remarks>Specify 'oob' as the callback url for no callback to be performed.</remarks>
    /// <param name="callbackUrl">The callback Uri, or 'oob' if no callback is to be performed.</param>
    public async Task<OAuthRequestToken> OAuthGetRequestTokenAsync(string callbackUrl, CancellationToken cancellationToken = default)
    {
        CheckApiKey();

        string url = "https://www.flickr.com/services/oauth/request_token";

        Dictionary<string, string> parameters = OAuthGetBasicParameters();

        parameters.Add("oauth_callback", callbackUrl);

        string sig = OAuthCalculateSignature("POST", url, parameters, null);

        parameters.Add("oauth_signature", sig);

        byte[] result = await FlickrResponder.GetDataResponseAsync(this, url, parameters, cancellationToken);

        return OAuthRequestToken.ParseResponse(result);
    }

    /// <summary>
    /// Returns an access token for the given request token, secret and authorization verifier.
    /// </summary>
    /// <param name="requestToken"></param>
    /// <param name="verifier"></param>
    public async Task<FlickrNet.Core.Internals.OAuthRequestToken> OAuthGetAccessTokenAsync(OAuthRequestToken requestToken, string verifier, CancellationToken cancellationToken = default)
    {
        return await OAuthGetAccessTokenAsync(requestToken.Token, requestToken.TokenSecret, verifier, cancellationToken);
    }

    /// <summary>
    /// For a given request token and verifier string return an access token.
    /// </summary>
    /// <param name="requestToken"></param>
    /// <param name="requestTokenSecret"></param>
    /// <param name="verifier"></param>
    public async Task<FlickrNet.Core.Internals.OAuthRequestToken> OAuthGetAccessTokenAsync(string requestToken, string requestTokenSecret, string verifier, CancellationToken cancellationToken = default)
    {
        CheckApiKey();

        string url = "https://www.flickr.com/services/oauth/access_token";

        Dictionary<string, string> parameters = OAuthGetBasicParameters();

        parameters.Add("oauth_verifier", verifier);
        parameters.Add("oauth_token", requestToken);

        string sig = OAuthCalculateSignature("POST", url, parameters, requestTokenSecret);

        parameters.Add("oauth_signature", sig);

        byte[] result = await FlickrResponder.GetDataResponseAsync(this, url, parameters, cancellationToken);

        return FlickrNet.Core.Internals.OAuthRequestToken.ParseResponse(result);
    }
}