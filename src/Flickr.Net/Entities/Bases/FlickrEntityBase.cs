using Flickr.Net.Internals.Attributes;

namespace Flickr.Net.Bases;

/// <inheritdoc/>
public abstract record FlickrEntityBase<TIdentifier> : IFlickrEntity<TIdentifier> where TIdentifier : IIdentifierType
{
    /// <inheritdoc/>
    [JsonPropertyGenericTypeName(0)]
    public TIdentifier Id { get; init; } = default!;
}

/// <inheritdoc/>
public abstract record FlickrEntityBase : IFlickrEntity;

/// <inheritdoc/>
public interface IFlickrEntity<T> : IFlickrEntity where T : IIdentifierType
{    [JsonPropertyGenericTypeName(0)]
    /// <summary>The unique identifier.</summary>
    public T Id { get; init; }
}
/// <summary>Marker interface for all Flickr API entity types.</summary>
public interface IFlickrEntity;
