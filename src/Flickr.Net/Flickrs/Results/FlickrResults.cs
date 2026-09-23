using System.Text.Json;
using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Internals.Attributes;

namespace Flickr.Net.Flickrs.Results;

/// <summary>
/// Contains details of the result from Flickr, or the error if an error occurred.
/// </summary>
/// <typeparam name="T">The type of the result returned from Flickr.</typeparam>
public record FlickrResult<T> : FlickrResult where T : IFlickrEntity
{
    /// <summary>
    /// If the call was successful then this contains the result.
    /// </summary>
    [JsonPropertyGenericTypeName(0)]
    public T? Content { get; init; }
}

/// <summary>
/// The flickr result.
/// </summary>
public record FlickrResult : IFlickrEntity
{
    /// <summary>
    /// True if the result returned an error.
    /// </summary>
    public bool HasError => State != "ok" || ErrorCode > 0;
    [JsonPropertyName("stat")]
    /// <summary>The response status.</summary>
    public virtual string State { get; init; } = string.Empty;

    /// <summary>
    /// If an error was returned by the Flickr API then this will contain the error code.
    /// </summary>
    [JsonPropertyName("code")]
    public int ErrorCode { get; init; } = int.MinValue;

    /// <summary>
    /// If an error was returned by the Flickr API then this will contain the error message.
    /// </summary>
    [JsonPropertyName("message")]
    public string ErrorMessage { get; init; } = string.Empty;
}
/// <typeparam name="TNextPhoto"></typeparam>
/// <typeparam name="TPrevPhoto"></typeparam>
public record FlickrContextResult<TNextPhoto, TPrevPhoto> : FlickrResult where TNextPhoto : IFlickrEntity where TPrevPhoto : IFlickrEntity
{
    [JsonPropertyName("count")]
    /// <summary>The count.</summary>
    public Count Count { get; init; }
    [JsonPropertyGenericTypeName(0)]
    /// <summary>The next photo in the context.</summary>
    public TNextPhoto? NextPhoto { get; init; }
    [JsonPropertyGenericTypeName(1)]
    /// <summary>The previous photo in the context.</summary>
    public TPrevPhoto? PrevPhoto { get; init; }
}
/// <typeparam name="TPrimary"></typeparam>
/// <typeparam name="TSecond"></typeparam>
public record FlickrAllContextResult<TPrimary, TSecond> : FlickrResult where TPrimary : IFlickrEntity where TSecond : IFlickrEntity
{
    [JsonPropertyGenericTypeName(0)]
    /// <summary>The primary photo identifier.</summary>
    public List<TPrimary> Primary { get; init; } = [];
    [JsonPropertyGenericTypeName(1)]
    /// <summary>The secondary items.</summary>
    public List<TSecond> Second { get; init; } = [];
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
    public T? Content { get; init; }
}
/// <typeparam name="T"></typeparam>
public record FlickrStatsResult<T> : FlickrResult<T> where T : IFlickrEntity
{
    [JsonPropertyName("period")]
    /// <summary>The stats period.</summary>
    public string? Period { get; init; }
    [JsonPropertyName("count")]
    /// <summary>The count.</summary>
    public int Count { get; init; }
}
/// <summary>Result type for Flickr API responses with dynamic/unknown content structure.</summary>
public record FlickrExtendedDataResult : FlickrResult
{
    [JsonPropertyName("@stat")]
    /// <summary>The response status.</summary>
    public override string State { get; init; } = string.Empty;
    [JsonExtensionData]
    /// <summary>The text content.</summary>
    public IDictionary<string, JsonElement> Content { get; init; } = new Dictionary<string, JsonElement>();
}
