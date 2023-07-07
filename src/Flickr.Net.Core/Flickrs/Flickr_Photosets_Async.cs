using Flickr.Net.Core.Flickrs.Results;
using Flickr.Net.Core.Internals.Extensions;

namespace Flickr.Net.Core;

/// <summary>
/// The flickr.
/// </summary>
public partial class Flickr : IFlickrPhotosets
{
    IFlickrPhotosetsComments IFlickrPhotosets.Comments => this;

    async Task IFlickrPhotosets.AddPhotoAsync(string photosetId, string photoId, CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photosets.addPhoto" },
            { "photoset_id", photosetId },
            { "photo_id", photoId }
        };

        await GetResponseAsync(parameters, cancellationToken);
    }

    async Task<string> IFlickrPhotosets.CreateAsync(string title, string primaryPhotoId, string description, CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photosets.create" },
            { "primary_photo_id", primaryPhotoId },
            { "title", title }
        };

        parameters.AppendIf("description", description, x => !string.IsNullOrEmpty(x), x => x);

        var result = await GetResponseAsync<PhotosetUnknownResponse>(parameters, cancellationToken);

        return result.GetValueOrDefault("id");
    }

    async Task IFlickrPhotosets.DeleteAsync(string photosetId, CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photosets.delete" },
            { "photoset_id", photosetId }
        };

        await GetResponseAsync(parameters, cancellationToken);
    }

    async Task IFlickrPhotosets.EditMetaAsync(string photosetId, string title, string description, CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photosets.editMeta" },
            { "photoset_id", photosetId },
            { "title", title }
        };

        parameters.AppendIf("description", description, x => !string.IsNullOrEmpty(x), x => x);

        await GetResponseAsync(parameters, cancellationToken);
    }

    async Task IFlickrPhotosets.EditPhotosAsync(string photosetId, string primaryPhotoId, string[] photoIds, CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photosets.editPhotos" },
            { "photoset_id", photosetId },
            { "primary_photo_id", primaryPhotoId },
            { "photo_ids", string.Join(",", photoIds) }
        };

        await GetResponseAsync(parameters, cancellationToken);
    }

    async Task<FlickrContextResult<NextPhoto, PrevPhoto>> IFlickrPhotosets.GetContextAsync(string photoId, string photosetId, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photosets.getContext" },
            { "photo_id", photoId },
            { "photoset_id", photosetId }
        };

        return await GetResponseAsync<FlickrContextResult<NextPhoto, PrevPhoto>>(parameters, cancellationToken);
    }

    async Task<Photoset> IFlickrPhotosets.GetInfoAsync(string photosetId, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photosets.getInfo" },
            { "photoset_id", photosetId }
        };

        return await GetResponseAsync<Photoset>(parameters, cancellationToken);
    }

    async Task<Photosets> IFlickrPhotosets.GetListAsync(string userId, int page, int perPage, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photosets.getList" }
        };

        parameters.AppendIf("user_id", userId, x => x != null, x => x);

        parameters.AppendIf("per_page", perPage, x => x > 0, x => x.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));

        parameters.AppendIf("page", page, x => x > 0, x => x.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));

        return await GetResponseAsync<Photosets>(parameters, cancellationToken);
    }

    async Task<PhotosetPhotos> IFlickrPhotosets.GetPhotosAsync(string photosetId, PhotoSearchExtras extras, PrivacyFilter privacyFilter, int page, int perPage, MediaType media, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photosets.getPhotos" },
            { "photoset_id", photosetId }
        };

        parameters.AppendIf("extras", extras, x => x != PhotoSearchExtras.None, x => x.ToFlickrString());

        parameters.AppendIf("privacy_filter", privacyFilter, x => x != PrivacyFilter.None, x => x.ToString("d"));

        parameters.AppendIf("per_page", perPage, x => x > 0, x => x.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));

        parameters.AppendIf("page", page, x => x > 0, x => x.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));

        if (media != MediaType.None)
        {
            parameters.Add("media", media switch
            {
                MediaType.Photos or MediaType.Photo => "photos",
                MediaType.Videos or MediaType.Video => "videos",
                _ or MediaType.All => "all",
            });
        }

        return await GetResponseAsync<PhotosetPhotos>(parameters, cancellationToken);
    }

    async Task IFlickrPhotosets.OrderSetsAsync(IEnumerable<string> photosetIds, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photosets.orderSets" },
            { "photoset_ids", string.Join(",", photosetIds.ToArray()) }
        };

        await GetResponseAsync(parameters, cancellationToken);
    }

    async Task IFlickrPhotosets.RemovePhotoAsync(string photosetId, string photoId, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photosets.removePhoto" },
            { "photoset_id", photosetId },
            { "photo_id", photoId }
        };

        await GetResponseAsync(parameters, cancellationToken);
    }

    async Task IFlickrPhotosets.RemovePhotosAsync(string photosetId, IEnumerable<string> photoIds, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photosets.removePhotos" },
            { "photoset_id", photosetId },
            { "photo_ids", string.Join(",", photoIds.ToArray()) }
        };

        await GetResponseAsync(parameters, cancellationToken);
    }

    async Task IFlickrPhotosets.ReorderPhotosAsync(string photosetId, IEnumerable<string> photoIds, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photosets.reorderPhotos" },
            { "photoset_id", photosetId },
            { "photo_ids", string.Join(",", photoIds.ToArray()) }
        };

        await GetResponseAsync(parameters, cancellationToken);
    }

    async Task IFlickrPhotosets.SetPrimaryPhotoAsync(string photosetId, string photoId, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photosets.setPrimaryPhoto" },
            { "photoset_id", photosetId },
            { "photo_id", photoId }
        };

        await GetResponseAsync(parameters, cancellationToken);
    }
}

