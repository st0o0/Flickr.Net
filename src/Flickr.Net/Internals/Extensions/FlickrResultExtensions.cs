using Flickr.Net.Exceptions.Handlers;
using Flickr.Net.Flickrs.Results;

namespace Flickr.Net.Internals.Extensions;

/// <summary>
/// </summary>
public static class FlickrResultExtensions
{
    /// <summary>
    /// </summary>
    public static T EnsureSuccessStatusCode<T>(this T flickrResult) where T : FlickrResult
    {
        if (flickrResult.HasError)
        {
            throw ExceptionHandler.CreateResponseException(flickrResult);
        }

        return flickrResult;
    }
}
