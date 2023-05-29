namespace FlickrNet.Core;

public partial class Flickr
{
    /// <summary>
    /// Add a photo to a photoset.
    /// </summary>
    /// <param name="photosetId">The ID of the photoset to add the photo to.</param>
    /// <param name="photoId">The ID of the photo to add.</param>
    public async Task PhotosetsAddPhotoAsync(string photosetId, string photoId, CancellationToken cancellationToken = default)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photosets.addPhoto" },
            { "photoset_id", photosetId },
            { "photo_id", photoId }
        };

        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }

    /// <summary>
    /// Creates a blank photoset, with a title and a primary photo (minimum requirements).
    /// </summary>
    /// <param name="title">The title of the photoset.</param>
    /// <param name="primaryPhotoId">The ID of the photo which will be the primary photo for the photoset. This photo will also be added to the set.</param>
    public async Task<Photoset> PhotosetsCreateAsync(string title, string primaryPhotoId, CancellationToken cancellationToken = default)
    {
        return await PhotosetsCreateAsync(title, null, primaryPhotoId, cancellationToken);
    }

    /// <summary>
    /// Creates a blank photoset, with a title, description and a primary photo.
    /// </summary>
    /// <param name="title">The title of the photoset.</param>
    /// <param name="description">THe description of the photoset.</param>
    /// <param name="primaryPhotoId">The ID of the photo which will be the primary photo for the photoset. This photo will also be added to the set.</param>
    public async Task<Photoset> PhotosetsCreateAsync(string title, string description, string primaryPhotoId, CancellationToken cancellationToken = default)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photosets.create" },
            { "primary_photo_id", primaryPhotoId }
        };
        if (!string.IsNullOrEmpty(title))
        {
            parameters.Add("title", title);
        }

        if (!string.IsNullOrEmpty(description))
        {
            parameters.Add("description", description);
        }

        return await GetResponseAsync<Photoset>(parameters, cancellationToken);
    }

    /// <summary>
    /// Deletes the specified photoset.
    /// </summary>
    /// <param name="photosetId">The ID of the photoset to delete.</param>
    public async Task PhotosetsDeleteAsync(string photosetId, CancellationToken cancellationToken = default)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photosets.delete" },
            { "photoset_id", photosetId }
        };

        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }

    /// <summary>
    /// Updates the title and description for a photoset.
    /// </summary>
    /// <param name="photosetId">The ID of the photoset to update.</param>
    /// <param name="title">The new title for the photoset.</param>
    /// <param name="description">The new description for the photoset.</param>
    public async Task PhotosetsEditMetaAsync(string photosetId, string title, string description, CancellationToken cancellationToken = default)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photosets.editMeta" },
            { "photoset_id", photosetId },
            { "title", title },
            { "description", description }
        };

        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }

    /// <summary>
    /// Sets the photos for a photoset.
    /// </summary>
    /// <remarks>
    /// Will remove any previous photos from the photoset.
    /// The order in thich the photoids are given is the order they will appear in the
    /// photoset page.
    /// </remarks>
    /// <param name="photosetId">The ID of the photoset to update.</param>
    /// <param name="primaryPhotoId">The ID of the new primary photo for the photoset.</param>
    /// <param name="photoIds">An array of photo IDs.</param>
    public async Task PhotosetsEditPhotosAsync(string photosetId, string primaryPhotoId, string[] photoIds, CancellationToken cancellationToken = default)
    {
        await PhotosetsEditPhotosAsync(photosetId, primaryPhotoId, string.Join(",", photoIds), cancellationToken);
    }

    /// <summary>
    /// Sets the photos for a photoset.
    /// </summary>
    /// <remarks>
    /// Will remove any previous photos from the photoset.
    /// The order in thich the photoids are given is the order they will appear in the
    /// photoset page.
    /// </remarks>
    /// <param name="photosetId">The ID of the photoset to update.</param>
    /// <param name="primaryPhotoId">The ID of the new primary photo for the photoset.</param>
    /// <param name="photoIds">An comma seperated list of photo IDs.</param>
    public async Task PhotosetsEditPhotosAsync(string photosetId, string primaryPhotoId, string photoIds, CancellationToken cancellationToken = default)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photosets.editPhotos" },
            { "photoset_id", photosetId },
            { "primary_photo_id", primaryPhotoId },
            { "photo_ids", photoIds }
        };

        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }

    /// <summary>
    /// Gets the context of the specified photo within the photoset.
    /// </summary>
    /// <param name="photoId">The photo id of the photo in the set.</param>
    /// <param name="photosetId">The id of the set.</param>
    public async Task<Context> PhotosetsGetContextAsync(string photoId, string photosetId, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photosets.getContext" },
            { "photo_id", photoId },
            { "photoset_id", photosetId }
        };

        return await GetResponseAsync<Context>(parameters, cancellationToken);
    }

    /// <summary>
    /// Gets the information about a photoset.
    /// </summary>
    /// <param name="photosetId">The ID of the photoset to return information for.</param>
    public async Task<Photoset> PhotosetsGetInfoAsync(string photosetId, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photosets.getInfo" },
            { "photoset_id", photosetId }
        };

        return await GetResponseAsync<Photoset>(parameters, cancellationToken);
    }

    /// <summary>
    /// Gets a list of the currently authenticated users photosets.
    /// </summary>
    /// <returns>A <see cref="PhotosetCollection"/> instance containing a collection of photosets.</returns>
    public async Task<PhotosetCollection> PhotosetsGetListAsync(CancellationToken cancellationToken = default)
    {
        CheckRequiresAuthentication();

        return await PhotosetsGetListAsync(null, 0, 0, cancellationToken);
    }

    /// <summary>
    /// Gets a list of the currently authenticated users photosets.
    /// </summary>
    /// <param name="page">The page of the results to return. Defaults to page 1.</param>
    /// <param name="perPage">The number of photosets to return per page. Defaults to 500.</param>
    /// <returns>A <see cref="PhotosetCollection"/> instance containing a collection of photosets.</returns>
    public async Task<PhotosetCollection> PhotosetsGetListAsync(int page, int perPage, CancellationToken cancellationToken = default)
    {
        CheckRequiresAuthentication();

        return await PhotosetsGetListAsync(null, page, perPage, cancellationToken);
    }

    /// <summary>
    /// Gets a list of the specified users photosets.
    /// </summary>
    /// <param name="userId">The ID of the user to return the photosets of.</param>
    public async Task<PhotosetCollection> PhotosetsGetListAsync(string userId, CancellationToken cancellationToken = default)
    {
        return await PhotosetsGetListAsync(userId, 0, 0, cancellationToken);
    }

    /// <summary>
    /// Gets a list of the specified users photosets.
    /// </summary>
    /// <param name="userId">The ID of the user to return the photosets of.</param>
    /// <param name="page">The page of the results to return. Defaults to page 1.</param>
    /// <param name="perPage">The number of photosets to return per page. Defaults to 500.</param>
    public async Task<PhotosetCollection> PhotosetsGetListAsync(string userId, int page, int perPage, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photosets.getList" }
        };
        if (userId != null)
        {
            parameters.Add("user_id", userId);
        }

        if (page > 0)
        {
            parameters.Add("page", page.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        if (perPage > 0)
        {
            parameters.Add("per_page", perPage.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        PhotosetCollection result = await GetResponseAsync<PhotosetCollection>(parameters, cancellationToken);
        foreach (Photoset photoset in result)
        {
            photoset.OwnerId = userId;
        }
        return result;
    }

    /// <summary>
    /// Gets a collection of photos for a photoset.
    /// </summary>
    /// <param name="photosetId">The ID of the photoset to return photos for.</param>
    public async Task<PhotosetPhotoCollection> PhotosetsGetPhotosAsync(string photosetId, CancellationToken cancellationToken = default)
    {
        return await PhotosetsGetPhotosAsync(photosetId, PhotoSearchExtras.None, PrivacyFilter.None, 0, 0, cancellationToken);
    }

    /// <summary>
    /// Gets a collection of photos for a photoset.
    /// </summary>
    /// <param name="photosetId">The ID of the photoset to return photos for.</param>
    /// <param name="page">The page to return, defaults to 1.</param>
    /// <param name="perPage">The number of photos to return per page.</param>
    public async Task<PhotosetPhotoCollection> PhotosetsGetPhotosAsync(string photosetId, int page, int perPage, CancellationToken cancellationToken = default)
    {
        return await PhotosetsGetPhotosAsync(photosetId, PhotoSearchExtras.None, PrivacyFilter.None, page, perPage, cancellationToken);
    }

    /// <summary>
    /// Gets a collection of photos for a photoset.
    /// </summary>
    /// <param name="photosetId">The ID of the photoset to return photos for.</param>
    /// <param name="privacyFilter">The privacy filter to search on.</param>
    public async Task<PhotosetPhotoCollection> PhotosetsGetPhotosAsync(string photosetId, PrivacyFilter privacyFilter, CancellationToken cancellationToken = default)
    {
        return await PhotosetsGetPhotosAsync(photosetId, PhotoSearchExtras.None, privacyFilter, 0, 0, cancellationToken);
    }

    /// <summary>
    /// Gets a collection of photos for a photoset.
    /// </summary>
    /// <param name="photosetId">The ID of the photoset to return photos for.</param>
    /// <param name="privacyFilter">The privacy filter to search on.</param>
    /// <param name="page">The page to return, defaults to 1.</param>
    /// <param name="perPage">The number of photos to return per page.</param>
    public async Task<PhotosetPhotoCollection> PhotosetsGetPhotosAsync(string photosetId, PrivacyFilter privacyFilter, int page, int perPage, CancellationToken cancellationToken = default)
    {
        return await PhotosetsGetPhotosAsync(photosetId, PhotoSearchExtras.None, privacyFilter, page, perPage, cancellationToken);
    }

    /// <summary>
    /// Gets a collection of photos for a photoset.
    /// </summary>
    /// <param name="photosetId">The ID of the photoset to return photos for.</param>
    /// <param name="extras">The extras to return for each photo.</param>
    public async Task<PhotosetPhotoCollection> PhotosetsGetPhotosAsync(string photosetId, PhotoSearchExtras extras, CancellationToken cancellationToken = default)
    {
        return await PhotosetsGetPhotosAsync(photosetId, extras, PrivacyFilter.None, 0, 0, cancellationToken);
    }

    /// <summary>
    /// Gets a collection of photos for a photoset.
    /// </summary>
    /// <param name="photosetId">The ID of the photoset to return photos for.</param>
    /// <param name="extras">The extras to return for each photo.</param>
    /// <param name="page">The page to return, defaults to 1.</param>
    /// <param name="perPage">The number of photos to return per page.</param>
    public async Task<PhotosetPhotoCollection> PhotosetsGetPhotosAsync(string photosetId, PhotoSearchExtras extras, int page, int perPage, CancellationToken cancellationToken = default)
    {
        return await PhotosetsGetPhotosAsync(photosetId, extras, PrivacyFilter.None, page, perPage, cancellationToken);
    }

    /// <summary>
    /// Gets a collection of photos for a photoset.
    /// </summary>
    /// <param name="photosetId">The ID of the photoset to return photos for.</param>
    /// <param name="extras">The extras to return for each photo.</param>
    /// <param name="privacyFilter">The privacy filter to search on.</param>
    public async Task<PhotosetPhotoCollection> PhotosetsGetPhotosAsync(string photosetId, PhotoSearchExtras extras, PrivacyFilter privacyFilter, CancellationToken cancellationToken = default)
    {
        return await PhotosetsGetPhotosAsync(photosetId, extras, privacyFilter, 0, 0, cancellationToken);
    }

    /// <summary>
    /// Gets a collection of photos for a photoset.
    /// </summary>
    /// <param name="photosetId">The ID of the photoset to return photos for.</param>
    /// <param name="extras">The extras to return for each photo.</param>
    /// <param name="privacyFilter">The privacy filter to search on.</param>
    /// <param name="page">The page to return, defaults to 1.</param>
    /// <param name="perPage">The number of photos to return per page.</param>
    public async Task<PhotosetPhotoCollection> PhotosetsGetPhotosAsync(string photosetId, PhotoSearchExtras extras, PrivacyFilter privacyFilter, int page, int perPage, CancellationToken cancellationToken = default)
    {
        return await PhotosetsGetPhotosAsync(photosetId, extras, privacyFilter, page, perPage, MediaType.None, cancellationToken);
    }

    /// <summary>
    /// Gets a collection of photos for a photoset.
    /// </summary>
    /// <param name="photosetId">The ID of the photoset to return photos for.</param>
    /// <param name="extras">The extras to return for each photo.</param>
    /// <param name="privacyFilter">The privacy filter to search on.</param>
    /// <param name="page">The page to return, defaults to 1.</param>
    /// <param name="perPage">The number of photos to return per page.</param>
    /// <param name="media">Filter on the type of media.</param>
    public async Task<PhotosetPhotoCollection> PhotosetsGetPhotosAsync(string photosetId, PhotoSearchExtras extras, PrivacyFilter privacyFilter, int page, int perPage, MediaType media, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photosets.getPhotos" },
            { "photoset_id", photosetId }
        };
        if (extras != PhotoSearchExtras.None)
        {
            parameters.Add("extras", UtilityMethods.ExtrasToString(extras));
        }

        if (privacyFilter != PrivacyFilter.None)
        {
            parameters.Add("privacy_filter", privacyFilter.ToString("d"));
        }

        if (page > 0)
        {
            parameters.Add("page", page.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        if (perPage > 0)
        {
            parameters.Add("per_page", perPage.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        if (media != MediaType.None)
        {
            parameters.Add("media", (media == MediaType.All ? "all" : (media == MediaType.Photos ? "photos" : (media == MediaType.Videos ? "videos" : string.Empty))));
        }

        return await GetResponseAsync<PhotosetPhotoCollection>(parameters, cancellationToken);
    }

    /// <summary>
    /// Changes the order of your photosets.
    /// </summary>
    /// <param name="photosetIds">An array of photoset IDs,
    /// ordered with the set to show first, first in the list.
    /// Any set IDs not given in the list will be set to appear at the end of the list, ordered by their IDs.</param>
    public async Task PhotosetsOrderSetsAsync(IEnumerable<string> photosetIds, CancellationToken cancellationToken = default)
    {
        await PhotosetsOrderSetsAsync(string.Join(",", photosetIds.ToArray()), cancellationToken);
    }

    /// <summary>
    /// Changes the order of your photosets.
    /// </summary>
    /// <param name="photosetIds">An array of photoset IDs,
    /// ordered with the set to show first, first in the list.
    /// Any set IDs not given in the list will be set to appear at the end of the list, ordered by their IDs.</param>
    public async Task PhotosetsOrderSetsAsync(string[] photosetIds, CancellationToken cancellationToken = default)
    {
        await PhotosetsOrderSetsAsync(string.Join(",", photosetIds), cancellationToken);
    }

    /// <summary>
    /// Changes the order of your photosets.
    /// </summary>
    /// <param name="photosetIds">A comma delimited list of photoset IDs,
    /// ordered with the set to show first, first in the list.
    /// Any set IDs not given in the list will be set to appear at the end of the list, ordered by their IDs.</param>
    public async Task PhotosetsOrderSetsAsync(string photosetIds, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photosets.orderSets" },
            { "photoset_ids", photosetIds }
        };

        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }

    /// <summary>
    /// Removes a photo from a photoset.
    /// </summary>
    /// <remarks>
    /// An exception will be raised if the photo is not in the set.
    /// </remarks>
    /// <param name="photosetId">The ID of the photoset to remove the photo from.</param>
    /// <param name="photoId">The ID of the photo to remove.</param>
    public async Task PhotosetsRemovePhotoAsync(string photosetId, string photoId, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photosets.removePhoto" },
            { "photoset_id", photosetId },
            { "photo_id", photoId }
        };

        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }

    /// <summary>
    /// Removes a photo from a photoset.
    /// </summary>
    /// <remarks>
    /// An exception will be raised if the photo is not in the set.
    /// </remarks>
    /// <param name="photosetId">The ID of the photoset to remove the photo from.</param>
    /// <param name="photoIds">The IDs of the photo to remove.</param>
    public async Task PhotosetsRemovePhotosAsync(string photosetId, string[] photoIds, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photosets.removePhotos" },
            { "photoset_id", photosetId },
            { "photo_ids", string.Join(",", photoIds) }
        };

        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }

    /// <summary>
    /// Removes a photo from a photoset.
    /// </summary>
    /// <remarks>
    /// An exception will be raised if the photo is not in the set.
    /// </remarks>
    /// <param name="photosetId">The ID of the photoset to reorder the photo for.</param>
    /// <param name="photoIds">The IDs of the photo to reorder.</param>
    public async Task PhotosetsReorderPhotosAsync(string photosetId, string[] photoIds, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photosets.reorderPhotos" },
            { "photoset_id", photosetId },
            { "photo_ids", string.Join(",", photoIds) }
        };

        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }

    /// <summary>
    /// Removes a photo from a photoset.
    /// </summary>
    /// <remarks>
    /// An exception will be raised if the photo is not in the set.
    /// </remarks>
    /// <param name="photosetId">The ID of the photoset to set the primary photo for.</param>
    /// <param name="photoId">The IDs of the photo to become the primary photo.</param>
    public async Task PhotosetsSetPrimaryPhotoAsync(string photosetId, string photoId, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photosets.setPrimaryPhoto" },
            { "photoset_id", photosetId },
            { "photo_id", photoId }
        };

        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }

    /// <summary>
    /// Gets a list of comments for a photoset.
    /// </summary>
    /// <param name="photosetId">The id of the photoset to return the comments for.</param>
    public async Task<PhotosetCommentCollection> PhotosetsCommentsGetListAsync(string photosetId, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photosets.comments.getList" },
            { "photoset_id", photosetId }
        };

        return await GetResponseAsync<PhotosetCommentCollection>(parameters, cancellationToken);
    }

    /// <summary>
    /// Adds a new comment to a photoset.
    /// </summary>
    /// <param name="photosetId">The ID of the photoset to add the comment to.</param>
    /// <param name="commentText">The text of the comment. Can contain some HTML.</param>
    public async Task<string> PhotosetsCommentsAddCommentAsync(string photosetId, string commentText, CancellationToken cancellationToken = default)
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
    public async Task PhotosetsCommentsDeleteCommentAsync(string commentId, CancellationToken cancellationToken = default)
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
    public async Task PhotosetsCommentsEditCommentAsync(string commentId, string commentText, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photosets.comments.editComment" },
            { "comment_id", commentId },
            { "comment_text", commentText }
        };

        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }
}