using Flickr.Net.Core.Entities;
using Flickr.Net.Core.Entities.Collections;
using Flickr.Net.Core.Enums;

namespace Flickr.Net.Core;

public partial class Flickr
{
    /// <summary>
    /// Approve a location suggestion for a photo.
    /// </summary>
    /// <param name="suggestionId">The suggestion to approve.</param>
    public async Task PhotosSuggestionsApproveSuggestionAsync(string suggestionId, CancellationToken cancellationToken = default)
    {
        CheckRequiresAuthentication();

        if (string.IsNullOrEmpty(suggestionId))
        {
            throw new ArgumentNullException(nameof(suggestionId));
        }

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.suggestions.approveSuggestion" },
            { "suggestion_id", suggestionId }
        };

        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }

    /// <summary>
    /// Get a list of suggestions for a photo.
    /// </summary>
    /// <param name="photoId">The photo id of the photo to list the suggestions for.</param>
    /// <param name="status">The type of status to filter by.</param>
    /// <returns></returns>
    public async Task<SuggestionCollection> PhotosSuggestionsGetListAsync(string photoId, SuggestionStatus status, CancellationToken cancellationToken = default)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.suggestions.getList" },
            { "photo_id", photoId },
            { "status_id", status.ToString("d") }
        };

        return await GetResponseAsync<SuggestionCollection>(parameters, cancellationToken);
    }

    /// <summary>
    /// Rejects a suggestion made for a location on a photo. Currently doesn't appear to actually work. Just use <see cref="Flickr.PhotosSuggestionsRemoveSuggestion"/> instead.
    /// </summary>
    /// <param name="suggestionId">The ID of the suggestion to remove.</param>
    public async Task PhotosSuggestionsRejectSuggestionAsync(string suggestionId, CancellationToken cancellationToken = default)
    {
        CheckRequiresAuthentication();

        if (string.IsNullOrEmpty(suggestionId))
        {
            throw new ArgumentNullException(nameof(suggestionId));
        }

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.suggestions.rejectSuggestion" },
            { "suggestion_id", suggestionId }
        };

        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }

    /// <summary>
    /// Remove a location suggestion from a photo.
    /// </summary>
    /// <param name="suggestionId">The suggestion to remove.</param>
    public async Task PhotosSuggestionsRemoveSuggestionAsync(string suggestionId, CancellationToken cancellationToken = default)
    {
        CheckRequiresAuthentication();

        if (string.IsNullOrEmpty(suggestionId))
        {
            throw new ArgumentNullException(nameof(suggestionId));
        }

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.suggestions.removeSuggestion" },
            { "suggestion_id", suggestionId }
        };

        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }

    /// <summary>
    /// Suggest a particular location for a photo.
    /// </summary>
    /// <param name="photoId">The id of the photo.</param>
    /// <param name="latitude">The latitude of the location to suggest.</param>
    /// <param name="longitude">The longitude of the location to suggest.</param>
    /// <param name="accuracy">The accuracy of the location to suggest.</param>
    /// <param name="woeId">The WOE ID of the location to suggest.</param>
    /// <param name="placeId">The Flickr place id of the location to suggest.</param>
    /// <param name="note">A note to add to the suggestion.</param>
    public async Task PhotosSuggestionsSuggestLocationAsync(string photoId, double latitude, double longitude, GeoAccuracy accuracy = GeoAccuracy.None, string woeId = null, string placeId = null, string note = null, CancellationToken cancellationToken = default)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.suggestions.suggestLocation" },
            { "photo_id", photoId },
            { "lat", latitude.ToString(System.Globalization.NumberFormatInfo.InvariantInfo) },
            { "lon", longitude.ToString(System.Globalization.NumberFormatInfo.InvariantInfo) }
        };

        if (accuracy != GeoAccuracy.None)
        {
            parameters.Add("accuracy", accuracy.ToString("D"));
        }

        if (!string.IsNullOrEmpty(placeId))
        {
            parameters.Add("place_id", placeId);
        }

        if (!string.IsNullOrEmpty(woeId))
        {
            parameters.Add("woe_id", woeId);
        }

        if (!string.IsNullOrEmpty(note))
        {
            parameters.Add("note", note);
        }

        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }
}