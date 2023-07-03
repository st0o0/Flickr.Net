using Flickr.Net.Core.Flickrs.Results;

namespace Flickr.Net.Core.Exceptions.Handlers;

/// <summary>
/// A handler that is used to generate an exception from the response sent back by Flickr.
/// </summary>
public static class ExceptionHandler
{
    /// <summary>
    /// Creates a <see cref="FlickrApiException"/> from the response sent back from Flickr.
    /// </summary>
    /// The
    /// <see cref="FlickrApiException"/>
    /// created from the information returned by Flickr.
    /// <returns></returns>
    public static Exception CreateResponseException(FlickrResult result) => CreateException(result.ErrorCode, result.ErrorMessage);

    private static FlickrApiException CreateException(int code, string message) => code switch
    {
        96 => new InvalidSignatureException(message),
        97 => new MissingSignatureException(message),
        98 => new LoginFailedInvalidTokenException(message),
        99 => new UserNotLoggedInInsufficientPermissionsException(message),
        100 => new InvalidApiKeyException(message),
        105 or 0 => new ServiceUnavailableException(message),
        111 => new FormatNotFoundException(message),
        112 => new MethodNotFoundException(message),
        116 => new BadUrlFoundException(message),
        114 or 115 => new FlickrApiException(code, message),
        _ => CreateExceptionFromMessage(code, message),
    };

    private static FlickrApiException CreateExceptionFromMessage(int code, string message) => message switch
    {
        "Photo not found" or "Photo not found." => new PhotoNotFoundException(code, message),
        "Photoset not found" or "Photoset not found." => new PhotosetNotFoundException(code, message),
        "Permission Denied" => new PermissionDeniedException(code, message),
        "User not found" or "User not found." => new UserNotFoundException(code, message),
        _ or "" => new FlickrApiException(code, message)
    };
}