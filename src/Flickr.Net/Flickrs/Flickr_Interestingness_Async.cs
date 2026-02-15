using System.Globalization;
using Flickr.Net.Enums;
using Flickr.Net.Internals.Extensions;

namespace Flickr.Net;

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

        parameters.AppendIf("date", date, x => x.HasValue && x > DateTime.MinValue, x => x.Value.ToString("yyyy-MM-dd", DateTimeFormatInfo.InvariantInfo));

        parameters.AppendIf("per_page", perPage, x => x > 0, x => x.ToString(NumberFormatInfo.InvariantInfo));

        parameters.AppendIf("page", page, x => x > 0, x => x.ToString(NumberFormatInfo.InvariantInfo));

        parameters.AppendIf("extras", extras, x => x != PhotoSearchExtras.None, x => x.ToFlickrString());

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