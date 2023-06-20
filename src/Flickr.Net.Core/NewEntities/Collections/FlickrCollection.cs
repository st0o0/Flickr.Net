using Flickr.Net.Core.Internals.Attributes;
using Flickr.Net.Core.Internals.JsonConverters;
using Flickr.Net.Core.NewEntities;
using Flickr.Net.Core.NewEntities.Flickr_Blog;
using Flickr.Net.Core.NewEntities.Flickr_Collections;
using Newtonsoft.Json;
using Member = Flickr.Net.Core.NewEntities.Member;
using Photo = Flickr.Net.Core.NewEntities.Photo;
using Predicate = Flickr.Net.Core.NewEntities.Predicate;
using Value = Flickr.Net.Core.NewEntities.Value;

namespace Flickr.Net.Core;

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
[FlickrJsonPropertyName("iconphotos")]
public class IconPhotos : FlickrCollection<IconPhoto>
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

/// <inheritdoc/>
[FlickrJsonPropertyName("topics")]
public class Topics : FlickrPaginationCollection<Topic>
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
    [JsonConverter(typeof(BoolConverter))]
    public bool IsPoolModerated { get; set; }

    [JsonIgnore]
    public string GroupIconUrl => UtilityMethods.BuddyIcon(IconServer, IconFarm, GroupId);
}

/// <inheritdoc/>
[FlickrJsonPropertyName("groups")]
public class Groups : FlickrPaginationCollection<Group>
{ }

/// <inheritdoc/>
//[FlickrJsonPropertyName("groups")]
//public class GroupSearchResults : FlickrPaginationCollection<GroupSearchResult>
//{ }

/// <inheritdoc/>
[FlickrJsonPropertyName("members")]
public class Members : FlickrPaginationCollection<Member>
{ }

/// <inheritdoc/>
[FlickrJsonPropertyName("namespaces")]
public class Namespaces : FlickrPaginationCollection<Namespace>
{ }

/// <inheritdoc/>
[FlickrJsonPropertyName("pairs")]
public class Pairs : FlickrPaginationCollection<Pair>
{ }

/// <inheritdoc/>
[FlickrJsonPropertyName("predicates")]
public class Predicates : FlickrPaginationCollection<Predicate>
{ }

/// <inheritdoc/>
[FlickrJsonPropertyName("values")]
public class Values : FlickrPaginationCollection<Value>
{
    [JsonProperty("namespace")]
    public string Namespace { get; set; }

    [JsonProperty("predicate")]
    public string Predicate { get; set; }
}

/// <inheritdoc/>
[FlickrJsonPropertyName("pandas")]
public class Pandas : FlickrCollection<Panda>
{ }

/// <inheritdoc/>
[FlickrJsonPropertyName("photos")]
public class PandaPhotos : FlickrCollection<PandaPhoto>
{
    [JsonProperty("interval")]
    public int Interval { get; set; }

    [JsonProperty("lastupdate")]
    [JsonConverter(typeof(TimestampToDateTimeConverter))]
    public DateTime LastUpdate { get; set; }

    [JsonProperty("total")]
    public int Total { get; set; }

    [JsonProperty("panda")]
    public string Panda { get; set; }
}