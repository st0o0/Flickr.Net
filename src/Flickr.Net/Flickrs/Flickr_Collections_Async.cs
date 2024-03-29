﻿using Flickr.Net.Internals.Extensions;

namespace Flickr.Net;

/// <summary>
/// The flickr.
/// </summary>
public partial class Flickr : IFlickrCollections
{
    async Task<Collection> IFlickrCollections.GetInfoAsync(string collectionId, CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.collections.getInfo" },
            { "collection_id", collectionId }
        };

        return await GetResponseAsync<Collection>(parameters, cancellationToken);
    }

    async Task<Collections> IFlickrCollections.GetTreeAsync(string collectionId, string userId, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(userId))
        {
            CheckRequiresAuthentication();
        }

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.collections.getTree" }
        };

        parameters.AppendIf("collection_id", collectionId, x => x != null, x => x);

        parameters.AppendIf("user_id", userId, x => x != null, x => x);

        return await GetResponseAsync<Collections>(parameters, cancellationToken);
    }
}

/// <summary>
/// The flickr collections.
/// </summary>
public interface IFlickrCollections
{
    /// <summary>
    /// Gets information about a collection. Requires authentication with 'read' access.
    /// </summary>
    /// <param name="collectionId">The ID for the collection to return.</param>
    /// <param name="cancellationToken"></param>
    Task<Collection> GetInfoAsync(string collectionId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a tree of collection.
    /// </summary>
    /// <param name="collectionId ">
    /// The ID of the collection to fetch a tree for, or zero to fetch the root collection.
    /// </param>
    /// <param name="userId">
    /// The ID of the user to fetch the tree for, or null if using the authenticated user.
    /// </param>
    /// <param name="cancellationToken"></param>
    Task<Collections> GetTreeAsync(string collectionId = null, string userId = null, CancellationToken cancellationToken = default);
}