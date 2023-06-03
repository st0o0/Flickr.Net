namespace Flickr.Net.Core;

public partial class Flickr : IFlickrCollections
{
    async Task<CollectionInfo> IFlickrCollections.GetInfoAsync(string collectionId, CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.collections.getInfo" },
            { "collection_id", collectionId }
        };

        return await GetResponseAsync<CollectionInfo>(parameters, cancellationToken);
    }

    async Task<CollectionCollection> IFlickrCollections.GetTreeAsync(string collectionId, string userId, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(userId))
        {
            CheckRequiresAuthentication();
        }

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.collections.getTree" }
        };

        if (collectionId != null)
        {
            parameters.Add("collection_id", collectionId);
        }

        if (userId != null)
        {
            parameters.Add("user_id", userId);
        }

        return await GetResponseAsync<CollectionCollection>(parameters, cancellationToken);
    }
}

public interface IFlickrCollections
{
    /// <summary>
    /// Gets information about a collection. Requires authentication with 'read' access.
    /// </summary>
    /// <param name="collectionId">The ID for the collection to return.</param>
    Task<CollectionInfo> GetInfoAsync(string collectionId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a tree of collection.
    /// </summary>
    /// <param name="collectionId ">The ID of the collection to fetch a tree for, or zero to fetch the root collection.</param>
    /// <param name="userId">The ID of the user to fetch the tree for, or null if using the authenticated user.</param>
    Task<CollectionCollection> GetTreeAsync(string collectionId = null, string userId = null, CancellationToken cancellationToken = default);
}