using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flickr.Net.Core.Internals.JsonConverters;
using Newtonsoft.Json;

namespace Flickr.Net.Core.NewEntities;

public class Restrictions
{
    [JsonProperty("photos_ok")]
    [JsonConverter(typeof(BoolConverter))]
    public bool PhotosOk { get; set; }

    [JsonProperty("videos_ok")]
    [JsonConverter(typeof(BoolConverter))]
    public bool VideosOk { get; set; }

    [JsonProperty("images_ok")]
    [JsonConverter(typeof(BoolConverter))]
    public bool ImagesOk { get; set; }

    [JsonProperty("screens_ok")]
    [JsonConverter(typeof(BoolConverter))]
    public bool ScreensOk { get; set; }

    [JsonProperty("art_ok")]
    [JsonConverter(typeof(BoolConverter))]
    public bool ArtOk { get; set; }

    [JsonProperty("safe_ok")]
    [JsonConverter(typeof(BoolConverter))]
    public bool SafeOk { get; set; }

    [JsonProperty("moderate_ok")]
    [JsonConverter(typeof(BoolConverter))]
    public bool ModerateOk { get; set; }

    [JsonProperty("restricted_ok")]
    [JsonConverter(typeof(BoolConverter))]
    public bool RestrictedOk { get; set; }

    [JsonProperty("has_geo")]
    [JsonConverter(typeof(BoolConverter))]
    public bool HasGeo { get; set; }
}