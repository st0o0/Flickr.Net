﻿using Flickr.Net.Flickrs.Results;
using Flickr.Net.Internals.Extensions;

namespace Flickr.Net;

/// <summary>
/// The flickr.
/// </summary>
public partial class Flickr : IFlickrFavorites
{
    async Task IFlickrFavorites.AddAsync(string photoId, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.favorites.add" },
            { "photo_id", photoId }
        };

        await GetResponseAsync(parameters, cancellationToken);
    }

    async Task<FlickrContextResult<NextPhoto, PrevPhoto>> IFlickrFavorites.GetContextAsync(string photoId, string userId, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.favorites.getContext" },
            { "user_id", userId },
            { "photo_id", photoId },
        };

        return await GetContextResponseAsync<NextPhoto, PrevPhoto>(parameters, cancellationToken);
    }

    async Task<PagedPhotos> IFlickrFavorites.GetListAsync(string userId, DateTime? minFavoriteDate, DateTime? maxFavoriteDate, PhotoSearchExtras extras, int page, int perPage, CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.favorites.getList" }
        };

        parameters.AppendIf("user_id", userId, x => x != null, x => x);

        parameters.AppendIf("min_fav_date", maxFavoriteDate, x => x.HasValue && x > DateTime.MinValue, x => x.Value.ToUnixTimestamp());

        parameters.AppendIf("max_fav_date", maxFavoriteDate, x => x.HasValue && x > DateTime.MinValue, x => x.Value.ToUnixTimestamp());

        parameters.AppendIf("extras", extras, x => x != PhotoSearchExtras.None, x => x.ToFlickrString());

        parameters.AppendIf("per_page", perPage, x => x > 0, x => x.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));

        parameters.AppendIf("page", page, x => x > 0, x => x.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));

        return await GetResponseAsync<PagedPhotos>(parameters, cancellationToken);
    }

    async Task<PagedPhotos> IFlickrFavorites.GetPublicListAsync(string userId, int page, int perPage, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.favorites.getPublicList" },
            { "user_id", userId }
        };

        parameters.AppendIf("per_page", perPage, x => x > 0, x => x.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));

        parameters.AppendIf("page", page, x => x > 0, x => x.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));

        return await GetResponseAsync<PagedPhotos>(parameters, cancellationToken);
    }

    async Task IFlickrFavorites.RemoveAsync(string photoId, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.favorites.remove" },
            { "photo_id", photoId }
        };

        await GetResponseAsync(parameters, cancellationToken);
    }
}

/// <summary>
/// The flickr favorites.
/// </summary>
public interface IFlickrFavorites
{
    /// <summary>
    /// Adds a photo to the logged in favourites. Requires authentication.
    /// </summary>
    /// <param name="photoId">The id of the photograph to add.</param>
    /// <param name="cancellationToken"></param>
    Task AddAsync(string photoId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get the next and previous favorites in a users list of favorites, based on one of their favorites.
    /// </summary>
    /// <param name="photoId">
    /// The photo id of the photo for which to find the next and previous favorites.
    /// </param>
    /// <param name="userId">The user id of the users whose favorites you wish to search.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<FlickrContextResult<NextPhoto, PrevPhoto>> GetContextAsync(string photoId, string userId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get a list of favourites for the specified user.
    /// </summary>
    /// <param name="userId">The user id of the user whose favourites you wish to retrieve.</param>
    /// <param name="minFavoriteDate">Minimum date that a photo was favorited on.</param>
    /// <param name="maxFavoriteDate">Maximum date that a photo was favorited on.</param>
    /// <param name="extras">The extras to return for each photo.</param>
    /// <param name="page">The page to download this time.</param>
    /// <param name="perPage">Number of photos to include per page.</param>
    /// <param name="cancellationToken"></param>
    Task<PagedPhotos> GetListAsync(string userId = null, DateTime? minFavoriteDate = null, DateTime? maxFavoriteDate = null, PhotoSearchExtras extras = PhotoSearchExtras.None, int page = 0, int perPage = 0, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the public favourites for a specified user.
    /// </summary>
    /// <remarks>
    /// This function differs from <see cref="GetListAsync(string, DateTime?,
    /// DateTime?, PhotoSearchExtras, int, int, CancellationToken)"/> in that the user id is not optional.
    /// </remarks>
    /// <param name="userId">The is of the user whose favourites you wish to return.</param>
    /// <param name="page">The specific page to return.</param>
    /// <param name="perPage">The number of photos to return per page.</param>
    /// <param name="cancellationToken"></param>
    Task<PagedPhotos> GetPublicListAsync(string userId, int page = 0, int perPage = 0, CancellationToken cancellationToken = default);

    /// <summary>
    /// Removes a photograph from the logged in users favourites. Requires authentication.
    /// </summary>
    /// <param name="photoId">The id of the photograph to remove.</param>
    /// <param name="cancellationToken"></param>
    Task RemoveAsync(string photoId, CancellationToken cancellationToken = default);
}