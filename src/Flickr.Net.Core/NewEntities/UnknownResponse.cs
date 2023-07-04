using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;
using Newtonsoft.Json.Linq;

namespace Flickr.Net.Core;

public class UnknownResponse : Dictionary<string, string>, IFlickrEntity
{ }

[FlickrJsonPropertyName("comment")]
public class CommentUnknownResponse : UnknownResponse
{ }

[FlickrJsonPropertyName("note")]
public class NoteUnknownResponse : UnknownResponse
{ }

[FlickrJsonPropertyName("photoset")]
public class PhotosetUnknownResponse : UnknownResponse
{ }

[FlickrJsonPropertyName("person")]
public class PersonUnknownResponse : UnknownResponse
{ }

[FlickrJsonPropertyName("group")]
public class GroupUnknownResponse : UnknownResponse
{ }

[FlickrJsonPropertyName("user")]
public class UserUnknownResponse : UnknownResponse
{ }