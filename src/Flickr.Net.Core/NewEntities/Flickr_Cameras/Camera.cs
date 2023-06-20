using Flickr.Net.Core.NewEntities.Flickr_Cameras;
using Newtonsoft.Json;

namespace Flickr.Net.Core.NewEntities;

public class Camera
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("details")]
    public Details Details { get; set; }

    [JsonProperty("images")]
    public Image Image { get; set; }
}