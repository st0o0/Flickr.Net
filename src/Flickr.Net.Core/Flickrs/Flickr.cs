using Flickr.Net.Core.Configuration;
using Flickr.Net.Core.Exceptions;
using Flickr.Net.Core.Exceptions.Handlers;
using Flickr.Net.Core.Internals.Caching;
using Flickr.Net.Core.Internals.HttpContents;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Xml;

namespace Flickr.Net.Core;

/// <summary>
/// The main Flickr class.
/// </summary>
/// <remarks>
/// Create an instance of this class and then call its methods to perform methods on Flickr.
/// </remarks>
/// <example>
/// <code>
/// FlickrNet.Flickr flickr = new FlickrNet.Flickr();
/// User user = flickr.PeopleFindByEmail("cal@iamcal.com");
/// Console.WriteLine("User Id is " + u.UserId);
/// </code>
/// </example>
public partial class Flickr
{
    private readonly Cache _cache;
    private readonly FlickrConfigurationSettings _settings;
    private readonly string _apiToken;
    private string _sharedSecret;
    private string _lastRequest;

    /// <summary>
    /// Constructor loads configuration settings from app.config or web.config file if they exist.
    /// </summary>
    public Flickr(FlickrConfigurationSettings settings)
    {
        _cache = new Cache(settings);
        _settings = settings;
        InstanceCacheDisabled = settings.CacheDisabled;
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
    /// Creates a new instance of the <see cref="Flickr"/> class with an API key and a Shared Secret.
    /// This is only useful really useful for calling the Auth functions as all other
    /// authenticationed methods also require the API Token.
    /// </summary>
    /// <param name="apiKey">Your Flickr API Key.</param>
    /// <param name="sharedSecret">Your Flickr Shared Secret.</param>
    public Flickr(string apiKey, string sharedSecret)
        : this(new FlickrConfigurationSettings() { ApiKey = apiKey, SharedSecret = sharedSecret })
    {
    }

    protected static string UploadUrl => "https://up.flickr.com/services/upload/";

    protected static string ReplaceUrl => "https://up.flickr.com/services/replace/";

    protected static string AuthUrl => "https://www.flickr.com/services/auth/";

    protected Cache Cache => _cache;

    /// <summary>
    /// property for all places functions
    /// </summary>
    public IFlickrPlaces Places => this;

    /// <summary>
    /// property for all tags functions
    /// </summary>
    public IFlickrTags Tags => this;

    /// <summary>
    /// property for all test functions
    /// </summary>
    public IFlickrTest Test => this;

    /// <summary>
    /// property for all upload functions
    /// </summary>
    public IFlickrUpload Upload => this;

    /// <summary>
    /// property for all urls functions
    /// </summary>
    public IFlickrUrls Urls => this;

    /// <summary>
    /// The base URL for all Flickr REST method calls.
    /// </summary>
    public static Uri BaseUri => new("https://api.flickr.com/services/rest/");

    /// <summary>
    /// Get or set the API Key to be used by all calls. API key is mandatory for all
    /// calls to Flickr.
    /// </summary>
    public string ApiKey => _settings.ApiKey;

    /// <summary>
    /// API shared secret is required for all calls that require signing, which includes
    /// all methods that require authentication, as well as the actual flickr.auth.* calls.
    /// </summary>
    public string ApiSecret => _settings.SharedSecret;

    /// <summary>
    /// OAuth Access Token. Needed for authenticated access using OAuth to Flickr.
    /// </summary>
    public string OAuthAccessToken { get; set; }

    /// <summary>
    /// OAuth Access Token Secret. Needed for authenticated access using OAuth to Flickr.
    /// </summary>
    public string OAuthAccessTokenSecret { get; set; }

    /// <summary>
    /// Gets or sets whether the cache should be disabled. Use only in extreme cases where you are sure you
    /// don't want any caching.
    /// </summary>
    public bool CacheDisabled => _settings.CacheDisabled;

    /// <summary>
    /// Override if the cache is disabled for this particular instance of <see cref="Flickr"/>.
    /// </summary>
    public bool InstanceCacheDisabled { get; set; }

    /// <summary>
    /// All GET calls to Flickr are cached by the Flickr.Net API. Set the <see cref="CacheTimeout"/>
    /// to determine how long these calls should be cached (make this as long as possible!)
    /// </summary>
    public TimeSpan CacheTimeout => _settings.CacheTimeout;

    /// <summary>
    /// Sets or gets the location to store the Cache files.
    /// </summary>
    public string CacheLocation => _settings.CacheLocation;

    /// <summary>
    /// <see cref="CacheSizeLimit"/> is the cache file size in bytes for downloaded
    /// pictures. The default is 50MB (or 50 * 1024 * 1025 in bytes).
    /// </summary>
    public static long CacheSizeLimit
    {
        get { return Cache.CacheSizeLimit; }
        set { Cache.CacheSizeLimit = value; }
    }

    /// <summary>
    /// Internal timeout for all web requests in milliseconds. Defaults to 30 seconds.
    /// </summary>
    public int HttpTimeout { get; set; } = 3600000;

    /// <summary>
    /// Checks to see if a shared secret and an api token are stored in the object.
    /// Does not check if these values are valid values.
    /// </summary>
    public bool IsAuthenticated
    {
        get
        {
            return _sharedSecret != null && _apiToken != null;
        }
    }

    /// <summary>
    /// Returns the raw XML returned from the last response.
    /// Only set it the response was not returned from cache.
    /// </summary>
    public byte[] LastResponse { get; private set; }

    /// <summary>
    /// Returns the last URL requested. Includes API signing.
    /// </summary>
    public string LastRequest
    {
        get { return _lastRequest; }
    }

    [MemberNotNull(nameof(ApiKey))]
    internal void CheckApiKey()
    {
        if (string.IsNullOrEmpty(ApiKey))
        {
            throw new ApiKeyRequiredException();
        }
    }

    [MemberNotNull(nameof(ApiSecret))]
    internal void CheckSigned()
    {
        CheckApiKey();

        if (string.IsNullOrEmpty(ApiSecret))
        {
            throw new SignatureRequiredException();
        }
    }

    [MemberNotNull(nameof(ApiSecret))]
    internal void CheckRequiresAuthentication()
    {
        CheckSigned();

        if (!string.IsNullOrEmpty(OAuthAccessToken) && !string.IsNullOrEmpty(OAuthAccessTokenSecret))
        {
            return;
        }

        throw new AuthenticationRequiredException();
    }

    /// <summary>
    /// Calculates the Flickr method cal URL based on the passed in parameters, and also generates the signature if required.
    /// </summary>
    /// <param name="parameters">A Dictionary containing a list of parameters to add to the method call.</param>
    /// <param name="includeSignature">Boolean use to decide whether to generate the api call signature as well.</param>
    /// <returns>The <see cref="Uri"/> for the method call.</returns>
    public string CalculateUri(Dictionary<string, string> parameters, bool includeSignature)
    {
        if (includeSignature)
        {
            string signature = CalculateAuthSignature(parameters);
            parameters.Add("api_sig", signature);
        }

        var url = new StringBuilder();
        url.Append('?');
        foreach (KeyValuePair<string, string> pair in parameters)
        {
            var escapedValue = UtilityMethods.EscapeDataString(pair.Value ?? "");
            url.AppendFormat(System.Globalization.CultureInfo.InvariantCulture, "{0}={1}&", pair.Key, escapedValue);
        }

        return BaseUri.AbsoluteUri + url.ToString();
    }

    private string CalculateAuthSignature(Dictionary<string, string> parameters)
    {
        var sorted = parameters.OrderBy(p => p.Key);

        var sb = new StringBuilder(ApiSecret);
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

        foreach (KeyValuePair<string, string> i in parameters)
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
    public static void Load(this IFlickrParsable item, byte[] bytes)
    {
        try
        {
            using MemoryStream ms = new(bytes);
            using XmlReader reader = XmlReader.Create(ms, new XmlReaderSettings
            {
                IgnoreWhitespace = true
            });

            if (!reader.ReadToDescendant("rsp"))
            {
                throw new Exception("Unable to find response element 'rsp' in Flickr response");
            }
            while (reader.MoveToNextAttribute())
            {
                if (reader.LocalName == "stat" && reader.Value == "fail")
                {
                    throw ExceptionHandler.CreateResponseException(reader);
                }
            }

            reader.MoveToElement();
            reader.Read();

            item.Load(reader);
        }
        catch (XmlException)
        {
            throw;
        }
    }

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
