using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core.Bases;

/// <summary>
/// </summary>
public interface IIdentifierType
{
    /// <summary>
    /// </summary>
    string Id { get; }
}

/// <summary>
/// </summary>
public abstract record IdentifierType : IIdentifierType
{
    /// <inheritdoc/>
    public string Id { get; init; }

    /// <summary>
    /// </summary>
    public static implicit operator string(IdentifierType value) => value.Id;

    /// <summary>
    /// </summary>
    public static implicit operator IdentifierType(string value) => new Id() { Id = value };
}

/// <summary>
/// </summary>
[FlickrJsonPropertyName("id")]
public record Id : IdentifierType
{
    /// <summary>
    /// </summary>
    public static implicit operator string(Id value) => value.Id;

    /// <summary>
    /// </summary>
    public static implicit operator Id(string value) => new() { Id = value };
}

/// <summary>
/// </summary>
[FlickrJsonPropertyName("nsid")]
public record NsId : IdentifierType
{
    /// <summary>
    /// </summary>
    public static implicit operator string(NsId value) => value.Id;

    /// <summary>
    /// </summary>
    public static implicit operator NsId(string value) => new() { Id = value };
}

/// <summary>
/// </summary>
[FlickrJsonPropertyName("photo_id")]
public record PhotoId : IdentifierType
{
    /// <summary>
    /// </summary>
    public static implicit operator string(PhotoId value) => value.Id;

    /// <summary>
    /// </summary>
    public static implicit operator PhotoId(string value) => new() { Id = value };
}

/// <summary>
/// </summary>
[FlickrJsonPropertyName("photoset_id")]
public record PhotosetId : IdentifierType
{
    /// <summary>
    /// </summary>
    public static implicit operator string(PhotosetId value) => value.Id;

    /// <summary>
    /// </summary>
    public static implicit operator PhotosetId(string value) => new() { Id = value };
}