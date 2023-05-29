namespace FlickrNet.Core;

public partial class Flickr
{
    /// <summary>
    /// Returns a list of recent activity on photos belonging to the calling user.
    /// </summary>
    /// <remarks>
    /// <b>Do not poll this method more than once an hour.</b>
    /// </remarks>
    public async Task<ActivityItemCollection> ActivityUserPhotosAsync(CancellationToken cancellationToken = default)
    {
        return await ActivityUserPhotosAsync(null, 0, 0, cancellationToken);
    }

    /// <summary>
    /// Returns a list of recent activity on photos belonging to the calling user.
    /// </summary>
    /// <remarks>
    /// <b>Do not poll this method more than once an hour.</b>
    /// </remarks>
    /// <param name="page">The page numver of the activity to return.</param>
    /// <param name="perPage">The number of activities to return per page.</param>
    public async Task<ActivityItemCollection> ActivityUserPhotosAsync(int page, int perPage, CancellationToken cancellationToken = default)
    {
        return await ActivityUserPhotosAsync(null, page, perPage, cancellationToken);
    }

    /// <summary>
    /// Returns a list of recent activity on photos belonging to the calling user.
    /// </summary>
    /// <remarks>
    /// <b>Do not poll this method more than once an hour.</b>
    /// </remarks>
    /// <param name="timePeriod">The number of days or hours you want to get activity for.</param>
    /// <param name="timeType">'d' for days, 'h' for hours.</param>
    public async Task<ActivityItemCollection> ActivityUserPhotosAsync(int timePeriod, string timeType, CancellationToken cancellationToken = default)
    {
        return await ActivityUserPhotosAsync(timePeriod, timeType, 0, 0, cancellationToken);
    }

    /// <summary>
    /// Returns a list of recent activity on photos belonging to the calling user.
    /// </summary>
    /// <remarks>
    /// <b>Do not poll this method more than once an hour.</b>
    /// </remarks>
    /// <param name="timePeriod">The number of days or hours you want to get activity for.</param>
    /// <param name="timeType">'d' for days, 'h' for hours.</param>
    /// <param name="page">The page numver of the activity to return.</param>
    /// <param name="perPage">The number of activities to return per page.</param>
    public async Task<ActivityItemCollection> ActivityUserPhotosAsync(int timePeriod, string timeType, int page, int perPage, CancellationToken cancellationToken = default)
    {
        if (timePeriod == 0)
        {
            throw new ArgumentOutOfRangeException(nameof(timePeriod), "Time Period should be greater than 0");
        }

        ArgumentNullException.ThrowIfNull(timeType, nameof(timeType));

        if (timeType != "d" && timeType != "h")
        {
            throw new ArgumentOutOfRangeException(nameof(timeType), "Time type must be 'd' or 'h'");
        }

        return await ActivityUserPhotosAsync(timePeriod + timeType, page, perPage, cancellationToken);
    }

    private async Task<ActivityItemCollection> ActivityUserPhotosAsync(string timeframe, int page, int perPage, CancellationToken cancellationToken = default)
    {
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

        return await GetResponseAsync<ActivityItemCollection>(parameters, cancellationToken);
    }

    /// <summary>
    /// Returns a list of recent activity on photos commented on by the calling user.
    /// </summary>
    /// <remarks>
    /// <b>Do not poll this method more than once an hour.</b>
    /// </remarks>
    /// <param name="page">The page of the activity to return.</param>
    /// <param name="perPage">The number of activities to return per page.</param>
    public async Task<ActivityItemCollection> ActivityUserCommentsAsync(int page, int perPage, CancellationToken cancellationToken = default)
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

        return await GetResponseAsync<ActivityItemCollection>(parameters, cancellationToken);
    }
}