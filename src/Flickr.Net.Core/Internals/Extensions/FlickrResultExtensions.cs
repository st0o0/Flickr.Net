using Flickr.Net.Core.Exceptions.Handlers;
using Flickr.Net.Core.Flickrs.Results;

namespace Flickr.Net.Core.Internals.Extensions;

public static class FlickrResultExtensions
{
    public static T EnsureSuccessStatusCode<T>(this T flickrResult) where T : FlickrResult
    {
        if (flickrResult.HasError)
        {
            throw ExceptionHandler.CreateResponseException(flickrResult);
        }

        return flickrResult;
    }
}
