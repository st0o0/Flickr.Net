using Flickr.Net.Bases;
using Flickr.Net.Internals.Attributes;

namespace Flickr.Net;
/// <summary>Represents a raw/unknown response from the Flickr API.</summary>
public class UnknownResponse : Dictionary<string, string>, IFlickrEntity;
[FlickrJsonPropertyName("comment")]
public class CommentUnknownResponse : UnknownResponse;
[FlickrJsonPropertyName("note")]
public class NoteUnknownResponse : UnknownResponse;
[FlickrJsonPropertyName("photoset")]
public class PhotosetUnknownResponse : UnknownResponse;
[FlickrJsonPropertyName("person")]
public class PersonUnknownResponse : UnknownResponse;
[FlickrJsonPropertyName("group")]
public class GroupUnknownResponse : UnknownResponse;
[FlickrJsonPropertyName("user")]
public class UserUnknownResponse : UnknownResponse;
