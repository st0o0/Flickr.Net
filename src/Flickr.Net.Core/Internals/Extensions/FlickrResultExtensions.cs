using Flickr.Net.Core.Exceptions.Handlers;
using Flickr.Net.Core.Flickrs.Results;

namespace Flickr.Net.Core.Internals.Extensions;

/// <summary>
/// </summary>
public static class FlickrResultExtensions
{
    /// <summary>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="flickrResult"></param>
    /// <returns></returns>
    public static T EnsureSuccessStatusCode<T>(this T flickrResult) where T : FlickrResult
    {
        if (flickrResult.HasError)
        {
            throw ExceptionHandler.CreateResponseException(flickrResult);
        }

        return flickrResult;
    }
}
