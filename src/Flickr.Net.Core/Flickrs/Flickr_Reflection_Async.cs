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

    async Task<Methods> IFlickrReflection.GetMethodsAsync(CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.reflection.getMethods" }
        };

        return await GetResponseAsync<Methods>(parameters, cancellationToken);
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
    /// <param name="cancellationToken"></param>
    /// <remarks>Note: Not all methods might be supported by the FlickrNet Library.</remarks>
    Task<Methods> GetMethodsAsync(CancellationToken cancellationToken = default);
}