namespace FlickrNet.Core;

public partial class Flickr
{
    /// <summary>
    /// Gets a list of comments for a photo.
    /// </summary>
    /// <param name="photoId">The id of the photo to return the comments for.</param>
    public async Task<PhotoCommentCollection> PhotosCommentsGetListAsync(string photoId, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.comments.getList" },
            { "photo_id", photoId }
        };

        return await GetResponseAsync<PhotoCommentCollection>(parameters, cancellationToken);
    }

    /// <summary>
    /// Adds a new comment to a photo.
    /// </summary>
    /// <param name="photoId">The ID of the photo to add the comment to.</param>
    /// <param name="commentText">The text of the comment. Can contain some HTML.</param>
    public async Task<string> PhotosCommentsAddCommentAsync(string photoId, string commentText, CancellationToken cancellationToken = default)
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

    /// <summary>
    /// Deletes a comment from a photo.
    /// </summary>
    /// <param name="commentId">The ID of the comment to delete.</param>
    public async Task PhotosCommentsDeleteCommentAsync(string commentId, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.comments.deleteComment" },
            { "comment_id", commentId }
        };

        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }

    /// <summary>
    /// Edits a comment.
    /// </summary>
    /// <param name="commentId">The ID of the comment to edit.</param>
    /// <param name="commentText">The new text for the comment.</param>
    public async Task PhotosCommentsEditCommentAsync(string commentId, string commentText, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.comments.editComment" },
            { "comment_id", commentId },
            { "comment_text", commentText }
        };

        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }

    /// <summary>
    /// Return the list of photos belonging to your contacts that have been commented on recently.
    /// </summary>
    /// <returns></returns>
    public async Task<PhotoCollection> PhotosCommentsGetRecentForContactsAsync(CancellationToken cancellationToken = default)
    {
        return await PhotosCommentsGetRecentForContactsAsync(DateTime.MinValue, null, PhotoSearchExtras.None, 0, 0, cancellationToken);
    }

    /// <summary>
    /// Return the list of photos belonging to your contacts that have been commented on recently.
    /// </summary>
    /// <param name="page">The page of results to return. If this argument is omitted, it defaults to 1.</param>
    /// <param name="perPage">Number of photos to return per page. If this argument is omitted, it defaults to 100.
    ///  The maximum allowed value is 500.</param>
    public async Task<PhotoCollection> PhotosCommentsGetRecentForContactsAsync(int page, int perPage, CancellationToken cancellationToken = default)
    {
        return await PhotosCommentsGetRecentForContactsAsync(DateTime.MinValue, null, PhotoSearchExtras.None, page, perPage, cancellationToken);
    }

    /// <summary>
    /// Return the list of photos belonging to your contacts that have been commented on recently.
    /// </summary>
    /// <param name="dateLastComment">Limits the resultset to photos that have been commented on since this date.
    /// The default, and maximum, offset is (1) hour.</param>
    /// <param name="extras"></param>
    /// <param name="page">The page of results to return. If this argument is omitted, it defaults to 1.</param>
    /// <param name="perPage">Number of photos to return per page. If this argument is omitted, it defaults to 100.
    /// The maximum allowed value is 500.</param>
    public async Task<PhotoCollection> PhotosCommentsGetRecentForContactsAsync(DateTime dateLastComment, PhotoSearchExtras extras, int page, int perPage, CancellationToken cancellationToken = default)
    {
        return await PhotosCommentsGetRecentForContactsAsync(dateLastComment, null, extras, page, perPage, cancellationToken);
    }

    /// <summary>
    /// Return the list of photos belonging to your contacts that have been commented on recently.
    /// </summary>
    /// <param name="dateLastComment">Limits the resultset to photos that have been commented on since this date.
    /// The default, and maximum, offset is (1) hour.</param>
    /// <param name="contactsFilter">A list of contact NSIDs to limit the scope of the query to.</param>
    /// <param name="extras"></param>
    /// <param name="page">The page of results to return. If this argument is omitted, it defaults to 1.</param>
    /// <param name="perPage">Number of photos to return per page. If this argument is omitted, it defaults to 100.
    /// The maximum allowed value is 500.</param>
    public async Task<PhotoCollection> PhotosCommentsGetRecentForContactsAsync(DateTime dateLastComment, string[] contactsFilter, PhotoSearchExtras extras, int page, int perPage, CancellationToken cancellationToken = default)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.comments.getRecentForContacts" }
        };
        if (dateLastComment != DateTime.MinValue)
        {
            parameters.Add("date_lastcomment", UtilityMethods.DateToUnixTimestamp(dateLastComment));
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