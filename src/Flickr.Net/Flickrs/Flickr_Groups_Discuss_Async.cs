namespace Flickr.Net;

/// <summary>
/// The flickr.
/// </summary>
public sealed partial class FlickrClient : IFlickrGroupsDiscuss
{
    IFlickrGroupsDiscussReplies IFlickrGroupsDiscuss.Replies => this;

    IFlickrGroupsDiscussTopics IFlickrGroupsDiscuss.Topics => this;
}

/// <summary>
/// The flickr groups discuss.
/// </summary>
public interface IFlickrGroupsDiscuss
{
    /// <summary>
    /// </summary>
    IFlickrGroupsDiscussReplies Replies { get; }

    /// <summary>
    /// </summary>
    IFlickrGroupsDiscussTopics Topics { get; }
}