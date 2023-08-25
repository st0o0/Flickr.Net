using System.Text.Json.Serialization;

namespace Flickr.Net.Core.Bases;

public abstract record PhotoBase : FlickrEntityBase<Id>
{
    [JsonPropertyName("secret")]
    public string Secret { get; set; }

    [JsonPropertyName("server")]
    public string Server { get; set; }
}

public abstract record DeluxePhotoBase : PhotoBase
{
    [JsonPropertyName("owner")]
    public string Owner { get; set; }

    [JsonPropertyName("farm")]
    public string Farm { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }
}

public abstract record UltraDeluxePhotoBase : DeluxePhotoBase
{
    [JsonPropertyName("ispublic")]
    public bool IsPublic { get; set; }

    [JsonPropertyName("isfriend")]
    public bool IsFriend { get; set; }

    [JsonPropertyName("isfamily")]
    public bool IsFamily { get; set; }
}
