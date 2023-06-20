using Newtonsoft.Json;

namespace Flickr.Net.Core.Bases;

public abstract record PhotoBase : FlickrEntityBase<Id>
{
    [JsonProperty("secret")]
    public string Secret { get; set; }

    [JsonProperty("server")]
    public string Server { get; set; }

    [JsonProperty("title")]
    public string Title { get; set; }
}

public abstract record ExtendedPhotoBase : PhotoBase
{
    [JsonProperty("owner")]
    public string Owner { get; set; }

    [JsonProperty("farm")]
    public string Farm { get; set; }
}
