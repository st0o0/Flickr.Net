using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

/// <summary>
/// Successful authentication returns a <see cref="OAuth"/> object.
/// </summary>
[FlickrJsonPropertyName("oauth")]
public sealed record OAuth : FlickrEntityBase
{
    /// <summary>
    /// The authentication token returned by the <see
    /// cref="IFlickrOAuth.GetAccessTokenAsync(OAuthRequestToken, string, CancellationToken)"/> or
    /// <see cref="IFlickrOAuth.CheckTokenAsync(CancellationToken)"/> methods.
    /// </summary>
    [JsonPropertyName("token")]
    public string Token { get; set; }

    /// <summary>
    /// The permissions the current token allows the application to perform.
    /// </summary>
    [JsonPropertyName("perms")]
    public AuthLevel Perms { get; set; }

    /// <summary>
    /// The <see cref="User"/> object associated with the token. Readonly.
    /// </summary>
    [JsonPropertyName("user")]
    public User User { get; set; }
}