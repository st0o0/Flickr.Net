using System.Text;
using System.Text.Json;
using Flickr.Net.Core.Flickrs.Results;
using Flickr.Net.Core.Internals.Extensions;
using Newtonsoft.Json.Linq;

namespace Flickr.Net.Core;

/// <summary>
/// The flickr.
/// </summary>
public partial class Flickr : IFlickrUpload
{
    async Task<string> IFlickrUpload.UploadPictureAsync(Stream stream, string fileName, string title,
         string description, string tags, bool isPublic, bool isFamily, bool isFriend,
         ContentType contentType, SafetyLevel safetyLevel, HiddenFromSearch hiddenFromSearch,
         IProgress<double> progress, CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Uri uploadUri = new(UploadUrl);

        Dictionary<string, string> parameters = new();

        parameters.AppendIf("title", title, x => x != null && x.Length > 0, x => x);

        parameters.AppendIf("description", description, x => x != null && x.Length > 0, x => x);

        parameters.AppendIf("tags", tags, x => x != null && x.Length > 0, x => x);

        parameters.Add("is_public", isPublic ? "1" : "0");

        parameters.Add("is_friend", isFriend ? "1" : "0");

        parameters.Add("is_family", isFamily ? "1" : "0");

        parameters.AppendIf("safety_level", safetyLevel, x => x != SafetyLevel.None, x => x.ToString("D"));

        parameters.AppendIf("content_type", contentType, x => x != ContentType.None, x => x.ToString("D"));

        parameters.AppendIf("hidden", hiddenFromSearch, x => x != HiddenFromSearch.None, x => x.ToString("D"));

        if (!string.IsNullOrEmpty(FlickrSettings.OAuthAccessToken))
        {
            parameters.Remove("api_key");
            OAuthGetBasicParameters(parameters);
            parameters.Add("oauth_token", FlickrSettings.OAuthAccessToken);
            var sig = ((IFlickrOAuth)this).CalculateSignature("POST", uploadUri.AbsoluteUri, parameters, FlickrSettings.OAuthAccessTokenSecret);
            parameters.Add("oauth_signature", sig);
        }
        else
        {
            parameters.Add("auth_token", _settings.ApiKey ?? string.Empty);
        }

        var result = await UploadDataAsync(stream, fileName, progress, uploadUri, parameters, cancellationToken);

        return result.GetString();
    }

    async Task<string> IFlickrUpload.ReplacePictureAsync(Stream stream, string fileName, string photoId, IProgress<double> progress, CancellationToken cancellationToken)
    {
        Uri replaceUri = new(ReplaceUrl);

        Dictionary<string, string> parameters = new()
        {
            { "photo_id", photoId },
            { "api_key", FlickrSettings.ApiKey ?? string.Empty }
        };

        if (!string.IsNullOrEmpty(FlickrSettings.OAuthAccessToken))
        {
            parameters.Remove("api_key");
            OAuthGetBasicParameters(parameters);
            parameters.Add("oauth_token", FlickrSettings.OAuthAccessToken);
            var sig = ((IFlickrOAuth)this).CalculateSignature("POST", replaceUri.AbsoluteUri, parameters, FlickrSettings.OAuthAccessTokenSecret);
            parameters.Add("oauth_signature", sig);
        }
        else
        {
            parameters.Add("auth_token", _settings.ApiKey ?? string.Empty);
        }

        var result = await UploadDataAsync(stream, fileName, progress, replaceUri, parameters, cancellationToken);
        return result.GetProperty("#text").GetString();
    }

    private static async Task<JsonElement> UploadDataAsync(Stream imageStream, string fileName, IProgress<double> progress, Uri uploadUri, Dictionary<string, string> parameters, CancellationToken cancellationToken = default)
    {
        var authHeader = FlickrResponder.OAuthCalculateAuthHeader(parameters);

        var boundary = "FLICKR_MIME_" + DateTime.Now.ToString("yyyyMMddhhmmss", System.Globalization.DateTimeFormatInfo.InvariantInfo);

        var content = CreateUploadData(imageStream, fileName, progress, parameters, boundary, cancellationToken);

        HttpRequestMessage requestMessage = new()
        {
            RequestUri = uploadUri,
            Method = HttpMethod.Post,
            Content = content,
        };

        if (!string.IsNullOrEmpty(authHeader))
        {
            requestMessage.Headers.Add("Authorization", authHeader);
        }

        var client = new HttpClient();

        var responseMessage = await client.SendAsync(requestMessage, cancellationToken);

        responseMessage.EnsureSuccessStatusCode();

        var xml = await responseMessage.Content.ReadAsStringAsync(cancellationToken);
        var json = FlickrConvert.XmlToJson(xml);

        using var ms = new MemoryStream(Encoding.UTF8.GetBytes(json));

        var flickrResults = FlickrConvert.DeserializeObject<FlickrExtendedDataResult>(ms);

        flickrResults = flickrResults.EnsureSuccessStatusCode();

        if (flickrResults.Content.TryGetValue("photoid", out var value))
        {
            return value;
        }

        throw new InvalidOperationException(nameof(flickrResults.Content));
    }
}

/// <summary>
/// The flickr upload.
/// </summary>
public interface IFlickrUpload
{
    /// <summary>
    /// UploadPicture method that does all the uploading work.
    /// </summary>
    /// <param name="stream">The <see cref="Stream"/> object containing the pphoto to be uploaded.</param>
    /// <param name="fileName">
    /// The filename of the file to upload. Used as the title if title is null.
    /// </param>
    /// <param name="title">The title of the photo (optional).</param>
    /// <param name="description">The description of the photograph (optional).</param>
    /// <param name="tags">The tags for the photograph (optional).</param>
    /// <param name="isPublic">false for private, true for public.</param>
    /// <param name="isFamily">true if visible to family.</param>
    /// <param name="isFriend">true if visible to friends only.</param>
    /// <param name="contentType">The content type of the photo, i.e. Photo, Screenshot or Other.</param>
    /// <param name="safetyLevel">The safety level of the photo, i.e. Safe, Moderate or Restricted.</param>
    /// <param name="hiddenFromSearch">Is the photo hidden from public searches.</param>
    /// <param name="progress"></param>
    /// <param name="cancellationToken"></param>
    Task<string> UploadPictureAsync(Stream stream, string fileName, string title = null,
        string description = null, string tags = null, bool isPublic = false, bool isFamily = false, bool isFriend = false,
        ContentType contentType = ContentType.None, SafetyLevel safetyLevel = SafetyLevel.None, HiddenFromSearch hiddenFromSearch = HiddenFromSearch.None,
        IProgress<double> progress = default, CancellationToken cancellationToken = default);

    /// <summary>
    /// Replace an existing photo on Flickr.
    /// </summary>
    /// <param name="stream">The <see cref="Stream"/> object containing the photo to be uploaded.</param>
    /// <param name="fileName">The filename of the file to replace the existing item with.</param>
    /// <param name="photoId">The ID of the photo to replace.</param>
    /// <param name="progress"></param>
    /// <param name="cancellationToken"></param>
    Task<string> ReplacePictureAsync(Stream stream, string fileName, string photoId, IProgress<double> progress = default, CancellationToken cancellationToken = default);
}
