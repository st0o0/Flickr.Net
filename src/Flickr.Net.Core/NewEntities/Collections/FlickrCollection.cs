using Flickr.Net.Core.Internals.Attributes;
using Flickr.Net.Core.NewEntities.Flickr_Photos;
using Newtonsoft.Json;

namespace Flickr.Net.Core;

/// <summary>
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract record FlickrCollection<T>
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
public abstract record FlickrPaginationCollection<T> : FlickrCollection<T>
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
public record Blogs : FlickrCollection<Blog>
{ }

/// <inheritdoc/>
[FlickrJsonPropertyName("items")]
public record Items : FlickrCollection<Item>
{ }

/// <inheritdoc/>
[FlickrJsonPropertyName("services")]
public record Services : FlickrCollection<Service>
{ }

/// <inheritdoc/>
[FlickrJsonPropertyName("cameras")]
public record Cameras : FlickrCollection<Camera>
{
    /// <summary>
    /// </summary>
    [JsonProperty("brand")]
    public string Brand { get; set; }
}

/// <inheritdoc/>
[FlickrJsonPropertyName("brands")]
public record Brands : FlickrCollection<Brand>
{ }

/// <inheritdoc/>
[FlickrJsonPropertyName("photo")]
public record Photos : FlickrCollection<Photo>
{
}

/// <inheritdoc/>
[FlickrJsonPropertyName("iconphotos")]
public record IconPhotos : FlickrCollection<IconPhoto>
{
}

/// <inheritdoc/>
[FlickrJsonPropertyName("photo")]
public record PagedPhotos : FlickrPaginationCollection<Photo>
{
}

/// <inheritdoc/>
[FlickrJsonPropertyName("collections")]
public record Collections : FlickrCollection<Collection>
{ }

/// <inheritdoc/>
[FlickrJsonPropertyName("institutions")]
public record Institutions : FlickrCollection<Institution>
{ }

/// <inheritdoc/>
[FlickrJsonPropertyName("urls")]
public record Urls : FlickrCollection<Url>
{ }

/// <inheritdoc/>
[FlickrJsonPropertyName("contacts")]
public record Contacts : FlickrPaginationCollection<Contact>
{ }

/// <inheritdoc/>
[FlickrJsonPropertyName("galleries")]
public record Galleries : FlickrPaginationCollection<Gallery>
{
    /// <summary>
    /// </summary>
    [JsonProperty("user_id")]
    public string UserId { get; set; }
}

/// <inheritdoc/>
[FlickrJsonPropertyName("photos")]
public record GalleryPhotos : FlickrPaginationCollection<GalleryPhoto>
{ }

/// <inheritdoc/>
[FlickrJsonPropertyName("replies")]
public record Replies : FlickrCollection<Reply>
{
    [JsonProperty("topic")]
    public Topic Topic { get; set; }
}

/// <inheritdoc/>
[FlickrJsonPropertyName("topics")]
public record Topics : FlickrPaginationCollection<Topic>
{
    [JsonProperty("group_id")]
    public string GroupId { get; set; }

    [JsonProperty("iconserver")]
    public string IconServer { get; set; }

    [JsonProperty("iconfarm")]
    public string IconFarm { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("members")]
    public int Members { get; set; }

    [JsonProperty("privacy")]
    public PoolPrivacy Privacy { get; set; }

    [JsonProperty("lang")]
    public string Lang { get; set; }

    [JsonProperty("ispoolmoderated")]
    public bool IsPoolModerated { get; set; }

    [JsonIgnore]
    public string GroupIconUrl => UtilityMethods.BuddyIcon(IconServer, IconFarm, GroupId);
}

/// <inheritdoc/>
[FlickrJsonPropertyName("groups")]
public record Groups : FlickrPaginationCollection<Group>
{ }

/// <inheritdoc/>
//[FlickrJsonPropertyName("groups")]
//public class GroupSearchResults : FlickrPaginationCollection<GroupSearchResult>
//{ }

/// <inheritdoc/>
[FlickrJsonPropertyName("members")]
public record Members : FlickrPaginationCollection<Member>
{ }

/// <inheritdoc/>
[FlickrJsonPropertyName("namespaces")]
public record Namespaces : FlickrPaginationCollection<Namespace>
{ }

/// <inheritdoc/>
[FlickrJsonPropertyName("pairs")]
public record Pairs : FlickrPaginationCollection<Pair>
{ }

/// <inheritdoc/>
[FlickrJsonPropertyName("predicates")]
public record Predicates : FlickrPaginationCollection<Predicate>
{ }

/// <inheritdoc/>
[FlickrJsonPropertyName("values")]
public record Values : FlickrPaginationCollection<Value>
{
    [JsonProperty("namespace")]
    public string Namespace { get; set; }

    [JsonProperty("predicate")]
    public string Predicate { get; set; }
}

/// <inheritdoc/>
[FlickrJsonPropertyName("pandas")]
public record Pandas : FlickrCollection<Panda>
{ }

/// <inheritdoc/>
[FlickrJsonPropertyName("photos")]
public record PandaPhotos : FlickrCollection<PandaPhoto>
{
    [JsonProperty("interval")]
    public int Interval { get; set; }

    [JsonProperty("lastupdate")]
    public DateTime LastUpdate { get; set; }

    [JsonProperty("total")]
    public int Total { get; set; }

    [JsonProperty("panda")]
    public string Panda { get; set; }
}

/// <inheritdoc/>
[FlickrJsonPropertyName("set")]
public record Sets : FlickrCollection<Set>
{ }

/// <inheritdoc/>
[FlickrJsonPropertyName("pool")]
public record Pools : FlickrCollection<Pool>
{ }

/// <inheritdoc/>
[FlickrJsonPropertyName("photocounts")]
public record PhotoCounts : FlickrCollection<PhotoCount>
{ }