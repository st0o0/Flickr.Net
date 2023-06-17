using Flickr.Net.Core.Internals.Attributes;
using Newtonsoft.Json;

namespace Flickr.Net.Core.NewEntities;

/// <summary>
/// Contains details of a user
/// </summary>
[FlickrJsonPropertyName("user")]
public class User
{
    /// <summary>
    /// The ID of the found user.
    /// </summary>
    [JsonProperty("nsid")]
    public string Id { get; set; }

    /// <summary>
    /// The username of the found user.
    /// </summary>
    [JsonProperty("username")]
    public string UserName { get; set; }

    /// <summary>
    /// The full name of the user. Only returned by <see
    /// cref="IFlickrOAuth.GetAccessTokenAsync(OAuthRequestToken, string, CancellationToken)"/>.
    /// </summary>
    [JsonProperty("fullname")]
    public string FullName { get; set; }
}
