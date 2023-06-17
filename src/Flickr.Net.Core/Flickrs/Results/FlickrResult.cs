using Flickr.Net.Core.Exceptions;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core.Flickrs.Results;

/// <summary>
/// Contains details of the result from Flickr, or the error if an error occurred.
/// </summary>
/// <typeparam name="T">The type of the result returned from Flickr.</typeparam>
public class FlickrResult<T> : FlickrResult
{
    /// <summary>
    /// If the call was successful then this contains the result.
    /// </summary>
    [JsonPropertyGenericTypeName(0)]
    public T Content { get; set; }
}

/// <summary>
/// The flickr result.
/// </summary>
public class FlickrResult
{
    private Exception _exception;

    /// <summary>
    /// True if the result returned an error.
    /// </summary>
    public bool HasError { get; set; }

    /// <summary>
    /// If the call was unsuccessful then this contains the exception.
    /// </summary>
    public Exception Error
    {
        get
        {
            return _exception;
        }
        set
        {
            _exception = value;
            if (value == null)
            {
                HasError = false;
                return;
            }
            HasError = true;
            if (value is FlickrApiException flickrApiException)
            {
                ErrorCode = flickrApiException.Code;
                ErrorMessage = flickrApiException.OriginalMessage;
            }
        }
    }

    /// <summary>
    /// If an error was returned by the Flickr API then this will contain the error code.
    /// </summary>
    public int ErrorCode { get; set; }

    /// <summary>
    /// If an error was returned by the Flickr API then this will contain the error message.
    /// </summary>
    public string ErrorMessage { get; set; }
}