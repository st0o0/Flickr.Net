using Flickr.Net.Core.NewEntities;
using Flickr.Net.Core.NewEntities.Collections;

namespace Flickr.Net.Core;

/// <summary>
/// The flickr.
/// </summary>
public partial class Flickr : IFlickrCameras
{
    async Task<List<Brand>> IFlickrCameras.GetBrandsAsync(CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.cameras.getBrands" }
        };

        return await GetResponseAsync<Brands>(parameters, cancellationToken);
    }

    async Task<List<Camera>> IFlickrCameras.GetBrandModelsAsync(string brandId, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.cameras.getBrandModels" },
            { "brand", brandId }
        };

        return await GetResponseAsync<Cameras>(parameters, cancellationToken);
    }
}

/// <summary>
/// The flickr cameras.
/// </summary>
public interface IFlickrCameras
{
    /// <summary>
    /// Gets a list of camera brands.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<List<Brand>> GetBrandsAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Get a list of camera models for a particular brand id.
    /// </summary>
    /// <param name="brandId">The ID of the brand you want the models of.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<List<Camera>> GetBrandModelsAsync(string brandId, CancellationToken cancellationToken = default);
}