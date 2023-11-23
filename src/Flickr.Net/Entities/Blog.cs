using System.Text.Json.Serialization;
using Flickr.Net.Bases;

namespace Flickr.Net;

/// <summary>
/// Provides details of a specific blog, as configured by the user.
/// </summary>
public record Blog : FlickrEntityBase<Id>
{
    /// <summary>
    /// The name you have assigned to the blog in Flickr. ///
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// If Flickr stores the password for this then this will be 0, meaning you do not need to pass
    /// in the password when posting.
    /// </summary>
    [JsonPropertyName("needspassword")]
    public bool NeedPassword { get; set; }

    /// <summary>
    /// The URL of the blog website.
    /// </summary>
    [JsonPropertyName("url")]
    public string Url { get; set; }
}