using Flickr.Net.Core.Internals.Extensions;

namespace Flickr.Net.Core;

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

        if (extras != PhotoSearchExtras.None)
        {
            parameters.Add("extras", extras.ToFlickrString());
        }

        if (perPage > 0)
        {
            parameters.Add("per_page", perPage.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        if (page > 0)
        {
            parameters.Add("page", page.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

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