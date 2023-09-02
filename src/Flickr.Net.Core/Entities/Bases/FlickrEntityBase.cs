using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core.Bases;

/// <summary>
/// </summary>
public abstract record FlickrEntityBase<TIdentifier> : IFlickrEntity<TIdentifier> where TIdentifier : IdentifierType
{
    /// <summary>
    /// </summary>
    [JsonPropertyGenericTypeName(0)]
    public TIdentifier Id { get; set; }
}

/// <summary>
/// </summary>
public abstract record FlickrEntityBase : IFlickrEntity { }

/// <summary>
/// </summary>
public interface IFlickrEntity<T> : IFlickrEntity where T : IdentifierType
{
    /// <summary>
    /// </summary>
    [JsonPropertyGenericTypeName(0)]
    public T Id { get; set; }
}

/// <summary>
/// </summary>
public interface IFlickrEntity
{ }