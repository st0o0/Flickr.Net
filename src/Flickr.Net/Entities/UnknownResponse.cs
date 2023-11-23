using Flickr.Net.Bases;
using Flickr.Net.Internals.Attributes;

namespace Flickr.Net;

/// <summary>
/// </summary>
public class UnknownResponse : Dictionary<string, string>, IFlickrEntity
{ }

/// <summary>
/// </summary>
[FlickrJsonPropertyName("comment")]
public class CommentUnknownResponse : UnknownResponse
{ }

/// <summary>
/// </summary>
[FlickrJsonPropertyName("note")]
public class NoteUnknownResponse : UnknownResponse
{ }

/// <summary>
/// </summary>
[FlickrJsonPropertyName("photoset")]
public class PhotosetUnknownResponse : UnknownResponse
{ }

/// <summary>
/// </summary>
[FlickrJsonPropertyName("person")]
public class PersonUnknownResponse : UnknownResponse
{ }

/// <summary>
/// </summary>
[FlickrJsonPropertyName("group")]
public class GroupUnknownResponse : UnknownResponse
{ }

/// <summary>
/// </summary>
[FlickrJsonPropertyName("user")]
public class UserUnknownResponse : UnknownResponse
{ }