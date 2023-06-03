using Flickr.Net.Core.Entities;
using Flickr.Net.Core.Entities.Interfaces;
using Flickr.Net.Core.Enums;
using Flickr.Net.Core.Internals;

namespace Flickr.Net.Core;

public partial class Flickr : IFlickrUpload
{
    public async Task<string> UploadPictureAsync(Stream stream, string fileName, string title,
         string description, string tags, bool isPublic, bool isFamily, bool isFriend,
         ContentType contentType, SafetyLevel safetyLevel, HiddenFromSearch hiddenFromSearch,
         IProgress<double> progress, CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Uri uploadUri = new(UploadUrl);

        Dictionary<string, string> parameters = new();

        if (title != null && title.Length > 0)
        {
            parameters.Add("title", title);
        }

        if (description != null && description.Length > 0)
        {
            parameters.Add("description", description);
        }

        if (tags != null && tags.Length > 0)
        {
            parameters.Add("tags", tags);
        }

        parameters.Add("is_public", isPublic ? "1" : "0");
        parameters.Add("is_friend", isFriend ? "1" : "0");
        parameters.Add("is_family", isFamily ? "1" : "0");

        if (safetyLevel != SafetyLevel.None)
        {
            parameters.Add("safety_level", safetyLevel.ToString("D"));
        }

        if (contentType != ContentType.None)
        {
            parameters.Add("content_type", contentType.ToString("D"));
        }

        if (hiddenFromSearch != HiddenFromSearch.None)
        {
            parameters.Add("hidden", hiddenFromSearch.ToString("D"));
        }

        if (!string.IsNullOrEmpty(OAuthAccessToken))
        {
            parameters.Remove("api_key");
            OAuthGetBasicParameters(parameters);
            parameters.Add("oauth_token", OAuthAccessToken);
            string sig = OAuthCalculateSignature("POST", uploadUri.AbsoluteUri, parameters, OAuthAccessTokenSecret);
            parameters.Add("oauth_signature", sig);
        }
        else
        {
            parameters.Add("auth_token", _apiToken ?? string.Empty);
        }

        return await UploadDataAsync(stream, fileName, progress, uploadUri, parameters, cancellationToken);
    }

    public async Task<string> ReplacePictureAsync(Stream stream, string fileName, string photoId, IProgress<double> progress, CancellationToken cancellationToken)
    {
        Uri replaceUri = new(ReplaceUrl);

        Dictionary<string, string> parameters = new()
        {
            { "photo_id", photoId },
            { "api_key", ApiKey }
        };

        parameters.Add("api_key", _apiToken ?? string.Empty);

        if (!string.IsNullOrEmpty(OAuthAccessToken))
        {
            parameters.Remove("api_key");
            OAuthGetBasicParameters(parameters);
            parameters.Add("oauth_token", OAuthAccessToken);
            string sig = OAuthCalculateSignature("POST", replaceUri.AbsoluteUri, parameters, OAuthAccessTokenSecret);
            parameters.Add("oauth_signature", sig);
        }
        else
        {
            parameters.Add("auth_token", _apiToken ?? string.Empty);
        }

        return await UploadDataAsync(stream, fileName, progress, replaceUri, parameters, cancellationToken);
    }

    private static async Task<string> UploadDataAsync(Stream imageStream, string fileName, IProgress<double> progress, Uri uploadUri, Dictionary<string, string> parameters, CancellationToken cancellationToken = default)
    {
        string authHeader = FlickrResponder.OAuthCalculateAuthHeader(parameters);

        string boundary = "FLICKR_MIME_" + DateTime.Now.ToString("yyyyMMddhhmmss", System.Globalization.DateTimeFormatInfo.InvariantInfo);

        MultipartFormDataContent content = CreateUploadData(imageStream, fileName, progress, parameters, boundary, cancellationToken);

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

        HttpResponseMessage responseMessage = await new HttpClient().SendAsync(requestMessage, cancellationToken);

        responseMessage.EnsureSuccessStatusCode();

        UnknownResponse t = new();
        ((IFlickrParsable)t).Load(await responseMessage.Content.ReadAsByteArrayAsync(cancellationToken));
        return t.GetElementValue("photoid");

        //HttpWebRequest req = (HttpWebRequest)WebRequest.Create(uploadUri);
        //req.Method = "POST";
        //req.ContentType = "multipart/form-data; boundary=" + boundary;
        //req.SendChunked = true;
        //req.AllowWriteStreamBuffering = false;

        //if (!string.IsNullOrEmpty(authHeader))
        //{
        //    req.Headers["Authorization"] = authHeader;
        //}

        //req.BeginGetRequestStream(
        //    r =>
        //    {
        //        using (Stream reqStream = req.EndGetRequestStream(r))
        //        {
        //            int bufferSize = 32 * 1024;
        //            if (dataBuffer.Length / 100 > bufferSize)
        //            {
        //                bufferSize = bufferSize * 2;
        //            }

        //            dataBuffer.UploadProgress += (o, e) => { if (OnUploadProgress != null) { OnUploadProgress(this, e); } };
        //            dataBuffer.CopyTo(reqStream, bufferSize);
        //            reqStream.Close();
        //        }

        //        req.BeginGetResponse(
        //            r2 =>
        //            {
        //                FlickrResult<string> result = new FlickrResult<string>();

        //                try
        //                {
        //                    WebResponse res = req.EndGetResponse(r2);
        //                    StreamReader sr = new(res.GetResponseStream());
        //                    string responseXml = sr.ReadToEnd();
        //                    sr.Close();

        //                    UnknownResponse t = new();
        //                    ((IFlickrParsable)t).Load(responseXml);
        //                    result.Result = t.GetElementValue("photoid");
        //                    result.HasError = false;
        //                }
        //                catch (Exception ex)
        //                {
        //                    if (ex is WebException)
        //                    {
        //                        OAuthException oauthEx = new(ex);
        //                        result.Error = string.IsNullOrEmpty(oauthEx.Message) ? ex : oauthEx;
        //                    }
        //                    else
        //                    {
        //                        result.Error = ex;
        //                    }
        //                }

        //                callback(result);
        //            },
        //            this);
        //    },
        //    this);
    }
}

public interface IFlickrUpload
{
    /// <summary>
    /// UploadPicture method that does all the uploading work.
    /// </summary>
    /// <param name="stream">The <see cref="Stream"/> object containing the pphoto to be uploaded.</param>
    /// <param name="fileName">The filename of the file to upload. Used as the title if title is null.</param>
    /// <param name="title">The title of the photo (optional).</param>
    /// <param name="description">The description of the photograph (optional).</param>
    /// <param name="tags">The tags for the photograph (optional).</param>
    /// <param name="isPublic">false for private, true for public.</param>
    /// <param name="isFamily">true if visible to family.</param>
    /// <param name="isFriend">true if visible to friends only.</param>
    /// <param name="contentType">The content type of the photo, i.e. Photo, Screenshot or Other.</param>
    /// <param name="safetyLevel">The safety level of the photo, i.e. Safe, Moderate or Restricted.</param>
    /// <param name="hiddenFromSearch">Is the photo hidden from public searches.</param>
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
    Task<string> ReplacePictureAsync(Stream stream, string fileName, string photoId, IProgress<double> progress = default, CancellationToken cancellationToken = default);
}