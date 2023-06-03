using Flickr.Net.Core.Entities;
using Flickr.Net.Core.Entities.Collections;
using Flickr.Net.Core.Enums;
using Flickr.Net.Core.Internals;

namespace Flickr.Net.Core;

// TODO:
public partial class Flickr
{
    /// <summary>
    /// Get a list of current 'Pandas' supported by Flickr.
    /// </summary>
    /// <returns>An array of panda names.</returns>
    public async Task<string[]> PandaGetListAsync(CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.panda.getList" }
        };

        UnknownResponse result = await GetResponseAsync<UnknownResponse>(parameters, cancellationToken);
        return result.GetElementArray("panda");
    }

    /// <summary>
    /// Gets a list of photos for the given panda.
    /// </summary>
    /// <param name="pandaName">The name of the panda to return photos for.</param>
    /// <param name="extras">The extras to return with the photos.</param>
    /// <param name="perPage">The number of photos to return per page.</param>
    /// <param name="page">The age to return.</param>
    public async Task<PandaPhotoCollection> PandaGetPhotosAsync(string pandaName, PhotoSearchExtras extras = PhotoSearchExtras.None, int page = 0, int perPage = 0, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.panda.getPhotos" },
            { "panda_name", pandaName }
        };

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

        return await GetResponseAsync<PandaPhotoCollection>(parameters, cancellationToken);
    }
}