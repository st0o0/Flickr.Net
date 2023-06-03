using Flickr.Net.Core.Entities;
using Flickr.Net.Core.Entities.Collections;

namespace Flickr.Net.Core;

// TODO:
public partial class Flickr
{
    /// <summary>
    /// Gets a list of blogs that have been set up by the user.
    /// Requires authentication.
    /// </summary>
    /// <remarks></remarks>
    public async Task<BlogCollection> BlogsGetListAsync(CancellationToken cancellationToken = default)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.blogs.getList" }
        };

        return await GetResponseAsync<BlogCollection>(parameters, cancellationToken);
    }

    /// <summary>
    /// Return a list of Flickr supported blogging services.
    /// </summary>
    public async Task<BlogServiceCollection> BlogsGetServicesAsync(CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.blogs.getServices" }
        };

        return await GetResponseAsync<BlogServiceCollection>(parameters, cancellationToken);
    }

    /// <summary>
    /// Posts a photo already uploaded to a blog.
    /// Requires authentication.
    /// </summary>
    /// <param name="blogId">The Id of the blog to post the photo too.</param>
    /// <param name="photoId">The Id of the photograph to post.</param>
    /// <param name="title">The title of the blog post.</param>
    /// <param name="description">The body of the blog post.</param>
    public async Task<NoResponse> BlogsPostPhotoAsync(string blogId, string photoId, string title, string description, CancellationToken cancellationToken = default)
    {
        return await BlogsPostPhotoAsync(blogId, photoId, title, description, null, cancellationToken);
    }

    /// <summary>
    /// Posts a photo already uploaded to a blog.
    /// Requires authentication.
    /// </summary>
    /// <param name="blogId">The Id of the blog to post the photo too.</param>
    /// <param name="photoId">The Id of the photograph to post.</param>
    /// <param name="title">The title of the blog post.</param>
    /// <param name="description">The body of the blog post.</param>
    /// <param name="blogPassword">The password of the blog if it is not already stored in flickr.</param>
    public async Task<NoResponse> BlogsPostPhotoAsync(string blogId, string photoId, string title, string description, string blogPassword, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.blogs.postPhoto" },
            { "blog_id", blogId },
            { "photo_id", photoId },
            { "title", title },
            { "description", description }
        };

        if (blogPassword != null)
        {
            parameters.Add("blog_password", blogPassword);
        }

        return await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }
}