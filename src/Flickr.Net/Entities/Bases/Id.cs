using Flickr.Net.Internals.Attributes;

namespace Flickr.Net.Bases;

/// <summary>
/// </summary>
public interface IIdentifierType;

/// <inheritdoc/>
public abstract record IdentifierType : IIdentifierType
{
    /// <summary>
    /// </summary>
    protected string _id;

    /// <summary>
    /// </summary>
    public static implicit operator string(IdentifierType value) => value._id;

    /// <summary>
    /// </summary>
    public static implicit operator IdentifierType(string value) => new Id { _id = value };
}

/// <inheritdoc/>
[FlickrJsonPropertyName("id")]
public record Id : IdentifierType
{
    /// <summary>
    /// </summary>
    public static implicit operator string(Id value) => value._id;

    /// <summary>
    /// </summary>
    public static implicit operator Id(string value) => new() { _id = value };
}

/// <inheritdoc/>
[FlickrJsonPropertyName("nsid")]
public record NsId : IdentifierType
{
    /// <summary>
    /// </summary>
    public static implicit operator string(NsId value) => value._id;

    /// <summary>
    /// </summary>
    public static implicit operator NsId(string value) => new() { _id = value };
}

/// <inheritdoc/>
[FlickrJsonPropertyName("photo_id")]
public record PhotoId : IdentifierType
{
    /// <summary>
    /// </summary>
    public static implicit operator string(PhotoId value) => value._id;

    /// <summary>
    /// </summary>
    public static implicit operator PhotoId(string value) => new() { _id = value };
}

/// <inheritdoc/>
[FlickrJsonPropertyName("photoset_id")]
public record PhotosetId : IdentifierType
{
    /// <summary>
    /// </summary>
    public static implicit operator string(PhotosetId value) => value._id;

    /// <summary>
    /// </summary>
    public static implicit operator PhotosetId(string value) => new() { _id = value };
}