/// <summary>
/// The flickr photosets.
/// </summary>
public interface IFlickrPhotosets
{
    /// <summary>
    /// property for all photosets comment functions
    /// </summary>
    IFlickrPhotosetsComments Comments { get; }

    /// <summary>
    /// Add a photo to a photoset.
    /// </summary>
    /// <param name="photosetId">The ID of the photoset to add the photo to.</param>
    /// <param name="photoId">The ID of the photo to add.</param>
    /// <param name="cancellationToken"></param>
    /// <return></return>
    Task AddPhotoAsync(string photosetId, string photoId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a blank photoset, with a title, description and a primary photo.
    /// </summary>
    /// <param name="title">The title of the photoset.</param>
    /// <param name="description">THe description of the photoset.</param>
    /// <param name="primaryPhotoId">
    /// The ID of the photo which will be the primary photo for the photoset. This photo will also
    /// be added to the set.
    /// </param>
    /// <param name="cancellationToken"></param>
    /// <return></return>
    Task<string> CreateAsync(string title, string primaryPhotoId, string description = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes the specified photoset.
    /// </summary>
    /// <param name="photosetId">The ID of the photoset to delete.</param>
    /// <param name="cancellationToken"></param>
    Task DeleteAsync(string photosetId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates the title and description for a photoset.
    /// </summary>
    /// <param name="photosetId">The ID of the photoset to update.</param>
    /// <param name="title">The new title for the photoset.</param>
    /// <param name="description">The new description for the photoset.</param>
    /// <param name="cancellationToken"></param>
    /// <return></return>
    Task EditMetaAsync(string photosetId, string title, string description = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Sets the photos for a photoset.
    /// </summary>
    /// <remarks>
    /// Will remove any previous photos from the photoset. The order in thich the photoids are given
    /// is the order they will appear in the photoset page.
    /// </remarks>
    /// <param name="photosetId">The ID of the photoset to update.</param>
    /// <param name="primaryPhotoId">The ID of the new primary photo for the photoset.</param>
    /// <param name="photoIds">An array of photo IDs.</param>
    /// <param name="cancellationToken"></param>
    /// <return></return>
    Task EditPhotosAsync(string photosetId, string primaryPhotoId, string[] photoIds, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the context of the specified photo within the photoset.
    /// </summary>
    /// <param name="photoId">The photo id of the photo in the set.</param>
    /// <param name="photosetId">The id of the set.</param>
    /// <param name="cancellationToken"></param>
    /// <return></return>
    Task<FlickrContextResult<NextPhoto, PrevPhoto>> GetContextAsync(string photoId, string photosetId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the information about a photoset.
    /// </summary>
    /// <param name="photosetId">The ID of the photoset to return information for.</param>
    /// <param name="cancellationToken"></param>
    /// <return></return>
    Task<Photoset> GetInfoAsync(string photosetId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a list of the specified users photosets.
    /// </summary>
    /// <param name="userId">The ID of the user to return the photosets of.</param>
    /// <param name="page">The page of the results to return. Defaults to page 1.</param>
    /// <param name="perPage">The number of photosets to return per page. Defaults to 500.</param>
    /// <param name="cancellationToken"></param>
    /// <return></return>
    Task<Photosets> GetListAsync(string userId, int page = 0, int perPage = 0, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a collection of photos for a photoset.
    /// </summary>
    /// <param name="photosetId">The ID of the photoset to return photos for.</param>
    /// <param name="extras">The extras to return for each photo.</param>
    /// <param name="privacyFilter">The privacy filter to search on.</param>
    /// <param name="page">The page to return, defaults to 1.</param>
    /// <param name="perPage">The number of photos to return per page.</param>
    /// <param name="media">Filter on the type of media.</param>
    /// <param name="cancellationToken"></param>
    /// <return></return>
    Task<PhotosetPhotos> GetPhotosAsync(string photosetId, PhotoSearchExtras extras = PhotoSearchExtras.None, PrivacyFilter privacyFilter = PrivacyFilter.None, int page = 0, int perPage = 0, MediaType media = MediaType.None, CancellationToken cancellationToken = default);

    /// <summary>
    /// Changes the order of your photosets.
    /// </summary>
    /// <param name="photosetIds">
    /// An array of photoset IDs, ordered with the set to show first, first in the list. Any set IDs
    /// not given in the list will be set to appear at the end of the list, ordered by their IDs.
    /// </param>
    /// <param name="cancellationToken"></param>
    /// <return></return>
    Task OrderSetsAsync(IEnumerable<string> photosetIds, CancellationToken cancellationToken = default);

    /// <summary>
    /// Removes a photo from a photoset.
    /// </summary>
    /// <remarks>An exception will be raised if the photo is not in the set.</remarks>
    /// <param name="photosetId">The ID of the photoset to remove the photo from.</param>
    /// <param name="photoId">The ID of the photo to remove.</param>
    /// <param name="cancellationToken"></param>
    /// <return></return>
    Task RemovePhotoAsync(string photosetId, string photoId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Removes a photo from a photoset.
    /// </summary>
    /// <remarks>An exception will be raised if the photo is not in the set.</remarks>
    /// <param name="photosetId">The ID of the photoset to remove the photo from.</param>
    /// <param name="photoIds">The IDs of the photo to remove.</param>
    /// <param name="cancellationToken"></param>
    /// <return></return>
    Task RemovePhotosAsync(string photosetId, IEnumerable<string> photoIds, CancellationToken cancellationToken = default);

    /// <summary>
    /// Removes a photo from a photoset.
    /// </summary>
    /// <remarks>An exception will be raised if the photo is not in the set.</remarks>
    /// <param name="photosetId">The ID of the photoset to reorder the photo for.</param>
    /// <param name="photoIds">The IDs of the photo to reorder.</param>
    /// <param name="cancellationToken"></param>
    /// <return></return>
    Task ReorderPhotosAsync(string photosetId, IEnumerable<string> photoIds, CancellationToken cancellationToken = default);

    /// <summary>
    /// Removes a photo from a photoset.
    /// </summary>
    /// <remarks>An exception will be raised if the photo is not in the set.</remarks>
    /// <param name="photosetId">The ID of the photoset to set the primary photo for.</param>
    /// <param name="photoId">The IDs of the photo to become the primary photo.</param>
    /// <param name="cancellationToken"></param>
    /// <return></return>
    Task SetPrimaryPhotoAsync(string photosetId, string photoId, CancellationToken cancellationToken = default);
}