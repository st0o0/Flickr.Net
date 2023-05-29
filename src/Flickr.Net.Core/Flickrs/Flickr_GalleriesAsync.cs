namespace FlickrNet.Core;

public partial class Flickr
{
    /// <summary>
    /// Add a photo to a gallery.
    /// </summary>
    /// <param name="galleryId">The ID of the gallery to add a photo to.
    /// Note: this is the compound ID returned in methods like <see cref="Flickr.GalleriesGetList(string, int, int)"/>,
    /// and <see cref="Flickr.GalleriesGetListForPhoto(string, int, int)"/>.</param>
    /// <param name="photoId">The photo ID to add to the gallery</param>
    public async Task GalleriesAddPhotoAsync(string galleryId, string photoId, CancellationToken cancellationToken = default)
    {
        await GalleriesAddPhotoAsync(galleryId, photoId, null, cancellationToken);
    }

    /// <summary>
    /// Add a photo to a gallery.
    /// </summary>
    /// <param name="galleryId">The ID of the gallery to add a photo to.
    /// Note: this is the compound ID returned in methods like <see cref="Flickr.GalleriesGetList(string, int, int)"/>,
    /// and <see cref="Flickr.GalleriesGetListForPhoto(string, int, int)"/>.</param>
    /// <param name="photoId">The photo ID to add to the gallery</param>
    /// <param name="comment">A short comment or story to accompany the photo.</param>
    public async Task GalleriesAddPhotoAsync(string galleryId, string photoId, string comment, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.galleries.addPhoto" },
            { "gallery_id", galleryId },
            { "photo_id", photoId }
        };
        if (!string.IsNullOrEmpty(comment))
        {
            parameters.Add("comment", comment);
        }

        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }

    /// <summary>
    /// Create a new gallery for the calling user.
    /// </summary>
    /// <param name="title">The name of the gallery.</param>
    /// <param name="description">A short description for the gallery.</param>
    public async Task GalleriesCreateAsync(string title, string description, CancellationToken cancellationToken = default)
    {
        await GalleriesCreateAsync(title, description, null, cancellationToken);
    }

    /// <summary>
    /// Create a new gallery for the calling user.
    /// </summary>
    /// <param name="title">The name of the gallery.</param>
    /// <param name="description">A short description for the gallery.</param>
    /// <param name="primaryPhotoId">The first photo to add to your gallery.</param>
    public async Task GalleriesCreateAsync(string title, string description, string primaryPhotoId, CancellationToken cancellationToken = default)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.galleries.create" },
            { "title", title },
            { "description", description }
        };
        if (!string.IsNullOrEmpty(primaryPhotoId))
        {
            parameters.Add("primary_photo_id", primaryPhotoId);
        }

        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }

    /// <summary>
    /// Modify the meta-data for a gallery.
    /// </summary>
    /// <param name="galleryId">The gallery ID to update.</param>
    /// <param name="title">The new title for the gallery.</param>
    public async Task GalleriesEditMetaAsync(string galleryId, string title, CancellationToken cancellationToken = default)
    {
        await GalleriesEditMetaAsync(galleryId, title, null, cancellationToken);
    }

    /// <summary>
    /// Modify the meta-data for a gallery.
    /// </summary>
    /// <param name="galleryId">The gallery ID to update.</param>
    /// <param name="title">The new title for the gallery.</param>
    /// <param name="description">The new description for the gallery.</param>
    public async Task GalleriesEditMetaAsync(string galleryId, string title, string description, CancellationToken cancellationToken = default)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.galleries.editMeta" },
            { "gallery_id", galleryId },
            { "title", title }
        };
        if (!string.IsNullOrEmpty(description))
        {
            parameters.Add("description", description);
        }

        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }

    /// <summary>
    /// Edit the comment for a gallery photo.
    /// </summary>
    /// <param name="galleryId">The ID of the gallery to add a photo to.
    /// Note: this is the compound ID returned in methods like <see cref="Flickr.GalleriesGetList(string, int, int)"/>,
    /// and <see cref="Flickr.GalleriesGetListForPhoto(string, int, int)"/>.</param>
    /// <param name="photoId">The photo ID to add to the gallery.</param>
    /// <param name="comment">The updated comment the photo.</param>
    public async Task GalleriesEditPhotoAsync(string galleryId, string photoId, string comment, CancellationToken cancellationToken = default)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.galleries.editPhoto" },
            { "gallery_id", galleryId },
            { "photo_id", photoId },
            { "comment", comment }
        };

        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }

    /// <summary>
    /// Modify the photos in a gallery. Use this method to add, remove and re-order photos.
    /// </summary>
    /// <param name="galleryId">The id of the gallery to modify. The gallery must belong to the calling user.</param>
    /// <param name="primaryPhotoId">The id of the photo to use as the 'primary' photo for the gallery. This id must also be passed along in photo_ids list argument.</param>
    /// <param name="photoIds">An enumeration of photo ids to include in the gallery.
    /// They will appear in the set in the order sent. This list must contain the primary photo id.
    /// This list of photos replaces the existing list.</param>
    public async Task GalleriesEditPhotosAsync(string galleryId, string primaryPhotoId, IEnumerable<string> photoIds, CancellationToken cancellationToken = default)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.galleries.editPhotos" },
            { "gallery_id", galleryId },
            { "primary_photo_id", primaryPhotoId }
        };
        List<string> ids = new(photoIds);
        parameters.Add("photo_ids", string.Join(",", ids.ToArray()));

        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }

    /// <summary>
    /// Get the information about a gallery.
    /// </summary>
    /// <param name="galleryId">The gallery ID you are requesting information for.</param>
    public async Task<Gallery> GalleriesGetInfoAsync(string galleryId, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.galleries.getInfo" },
            { "gallery_id", galleryId }
        };

        return await GetResponseAsync<Gallery>(parameters, cancellationToken);
    }

    /// <summary>
    /// Gets a list of galleries for the calling user. Must be authenticated.
    /// </summary>
    public async Task<GalleryCollection> GalleriesGetListAsync(CancellationToken cancellationToken = default)
    {
        CheckRequiresAuthentication();

        return await GalleriesGetListAsync(null, 0, 0, cancellationToken);
    }

    /// <summary>
    /// Gets a list of galleries for the calling user. Must be authenticated.
    /// </summary>
    /// <param name="page"></param>
    /// <param name="perPage"></param>
    public async Task<GalleryCollection> GalleriesGetListAsync(int page, int perPage, CancellationToken cancellationToken = default)
    {
        CheckRequiresAuthentication();

        return await GalleriesGetListAsync(null, page, perPage, cancellationToken);
    }

    /// <summary>
    /// Gets a list of galleries for the specified user.
    /// </summary>
    /// <param name="userId">The user to return the galleries for.</param>
    public async Task<GalleryCollection> GalleriesGetListAsync(string userId, CancellationToken cancellationToken = default)
    {
        return await GalleriesGetListAsync(userId, 0, 0, cancellationToken);
    }

    /// <summary>
    /// Gets a list of galleries for the specified user.
    /// </summary>
    /// <param name="userId">The user to return the galleries for.</param>
    /// <param name="page"></param>
    /// <param name="perPage"></param>
    public async Task<GalleryCollection> GalleriesGetListAsync(string userId, int page, int perPage, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.galleries.getList" }
        };
        if (!string.IsNullOrEmpty(userId))
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

        return await GetResponseAsync<GalleryCollection>(parameters, cancellationToken);
    }

    /// <summary>
    /// Return the list of galleries to which a photo has been added. Galleries are returned sorted by date which the photo was added to the gallery.
    /// </summary>
    /// <param name="photoId">The ID of the photo to fetch a list of galleries for.</param>
    public async Task<GalleryCollection> GalleriesGetListForPhotoAsync(string photoId, CancellationToken cancellationToken = default)
    {
        return await GalleriesGetListForPhotoAsync(photoId, 0, 0, cancellationToken);
    }

    /// <summary>
    /// Return the list of galleries to which a photo has been added. Galleries are returned sorted by date which the photo was added to the gallery.
    /// </summary>
    /// <param name="photoId">The ID of the photo to fetch a list of galleries for.</param>
    /// <param name="page">The page of results to return. If this argument is omitted, it defaults to 1.</param>
    /// <param name="perPage">Number of galleries to return per page. If this argument is omitted, it defaults to 100. The maximum allowed value is 500.</param>
    public async Task<GalleryCollection> GalleriesGetListForPhotoAsync(string photoId, int page, int perPage, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.galleries.getListForPhoto" },
            { "photo_id", photoId }
        };
        if (page > 0)
        {
            parameters.Add("page", page.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        if (perPage > 0)
        {
            parameters.Add("per_page", perPage.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        return await GetResponseAsync<GalleryCollection>(parameters, cancellationToken);
    }

    /// <summary>
    /// Return the list of photos for a gallery.
    /// </summary>
    /// <param name="galleryId">The ID of the gallery of photos to return.</param>
    public async Task<GalleryPhotoCollection> GalleriesGetPhotosAsync(string galleryId, CancellationToken cancellationToken = default)
    {
        return await GalleriesGetPhotosAsync(galleryId, PhotoSearchExtras.None, cancellationToken);
    }

    /// <summary>
    /// Return the list of photos for a gallery.
    /// </summary>
    /// <param name="galleryId">The ID of the gallery of photos to return.</param>
    /// <param name="extras">A list of extra information to fetch for each returned record.</param>
    public async Task<GalleryPhotoCollection> GalleriesGetPhotosAsync(string galleryId, PhotoSearchExtras extras, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.galleries.getPhotos" },
            { "gallery_id", galleryId }
        };
        if (extras != PhotoSearchExtras.None)
        {
            parameters.Add("extras", UtilityMethods.ExtrasToString(extras));
        }

        return await GetResponseAsync<GalleryPhotoCollection>(parameters, cancellationToken);
    }

    /// <summary>
    /// Remove a photo from a gallery (and optionally update the gallery description).
    /// </summary>
    /// <param name="galleryId"></param>
    /// <param name="photoId"></param>
    /// <param name="fullResponse"></param>
    public async Task GalleriesRemovePhoto(string galleryId, string photoId, string fullResponse = null, CancellationToken cancellationToken = default)
    {
        CheckRequiresAuthentication();

        var parameters = new Dictionary<string, string>
        {
            { "method", "flickr.galleries.removePhoto" },
            { "gallery_id", galleryId },
            { "photo_id", photoId },
            { "full_response", fullResponse ?? "" }
        };

        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }
}