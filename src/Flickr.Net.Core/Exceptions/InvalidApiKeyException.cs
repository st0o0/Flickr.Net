﻿namespace Flickr.Net.Core.Exceptions;

/// <summary>
/// Error: 100: Invalid API Key
/// </summary>
/// <remarks>The API key passed was not valid or has expired.</remarks>
public class InvalidApiKeyException : FlickrApiException
{
    internal InvalidApiKeyException(string message)
        : base(100, message)
    {
    }
}