using Flickr.Net.Core.Internals.Extensions;

namespace Flickr.Net.Core;

/// <summary>
/// The flickr.
/// </summary>
public partial class Flickr : IFlickrPhotosSuggestions
{
    async Task IFlickrPhotosSuggestions.ApproveSuggestionAsync(string suggestionId, CancellationToken cancellationToken)
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

        await GetResponseAsync(parameters, cancellationToken);
    }

    async Task<UnknownResponse> IFlickrPhotosSuggestions.GetListAsync(string photoId, SuggestionStatus status, CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.suggestions.getList" },
            { "photo_id", photoId },
            { "status_id", status.GetEnumMemberValue() }
        };

        return await GetResponseAsync<UnknownResponse>(parameters, cancellationToken);
    }

    async Task IFlickrPhotosSuggestions.RejectSuggestionAsync(string suggestionId, CancellationToken cancellationToken)
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

        await GetResponseAsync(parameters, cancellationToken);
    }

    async Task IFlickrPhotosSuggestions.RemoveSuggestionAsync(string suggestionId, CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        ArgumentException.ThrowIfNullOrEmpty(suggestionId);

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.suggestions.removeSuggestion" },
            { "suggestion_id", suggestionId }
        };

        await GetResponseAsync(parameters, cancellationToken);
    }

    async Task IFlickrPhotosSuggestions.SuggestLocationAsync(string photoId, double latitude, double longitude, GeoAccuracy accuracy, WoeId? woeId, PlaceId? placeId, string note, CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.suggestions.suggestLocation" },
            { "photo_id", photoId },
            { "lat", latitude.ToString(System.Globalization.NumberFormatInfo.InvariantInfo) },
            { "lon", longitude.ToString(System.Globalization.NumberFormatInfo.InvariantInfo) }
        };

        parameters.AppendIf("accuracy", accuracy, x => x != GeoAccuracy.None, x => x.ToString("D"));

        parameters.AppendIf("woe_id", woeId, x => !string.IsNullOrEmpty(x), x => x);

        parameters.AppendIf("place_id", placeId, x => !string.IsNullOrEmpty(x), x => x);

        parameters.AppendIf("note", note, x => !string.IsNullOrEmpty(x), x => x);

        await GetResponseAsync(parameters, cancellationToken);
    }
}

/// <summary>
/// The flickr photos suggestions.
/// </summary>
public interface IFlickrPhotosSuggestions
{
    /// <summary>
    /// Approve a location suggestion for a photo.
    /// </summary>
    /// <param name="suggestionId">The suggestion to approve.</param>
    /// <param name="cancellationToken"></param>
    Task ApproveSuggestionAsync(string suggestionId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get a list of suggestions for a photo.
    /// </summary>
    /// <param name="photoId">The photo id of the photo to list the suggestions for.</param>
    /// <param name="status">The type of status to filter by.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<UnknownResponse> GetListAsync(string photoId, SuggestionStatus status, CancellationToken cancellationToken = default);

    /// <summary>
    /// Rejects a suggestion made for a location on a photo. Currently doesn't appear to actually
    /// work. Just use <see cref="IFlickrPhotosSuggestions.RemoveSuggestionAsync(string,
    /// CancellationToken)"/> instead.
    /// </summary>
    /// <param name="suggestionId">The ID of the suggestion to remove.</param>
    /// <param name="cancellationToken"></param>
    Task RejectSuggestionAsync(string suggestionId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Remove a location suggestion from a photo.
    /// </summary>
    /// <param name="suggestionId">The suggestion to remove.</param>
    /// <param name="cancellationToken"></param>
    Task RemoveSuggestionAsync(string suggestionId, CancellationToken cancellationToken = default);

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
    /// <param name="cancellationToken"></param>
    Task SuggestLocationAsync(string photoId, double latitude, double longitude, GeoAccuracy accuracy = GeoAccuracy.None, WoeId? woeId = null, PlaceId? placeId = null, string note = null, CancellationToken cancellationToken = default);
}