using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flickr.Net.Core.Internals.Attributes;
using Flickr.Net.Core.Internals.JsonConverters;
using Flickr.Net.Core.NewEntities.Collections;
using Newtonsoft.Json;

namespace Flickr.Net.Core.NewEntities;

[FlickrJsonPropertyName("collection")]
public class Collection
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("child_count")]
    public int ChildCount { get; set; }

    [JsonProperty("datecreate")]
    [JsonConverter(typeof(FlickrTimestampToDateTimeConverter))]
    public DateTime DateCreate { get; set; }

    [JsonProperty("iconlarge")]
    public string Iconlarge { get; set; }

    [JsonProperty("iconsmall")]
    public string Iconsmall { get; set; }

    [JsonProperty("server")]
    public string Server { get; set; }

    [JsonProperty("secret")]
    public string Secret { get; set; }

    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("iconphotos")]
    public Photos IconPhotos { get; set; }
}
