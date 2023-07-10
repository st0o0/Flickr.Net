using Flickr.Net.Core.Internals.Extensions;

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

        parameters.AppendIf("per_page", perPage, x => x > 0, x => x.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));

        parameters.AppendIf("page", page, x => x > 0, x => x.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));

        return await GetResponseAsync<Items>(parameters, cancellationToken);
    }

    async Task<Items> IFlickrActivity.UserPhotosAsync(int timePeriod, TimeType timeType, int page, int perPage, CancellationToken cancellationToken)
    {
        if (timePeriod == 0)
        {
            throw new ArgumentOutOfRangeException(nameof(timePeriod), "Time Period should be greater than 0");
        }

        ArgumentNullException.ThrowIfNull(timeType, nameof(timeType));

        var timeframe = timePeriod + timeType.GetEnumMemberValue();

        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.activity.userPhotos" }
        };

        parameters.AppendIf("timeframe", timeframe, x => x != null && x.Length > 0, x => x);

        parameters.AppendIf("per_page", perPage, x => x > 0, x => x.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));

        parameters.AppendIf("page", page, x => x > 0, x => x.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));

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