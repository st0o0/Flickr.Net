using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flickr.Net.Core.Internals.Attributes;
using Newtonsoft.Json;

namespace Flickr.Net.Core.NewEntities.Collections;

/// <summary>
/// Contains a list of <see cref="Blog"/> items for the user.
/// </summary>
[FlickrJsonPropertyName("blogs")]
internal class Blogs
{
    /// <summary>
    /// </summary>
    [JsonProperty("blog")]
    public List<Blog> Blog { get; set; }
}