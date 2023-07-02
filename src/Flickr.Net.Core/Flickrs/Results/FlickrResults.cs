using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core.Flickrs.Results;

//todo: where T : IFlickrEntity
/// <summary>
/// Contains details of the result from Flickr, or the error if an error occurred.
/// </summary>
/// <typeparam name="T">The type of the result returned from Flickr.</typeparam>
public record FlickrResult<T> : FlickrResult
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
public record FlickrResult
{
    /// <summary>
    /// True if the result returned an error.
    /// </summary>
    public bool HasError => State != "ok" || ErrorCode > 0;

    [JsonProperty("stat")]
    public string State { get; set; } = string.Empty;

    /// <summary>
    /// If an error was returned by the Flickr API then this will contain the error code.
    /// </summary>
    [JsonProperty("code")]
    public int ErrorCode { get; set; } = int.MinValue;

    /// <summary>
    /// If an error was returned by the Flickr API then this will contain the error message.
    /// </summary>
    [JsonProperty("message")]
    public string ErrorMessage { get; set; } = string.Empty;
}

/// <summary>
/// </summary>
/// <typeparam name="TNextPhoto"></typeparam>
/// <typeparam name="TPrevPhoto"></typeparam>
public record FlickrContextResult<TNextPhoto, TPrevPhoto> : FlickrResult where TNextPhoto : IFlickrEntity where TPrevPhoto : IFlickrEntity
{
    /// <summary>
    /// </summary>
    [JsonProperty("count")]
    public Count Count { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyGenericTypeName(0)]
    public TNextPhoto NextPhoto { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyGenericTypeName(1)]
    public TPrevPhoto PrevPhoto { get; set; }
}

public record FlickrAllContextResult<TPrimary, TSecond> : FlickrResult where TPrimary : IFlickrEntity where TSecond : IFlickrEntity
{
    /// <summary>
    /// </summary>
    [JsonPropertyGenericTypeName(0)]
    public List<TPrimary> Primary { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyGenericTypeName(1)]
    public List<TSecond> Second { get; set; }
}

/// <summary>
/// Contains details of the result from Flickr, or the error if an error occurred.
/// </summary>
/// <typeparam name="T">The type of the result returned from Flickr.</typeparam>
public record FlickrUnknownResult<T> : FlickrResult where T : UnknownResponse
{
    /// <summary>
    /// If the call was successful then this contains the result.
    /// </summary>
    [JsonPropertyGenericTypeName(0)]
    public T Content { get; set; }
}

/// <summary>
/// </summary>
/// <typeparam name="T"></typeparam>
public record FlickrStatsResult<T> : FlickrResult<T>
{
    [JsonProperty("period")]
    public string Period { get; set; }

    [JsonProperty("count")]
    public int Count { get; set; }
}

public struct Count
{
    [JsonProperty("_content")]
    public int Content { get; set; }

    public static implicit operator int(Count count) => count.Content;

    public static implicit operator Count(int count) => new() { Content = count };
}