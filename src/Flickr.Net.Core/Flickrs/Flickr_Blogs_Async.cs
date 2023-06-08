namespace Flickr.Net.Core;

/// <summary>
/// The flickr.
/// </summary>
public partial class Flickr : IFlickrBlogs
{
    async Task<BlogCollection> IFlickrBlogs.GetListAsync(CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.blogs.getList" }
        };

        return await GetResponseAsync<BlogCollection>(parameters, cancellationToken);
    }

    async Task<BlogServiceCollection> IFlickrBlogs.GetServicesAsync(CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.blogs.getServices" }
        };

        return await GetResponseAsync<BlogServiceCollection>(parameters, cancellationToken);
    }

    async Task<NoResponse> IFlickrBlogs.PostPhotoAsync(string blogId, string photoId, string title, string description, string blogPassword, CancellationToken cancellationToken)
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

/// <summary>
/// The flickr blogs.
/// </summary>
public interface IFlickrBlogs
{
    /// <summary>
    /// Gets a list of blogs that have been set up by the user. Requires authentication.
    /// </summary>
    /// <remarks></remarks>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<BlogCollection> GetListAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Return a list of Flickr supported blogging services.
    /// </summary>
    /// ///
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<BlogServiceCollection> GetServicesAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Posts a photo already uploaded to a blog. Requires authentication.
    /// </summary>
    /// <param name="blogId">The Id of the blog to post the photo too.</param>
    /// <param name="photoId">The Id of the photograph to post.</param>
    /// <param name="title">The title of the blog post.</param>
    /// <param name="description">The body of the blog post.</param>
    /// <param name="blogPassword">The password of the blog if it is not already stored in flickr.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<NoResponse> PostPhotoAsync(string blogId, string photoId, string title, string description, string blogPassword = null, CancellationToken cancellationToken = default);
}