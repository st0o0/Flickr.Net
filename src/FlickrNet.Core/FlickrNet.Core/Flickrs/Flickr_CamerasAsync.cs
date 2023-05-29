namespace FlickrNet.Core;

public partial class Flickr
{
    /// <summary>
    /// Gets a list of camera brands.
    /// </summary>
    /// <returns></returns>
    public async Task<BrandCollection> CamerasGetBrandsAsync(CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new() { { "method", "flickr.cameras.getBrands" } };
        return await GetResponseAsync<BrandCollection>(parameters, cancellationToken);
    }

    /// <summary>
    /// Get a list of camera models for a particular brand id.
    /// </summary>
    /// <param name="brandId">The ID of the brand you want the models of.</param>
    /// <returns></returns>
    public async Task<CameraCollection> CamerasGetBrandModelsAsync(string brandId, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            {"method", "flickr.cameras.getBrandModels"},
            { "brand", brandId}
    };

        return await GetResponseAsync<CameraCollection>(parameters, cancellationToken);
    }
}