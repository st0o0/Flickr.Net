namespace FlickrNet.Core;

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
    public async Task<PandaPhotoCollection> PandaGetPhotosAsync(string pandaName, CancellationToken cancellationToken = default)
    {
        return await PandaGetPhotosAsync(pandaName, PhotoSearchExtras.None, 0, 0, cancellationToken);
    }

    /// <summary>
    /// Gets a list of photos for the given panda.
    /// </summary>
    /// <param name="pandaName">The name of the panda to return photos for.</param>
    /// <param name="extras">The extras to return with the photos.</param>
    public async Task<PandaPhotoCollection> PandaGetPhotosAsync(string pandaName, PhotoSearchExtras extras, CancellationToken cancellationToken = default)
    {
        return await PandaGetPhotosAsync(pandaName, extras, 0, 0, cancellationToken);
    }

    /// <summary>
    /// Gets a list of photos for the given panda.
    /// </summary>
    /// <param name="pandaName">The name of the panda to return photos for.</param>
    /// <param name="perPage">The number of photos to return per page.</param>
    /// <param name="page">The age to return.</param>
    public async Task<PandaPhotoCollection> PandaGetPhotosAsync(string pandaName, int page, int perPage, CancellationToken cancellationToken = default)
    {
        return await PandaGetPhotosAsync(pandaName, PhotoSearchExtras.None, page, perPage, cancellationToken);
    }

    /// <summary>
    /// Gets a list of photos for the given panda.
    /// </summary>
    /// <param name="pandaName">The name of the panda to return photos for.</param>
    /// <param name="extras">The extras to return with the photos.</param>
    /// <param name="perPage">The number of photos to return per page.</param>
    /// <param name="page">The age to return.</param>
    public async Task<PandaPhotoCollection> PandaGetPhotosAsync(string pandaName, PhotoSearchExtras extras, int page, int perPage, CancellationToken cancellationToken = default)
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