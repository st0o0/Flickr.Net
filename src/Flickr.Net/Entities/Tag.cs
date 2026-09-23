using Flickr.Net.Internals.Attributes;

namespace Flickr.Net;

[FlickrJsonPropertyName("tag")]
/// <summary>Represents a tag.</summary>
public record Tag : TagBase;
