namespace Flickr.Net.Core;

/// <summary>
/// The flickr.
/// </summary>
public partial class Flickr : IFlickrReflection
{
    async Task<Method> IFlickrReflection.GetMethodInfoAsync(string methodName, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.reflection.getMethodInfo" },
            { "method_name", methodName }
        };

        return await GetResponseAsync<Method>(parameters, cancellationToken);
    }

    async Task<MethodCollection> IFlickrReflection.GetMethodsAsync(CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.reflection.getMethods" }
        };

        return await GetResponseAsync<MethodCollection>(parameters, cancellationToken);
    }
}

/// <summary>
/// The flickr reflection.
/// </summary>
public interface IFlickrReflection
{
    /// <summary>
    /// Gets the method details for a given method.
    /// </summary>
    /// <param name="methodName">The name of the method to retrieve.</param>
    /// <param name="cancellationToken"></param>
    Task<Method> GetMethodInfoAsync(string methodName, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets an array of supported method names for Flickr.
    /// </summary>
    /// <remarks>Note: Not all methods might be supported by the FlickrNet Library.</remarks>
    Task<MethodCollection> GetMethodsAsync(CancellationToken cancellationToken = default);
}