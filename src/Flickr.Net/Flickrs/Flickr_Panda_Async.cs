using Flickr.Net.Enums;
using Flickr.Net.Internals.Extensions;

namespace Flickr.Net;

/// <summary>
/// The flickr.
/// </summary>
public partial class Flickr : IFlickrPanda
{
    async Task<Pandas> IFlickrPanda.GetListAsync(CancellationToken cancellationToken)

    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.panda.getList" }
        };

        return await GetResponseAsync<Pandas>(parameters, cancellationToken);
    }

    async Task<PandaPhotos> IFlickrPanda.GetPhotosAsync(string pandaName, PhotoSearchExtras extras, int page, int perPage, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.panda.getPhotos" },
            { "panda_name", pandaName }
        };

        parameters.AppendIf("per_page", perPage, x => x > 0, x => x.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));

        parameters.AppendIf("page", page, x => x > 0, x => x.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));

        parameters.AppendIf("extras", extras, x => x != PhotoSearchExtras.None, x => x.ToFlickrString());

        return await GetResponseAsync<PandaPhotos>(parameters, cancellationToken);
    }
}

/// <summary>
/// The flickr panda.
/// </summary>
public interface IFlickrPanda
{
    /// <summary>
    /// Get a list of current 'Pandas' supported by Flickr.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>An array of panda names.</returns>
    Task<Pandas> GetListAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a list of photos for the given panda.
    /// </summary>
    /// <param name="pandaName">The name of the panda to return photos for.</param>
    /// <param name="extras">The extras to return with the photos.</param>
    /// <param name="page">The age to return.</param>
    /// <param name="perPage">The number of photos to return per page.</param>
    /// <param name="cancellationToken"></param>
    Task<PandaPhotos> GetPhotosAsync(string pandaName, PhotoSearchExtras extras = PhotoSearchExtras.None, int page = 0, int perPage = 0, CancellationToken cancellationToken = default);
}