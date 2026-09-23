using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Enums;
using Flickr.Net.Internals;
using Flickr.Net.Internals.Attributes;

namespace Flickr.Net;

/// <summary>
/// Base collection type for Flickr API responses containing a list of entities.
/// </summary>
/// <typeparam name="T">The entity type contained in the collection.</typeparam>
public abstract record FlickrCollection<T> : FlickrEntityBase where T : IFlickrEntity
{
    /// <summary>Gets or sets the list of entities in this collection.</summary>
    [JsonPropertyGenericTypeName(0)]
    public List<T> Values { get; set; } = [];

    /// <summary>Implicitly converts the collection to a list of its values.</summary>
    /// <param name="collection">The collection to convert.</param>
    public static implicit operator List<T>(FlickrCollection<T> collection) => collection.Values;
}

/// <summary>
/// Base collection type for paginated Flickr API responses.
/// </summary>
/// <typeparam name="T">The entity type contained in the collection.</typeparam>
public abstract record FlickrPaginationCollection<T> : FlickrCollection<T> where T : IFlickrEntity
{
    /// <summary>Gets or sets the current page number.</summary>
    [JsonPropertyName("page")]
    public int Page { get; set; }

    /// <summary>Gets or sets the total number of pages.</summary>
    [JsonPropertyName("pages")]
    public int Pages { get; set; }

    /// <summary>Gets or sets the number of items per page.</summary>
    [JsonPropertyName("perpage")]
    public int PerPage { get; set; }

    /// <summary>Gets or sets the total number of items across all pages.</summary>
    [JsonPropertyName("total")]
    public int Total { get; set; }
}

/// <inheritdoc/>
[FlickrJsonPropertyName("blogs")]
public record Blogs : FlickrCollection<Blog>;

/// <inheritdoc/>
[FlickrJsonPropertyName("items")]
public record Items : FlickrCollection<Item>;

/// <inheritdoc/>
[FlickrJsonPropertyName("services")]
public record Services : FlickrCollection<Service>;

/// <inheritdoc/>
[FlickrJsonPropertyName("cameras")]
public record Cameras : FlickrCollection<Camera>
{
    /// <summary>Gets or sets the camera brand name.</summary>
    [JsonPropertyName("brand")]
    public string Brand { get; set; }
}

/// <inheritdoc/>
[FlickrJsonPropertyName("brands")]
public record Brands : FlickrCollection<Brand>;

/// <inheritdoc/>
[FlickrJsonPropertyName("photos")]
public record Photos : FlickrCollection<Photo>;

/// <inheritdoc/>
[FlickrJsonPropertyName("iconphotos")]
public record IconPhotos : FlickrCollection<IconPhoto>;

/// <inheritdoc/>
[FlickrJsonPropertyName("photos")]
public record PagedPhotos : FlickrPaginationCollection<Photo>;

/// <inheritdoc/>
[FlickrJsonPropertyName("collections")]
public record Collections : FlickrCollection<Collection>;

/// <inheritdoc/>
[FlickrJsonPropertyName("institutions")]
public record Institutions : FlickrCollection<Institution>;

/// <inheritdoc/>
[FlickrJsonPropertyName("urls")]
public record Urls : FlickrCollection<Url>;

/// <inheritdoc/>
[FlickrJsonPropertyName("contacts")]
public record Contacts : FlickrPaginationCollection<Contact>;

/// <inheritdoc/>
[FlickrJsonPropertyName("galleries")]
public record Galleries : FlickrPaginationCollection<Gallery>;

/// <inheritdoc/>
[FlickrJsonPropertyName("galleries")]
public record UserGalleries : Galleries
{
    /// <summary>Gets or sets the user ID that owns these galleries.</summary>
    [JsonPropertyName("user_id")]
    public string UserId { get; set; }
}

/// <inheritdoc/>
[FlickrJsonPropertyName("galleries")]
public record PhotoGalleries : Galleries
{
    /// <summary>Gets or sets the photo ID that appears in these galleries.</summary>
    [JsonPropertyName("photo_id")]
    public string PhotoId { get; set; }
}

/// <inheritdoc/>
[FlickrJsonPropertyName("photos")]
public record GalleryPhotos : FlickrPaginationCollection<GalleryPhoto>;

/// <inheritdoc/>
[FlickrJsonPropertyName("replies")]
public record Replies : FlickrCollection<Reply>
{
    /// <summary>Gets or sets the topic that these replies belong to.</summary>
    [JsonPropertyName("topic")]
    public Topic Topic { get; set; }
}

/// <inheritdoc/>
[FlickrJsonPropertyName("topics")]
public record Topics : FlickrPaginationCollection<Topic>
{
    /// <summary>Gets or sets the group ID.</summary>
    [JsonPropertyName("group_id")]
    public string GroupId { get; set; }

    /// <summary>Gets or sets the icon server for the group icon.</summary>
    [JsonPropertyName("iconserver")]
    public string IconServer { get; set; }

