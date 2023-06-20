using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core.Bases;

public interface IIdentifierType
{
}

[FlickrJsonPropertyName("nsid")]
public struct NsId : IIdentifierType
{
    private string _id;

    public static implicit operator string(NsId value) => value._id;

    public static implicit operator NsId(string value) => new() { _id = value };
}

[FlickrJsonPropertyName("id")]
public struct Id : IIdentifierType
{
    private string _id;

    public static implicit operator string(Id value) => value._id;

    public static implicit operator Id(string value) => new() { _id = value };
}