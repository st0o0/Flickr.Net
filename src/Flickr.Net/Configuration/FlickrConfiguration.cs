using Flickr.Net.Enums;

namespace Flickr.Net.Configuration;

/// <summary>
/// The flickr configuration.
/// </summary>
public class FlickrConfiguration
{
    /// <summary>
    /// Gets or sets the api key.
    /// </summary>
    public string ApiKey { get; set; }

    /// <summary>
    /// Gets or sets the shared secret.
    /// </summary>
    public string SharedSecret { get; set; }

    /// <summary>
    /// Gets or sets the default extras to include in photo search results.
    /// When set, these extras are automatically merged with any extras specified in
    /// <see cref="PhotoSearchOptions.Extras"/> on a per-call basis.
    /// </summary>
    /// <example>
    /// <code>
    /// var config = new FlickrConfiguration
    /// {
    ///     ApiKey = "...",
    ///     DefaultSearchExtras = PhotoSearchExtras.Description | PhotoSearchExtras.DateTaken
    /// };
    /// var flickr = new FlickrClient(config);
    /// // All SearchAsync calls will now include description and date_taken automatically
    /// </code>
    /// </example>
    public PhotoSearchExtras? DefaultSearchExtras { get; set; }
}
