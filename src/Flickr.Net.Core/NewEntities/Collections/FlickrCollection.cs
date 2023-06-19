using Flickr.Net.Core.Internals.Attributes;
using Newtonsoft.Json;

namespace Flickr.Net.Core.NewEntities.Collections;

/// <summary>
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class FlickrCollection<T>
{
    /// <summary>
    /// </summary>
    [JsonPropertyGenericTypeName(0)]
    public List<T> Values { get; set; } = new List<T>();

    /// <summary>
    /// </summary>
    /// <param name="collection"></param>
    public static implicit operator List<T>(FlickrCollection<T> collection) => collection.Values;
}

/// <summary>
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class FlickrPaginationCollection<T> : FlickrCollection<T>
{
    /// <summary>
    /// </summary>
    [JsonProperty("page")]
    public int Page { get; set; }

    /// <summary>
    /// </summary>
    [JsonProperty("pages")]
    public int Pages { get; set; }

    /// <summary>
    /// </summary>
    [JsonProperty("perpage")]
    public int PerPage { get; set; }

    /// <summary>
    /// </summary>
    [JsonProperty("total")]
    public int Total { get; set; }
}

/// <inheritdoc/>
[FlickrJsonPropertyName("blogs")]
public class Blogs : FlickrCollection<Blog>
{ }

/// <inheritdoc/>
[FlickrJsonPropertyName("items")]
public class Items : FlickrCollection<Item>
{ }

/// <inheritdoc/>
[FlickrJsonPropertyName("services")]
public class Services : FlickrCollection<Service>
{ }

/// <inheritdoc/>
[FlickrJsonPropertyName("cameras")]
public class Cameras : FlickrCollection<Camera>
{
    /// <summary>
    /// </summary>
    [JsonProperty("brand")]
    public string Brand { get; set; }
}

/// <inheritdoc/>
[FlickrJsonPropertyName("brands")]
public class Brands : FlickrCollection<Brand>
{ }

/// <inheritdoc/>
[FlickrJsonPropertyName("photo")]
public class Photos : FlickrCollection<Photo>
{
}

/// <inheritdoc/>
[FlickrJsonPropertyName("photo")]
public class PagedPhotos : FlickrPaginationCollection<Photo>
{
}

/// <inheritdoc/>
[FlickrJsonPropertyName("collections")]
public class Collections : FlickrCollection<Collection>
{ }

/// <inheritdoc/>
[FlickrJsonPropertyName("institutions")]
public class Institutions : FlickrCollection<Institution>
{ }

/// <inheritdoc/>
[FlickrJsonPropertyName("urls")]
public class Urls : FlickrCollection<Url>
{ }

/// <inheritdoc/>
[FlickrJsonPropertyName("contacts")]
public class Contacts : FlickrPaginationCollection<Contact>
{ }

/// <inheritdoc/>
[FlickrJsonPropertyName("galleries")]
public class Galleries : FlickrPaginationCollection<Gallery>
{
    /// <summary>
    /// </summary>
    [JsonProperty("user_id")]
    public string UserId { get; set; }
}

/// <inheritdoc/>
[FlickrJsonPropertyName("photos")]
public class GalleryPhotos : FlickrPaginationCollection<GalleryPhoto>
{ }

/// <inheritdoc/>
[FlickrJsonPropertyName("replies")]
public class Replies : FlickrCollection<Reply>
{
    [JsonProperty("topic")]
    public Topic Topic { get; set; }
}