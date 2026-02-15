using Flickr.Net.Internals.Attributes;

namespace Flickr.Net.Bases;

/// <inheritdoc/>
public abstract record FlickrEntityBase<TIdentifier> : IFlickrEntity<TIdentifier> where TIdentifier : IIdentifierType
{
    /// <inheritdoc/>
    [JsonPropertyGenericTypeName(0)]
    public TIdentifier Id { get; set; }
}

/// <inheritdoc/>
public abstract record FlickrEntityBase : IFlickrEntity;

/// <inheritdoc/>
public interface IFlickrEntity<T> : IFlickrEntity where T : IIdentifierType
{
    /// <summary>
    /// </summary>
    [JsonPropertyGenericTypeName(0)]
    public T Id { get; set; }
}

/// <summary>
/// </summary>
public interface IFlickrEntity;