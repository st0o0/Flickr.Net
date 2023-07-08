using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core.Bases;

public abstract record FlickrEntityBase<TIdentifier> : IFlickrEntity<TIdentifier> where TIdentifier : IIdentifierType
{
    [JsonPropertyGenericTypeName(0)]
    public TIdentifier Id { get; set; }
}

public abstract record FlickrEntityBase : IFlickrEntity { }

public interface IFlickrEntity<T> : IFlickrEntity where T : IIdentifierType
{
    [JsonPropertyGenericTypeName(0)]
    public T Id { get; set; }
}

public interface IFlickrEntity
{ }