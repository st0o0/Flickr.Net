using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flickr.Net.Core.Internals.JsonConverters;
using Newtonsoft.Json;

namespace Flickr.Net.Core.NewEntities;

/// <summary>
/// Provides details of a specific blog, as configured by the user.
/// </summary>
public class Blog
{
    /// <summary>
    /// The ID Flickr has assigned to the blog. Use this to post to the blog using <see
    /// cref="IFlickrBlogs.PostPhotoAsync(string, string, string, string, string, CancellationToken)"/>.
    /// </summary>
    [JsonProperty("id")]
    public string Id { get; set; }

    /// <summary>
    /// The name you have assigned to the blog in Flickr. ///
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    /// If Flickr stores the password for this then this will be 0, meaning you do not need to pass
    /// in the password when posting.
    /// </summary>
    [JsonProperty("needspassword")]
    [JsonConverter(typeof(BoolConverter))]
    public bool NeedPassword { get; set; }

    /// <summary>
    /// The URL of the blog website.
    /// </summary>
    [JsonProperty("url")]
    public string Url { get; set; }
}
