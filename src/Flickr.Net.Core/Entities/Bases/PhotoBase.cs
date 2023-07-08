namespace Flickr.Net.Core.Bases;

public abstract record PhotoBase : FlickrEntityBase<Id>
{
    [JsonProperty("secret")]
    public string Secret { get; set; }

    [JsonProperty("server")]
    public string Server { get; set; }
}

public abstract record DeluxePhotoBase : PhotoBase
{
    [JsonProperty("owner")]
    public string Owner { get; set; }

    [JsonProperty("farm")]
    public string Farm { get; set; }

    [JsonProperty("title")]
    public string Title { get; set; }
}

public abstract record UltraDeluxePhotoBase : DeluxePhotoBase
{
    [JsonProperty("ispublic")]
    public bool IsPublic { get; set; }

    [JsonProperty("isfriend")]
    public bool IsFriend { get; set; }

    [JsonProperty("isfamily")]
    public bool IsFamily { get; set; }
}
