namespace Flickr.Net.Exceptions;

/// <summary>
/// Error: 96: Invalid signature
/// </summary>
/// <remarks>The passed signature was invalid.</remarks>
public sealed class InvalidSignatureException : FlickrApiException
{
    internal InvalidSignatureException(string message) : base(96, message)
    { }
}