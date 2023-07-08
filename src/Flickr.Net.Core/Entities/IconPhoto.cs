using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

[FlickrJsonPropertyName("photos")]
public record IconPhoto : UltraDeluxePhotoBase
{ }