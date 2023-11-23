using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Internals.Attributes;

namespace Flickr.Net;

/// <summary>
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract record FlickrCollection<T> : FlickrEntityBase where T : IFlickrEntity
{
    /// <summary>
    /// </summary>
    [JsonPropertyGenericTypeName(0)]
    public List<T> Values { get; set; } = [];

    /// <summary>
    /// </summary>
    /// <param name="collection"></param>
    public static implicit operator List<T>(FlickrCollection<T> collection) => collection.Values;
}

/// <summary>
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract record FlickrPaginationCollection<T> : FlickrCollection<T> where T : IFlickrEntity
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("page")]
    public int Page { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("pages")]
    public int Pages { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("perpage")]
    public int PerPage { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("total")]
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
    [JsonPropertyName("brand")]
    public string Brand { get; set; }
}

/// <inheritdoc/>
[FlickrJsonPropertyName("brands")]
public record Brands : FlickrCollection<Brand>
{ }

/// <inheritdoc/>
[FlickrJsonPropertyName("photos")]
public record Photos : FlickrCollection<Photo>
{
}

/// <inheritdoc/>
[FlickrJsonPropertyName("iconphotos")]
public record IconPhotos : FlickrCollection<IconPhoto>
{
}

/// <inheritdoc/>
[FlickrJsonPropertyName("photos")]
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
}

/// <inheritdoc/>
[FlickrJsonPropertyName("galleries")]
public record UserGalleries : Galleries
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("user_id")]
    public string UserId { get; set; }
}

/// <inheritdoc/>
[FlickrJsonPropertyName("galleries")]
public record PhotoGalleries : Galleries
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("photo_id")]
    public string PhotoId { get; set; }
}

/// <inheritdoc/>
[FlickrJsonPropertyName("photos")]
public record GalleryPhotos : FlickrPaginationCollection<GalleryPhoto>
{ }

/// <inheritdoc/>
[FlickrJsonPropertyName("replies")]
public record Replies : FlickrCollection<Reply>
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("topic")]
    public Topic Topic { get; set; }
}

/// <inheritdoc/>
[FlickrJsonPropertyName("topics")]
public record Topics : FlickrPaginationCollection<Topic>
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("group_id")]
    public string GroupId { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("iconserver")]
    public string IconServer { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("iconfarm")]
    public string IconFarm { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("members")]
    public int Members { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("privacy")]
    public PoolPrivacy Privacy { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("lang")]
    public string Lang { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("ispoolmoderated")]
    public bool IsPoolModerated { get; set; }

    /// <summary>
    /// </summary>
    [JsonIgnore]
    public string GroupIconUrl => UtilityMethods.BuddyIcon(IconServer, IconFarm, GroupId);
}

/// <inheritdoc/>
[FlickrJsonPropertyName("groups")]
public record Groups : FlickrPaginationCollection<Group>
{ }

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
    /// <summary>
    /// </summary>
    [JsonPropertyName("namespace")]
    public string Namespace { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("predicate")]
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
    /// <summary>
    /// </summary>
    [JsonPropertyName("interval")]
    public int Interval { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("lastupdate")]
    public DateTime LastUpdate { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("total")]
    public int Total { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("panda")]
    public string Panda { get; set; }
}

/// <inheritdoc/>
[FlickrJsonPropertyName("set")]
public record Sets : FlickrCollection<CollectionSet>
{ }

/// <inheritdoc/>
[FlickrJsonPropertyName("pool")]
public record Pools : FlickrCollection<Pool>
{ }

/// <inheritdoc/>
[FlickrJsonPropertyName("photocounts")]
public record PhotoCounts : FlickrCollection<PhotoCount>
{ }

/// <inheritdoc/>
[FlickrJsonPropertyName("photo")]
public record PhotoPersons : FlickrPaginationCollection<PhotoPerson>
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("secret")]
    public string Secret { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("server")]
    public string Server { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("farm")]
    public int Farm { get; set; }
}

/// <inheritdoc/>
[FlickrJsonPropertyName("notes")]
public record Notes : FlickrCollection<Note>
{ }

