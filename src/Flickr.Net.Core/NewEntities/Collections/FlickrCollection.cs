using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

/// <summary>
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract record FlickrCollection<T> : FlickrEntityBase where T : IFlickrEntity
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
public abstract record FlickrPaginationCollection<T> : FlickrCollection<T> where T : IFlickrEntity
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
    [JsonProperty("user_id")]
    public string UserId { get; set; }
}

/// <inheritdoc/>
[FlickrJsonPropertyName("galleries")]
public record PhotoGalleries : Galleries
{
    /// <summary>
    /// </summary>
    [JsonProperty("photo_id")]
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
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("secret")]
    public string Secret { get; set; }

    [JsonProperty("server")]
    public string Server { get; set; }

    [JsonProperty("farm")]
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
    [JsonProperty("canblog")]
    public bool CanBlog { get; set; }

    [JsonProperty("canprint")]
    public bool CanPrint { get; set; }

    [JsonProperty("candownload")]
    public bool CanDownload { get; set; }
}

/// <inheritdoc/>
[FlickrJsonPropertyName("comments")]
public abstract record Comments<T> : FlickrCollection<Comment> where T : IIdentifierType
{
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
    [JsonProperty("total")]
    public int Total { get; set; }

    [JsonProperty("photo_width")]
    public int PhotoWidth { get; set; }

    [JsonProperty("photo_height")]
    public int PhotoHeight { get; set; }
}

/// <inheritdoc/>
[FlickrJsonPropertyName("photosets")]
public record Photosets : FlickrPaginationCollection<Photoset>
{
    [JsonProperty("cancreate")]
    public bool CanCreate { get; set; }
}

/// <inheritdoc/>
[FlickrJsonPropertyName("photoset")]
public record PhotosetPhotos : FlickrPaginationCollection<PhotosetPhoto>
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("primary")]
    public string Primary { get; set; }

    [JsonProperty("owner")]
    public string Owner { get; set; }

    [JsonProperty("ownername")]
    public string Ownername { get; set; }

    [JsonProperty("title")]
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
    [JsonProperty("name")]
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
    [JsonProperty("source")]
    public string Source { get; set; }

    [JsonProperty("total")]
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
    [JsonProperty("source")]
    public string Source { get; set; }
}