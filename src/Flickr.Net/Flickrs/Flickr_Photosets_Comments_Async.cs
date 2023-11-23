namespace Flickr.Net;

/// <summary>
/// The flickr.
/// </summary>
public partial class Flickr : IFlickrPhotosetsComments
{
    async Task<string> IFlickrPhotosetsComments.AddCommentAsync(string photosetId, string commentText, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photosets.comments.addComment" },
            { "photoset_id", photosetId },
            { "comment_text", commentText }
        };

        var result = await GetResponseAsync<CommentUnknownResponse>(parameters, cancellationToken);

        return result.GetValueOrDefault("id");
    }

    async Task IFlickrPhotosetsComments.DeleteCommentAsync(string commentId, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photosets.comments.deleteComment" },
            { "comment_id", commentId }
        };

        await GetResponseAsync(parameters, cancellationToken);
    }

    async Task IFlickrPhotosetsComments.EditCommentAsync(string commentId, string commentText, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photosets.comments.editComment" },
            { "comment_id", commentId },
            { "comment_text", commentText }
        };

        await GetResponseAsync(parameters, cancellationToken);
    }

    async Task<PhotosetComments> IFlickrPhotosetsComments.GetListAsync(string photosetId, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photosets.comments.getList" },
            { "photoset_id", photosetId }
        };

        return await GetResponseAsync<PhotosetComments>(parameters, cancellationToken);
    }
}

/// <summary>
/// The flickr photosets comments.
/// </summary>
public interface IFlickrPhotosetsComments
{
    /// <summary>
    /// Adds a new comment to a photoset.
    /// </summary>
    /// <param name="photosetId">The ID of the photoset to add the comment to.</param>
    /// <param name="commentText">The text of the comment. Can contain some HTML.</param>
    /// <param name="cancellationToken"></param>
    Task<string> AddCommentAsync(string photosetId, string commentText, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a comment from a photoset.
    /// </summary>
    /// <param name="commentId">The ID of the comment to delete.</param>
    /// <param name="cancellationToken"></param>
    Task DeleteCommentAsync(string commentId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Edits a comment.
    /// </summary>
    /// <param name="commentId">The ID of the comment to edit.</param>
    /// <param name="commentText">The new text for the comment.</param>
    /// <param name="cancellationToken"></param>
    Task EditCommentAsync(string commentId, string commentText, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a list of comments for a photoset.
    /// </summary>
    /// <param name="photosetId">The id of the photoset to return the comments for.</param>
    /// <param name="cancellationToken"></param>
    Task<PhotosetComments> GetListAsync(string photosetId, CancellationToken cancellationToken = default);
}