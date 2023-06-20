using Flickr.Net.Core.NewEntities;

namespace Flickr.Net.Core;

/// <summary>
/// The flickr.
/// </summary>
public partial class Flickr : IFlickrGroupsDiscussTopics
{
    async Task IFlickrGroupsDiscussTopics.TopicsAddAsync(string groupId, string subject, string message, CancellationToken cancellationToken)
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

        await GetResponseAsync(parameters, cancellationToken);
    }

    async Task<Topics> IFlickrGroupsDiscussTopics.TopicsGetListAsync(string groupId, int page, int perPage, CancellationToken cancellationToken)
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

        return await GetResponseAsync<Topics>(parameters, cancellationToken);
    }

    async Task<Topic> IFlickrGroupsDiscussTopics.TopicsGetInfoAsync(string topicId, CancellationToken cancellationToken)
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

/// <summary>
/// The flickr groups discuss topics.
/// </summary>
public interface IFlickrGroupsDiscussTopics
{
    /// <summary>
    /// Add a new topic to a group.
    /// </summary>
    /// <param name="groupId">The id of the group to add a new topic too.</param>
    /// <param name="subject">The subject line of the new topic.</param>
    /// <param name="message">The message content of the new topic.</param>
    /// <param name="cancellationToken"></param>
    /// <return></return>
    Task TopicsAddAsync(string groupId, string subject, string message, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a list of topics for a particular group.
    /// </summary>
    /// <param name="groupId">The id of the group.</param>
    /// <param name="page">The page of topics you wish to return.</param>
    /// <param name="perPage">The number of topics per page to return.</param>
    /// <param name="cancellationToken"></param>
    /// <return></return>
    Task<Topics> TopicsGetListAsync(string groupId, int page = 0, int perPage = 0, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets information on a particular topic with a group.
    /// </summary>
    /// <param name="topicId">The id of the topic you with information on.</param>
    /// <param name="cancellationToken"></param>
    /// <return></return>
    Task<Topic> TopicsGetInfoAsync(string topicId, CancellationToken cancellationToken = default);
}