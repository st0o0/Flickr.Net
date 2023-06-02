using Flickr.Net.Core.Entities;
using Flickr.Net.Core.Entities.Collections;

namespace Flickr.Net.Core;

public partial class Flickr
{
    /// <summary>
    /// Gets information about a collection. Requires authentication with 'read' access.
    /// </summary>
    /// <param name="collectionId">The ID for the collection to return.</param>
    public async Task<CollectionInfo> CollectionsGetInfoAsync(string collectionId, CancellationToken cancellationToken = default)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.collections.getInfo" },
            { "collection_id", collectionId }
        };

        return await GetResponseAsync<CollectionInfo>(parameters, cancellationToken);
    }

    /// <summary>
    /// Gets a tree of collection. Requires authentication.
    /// </summary>
    public async Task<CollectionCollection> CollectionsGetTreeAsync(CancellationToken cancellationToken = default)
    {
        return await CollectionsGetTreeAsync(null, null, cancellationToken);
    }

    /// <summary>
    /// Gets a tree of collection.
    /// </summary>
    /// <param name="collectionId ">The ID of the collection to fetch a tree for, or zero to fetch the root collection.</param>
    /// <param name="userId">The ID of the user to fetch the tree for, or null if using the authenticated user.</param>
    public async Task<CollectionCollection> CollectionsGetTreeAsync(string collectionId = null, string userId = null, CancellationToken cancellationToken = default)
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

    /// <summary>
    /// Allows you to update the title and description for a collection.
    /// </summary>
    /// <remarks>This method is unsupported by Flickr currently, but it does appear to work.</remarks>
    /// <param name="collectionId">The collection id of the collection, in the format nnnnn-nnnnnnnnnnnnnnnnn.</param>
    /// <param name="title">The new title.</param>
    /// <param name="description">The new description.</param>
    [Obsolete("KEKW", true)]
    public async Task CollectionsEditMetaAsync(string collectionId, string title, string description, CancellationToken cancellationToken = default)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.collections.editMeta" },
            { "collection_id", collectionId },
            { "title", title },
            { "description", description }
        };

        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }
}