using Flickr.Net.Core.Internals.Extensions;

namespace Flickr.Net.Core;

/// <summary>
/// The flickr.
/// </summary>
public partial class Flickr : IFlickrInterestingness
{
    async Task<PagedPhotos> IFlickrInterestingness.GetListAsync(DateTime? date, PhotoSearchExtras extras, int page, int perPage, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.interestingness.getList" }
        };

        if (date.HasValue && date > DateTime.MinValue)
        {
            parameters.Add("date", date.Value.ToString("yyyy-MM-dd", System.Globalization.DateTimeFormatInfo.InvariantInfo));
        }

        if (perPage > 0)
        {
            parameters.Add("per_page", perPage.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        if (page > 0)
        {
            parameters.Add("page", page.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        if (extras != PhotoSearchExtras.None)
        {
            parameters.Add("extras", extras.ToFlickrString());
        }

        return await GetResponseAsync<PagedPhotos>(parameters, cancellationToken);
    }
}

/// <summary>
/// The flickr interestingness.
/// </summary>
public interface IFlickrInterestingness
{
    /// <summary>
    /// Gets a list of photos from the most recent interstingness list.
    /// </summary>
    /// <param name="date">The date to return the interestingness photos for.</param>
    /// <param name="extras">
    /// The extra parameters to return along with the search results. See <see
    /// cref="PhotoSearchOptions"/> for more details.
    /// </param>
    /// <param name="page">The page of the results to return.</param>
    /// <param name="perPage">The number of results to return per page.</param>
    /// <param name="cancellationToken"></param>
    Task<PagedPhotos> GetListAsync(DateTime? date, PhotoSearchExtras extras, int page, int perPage, CancellationToken cancellationToken);
}