/// <inheritdoc/>
[FlickrJsonPropertyName("tags")]
public record PhotoInfoTags : FlickrCollection<PhotoTag>
{ }

/// <inheritdoc/>
[FlickrJsonPropertyName("sizes")]
public record Sizes : FlickrCollection<Size>
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("canblog")]
    public bool CanBlog { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("canprint")]
    public bool CanPrint { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("candownload")]
    public bool CanDownload { get; set; }
}

/// <inheritdoc/>
[FlickrJsonPropertyName("comments")]
public abstract record Comments<T> : FlickrCollection<Comment> where T : IIdentifierType
{
    /// <summary>
    /// </summary>
    [JsonPropertyGenericTypeName(0)]
    public T Id { get; set; }
}

/// <inheritdoc/>
public record PhotosetComments : Comments<PhotosetId>
{ }

/// <inheritdoc/>
public record PhotoComments : Comments<PhotoId>
{ }

/// <inheritdoc/>
public record Licenses : FlickrCollection<License>
{ }

/// <inheritdoc/>
public record Subscriptions : FlickrCollection<Subscription>
{ }

/// <inheritdoc/>
[FlickrJsonPropertyName("topics")]
public record TopicNames : FlickrCollection<TopicName>
{ }

/// <inheritdoc/>
[FlickrJsonPropertyName("uploader")]
public record Tickets : FlickrCollection<Ticket>
{ }

/// <inheritdoc/>
[FlickrJsonPropertyName("people")]
public record PeoplePersons : FlickrCollection<PeoplePerson>
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("total")]
    public int Total { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("photo_width")]
    public int PhotoWidth { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("photo_height")]
    public int PhotoHeight { get; set; }
}

/// <inheritdoc/>
[FlickrJsonPropertyName("photosets")]
public record Photosets : FlickrPaginationCollection<Photoset>
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("cancreate")]
    public bool CanCreate { get; set; }
}

/// <inheritdoc/>
[FlickrJsonPropertyName("photoset")]
public record PhotosetPhotos : FlickrPaginationCollection<PhotosetPhoto>
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("primary")]
    public string Primary { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("owner")]
    public string Owner { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("ownername")]
    public string Ownername { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("title")]
    public string Title { get; set; }
}

/// <inheritdoc/>
[FlickrJsonPropertyName("cover_photos")]
public record CoverPhotos : FlickrCollection<CoverPhoto>
{ }

/// <inheritdoc/>
[FlickrJsonPropertyName("methods")]
public record Methods : FlickrCollection<Method>
{ }

/// <inheritdoc/>
[FlickrJsonPropertyName("domains")]
public record Domains : FlickrPaginationCollection<Domain>
{ }

/// <inheritdoc/>
[FlickrJsonPropertyName("domain")]
public record Referrers : FlickrPaginationCollection<Referrer>
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }
}

/// <inheritdoc/>
[FlickrJsonPropertyName("stats")]
public record CSVFiles : FlickrCollection<CSVFile>
{ }

/// <inheritdoc/>
[FlickrJsonPropertyName("clusters")]
public record Clusters : FlickrCollection<Cluster>
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("source")]
    public string Source { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("total")]
    public int Total { get; set; }
}

/// <inheritdoc/>
[FlickrJsonPropertyName("photos")]
public record ClusterPhotos : FlickrCollection<ClusterPhoto>
{ }

/// <inheritdoc/>
[FlickrJsonPropertyName("hottags")]
public record Hottags : FlickrCollection<Hottag>
{ }

/// <inheritdoc/>
[FlickrJsonPropertyName("photos")]
public record StatsPhotos : FlickrPaginationCollection<StatsPhoto>
{ }

/// <inheritdoc/>
[FlickrJsonPropertyName("tags")]
public record UserTags : FlickrCollection<UserTag>
{ }

/// <inheritdoc/>
[FlickrJsonPropertyName("tags")]
public record Tags : FlickrCollection<Tag>
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("source")]
    public string Source { get; set; }
}