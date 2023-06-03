namespace Flickr.Net.Core;

public partial class Flickr
{
    /// <summary>
    /// Adds a new comment to a photoset.
    /// </summary>
    /// <param name="photosetId">The ID of the photoset to add the comment to.</param>
    /// <param name="commentText">The text of the comment. Can contain some HTML.</param>
    public async Task<string> PhotosetsCommentsAddCommentAsync(string photosetId, string commentText, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photosets.comments.addComment" },
            { "photoset_id", photosetId },
            { "comment_text", commentText }
        };

        UnknownResponse result = await GetResponseAsync<UnknownResponse>(parameters, cancellationToken);

        return result.GetAttributeValue("*", "id");
    }

    /// <summary>
    /// Deletes a comment from a photoset.
    /// </summary>
    /// <param name="commentId">The ID of the comment to delete.</param>
    public async Task PhotosetsCommentsDeleteCommentAsync(string commentId, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photosets.comments.deleteComment" },
            { "comment_id", commentId }
        };

        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }

    /// <summary>
    /// Edits a comment.
    /// </summary>
    /// <param name="commentId">The ID of the comment to edit.</param>
    /// <param name="commentText">The new text for the comment.</param>
    public async Task PhotosetsCommentsEditCommentAsync(string commentId, string commentText, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photosets.comments.editComment" },
            { "comment_id", commentId },
            { "comment_text", commentText }
        };

        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }

    /// <summary>
    /// Gets a list of comments for a photoset.
    /// </summary>
    /// <param name="photosetId">The id of the photoset to return the comments for.</param>
    public async Task<PhotosetCommentCollection> PhotosetsCommentsGetListAsync(string photosetId, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photosets.comments.getList" },
            { "photoset_id", photosetId }
        };

        return await GetResponseAsync<PhotosetCommentCollection>(parameters, cancellationToken);
    }
}