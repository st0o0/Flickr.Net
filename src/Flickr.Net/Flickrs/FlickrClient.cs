using System.Globalization;
using System.Text;
using Flickr.Net.Configuration;
using Flickr.Net.Exceptions;
using Flickr.Net.Internals;
using Flickr.Net.Internals.HttpContents;
using Flickr.Net.Settings;
using Microsoft.Extensions.Caching.Hybrid;
using Microsoft.Extensions.Options;

namespace Flickr.Net;

public sealed partial class FlickrClient : IFlickrClient
{
    private readonly HttpClient _httpClient;
    private readonly bool _ownsHttpClient;
    private readonly FlickrResponder _responder;
    private readonly HybridCache? _cache;

    /// <summary>
    /// Initializes a new instance of <see cref="FlickrClient"/> for use with dependency injection.
    /// </summary>
    /// <param name="httpClient">The HTTP client provided by <see cref="IHttpClientFactory"/>.</param>
    /// <param name="options">The Flickr configuration options.</param>
    /// <param name="cache">Optional <see cref="HybridCache"/> for response caching.</param>
    public FlickrClient(HttpClient httpClient, IOptions<FlickrConfiguration> options, HybridCache? cache = null)
    {
        var config = options.Value;
        FlickrSettings = new FlickrSettings(config);
        _httpClient = httpClient;
        _ownsHttpClient = false;
        _responder = new FlickrResponder(_httpClient);
        _cache = cache;
    }

    /// <summary>
    /// Initializes a new instance of <see cref="FlickrClient"/> with the specified configuration.
    /// </summary>
    /// <param name="config">The Flickr configuration.</param>
    public FlickrClient(FlickrConfiguration config)
        : this(new HttpClient(), Options.Create(config), cache: null)
    {
        _ownsHttpClient = true;
    }

    /// <summary>
    /// Initializes a new instance of <see cref="FlickrClient"/> with only an API key.
    /// </summary>
    /// <param name="apiKey">Your Flickr API key.</param>
    public FlickrClient(string apiKey)
        : this(apiKey, null)
    {
    }

    /// <summary>
    /// Initializes a new instance of <see cref="FlickrClient"/> with an API key and shared secret.
    /// </summary>
    /// <param name="apiKey">Your Flickr API key.</param>
    /// <param name="sharedSecret">Your Flickr shared secret.</param>
    public FlickrClient(string apiKey, string sharedSecret)
        : this(new FlickrConfiguration { ApiKey = apiKey, SharedSecret = sharedSecret })
    {
    }

    /// <summary>Gets the Flickr upload endpoint URL.</summary>
    internal string UploadUrl { get; init; } = "https://up.flickr.com/services/upload/";
    internal string ReplaceUrl { get; init; } = "https://up.flickr.com/services/replace/";
    internal string AuthUrl { get; init; } = "https://www.flickr.com/services/auth/";
    internal Uri BaseUri { get; init; } = new("https://api.flickr.com/services/rest/");

    /// <inheritdoc />
    public IFlickrActivity Activity => this;
    /// <inheritdoc />
    public IFlickrBlogs Blogs => this;
    /// <inheritdoc />
    public IFlickrCameras Cameras => this;
    /// <inheritdoc />
    public IFlickrCollections Collections => this;
    /// <inheritdoc />
    public IFlickrCommons Commons => this;
    /// <inheritdoc />
    public IFlickrContacts Contacts => this;
    /// <inheritdoc />
    public IFlickrFavorites Favorites => this;
    /// <inheritdoc />
    public IFlickrGalleries Galleries => this;
    /// <inheritdoc />
    public IFlickrGroups Groups => this;
    /// <inheritdoc />
    public IFlickrGroupsDiscuss GroupsDiscuss => this;
    /// <inheritdoc />
    public IFlickrGroupsDiscussReplies GroupsDiscussReplies => this;
    /// <inheritdoc />
    public IFlickrGroupsDiscussTopics GroupsDiscussTopics => this;
    /// <inheritdoc />
    public IFlickrGroupsMembers GroupsMembers => this;
    /// <inheritdoc />
    public IFlickrGroupsPools GroupsPools => this;
    /// <inheritdoc />
    public IFlickrInterestingness Interestingness => this;
    /// <inheritdoc />
    public IFlickrMachineTags MachineTags => this;
    /// <inheritdoc />
    public IFlickrOAuth OAuth => this;
    /// <inheritdoc />
    public IFlickrPanda Panda => this;
    /// <inheritdoc />
    public IFlickrPeople People => this;
    /// <inheritdoc />
    public IFlickrPlaces Places => this;
    /// <inheritdoc />
    public IFlickrPhotos Photos => this;
    /// <inheritdoc />
    public IFlickrPhotosComments PhotosComments => this;
    /// <inheritdoc />
    public IFlickrPhotosGeo PhotosGeo => this;
    /// <inheritdoc />
    public IFlickrPhotosLicenses PhotosLicenses => this;
    /// <inheritdoc />
    public IFlickrPhotosMisc PhotosMisc => this;
    /// <inheritdoc />
    public IFlickrPhotosNotes PhotosNotes => this;
    /// <inheritdoc />
    public IFlickrPhotosPeople PhotosPeople => this;
    /// <inheritdoc />
    public IFlickrPhotosSuggestions PhotosSuggestions => this;
    /// <inheritdoc />
    public IFlickrPhotosets Photosets => this;
    /// <inheritdoc />
    public IFlickrPhotosetsComments PhotosetsComments => this;
    /// <inheritdoc />
    public IFlickrPrefs Prefs => this;
    /// <inheritdoc />
    public IFlickrProfile Profile => this;
    /// <inheritdoc />
    public IFlickrPush Push => this;
    /// <inheritdoc />
    public IFlickrReflection Reflection => this;
    /// <inheritdoc />
    public IFlickrStats Stats => this;
    /// <inheritdoc />
    public IFlickrTags Tags => this;
    /// <inheritdoc />
    public IFlickrTest Test => this;
    /// <inheritdoc />
    public IFlickrUpload Upload => this;
    /// <inheritdoc />
    public IFlickrUrls Urls => this;
    /// <inheritdoc />
    public IFlickrTestimonials Testimonials => this;

