namespace Flickr.Net;

/// <summary>
/// Root interface for the Flickr API client, exposing all API sub-clients as properties.
/// </summary>
public interface IFlickrClient : IDisposable, IAsyncDisposable
{
    /// <summary>Provides access to Flickr activity API methods.</summary>
    IFlickrActivity Activity { get; }
    /// <summary>Provides access to Flickr blogs API methods.</summary>
    IFlickrBlogs Blogs { get; }
    /// <summary>Provides access to Flickr cameras API methods.</summary>
    IFlickrCameras Cameras { get; }
    /// <summary>Provides access to Flickr collections API methods.</summary>
    IFlickrCollections Collections { get; }
    /// <summary>Provides access to Flickr commons API methods.</summary>
    IFlickrCommons Commons { get; }
    /// <summary>Provides access to Flickr contacts API methods.</summary>
    IFlickrContacts Contacts { get; }
    /// <summary>Provides access to Flickr favorites API methods.</summary>
    IFlickrFavorites Favorites { get; }
    /// <summary>Provides access to Flickr galleries API methods.</summary>
    IFlickrGalleries Galleries { get; }
    /// <summary>Provides access to Flickr groups API methods.</summary>
    IFlickrGroups Groups { get; }
    /// <summary>Provides access to Flickr group discussion API methods.</summary>
    IFlickrGroupsDiscuss GroupsDiscuss { get; }
    /// <summary>Provides access to Flickr group discussion replies API methods.</summary>
    IFlickrGroupsDiscussReplies GroupsDiscussReplies { get; }
    /// <summary>Provides access to Flickr group discussion topics API methods.</summary>
    IFlickrGroupsDiscussTopics GroupsDiscussTopics { get; }
    /// <summary>Provides access to Flickr group members API methods.</summary>
    IFlickrGroupsMembers GroupsMembers { get; }
    /// <summary>Provides access to Flickr group pools API methods.</summary>
    IFlickrGroupsPools GroupsPools { get; }
    /// <summary>Provides access to Flickr interestingness API methods.</summary>
    IFlickrInterestingness Interestingness { get; }
    /// <summary>Provides access to Flickr machine tags API methods.</summary>
    IFlickrMachineTags MachineTags { get; }
    /// <summary>Provides access to Flickr OAuth API methods.</summary>
    IFlickrOAuth OAuth { get; }
    /// <summary>Provides access to Flickr panda API methods.</summary>
    IFlickrPanda Panda { get; }
    /// <summary>Provides access to Flickr people API methods.</summary>
    IFlickrPeople People { get; }
    /// <summary>Provides access to Flickr places API methods.</summary>
    IFlickrPlaces Places { get; }
    /// <summary>Provides access to Flickr photos API methods.</summary>
    IFlickrPhotos Photos { get; }
    /// <summary>Provides access to Flickr photo comments API methods.</summary>
    IFlickrPhotosComments PhotosComments { get; }
    /// <summary>Provides access to Flickr photo geo API methods.</summary>
    IFlickrPhotosGeo PhotosGeo { get; }
    /// <summary>Provides access to Flickr photo licenses API methods.</summary>
    IFlickrPhotosLicenses PhotosLicenses { get; }
    /// <summary>Provides access to Flickr photo miscellaneous API methods.</summary>
    IFlickrPhotosMisc PhotosMisc { get; }
    /// <summary>Provides access to Flickr photo notes API methods.</summary>
    IFlickrPhotosNotes PhotosNotes { get; }
    /// <summary>Provides access to Flickr photo people API methods.</summary>
    IFlickrPhotosPeople PhotosPeople { get; }
    /// <summary>Provides access to Flickr photo suggestions API methods.</summary>
    IFlickrPhotosSuggestions PhotosSuggestions { get; }
    /// <summary>Provides access to Flickr photosets API methods.</summary>
    IFlickrPhotosets Photosets { get; }
    /// <summary>Provides access to Flickr photoset comments API methods.</summary>
    IFlickrPhotosetsComments PhotosetsComments { get; }
    /// <summary>Provides access to Flickr preferences API methods.</summary>
    IFlickrPrefs Prefs { get; }
    /// <summary>Provides access to Flickr profile API methods.</summary>
    IFlickrProfile Profile { get; }
    /// <summary>Provides access to Flickr push subscription API methods.</summary>
    IFlickrPush Push { get; }
    /// <summary>Provides access to Flickr reflection API methods.</summary>
    IFlickrReflection Reflection { get; }
    /// <summary>Provides access to Flickr stats API methods.</summary>
    IFlickrStats Stats { get; }
    /// <summary>Provides access to Flickr tags API methods.</summary>
    IFlickrTags Tags { get; }
    /// <summary>Provides access to Flickr test API methods.</summary>
    IFlickrTest Test { get; }
    /// <summary>Provides access to Flickr upload API methods.</summary>
    IFlickrUpload Upload { get; }
    /// <summary>Provides access to Flickr URL API methods.</summary>
    IFlickrUrls Urls { get; }
    /// <summary>Provides access to Flickr testimonials API methods.</summary>
    IFlickrTestimonials Testimonials { get; }
}