    /// <summary>Gets or sets the icon farm for the group icon.</summary>
    [JsonPropertyName("iconfarm")]
    public string IconFarm { get; set; }

    /// <summary>Gets or sets the group name.</summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>Gets or sets the number of group members.</summary>
    [JsonPropertyName("members")]
    public int Members { get; set; }

    /// <summary>Gets or sets the group's pool privacy setting.</summary>
    [JsonPropertyName("privacy")]
    public PoolPrivacy Privacy { get; set; }

    /// <summary>Gets or sets the group's language code.</summary>
    [JsonPropertyName("lang")]
    public string Lang { get; set; }

    /// <summary>Gets or sets whether the group pool is moderated.</summary>
    [JsonPropertyName("ispoolmoderated")]
    public bool IsPoolModerated { get; set; }

    /// <summary>Gets the constructed URL for the group's icon.</summary>
    [JsonIgnore]
    public string GroupIconUrl => UtilityMethods.BuddyIcon(IconServer, IconFarm, GroupId);
}

/// <inheritdoc/>
[FlickrJsonPropertyName("groups")]
public record Groups : FlickrPaginationCollection<Group>;

//[FlickrJsonPropertyName("groups")]
//public class GroupSearchResults : FlickrPaginationCollection<GroupSearchResult>
//{ }

/// <inheritdoc/>
[FlickrJsonPropertyName("members")]
public record Members : FlickrPaginationCollection<Member>;

/// <inheritdoc/>
[FlickrJsonPropertyName("namespaces")]
public record Namespaces : FlickrPaginationCollection<Namespace>;

/// <inheritdoc/>
[FlickrJsonPropertyName("pairs")]
public record Pairs : FlickrPaginationCollection<Pair>;

/// <inheritdoc/>
[FlickrJsonPropertyName("predicates")]
public record Predicates : FlickrPaginationCollection<Predicate>;

/// <inheritdoc/>
[FlickrJsonPropertyName("values")]
public record Values : FlickrPaginationCollection<Value>
{
    /// <summary>Gets or sets the machine tag namespace.</summary>
    [JsonPropertyName("namespace")]
    public string Namespace { get; set; }

    /// <summary>Gets or sets the machine tag predicate.</summary>
    [JsonPropertyName("predicate")]
    public string Predicate { get; set; }
}

/// <inheritdoc/>
[FlickrJsonPropertyName("pandas")]
public record Pandas : FlickrCollection<Panda>;

/// <inheritdoc/>
[FlickrJsonPropertyName("photos")]
public record PandaPhotos : FlickrCollection<PandaPhoto>
{
    /// <summary>Gets or sets the refresh interval in seconds.</summary>
    [JsonPropertyName("interval")]
    public int Interval { get; set; }

    /// <summary>Gets or sets the last update timestamp.</summary>
    [JsonPropertyName("lastupdate")]
    public DateTime LastUpdate { get; set; }

    /// <summary>Gets or sets the total number of panda photos.</summary>
    [JsonPropertyName("total")]
    public int Total { get; set; }

    /// <summary>Gets or sets the panda name.</summary>
    [JsonPropertyName("panda")]
    public string Panda { get; set; }
}

/// <inheritdoc/>
[FlickrJsonPropertyName("set")]
public record Sets : FlickrCollection<CollectionSet>;

/// <inheritdoc/>
[FlickrJsonPropertyName("pool")]
public record Pools : FlickrCollection<Pool>;

/// <inheritdoc/>
[FlickrJsonPropertyName("photocounts")]
public record PhotoCounts : FlickrCollection<PhotoCount>;

/// <inheritdoc/>
[FlickrJsonPropertyName("photo")]
public record PhotoPersons : FlickrPaginationCollection<PhotoPerson>
{
    /// <summary>Gets or sets the photo ID.</summary>
    [JsonPropertyName("id")]
    public string Id { get; set; }

    /// <summary>Gets or sets the photo secret.</summary>
    [JsonPropertyName("secret")]
    public string Secret { get; set; }

    /// <summary>Gets or sets the photo server.</summary>
    [JsonPropertyName("server")]
    public string Server { get; set; }

    /// <summary>Gets or sets the photo farm.</summary>
    [JsonPropertyName("farm")]
    public int Farm { get; set; }
}

/// <inheritdoc/>
[FlickrJsonPropertyName("notes")]
public record Notes : FlickrCollection<Note>;

/// <inheritdoc/>
[FlickrJsonPropertyName("tags")]
public record PhotoInfoTags : FlickrCollection<PhotoTag>;

/// <inheritdoc/>
[FlickrJsonPropertyName("sizes")]
public record Sizes : FlickrCollection<Size>
{
    /// <summary>Gets or sets whether the photo can be blogged.</summary>
    [JsonPropertyName("canblog")]
    public bool CanBlog { get; set; }

    /// <summary>Gets or sets whether the photo can be printed.</summary>
    [JsonPropertyName("canprint")]
    public bool CanPrint { get; set; }

