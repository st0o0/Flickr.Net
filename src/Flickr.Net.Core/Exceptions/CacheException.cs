namespace FlickrNet.Core.Exceptions;

/// <summary>
/// An internal class used for catching caching exceptions.
/// </summary>
[Serializable]
public class CacheException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CacheException"/> class.
    /// </summary>
    public CacheException()
        : base()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="CacheException"/> class with a specified error message.
    /// </summary>
    /// <param name="message"></param>
    public CacheException(string message)
        : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="CacheException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="innerException"></param>
    public CacheException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
