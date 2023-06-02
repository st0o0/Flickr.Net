using Flickr.Net.Core.Entities.Collections;

namespace Flickr.Net.Core;

// TODO:
public partial class Flickr
{
    /// <summary>
    /// Gets an array of supported method names for Flickr.
    /// </summary>
    /// <remarks>
    /// Note: Not all methods might be supported by the FlickrNet Library.</remarks>
    public async Task<MethodCollection> ReflectionGetMethodsAsync(CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.reflection.getMethods" }
        };

        return await GetResponseAsync<MethodCollection>(parameters, cancellationToken);
    }

    /// <summary>
    /// Gets the method details for a given method.
    /// </summary>
    /// <param name="methodName">The name of the method to retrieve.</param>
    public async Task<Method> ReflectionGetMethodInfoAsync(string methodName, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.reflection.getMethodInfo" },
            { "api_key", ApiKey },
            { "method_name", methodName }
        };

        return await GetResponseAsync<Method>(parameters, cancellationToken);
    }
}