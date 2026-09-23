using Flickr.Net.Bases;
using Flickr.Net.Internals.Attributes;

namespace Flickr.Net;
[FlickrJsonPropertyName("group")]
/// <summary>Represents a group returned from a search query.</summary>
public record GroupSearchResult : GroupBase;
