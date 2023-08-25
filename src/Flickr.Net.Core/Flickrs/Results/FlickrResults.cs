using System.Text.Json;
using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;
using Newtonsoft.Json.Linq;

namespace Flickr.Net.Core.Flickrs.Results;

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
    public T Content { get; set; }
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
    public virtual string State { get; set; } = string.Empty;

    /// <summary>
    /// If an error was returned by the Flickr API then this will contain the error code.
    /// </summary>
    [JsonPropertyName("code")]
    public int ErrorCode { get; set; } = int.MinValue;

    /// <summary>
    /// If an error was returned by the Flickr API then this will contain the error message.
    /// </summary>
    [JsonPropertyName("message")]
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
    [JsonPropertyName("count")]
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

/// <summary>
/// </summary>
/// <typeparam name="TPrimary"></typeparam>
/// <typeparam name="TSecond"></typeparam>
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
public record FlickrStatsResult<T> : FlickrResult<T> where T : IFlickrEntity
{
    [JsonPropertyName("period")]
    public string Period { get; set; }

    [JsonPropertyName("count")]
    public int Count { get; set; }
}

/// <summary>
/// </summary>
public record FlickrExtendedDataResult : FlickrResult
{
    [JsonPropertyName("@stat")]
    public override string State { get; set; } = string.Empty;

    [System.Text.Json.Serialization.JsonExtensionData]
    public IDictionary<string, JsonElement> Content { get; set; }
}

public struct Count
{
    [JsonPropertyName("_content")]
    public int Content { get; set; }

    public static implicit operator int(Count count) => count.Content;

    public static implicit operator Count(int count) => new() { Content = count };
}