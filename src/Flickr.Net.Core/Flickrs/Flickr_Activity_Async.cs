namespace Flickr.Net.Core;

/// <summary>
/// The flickr.
/// </summary>
public partial class Flickr : IFlickrActivity
{
    async Task<Items> IFlickrActivity.UserCommentsAsync(int page, int perPage, CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.activity.userComments" }
        };

        if (page > 0)
        {
            parameters.Add("page", page.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        if (perPage > 0)
        {
            parameters.Add("per_page", perPage.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        return await GetResponseAsync<Items>(parameters, cancellationToken);
    }

    async Task<Items> IFlickrActivity.UserPhotosAsync(int timePeriod, TimeType timeType, int page, int perPage, CancellationToken cancellationToken)
    {
        if (timePeriod == 0)
        {
            throw new ArgumentOutOfRangeException(nameof(timePeriod), "Time Period should be greater than 0");
        }

        ArgumentNullException.ThrowIfNull(timeType, nameof(timeType));
        var timeframe = timePeriod + timeType == TimeType.Days ? "d" : "h";

        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.activity.userPhotos" }
        };

        if (timeframe != null && timeframe.Length > 0)
        {
            parameters.Add("timeframe", timeframe);
        }

        if (page > 0)
        {
            parameters.Add("page", page.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        if (perPage > 0)
        {
            parameters.Add("per_page", perPage.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        return await GetResponseAsync<Items>(parameters, cancellationToken);
    }
}

/// <summary>
/// The flickr activity.
/// </summary>
public interface IFlickrActivity
{
    /// <summary>
    /// Returns a list of recent activity on photos commented on by the calling user.
    /// </summary>
    /// <remarks><b>Do not poll this method more than once an hour.</b></remarks>
    /// <param name="page">The page of the activity to return.</param>
    /// <param name="perPage">The number of activities to return per page.</param>
    /// <param name="cancellationToken"></param>
    Task<Items> UserCommentsAsync(int page = 0, int perPage = 0, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns a list of recent activity on photos belonging to the calling user.
    /// </summary>
    /// <remarks><b>Do not poll this method more than once an hour.</b></remarks>
    /// <param name="timePeriod">The number of days or hours you want to get activity for.</param>
    /// <param name="timeType">'d' for days, 'h' for hours.</param>
    /// <param name="page">The page numver of the activity to return.</param>
    /// <param name="perPage">The number of activities to return per page.</param>
    /// <param name="cancellationToken"></param>
    Task<Items> UserPhotosAsync(int timePeriod, TimeType timeType = TimeType.Hours, int page = 0, int perPage = 0, CancellationToken cancellationToken = default);
}