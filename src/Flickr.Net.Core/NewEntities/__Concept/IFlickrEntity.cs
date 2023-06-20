using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core.NewEntities.__Concept;

public interface IFlickrEntity<T> where T : IIdentifierType
{
    [JsonPropertyGenericTypeName(0)]
    public T Id { get; set; }
}