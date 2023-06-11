namespace Flickr.Net.Core;

/// <summary>
/// The flickr.
/// </summary>
public partial class Flickr : IFlickrPanda
{
    async Task<string[]> IFlickrPanda.GetListAsync(CancellationToken cancellationToken)

    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.panda.getList" }
        };

        UnknownResponse result = await GetResponseAsync<UnknownResponse>(parameters, cancellationToken);
        return result.GetElementArray("panda");
    }

    async Task<PandaPhotoCollection> IFlickrPanda.GetPhotosAsync(string pandaName, PhotoSearchExtras extras, int page, int perPage, CancellationToken cancellationToken)
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
    Task<string[]> GetListAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a list of photos for the given panda.
    /// </summary>
    /// <param name="pandaName">The name of the panda to return photos for.</param>
    /// <param name="extras">The extras to return with the photos.</param>
    /// <param name="perPage">The number of photos to return per page.</param>
    /// <param name="page">The age to return.</param>
    /// <param name="cancellationToken"></param>
    Task<PandaPhotoCollection> GetPhotosAsync(string pandaName, PhotoSearchExtras extras = PhotoSearchExtras.None, int page = 0, int perPage = 0, CancellationToken cancellationToken = default);
}