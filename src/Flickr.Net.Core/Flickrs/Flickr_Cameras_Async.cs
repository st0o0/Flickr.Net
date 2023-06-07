namespace Flickr.Net.Core;

/// <summary>
/// The flickr.
/// </summary>
public partial class Flickr : IFlickrCameras
{
    async Task<BrandCollection> IFlickrCameras.GetBrandsAsync(CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.cameras.getBrands" }
        };

        return await GetResponseAsync<BrandCollection>(parameters, cancellationToken);
    }

    async Task<CameraCollection> IFlickrCameras.GetBrandModelsAsync(string brandId, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.cameras.getBrandModels" },
            { "brand", brandId }
        };

        return await GetResponseAsync<CameraCollection>(parameters, cancellationToken);
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
    /// <returns></returns>
    Task<BrandCollection> GetBrandsAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Get a list of camera models for a particular brand id.
    /// </summary>
    /// <param name="brandId">The ID of the brand you want the models of.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<CameraCollection> GetBrandModelsAsync(string brandId, CancellationToken cancellationToken = default);
}