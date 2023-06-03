using Flickr.Net.Core.Entities.Collections;
using Flickr.Net.Core.Enums;
using Flickr.Net.Core.Internals;
using Flickr.Net.Core.SearchOptions;

namespace Flickr.Net.Core;

// TODO:
public partial class Flickr
{
    /// <summary>
    /// Gets a list of photos from the most recent interstingness list.
    /// </summary>
    /// <param name="date">The date to return the interestingness photos for.</param>
    /// <param name="extras">The extra parameters to return along with the search results.
    /// See <see cref="PhotoSearchOptions"/> for more details.</param>
    /// <param name="perPage">The number of results to return per page.</param>
    /// <param name="page">The page of the results to return.</param>
    public async Task<PhotoCollection> InterestingnessGetListAsync(DateTime? date = null, PhotoSearchExtras extras = PhotoSearchExtras.None, int page = 0, int perPage = 0, CancellationToken cancellationToken = default)
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
            parameters.Add("extras", UtilityMethods.ExtrasToString(extras));
        }

        return await GetResponseAsync<PhotoCollection>(parameters, cancellationToken);
    }
}