using Flickr.Net.Bases;
using Flickr.Net.Internals.Attributes;

namespace Flickr.Net;
[FlickrJsonPropertyName("photo")]
/// <summary>Represents a photo within a tag cluster.</summary>
public record ClusterPhoto : UltraDeluxePhotoBase;
