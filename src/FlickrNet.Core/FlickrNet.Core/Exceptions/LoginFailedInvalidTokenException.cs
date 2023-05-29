﻿namespace FlickrNet.Core.Exceptions;

/// <summary>
/// Error: 98: Login failed / Invalid auth token
/// </summary>
/// <remarks>
/// The login details or auth token passed were invalid.
/// </remarks>
public class LoginFailedInvalidTokenException : FlickrApiException
{
    internal LoginFailedInvalidTokenException(string message)
        : base(98, message)
    {
    }
}