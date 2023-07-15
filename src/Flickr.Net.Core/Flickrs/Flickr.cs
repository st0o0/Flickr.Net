using System.Text;
using Flickr.Net.Core.Configuration;
using Flickr.Net.Core.Exceptions;
using Flickr.Net.Core.Internals.Caching;
using Flickr.Net.Core.Internals.HttpContents;
using Flickr.Net.Core.Settings;

namespace Flickr.Net.Core;

/// <summary>
/// The main Flickr class.
/// </summary>
/// <remarks>
/// Create an instance of this class and then call its methods to perform methods on Flickr.
/// </remarks>
/// <example>
/// <code>
///FlickrNet.Flickr flickr = new FlickrNet.Flickr();
///User user = flickr.PeopleFindByEmail("cal@iamcal.com");
///Console.WriteLine("User Id is " + u.UserId);
/// </code>
/// </example>
public partial class Flickr
{
    private readonly Cache _cache;
    private readonly FlickrSettings _settings;
    private readonly FlickrCachingSettings _cachingSettings;
    private string _lastRequest;

    /// <summary>
    /// Constructor loads configuration settings from app.config or web.config file if they exist.
    /// </summary>
    public Flickr(FlickrConfiguration config)
    {
        _cachingSettings = new FlickrCachingSettings(config);
        _cache = new Cache(_cachingSettings);
        _settings = new FlickrSettings(config);
    }

    /// <summary>
    /// Create a new instance of the <see cref="Flickr"/> class with no authentication.
    /// </summary>
    /// <param name="apiKey">Your Flickr API Key.</param>
    public Flickr(string apiKey)
        : this(apiKey, null)
    {
    }

    /// <summary>
    /// Creates a new instance of the <see cref="Flickr"/> class with an API key and a Shared
    /// Secret. This is only useful really useful for calling the Auth functions as all other
    /// authenticationed methods also require the API Token.
    /// </summary>
    /// <param name="apiKey">Your Flickr API Key.</param>
    /// <param name="sharedSecret">Your Flickr Shared Secret.</param>
    public Flickr(string apiKey, string sharedSecret)
        : this(new FlickrConfiguration() { ApiKey = apiKey, SharedSecret = sharedSecret })
    {
    }

    /// <summary>
    /// </summary>
    protected static string UploadUrl => "https://up.flickr.com/services/upload/";

    /// <summary>
    /// </summary>
    protected static string ReplaceUrl => "https://up.flickr.com/services/replace/";

    /// <summary>
    /// </summary>
    protected static string AuthUrl => "https://www.flickr.com/services/auth/";

    /// <summary>
    /// </summary>
    protected static Uri BaseUri => new("https://api.flickr.com/services/rest/");

    /// <summary>
    /// </summary>
    protected Cache Cache => _cache;

    /// <summary>
    /// property for all activity functions
    /// </summary>
    public IFlickrActivity Activity => this;

    /// <summary>
    /// property for all blog functions
    /// </summary>
    public IFlickrBlogs Blogs => this;

    /// <summary>
    /// property for all camera functions
    /// </summary>
    public IFlickrCameras Cameras => this;

    /// <summary>
    /// property for all collection functions
    /// </summary>
    public IFlickrCollections Collections => this;

    /// <summary>
    /// property for all common functions
    /// </summary>
    public IFlickrCommons Commons => this;

    /// <summary>
    /// property for all contact functions
    /// </summary>
    public IFlickrContacts Contacts => this;

    /// <summary>
    /// property for all favorites functions
    /// </summary>
    public IFlickrFavorites Favorites => this;

    /// <summary>
    /// property for all gallerie functions
    /// </summary>
    public IFlickrGalleries Galleries => this;

    /// <summary>
    /// property for all group functions
    /// </summary>
    public IFlickrGroups Groups => this;

    /// <summary>
    /// property for all interestingness functions
    /// </summary>
    public IFlickrInterestingness Interestingness => this;

    /// <summary>
    /// property for all machinetag functions
    /// </summary>
    public IFlickrMachineTags MachineTags => this;

    /// <summary>
    /// property for all oauth functions
    /// </summary>
    public IFlickrOAuth OAuth => this;

    /// <summary>
    /// property for all panda functions
    /// </summary>
    public IFlickrPanda Panda => this;

    /// <summary>
    /// property for all people functions
    /// </summary>
    public IFlickrPeople People => this;

    /// <summary>
    /// property for all photo functions
    /// </summary>
    public IFlickrPhotos Photos => this;

