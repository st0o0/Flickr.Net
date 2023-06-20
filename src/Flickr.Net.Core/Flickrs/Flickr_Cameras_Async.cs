namespace Flickr.Net.Core;

/// <summary>
/// The flickr.
/// </summary>
public partial class Flickr : IFlickrCameras
{
    async Task<Brands> IFlickrCameras.GetBrandsAsync(CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.cameras.getBrands" }
        };

        return await GetResponseAsync<Brands>(parameters, cancellationToken);
    }

    async Task<Cameras> IFlickrCameras.GetBrandModelsAsync(string brandId, CancellationToken cancellationToken)
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
    Task<Brands> GetBrandsAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Get a list of camera models for a particular brand id.
    /// </summary>
    /// <param name="brandId">The ID of the brand you want the models of.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Cameras> GetBrandModelsAsync(string brandId, CancellationToken cancellationToken = default);
}