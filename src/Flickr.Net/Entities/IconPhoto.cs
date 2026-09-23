using Flickr.Net.Bases;
using Flickr.Net.Internals.Attributes;

namespace Flickr.Net;
[FlickrJsonPropertyName("photos")]
/// <summary>Represents an icon photo used for collection thumbnails.</summary>
public record IconPhoto : UltraDeluxePhotoBase;