    /// <summary>
    /// property for all photosets functions
    /// </summary>
    public IFlickrPhotosets Photosets => this;

    /// <summary>
    /// property for all pref functions
    /// </summary>
    public IFlickrPrefs Prefs => this;

    /// <summary>
    /// property for all profile functions
    /// </summary>
    public IFlickrProfile Profile => this;

    /// <summary>
    /// property for all push functions
    /// </summary>
    public IFlickrPush Push => this;

    /// <summary>
    /// property for all reflection functions
    /// </summary>
    public IFlickrReflection Reflection => this;

    /// <summary>
    /// property for all stats functions
    /// </summary>
    public IFlickrStats Stats => this;

    /// <summary>
    /// property for all tags functions
    /// </summary>
    public IFlickrTags Tags => this;

    /// <summary>
    /// property for all test functions
    /// </summary>
    public IFlickrTest Test => this;

    /// <summary>
    /// property for upload and replace functions
    /// </summary>
    public IFlickrUpload Upload => this;

    /// <summary>
    /// property for all url functions
    /// </summary>
    public IFlickrUrls Urls => this;

    /// <summary>
    /// Gets the flickr caching settings.
    /// </summary>
    public FlickrCachingSettings FlickrCachingSettings => _cachingSettings;

    /// <summary>
    /// Gets the flickr settings.
    /// </summary>
    public FlickrSettings FlickrSettings => _settings;

    /// <summary>
    /// Checks to see if a shared secret and an api token are stored in the object. Does not check
    /// if these values are valid values.
    /// </summary>
    public bool IsAuthenticated
    {
        get
        {
            return _settings.ApiSecret != null && _settings.ApiKey != null;
        }
    }

    internal void CheckApiKey()
    {
        if (string.IsNullOrEmpty(_settings.ApiKey))
        {
            throw new ApiKeyRequiredException();
        }
    }

    internal void CheckSigned()
    {
        CheckApiKey();

        if (string.IsNullOrEmpty(_settings.ApiSecret))
        {
            throw new SignatureRequiredException();
        }
    }

    internal void CheckRequiresAuthentication()
    {
        CheckSigned();

        if (!string.IsNullOrEmpty(_settings.OAuthAccessToken) && !string.IsNullOrEmpty(_settings.OAuthAccessTokenSecret))
        {
            return;
        }

        throw new AuthenticationRequiredException();
    }

    /// <summary>
    /// Calculates the Flickr method cal URL based on the passed in parameters, and also generates
    /// the signature if required.
    /// </summary>
    /// <param name="parameters">
    /// A Dictionary containing a list of parameters to add to the method call.
    /// </param>
    /// <param name="includeSignature">
    /// Boolean use to decide whether to generate the api call signature as well.
    /// </param>
    /// <returns>The <see cref="Uri"/> for the method call.</returns>
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
            url.AppendFormat(System.Globalization.CultureInfo.InvariantCulture, "{0}={1}&", pair.Key, escapedValue);
        }

        return BaseUri.AbsoluteUri + url.ToString();
    }

    private string CalculateAuthSignature(Dictionary<string, string> parameters)
    {
        var sorted = parameters.OrderBy(p => p.Key);

        var sb = new StringBuilder(_settings.ApiKey);
        foreach (var pair in sorted)
        {
            sb.Append(pair.Key);
            sb.Append(pair.Value);
        }
        return UtilityMethods.MD5Hash(sb.ToString());
    }

    private static MultipartFormDataContent CreateUploadData(Stream imageStream, string fileName, IProgress<double> progress, Dictionary<string, string> parameters, string boundary, CancellationToken cancellationToken = default)
    {
        //bool oAuth = parameters.ContainsKey("oauth_consumer_key");

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

    private static Stream ConvertNonSeekableStreamToByteArray(Stream nonSeekableStream)
    {
        if (nonSeekableStream.CanSeek)
        {
            nonSeekableStream.Position = 0;
            return nonSeekableStream;
        }

        return nonSeekableStream;
    }
}

internal static class FlickrExtensions
{
    /// <summary>
    /// Whether a given character is allowed by XML 1.0.
    /// </summary>
    private static bool IsLegalXmlChar(int character)
    {
        return
        (
             character == 0x9 /* == '\t' == 9   */          ||
             character == 0xA /* == '\n' == 10  */          ||
             character == 0xD /* == '\r' == 13  */          ||
            (character >= 0x20 && character <= 0xD7FF) ||
            (character >= 0xE000 && character <= 0xFFFD) ||
            (character >= 0x10000 && character <= 0x10FFFF)
        );
    }
}