using Flickr.Net.Internals.Attributes;

namespace Flickr.Net.Bases;
/// <summary>Marker interface for Flickr entity identifier types.</summary>
public interface IIdentifierType;

/// <inheritdoc/>
public abstract record IdentifierType : IIdentifierType
{    protected string _id = string.Empty;
    /// <summary>Converts to the underlying string value.</summary>
    public static implicit operator string(IdentifierType value) => value._id;
    /// <summary>Converts from a string value.</summary>
    public static implicit operator IdentifierType(string value) => new Id { _id = value };
}

/// <inheritdoc/>
[FlickrJsonPropertyName("id")]
public record Id : IdentifierType
{    public static implicit operator string(Id value) => value._id;
    /// <summary>Converts from a string value.</summary>
    public static implicit operator Id(string value) => new() { _id = value };
}

/// <inheritdoc/>
[FlickrJsonPropertyName("nsid")]
public record NsId : IdentifierType
{    public static implicit operator string(NsId value) => value._id;
    /// <summary>Converts from a string value.</summary>
    public static implicit operator NsId(string value) => new() { _id = value };
}

/// <inheritdoc/>
[FlickrJsonPropertyName("photo_id")]
public record PhotoId : IdentifierType
{    public static implicit operator string(PhotoId value) => value._id;
    /// <summary>Converts from a string value.</summary>
    public static implicit operator PhotoId(string value) => new() { _id = value };
}

/// <inheritdoc/>
[FlickrJsonPropertyName("photoset_id")]
public record PhotosetId : IdentifierType
{    public static implicit operator string(PhotosetId value) => value._id;
    /// <summary>Converts from a string value.</summary>
    public static implicit operator PhotosetId(string value) => new() { _id = value };
}
