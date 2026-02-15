using Flickr.Net.Internals;

namespace Flickr.Net.Entities;

/// <summary>
/// The access authentication token return by Flickr after a successful authentication.
/// </summary>
public record OAuthAccessToken
{
    /// <summary>
    /// The access token string.
    /// </summary>
    public string Token { get; set; }

    ///<summary>
    /// The access token secret.
    ///  </summary>
    public string TokenSecret { get; set; }

    ///<summary>
    /// The user id of the authenticated user.
    ///</summary>
    public string UserId { get; set; }

    ///<summary>
    /// The username (screenname) of the authenticated user. ///
    ///</summary>
    public string Username { get; set; }

    ///<summary>
    /// The full name of the authenticated user. ///
    /// </summary>
    public string FullName { get; set; }

    ///<summary>
    /// Parses a URL parameter encoded string and returns a new
    /// <see cref="OAuthAccessToken"/>
    ///</summary>
    ///<param name = "response" > A URL parameter encoded string, e.g. "oauth_token=ABC&amp;oauth_token_secret=DEF&amp;user_id=1234567@N00".</param>
    ///<returns></returns>
    internal static OAuthAccessToken ParseResponse(string response)
    {
        var parts = UtilityMethods.StringToDictionary(response);

        OAuthAccessToken token = new(); if (parts.TryGetValue("oauth_token", out var oauth_token))
        {
            token = token with { Token = oauth_token };
        }

        if (parts.TryGetValue("oauth_token_secret", out var oauth_token_secret))
        {
            token = token with
            {
                TokenSecret = oauth_token_secret
            };
        }

        if (parts.TryGetValue("user_nsid", out var user_nsid))
        {
            token = token with
            {
                UserId = user_nsid
            };
        }

        if (parts.TryGetValue("fullname", out var fullname))
        {
            token = token with
            {
                FullName = fullname
            };
        }

        if (parts.TryGetValue("username", out var username))
        {
            token = token with
            {
                Username = username
            };
        }

        return token;
    }
}