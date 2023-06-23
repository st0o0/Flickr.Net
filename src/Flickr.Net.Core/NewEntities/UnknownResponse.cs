using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

public class UnknownResponse : Dictionary<string, string>, IFlickrEntity
{ }

[FlickrJsonPropertyName("group")]
public class GroupUnknownResponse : UnknownResponse
{ }

[FlickrJsonPropertyName("comment")]
public class CommentUnknownResponse : UnknownResponse
{ }

[FlickrJsonPropertyName("panda")]
public class PandaUnknownResponse : UnknownResponse
{ }