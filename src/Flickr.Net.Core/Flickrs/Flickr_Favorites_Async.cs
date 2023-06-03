using Flickr.Net.Core.Entities;
using Flickr.Net.Core.Entities.Collections;
using Flickr.Net.Core.Enums;
using Flickr.Net.Core.Internals;

namespace Flickr.Net.Core;

// TODO:
public partial class Flickr
{
    /// <summary>
    /// Adds a photo to the logged in favourites.
    /// Requires authentication.
    /// </summary>
    /// <param name="photoId">The id of the photograph to add.</param>
    public async Task FavoritesAddAsync(string photoId, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.favorites.add" },
            { "photo_id", photoId }
        };

        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }

    /// <summary>
    /// Get the next and previous favorites in a users list of favorites, based on one of their favorites.
    /// </summary>
    /// <param name="photoId">The photo id of the photo for which to find the next and previous favorites.</param>
    /// <param name="userId">The user id of the users whose favorites you wish to search.</param>
    /// <param name="numPrevious">The number of previous favorites to list. Defaults to 1.</param>
    /// <param name="numNext">The number of next favorites to list. Defaults to 1.</param>
    /// <param name="extras">Any extras to return for each photo in the previous and next list.</param>
    /// <returns></returns>
    public async Task<FavoriteContext> FavoritesGetContextAsync(string photoId, string userId, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.favorites.getContext" },
            { "user_id", userId },
            { "photo_id", photoId },
        };

        return await GetResponseAsync<FavoriteContext>(parameters, cancellationToken);
    }

    /// <summary>
    /// Get a list of favourites for the specified user.
    /// </summary>
    /// <param name="userId">The user id of the user whose favourites you wish to retrieve.</param>
    /// <param name="minFavoriteDate">Minimum date that a photo was favorited on.</param>
    /// <param name="maxFavoriteDate">Maximum date that a photo was favorited on. </param>
    /// <param name="extras">The extras to return for each photo.</param>
    /// <param name="perPage">Number of photos to include per page.</param>
    /// <param name="page">The page to download this time.</param>
    public async Task<PhotoCollection> FavoritesGetListAsync(string userId = null, DateTime? minFavoriteDate = null, DateTime? maxFavoriteDate = null, PhotoSearchExtras extras = PhotoSearchExtras.None, int page = 0, int perPage = 0, CancellationToken cancellationToken = default)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.favorites.getList" }
        };
        
        if (userId != null)
        {
            parameters.Add("user_id", userId);
        }

        if (minFavoriteDate.HasValue && minFavoriteDate > DateTime.MinValue)
        {
            parameters.Add("min_fav_date", UtilityMethods.DateToUnixTimestamp(minFavoriteDate.Value));
        }

        if (maxFavoriteDate.HasValue && maxFavoriteDate > DateTime.MinValue)
        {
            parameters.Add("max_fav_date", UtilityMethods.DateToUnixTimestamp(maxFavoriteDate.Value));
        }

        if (extras != PhotoSearchExtras.None)
        {
            parameters.Add("extras", UtilityMethods.ExtrasToString(extras));
        }

        if (perPage > 0)
        {
            parameters.Add("per_page", perPage.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        if (page > 0)
        {
            parameters.Add("page", page.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        return await GetResponseAsync<PhotoCollection>(parameters, cancellationToken);
    }

    /// <summary>
    /// Gets the public favourites for a specified user.
    /// </summary>
    /// <remarks>This function difers from <see cref="Flickr.FavoritesGetList(string)"/> in that the user id
    /// is not optional.</remarks>
    /// <param name="userId">The is of the user whose favourites you wish to return.</param>
    /// <param name="minFavoriteDate">Minimum date that a photo was favorited on.</param>
    /// <param name="maxFavoriteDate">Maximum date that a photo was favorited on. </param>
    /// <param name="extras">The extras to return for each photo.</param>
    /// <param name="perPage">The number of photos to return per page.</param>
    /// <param name="page">The specific page to return.</param>
    public async Task<PhotoCollection> FavoritesGetPublicListAsync(string userId, int page = 0, int perPage = 0, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.favorites.getPublicList" },
            { "user_id", userId }
        };

        if (perPage > 0)
        {
            parameters.Add("per_page", perPage.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        if (page > 0)
        {
            parameters.Add("page", page.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        return await GetResponseAsync<PhotoCollection>(parameters, cancellationToken);
    }

    /// <summary>
    /// Removes a photograph from the logged in users favourites.
    /// Requires authentication.
    /// </summary>
    /// <param name="photoId">The id of the photograph to remove.</param>
    public async Task FavoritesRemoveAsync(string photoId, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.favorites.remove" },
            { "photo_id", photoId }
        };

        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }
}