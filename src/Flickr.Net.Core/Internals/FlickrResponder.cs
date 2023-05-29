using System.Text;

namespace FlickrNet.Core.Internals;

/// <summary>
/// Flickr library interaction with the web goes in here.
/// </summary>
public static partial class FlickrResponder
{
    private const string PostContentType = "application/x-www-form-urlencoded";

    /// <summary>
    /// Returns the string for the Authorisation header to be used for OAuth authentication.
    /// Parameters other than OAuth ones are ignored.
    /// </summary>
    /// <param name="parameters">OAuth and other parameters.</param>
    /// <returns></returns>
    public static string OAuthCalculateAuthHeader(Dictionary<string, string> parameters)
    {
        var sb = new StringBuilder("OAuth ");
        var parametersStartingWithOauth = parameters
            .Where((pair) => pair.Key.StartsWith("oauth", StringComparison.Ordinal));
        foreach (var pair in parametersStartingWithOauth)
        {
            sb.Append(pair.Key + "=\"" + Uri.EscapeDataString(pair.Value) + "\",");
        }
        return sb.Remove(sb.Length - 1, 1).ToString();
    }

    /// <summary>
    /// Calculates for form encoded POST data to be included in the body of an OAuth call.
    /// </summary>
    /// <remarks>This will include all non-OAuth parameters. The OAuth parameter will be included in the Authentication header.</remarks>
    /// <param name="parameters"></param>
    /// <returns></returns>
    public static string OAuthCalculatePostData(Dictionary<string, string> parameters)
    {
        var sb = new StringBuilder();

        var parametersStartingWithoutOauth = parameters
            .Where((pair) => !pair.Key.StartsWith("oauth", StringComparison.Ordinal));
        foreach (var pair in parametersStartingWithoutOauth)
        {
            sb.Append(pair.Key + "=" + UtilityMethods.EscapeDataString(pair.Value) + "&");
        }

        return sb.ToString();
    }
}