    /// <summary>Gets the current Flickr settings for this client instance.</summary>
    public FlickrSettings FlickrSettings { get; }

    /// <summary>Gets a value indicating whether the client has both an API key and shared secret configured.</summary>
    public bool IsAuthenticated => FlickrSettings is { ApiSecret: not null, ApiKey: not null };

    internal void CheckApiKey()
    {
        if (string.IsNullOrEmpty(FlickrSettings.ApiKey))
        {
            throw new ApiKeyRequiredException();
        }
    }

    internal void CheckSigned()
    {
        CheckApiKey();

        if (string.IsNullOrEmpty(FlickrSettings.ApiSecret))
        {
            throw new SignatureRequiredException();
        }
    }

    internal void CheckRequiresAuthentication()
    {
        CheckSigned();

        if (!string.IsNullOrEmpty(FlickrSettings.OAuthAccessToken) &&
            !string.IsNullOrEmpty(FlickrSettings.OAuthAccessTokenSecret))
        {
            return;
        }

        throw new AuthenticationRequiredException();
    }

    internal string CalculateUri(Dictionary<string, string> parameters, bool includeSignature)
    {
        if (includeSignature)
        {
            var signature = CalculateAuthSignature(parameters);
            parameters.Add("api_sig", signature);
        }

        var url = new StringBuilder();
        url.Append('?');
        foreach (var pair in parameters)
        {
            var escapedValue = UtilityMethods.EscapeDataString(pair.Value ?? "");
            url.AppendFormat(CultureInfo.InvariantCulture, "{0}={1}&", pair.Key, escapedValue);
        }

        return BaseUri.AbsoluteUri + url;
    }

    private string CalculateAuthSignature(Dictionary<string, string> parameters)
    {
        var sorted = parameters.OrderBy(p => p.Key);

        var sb = new StringBuilder(FlickrSettings.ApiKey);
        foreach (var pair in sorted)
        {
            sb.Append(pair.Key);
            sb.Append(pair.Value);
        }

        return UtilityMethods.MD5Hash(sb.ToString());
    }

    private static MultipartFormDataContent CreateUploadData(Stream imageStream, string fileName,
        IProgress<double> progress, Dictionary<string, string> parameters, string boundary,
        CancellationToken cancellationToken = default)
    {
        MultipartFormDataContent content = new(boundary)
        {
            { new StreamedContent(imageStream, progress, cancellationToken), "photo", Path.GetFileName(fileName) }
        };

        foreach (var i in parameters)
        {
            if (i.Key.StartsWith("oauth", StringComparison.Ordinal))
            {
                continue;
            }

            content.Add(new StringContent(i.Value), i.Key);
        }

        return content;
    }

    /// <inheritdoc />
    public void Dispose()
    {
        if (_ownsHttpClient)
        {
            _httpClient.Dispose();
        }
    }

    /// <inheritdoc />
    public ValueTask DisposeAsync()
    {
        Dispose();
        GC.SuppressFinalize(this);
        return ValueTask.CompletedTask;
    }
}