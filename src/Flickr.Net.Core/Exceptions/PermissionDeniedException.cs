﻿namespace Flickr.Net.Core.Exceptions;

/// <summary>
/// Error: Permission Denied.
/// </summary>
/// <remarks>The owner of the photo does not want to share the data wih you.</remarks>
public class PermissionDeniedException : FlickrApiException
{
    internal PermissionDeniedException(int code, string message) : base(code, message)
    { }
}