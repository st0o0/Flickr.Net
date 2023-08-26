using Flickr.Net.Core.Internals.Attributes;
using Flickr.Net.Core.Internals.JsonConverters.IdentifierConverters;

namespace Flickr.Net.Core.Bases;

public interface IIdentifierType
{
}

public abstract record IdentifierType : IIdentifierType
{
    protected string _id;

    public static implicit operator string(IdentifierType value) => value._id;

    public static implicit operator IdentifierType(string value) => new Id() { _id = value };
}

[FlickrJsonPropertyName("id")]
public record Id : IdentifierType
{
    public static implicit operator string(Id value) => value._id;

    public static implicit operator Id(string value) => new Id() { _id = value };
}

[FlickrJsonPropertyName("nsid")]
public record NsId : IdentifierType
{
    public static implicit operator string(NsId value) => value._id;

    public static implicit operator NsId(string value) => new NsId() { _id = value };
}

[FlickrJsonPropertyName("photo_id")]
public record PhotoId : IdentifierType
{
    public static implicit operator string(PhotoId value) => value._id;

    public static implicit operator PhotoId(string value) => new PhotoId() { _id = value };
}

[FlickrJsonPropertyName("photoset_id")]
public record PhotosetId : IdentifierType
{
    public static implicit operator string(PhotosetId value) => value._id;

    public static implicit operator PhotosetId(string value) => new PhotosetId() { _id = value };
}