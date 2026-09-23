using Flickr.Net.Internals.Attributes;

namespace Flickr.Net;
[FlickrJsonPropertyName("tag")]
/// <summary>Represents a tag within a cluster.</summary>
public record ClusterTag : TagBase;
