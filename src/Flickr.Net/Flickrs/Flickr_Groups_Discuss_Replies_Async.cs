using System.Globalization;
using Flickr.Net.Internals.Extensions;

namespace Flickr.Net;

/// <summary>
/// The flickr.
/// </summary>
public partial class Flickr : IFlickrGroupsDiscussReplies
{
    async Task IFlickrGroupsDiscussReplies.AddAsync(string topicId, string message, CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        ArgumentException.ThrowIfNullOrEmpty(topicId);

        ArgumentException.ThrowIfNullOrEmpty(message);

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.groups.discuss.replies.add" },
            { "topic_id", topicId },
            { "message", message }
        };

        await GetResponseAsync(parameters, cancellationToken);
    }

    async Task IFlickrGroupsDiscussReplies.DeleteAsync(string topicId, string replyId, CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        ArgumentException.ThrowIfNullOrEmpty(topicId);

        ArgumentException.ThrowIfNullOrEmpty(replyId);

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.groups.discuss.replies.delete" },
            { "topic_id", topicId },
            { "reply_id", replyId }
        };

        await GetResponseAsync(parameters, cancellationToken);
    }

    async Task IFlickrGroupsDiscussReplies.EditAsync(string topicId, string replyId, string message, CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        ArgumentException.ThrowIfNullOrEmpty(topicId);

        ArgumentException.ThrowIfNullOrEmpty(replyId);

        ArgumentException.ThrowIfNullOrEmpty(message);

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.groups.discuss.replies.edit" },
            { "topic_id", topicId },
            { "reply_id", replyId },
            { "message", message }
        };

        await GetResponseAsync(parameters, cancellationToken);
    }

    async Task<Reply> IFlickrGroupsDiscussReplies.GetInfoAsync(string topicId, string replyId, CancellationToken cancellationToken)
    {
        ArgumentException.ThrowIfNullOrEmpty(topicId);
        ArgumentException.ThrowIfNullOrEmpty(replyId);

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.groups.discuss.replies.getInfo" },
            { "topic_id", topicId },
            { "reply_id", replyId }
        };

        return await GetResponseAsync<Reply>(parameters, cancellationToken);
    }

    async Task<Replies> IFlickrGroupsDiscussReplies.GetListAsync(string topicId, int perPage, int page, CancellationToken cancellationToken)
    {
        ArgumentException.ThrowIfNullOrEmpty(topicId);

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.groups.discuss.replies.getList" },
            { "topic_id", topicId }
        };

        parameters.AppendIf("per_page", perPage, x => x > 0, x => x.ToString(NumberFormatInfo.InvariantInfo));

        parameters.AppendIf("page", page, x => x > 0, x => x.ToString(NumberFormatInfo.InvariantInfo));

        return await GetResponseAsync<Replies>(parameters, cancellationToken);
    }
}

/// <summary>
/// The flickr groups discuss replies.
/// </summary>
public interface IFlickrGroupsDiscussReplies
{
    /// <summary>
    /// Add a new reply to a topic.
    /// </summary>
    /// <param name="topicId">The id of the topic to add the reply to.</param>
    /// <param name="message">The message content to add.</param>
    /// <param name="cancellationToken"></param>
    /// <return></return>
    Task AddAsync(string topicId, string message, CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete a reply to a particular topic.
    /// </summary>
    /// <param name="topicId">The id of the topic to delete the reply from.</param>
    /// <param name="replyId">The id of the reply to delete.</param>
    /// <param name="cancellationToken"></param>
    /// <return></return>
    Task DeleteAsync(string topicId, string replyId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Edit the contents of a reply.
    /// </summary>
    /// <param name="topicId">The id of the topic whose reply you want to edit.</param>
    /// <param name="replyId">The id of the reply to edit.</param>
    /// <param name="message">The new message content to replace the reply with.</param>
    /// <param name="cancellationToken"></param>
    /// <return></return>
    Task EditAsync(string topicId, string replyId, string message, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the details of a particular reply.
    /// </summary>
    /// <param name="topicId">The id of the topic for whose reply you want the details of.</param>
    /// <param name="replyId">The id of the reply you want the details of.</param>
    /// <param name="cancellationToken"></param>
    /// <return></return>
    Task<Reply> GetInfoAsync(string topicId, string replyId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a list of replies for a particular topic.
    /// </summary>
    /// <param name="topicId">The id of the topic to get the replies for.</param>
    /// <param name="page">The page of replies you wish to get.</param>
    /// <param name="perPage">The number of replies per page you wish to get.</param>
    /// <param name="cancellationToken"></param>
    /// <return></return>
    Task<Replies> GetListAsync(string topicId, int perPage, int page = 0, CancellationToken cancellationToken = default);
}