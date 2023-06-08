namespace Flickr.Net.Core;

/// <summary>
/// The flickr.
/// </summary>
public partial class Flickr : IFlickrPhotosComments
{
    async Task<string> IFlickrPhotosComments.AddCommentAsync(string photoId, string commentText, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.comments.addComment" },
            { "photo_id", photoId },
            { "comment_text", commentText }
        };

        UnknownResponse response = await GetResponseAsync<UnknownResponse>(parameters, cancellationToken);
        return response.GetAttributeValue("*", "id");
    }

    async Task IFlickrPhotosComments.DeleteCommentAsync(string commentId, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.comments.deleteComment" },
            { "comment_id", commentId }
        };

        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }

    async Task IFlickrPhotosComments.EditCommentAsync(string commentId, string commentText, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.comments.editComment" },
            { "comment_id", commentId },
            { "comment_text", commentText }
        };

        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }

    async Task<PhotoCommentCollection> IFlickrPhotosComments.GetListAsync(string photoId, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.comments.getList" },
            { "photo_id", photoId }
        };

        return await GetResponseAsync<PhotoCommentCollection>(parameters, cancellationToken);
    }

    async Task<PhotoCollection> IFlickrPhotosComments.GetRecentForContactsAsync(DateTime? dateLastComment, string[] contactsFilter, PhotoSearchExtras extras, int page, int perPage, CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.comments.getRecentForContacts" }
        };

        if (dateLastComment.HasValue && dateLastComment != DateTime.MinValue)
        {
            parameters.Add("date_lastcomment", UtilityMethods.DateToUnixTimestamp(dateLastComment.Value));
        }

        if (contactsFilter != null && contactsFilter.Length > 0)
        {
            parameters.Add("contacts_filter", string.Join(",", contactsFilter));
        }

        if (extras != PhotoSearchExtras.None)
        {
            parameters.Add("extras", UtilityMethods.ExtrasToString(extras));
        }

        if (page > 0)
        {
            parameters.Add("page", page.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        if (perPage > 0)
        {
            parameters.Add("per_page", perPage.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        return await GetResponseAsync<PhotoCollection>(parameters, cancellationToken);
    }
}

/// <summary>
/// The flickr photos comments.
/// </summary>
public interface IFlickrPhotosComments
{
    /// <summary>
    /// Adds a new comment to a photo.
    /// </summary>
    /// <param name="photoId">The ID of the photo to add the comment to.</param>
    /// <param name="commentText">The text of the comment. Can contain some HTML.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<string> AddCommentAsync(string photoId, string commentText, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a comment from a photo.
    /// </summary>
    /// <param name="commentId">The ID of the comment to delete.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task DeleteCommentAsync(string commentId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Edits a comment.
    /// </summary>
    /// <param name="commentId">The ID of the comment to edit.</param>
    /// <param name="commentText">The new text for the comment.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task EditCommentAsync(string commentId, string commentText, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a list of comments for a photo.
    /// </summary>
    /// <param name="photoId">The id of the photo to return the comments for.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<PhotoCommentCollection> GetListAsync(string photoId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Return the list of photos belonging to your contacts that have been commented on recently.
    /// </summary>
    /// <param name="dateLastComment">
    /// Limits the resultset to photos that have been commented on since this date. The default, and
    /// maximum, offset is (1) hour.
    /// </param>
    /// <param name="contactsFilter">A list of contact NSIDs to limit the scope of the query to.</param>
    /// <param name="extras"></param>
    /// <param name="page">
    /// The page of results to return. If this argument is omitted, it defaults to 1.
    /// </param>
    /// <param name="perPage">
    /// Number of photos to return per page. If this argument is omitted, it defaults to 100. The
    /// maximum allowed value is 500.
    /// </param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<PhotoCollection> GetRecentForContactsAsync(DateTime? dateLastComment = null, string[] contactsFilter = null, PhotoSearchExtras extras = PhotoSearchExtras.None, int page = 0, int perPage = 0, CancellationToken cancellationToken = default);
}