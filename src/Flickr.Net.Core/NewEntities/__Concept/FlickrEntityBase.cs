using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core.NewEntities.__Concept;
public abstract record FlickrEntityBase<TIdentifier> : IFlickrEntity<TIdentifier> where TIdentifier : IIdentifierType
{
    [JsonPropertyGenericTypeName(0)]
    public TIdentifier Id { get; set; }
}