    /// <summary>Gets or sets whether the photo can be downloaded.</summary>
    [JsonPropertyName("candownload")]
    public bool CanDownload { get; set; }
}

/// <inheritdoc/>
[FlickrJsonPropertyName("comments")]
public abstract record Comments<T> : FlickrCollection<Comment> where T : IIdentifierType
{
    /// <summary>Gets or sets the identifier of the commented entity.</summary>
    [JsonPropertyGenericTypeName(0)]
    public T Id { get; set; }
}

/// <inheritdoc/>
public record PhotosetComments : Comments<PhotosetId>;

/// <inheritdoc/>
public record PhotoComments : Comments<PhotoId>;

/// <inheritdoc/>
public record Licenses : FlickrCollection<License>;

/// <inheritdoc/>
public record Subscriptions : FlickrCollection<Subscription>;

/// <inheritdoc/>
[FlickrJsonPropertyName("topics")]
public record TopicNames : FlickrCollection<TopicName>;

/// <inheritdoc/>
[FlickrJsonPropertyName("uploader")]
public record Tickets : FlickrCollection<Ticket>;

/// <inheritdoc/>
[FlickrJsonPropertyName("people")]
public record PeoplePersons : FlickrCollection<PeoplePerson>
{
    /// <summary>Gets or sets the total number of people.</summary>
    [JsonPropertyName("total")]
    public int Total { get; set; }

    /// <summary>Gets or sets the photo width in pixels.</summary>
    [JsonPropertyName("photo_width")]
    public int PhotoWidth { get; set; }

    /// <summary>Gets or sets the photo height in pixels.</summary>
    [JsonPropertyName("photo_height")]
    public int PhotoHeight { get; set; }
}

/// <inheritdoc/>
[FlickrJsonPropertyName("photosets")]
public record Photosets : FlickrPaginationCollection<Photoset>
{
    /// <summary>Gets or sets whether the user can create new photosets.</summary>
    [JsonPropertyName("cancreate")]
    public bool CanCreate { get; set; }
}

/// <inheritdoc/>
[FlickrJsonPropertyName("photoset")]
public record PhotosetPhotos : FlickrPaginationCollection<PhotosetPhoto>
{
    /// <summary>Gets or sets the photoset ID.</summary>
    [JsonPropertyName("id")]
    public string Id { get; set; }

    /// <summary>Gets or sets the primary photo ID of the photoset.</summary>
    [JsonPropertyName("primary")]
    public string Primary { get; set; }

    /// <summary>Gets or sets the owner's user ID.</summary>
    [JsonPropertyName("owner")]
    public string Owner { get; set; }

    /// <summary>Gets or sets the owner's username.</summary>
    [JsonPropertyName("ownername")]
    public string Ownername { get; set; }

    /// <summary>Gets or sets the photoset title.</summary>
    [JsonPropertyName("title")]
    public string Title { get; set; }
}

/// <inheritdoc/>
[FlickrJsonPropertyName("cover_photos")]
public record CoverPhotos : FlickrCollection<CoverPhoto>;

/// <inheritdoc/>
[FlickrJsonPropertyName("methods")]
public record Methods : FlickrCollection<Method>;

/// <inheritdoc/>
[FlickrJsonPropertyName("domains")]
public record Domains : FlickrPaginationCollection<Domain>;

/// <inheritdoc/>
[FlickrJsonPropertyName("domain")]
public record Referrers : FlickrPaginationCollection<Referrer>
{
    /// <summary>Gets or sets the referrer domain name.</summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }
}

/// <inheritdoc/>
[FlickrJsonPropertyName("stats")]
public record CSVFiles : FlickrCollection<CSVFile>;

/// <inheritdoc/>
[FlickrJsonPropertyName("clusters")]
public record Clusters : FlickrCollection<Cluster>
{
    /// <summary>Gets or sets the cluster source tag.</summary>
    [JsonPropertyName("source")]
    public string Source { get; set; }

    /// <summary>Gets or sets the total number of clusters.</summary>
    [JsonPropertyName("total")]
    public int Total { get; set; }
}

/// <inheritdoc/>
[FlickrJsonPropertyName("photos")]
public record ClusterPhotos : FlickrCollection<ClusterPhoto>;

/// <inheritdoc/>
[FlickrJsonPropertyName("hottags")]
public record Hottags : FlickrCollection<Hottag>;

/// <inheritdoc/>
[FlickrJsonPropertyName("photos")]
public record StatsPhotos : FlickrPaginationCollection<StatsPhoto>;

/// <inheritdoc/>
[FlickrJsonPropertyName("tags")]
public record UserTags : FlickrCollection<UserTag>;

/// <inheritdoc/>
[FlickrJsonPropertyName("tags")]
public record Tags : FlickrCollection<Tag>
{
    /// <summary>Gets or sets the tag source identifier.</summary>
    [JsonPropertyName("source")]
    public string Source { get; set; }
}
