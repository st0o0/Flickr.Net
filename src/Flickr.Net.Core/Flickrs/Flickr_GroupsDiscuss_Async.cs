using Flickr.Net.Core.Entities;
using Flickr.Net.Core.Entities.Collections;

namespace Flickr.Net.Core;

public partial class Flickr
{
    /// <summary>
    /// Add a new reply to a topic.
    /// </summary>
    /// <param name="topicId">The id of the topic to add the reply to.</param>
    /// <param name="message">The message content to add.</param>
    public async Task GroupsDiscussRepliesAddAsync(string topicId, string message, CancellationToken cancellationToken = default)
    {
        CheckRequiresAuthentication();

        if (string.IsNullOrEmpty(topicId))
        {
            throw new ArgumentNullException(nameof(topicId));
        }

        if (string.IsNullOrEmpty(message))
        {
            throw new ArgumentNullException(nameof(message));
        }

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.groups.discuss.replies.add" },
            { "topic_id", topicId },
            { "message", message }
        };

        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }

    /// <summary>
    /// Delete a reply to a particular topic.
    /// </summary>
    /// <param name="topicId">The id of the topic to delete the reply from.</param>
    /// <param name="replyId">The id of the reply to delete.</param>
    public async Task GroupsDiscussRepliesDeleteAsync(string topicId, string replyId, CancellationToken cancellationToken = default)
    {
        CheckRequiresAuthentication();

        if (string.IsNullOrEmpty(topicId))
        {
            throw new ArgumentNullException(nameof(topicId));
        }

        if (string.IsNullOrEmpty(replyId))
        {
            throw new ArgumentNullException(nameof(replyId));
        }

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.groups.discuss.replies.delete" },
            { "topic_id", topicId },
            { "reply_id", replyId }
        };

        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }

    /// <summary>
    /// Edit the contents of a reply.
    /// </summary>
    /// <param name="topicId">The id of the topic whose reply you want to edit.</param>
    /// <param name="replyId">The id of the reply to edit.</param>
    /// <param name="message">The new message content to replace the reply with.</param>
    public async Task GroupsDiscussRepliesEditAsync(string topicId, string replyId, string message, CancellationToken cancellationToken = default)
    {
        CheckRequiresAuthentication();

        if (string.IsNullOrEmpty(topicId))
        {
            throw new ArgumentNullException(nameof(topicId));
        }

        if (string.IsNullOrEmpty(replyId))
        {
            throw new ArgumentNullException(nameof(replyId));
        }

        if (string.IsNullOrEmpty(message))
        {
            throw new ArgumentNullException(nameof(message));
        }

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.groups.discuss.replies.edit" },
            { "topic_id", topicId },
            { "reply_id", replyId },
            { "message", message }
        };

        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }

    /// <summary>
    /// Gets the details of a particular reply.
    /// </summary>
    /// <param name="topicId">The id of the topic for whose reply you want the details of.</param>
    /// <param name="replyId">The id of the reply you want the details of.</param>
    public async Task<TopicReply> GroupsDiscussRepliesGetInfoAsync(string topicId, string replyId, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(topicId))
        {
            throw new ArgumentNullException(nameof(topicId));
        }

        if (string.IsNullOrEmpty(replyId))
        {
            throw new ArgumentNullException(nameof(replyId));
        }

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.groups.discuss.replies.getInfo" },
            { "topic_id", topicId },
            { "reply_id", replyId }
        };

        return await GetResponseAsync<TopicReply>(parameters, cancellationToken);
    }

    /// <summary>
    /// Gets a list of replies for a particular topic.
    /// </summary>
    /// <param name="topicId">The id of the topic to get the replies for.</param>
    /// <param name="page">The page of replies you wish to get.</param>
    /// <param name="perPage">The number of replies per page you wish to get.</param>
    public async Task<TopicReplyCollection> GroupsDiscussRepliesGetListAsync(string topicId, int perPage, int page = 0, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(topicId))
        {
            throw new ArgumentNullException(nameof(topicId));
        }

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.groups.discuss.replies.getList" },
            { "topic_id", topicId }
        };

        if (perPage > 0)
        {
            parameters.Add("per_page", perPage.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        if (page > 0)
        {
            parameters.Add("page", page.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        return await GetResponseAsync<TopicReplyCollection>(parameters, cancellationToken);
    }

    /// <summary>
    /// Add a new topic to a group.
    /// </summary>
    /// <param name="groupId">The id of the group to add a new topic too.</param>
    /// <param name="subject">The subject line of the new topic.</param>
    /// <param name="message">The message content of the new topic.</param>
    public async Task GroupsDiscussTopicsAddAsync(string groupId, string subject, string message, CancellationToken cancellationToken = default)
    {
        CheckRequiresAuthentication();

        if (string.IsNullOrEmpty(groupId))
        {
            throw new ArgumentNullException(nameof(groupId));
        }

        if (string.IsNullOrEmpty(subject))
        {
            throw new ArgumentNullException(nameof(subject));
        }

        if (string.IsNullOrEmpty(message))
        {
            throw new ArgumentNullException(nameof(message));
        }

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.groups.discuss.topics.add" },
            { "group_id", groupId },
            { "subject", subject },
            { "message", message }
        };

        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }

    /// <summary>
    /// Gets a list of topics for a particular group.
    /// </summary>
    /// <param name="groupId">The id of the group.</param>
    /// <param name="page">The page of topics you wish to return.</param>
    /// <param name="perPage">The number of topics per page to return.</param>
    public async Task<TopicCollection> GroupsDiscussTopicsGetListAsync(string groupId, int page = 0, int perPage = 0, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(groupId))
        {
            throw new ArgumentNullException(nameof(groupId));
        }

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.groups.discuss.topics.getList" },
            { "group_id", groupId }
        };

        if (page > 0)
        {
            parameters.Add("page", page.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        if (perPage > 0)
        {
            parameters.Add("per_page", perPage.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        return await GetResponseAsync<TopicCollection>(parameters, cancellationToken);
    }

    /// <summary>
    /// Gets information on a particular topic with a group.
    /// </summary>
    /// <param name="topicId">The id of the topic you with information on.</param>
    public async Task<Topic> GroupsDiscussTopicsGetInfoAsync(string topicId, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(topicId))
        {
            throw new ArgumentNullException(nameof(topicId));
        }

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.groups.discuss.topics.getInfo" },
            { "topic_id", topicId }
        };

        return await GetResponseAsync<Topic>(parameters, cancellationToken);
    }
}