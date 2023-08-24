using Flickr.Net.Core.Internals.Attributes;
using Flickr.Net.Core.Internals.JsonConverters.IdentifierConverters;

namespace Flickr.Net.Core.Bases;

public interface IIdentifierType
{
}

[FlickrJsonPropertyName("nsid")]
[System.Text.Json.Serialization.JsonConverter(typeof(NsIdConverter))]
public struct NsId : IIdentifierType
{
    private string _id;

    public static implicit operator string(NsId value) => value._id;

    public static implicit operator NsId(string value) => new() { _id = value };
}

[FlickrJsonPropertyName("id")]
[System.Text.Json.Serialization.JsonConverter(typeof(IdConverter))]
public struct Id : IIdentifierType
{
    private string _id;

    public static implicit operator string(Id value) => value._id;

    public static implicit operator Id(string value) => new() { _id = value };
}

[FlickrJsonPropertyName("photo_id")]
[System.Text.Json.Serialization.JsonConverter(typeof(PhotoIdConverter))]
public struct PhotoId : IIdentifierType
{
    private string _id;

    public static implicit operator string(PhotoId value) => value._id;

    public static implicit operator PhotoId(string value) => new() { _id = value };
}

[FlickrJsonPropertyName("photoset_id")]
[System.Text.Json.Serialization.JsonConverter(typeof(PhotosetIdConverter))]
public struct PhotosetId : IIdentifierType
{
    private string _id;

    public static implicit operator string(PhotosetId value) => value._id;

    public static implicit operator PhotosetId(string value) => new() { _id = value };
}