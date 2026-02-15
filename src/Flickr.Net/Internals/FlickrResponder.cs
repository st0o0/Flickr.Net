using System.Text;

namespace Flickr.Net.Internals;

/// <summary>
/// Flickr library interaction with the web goes in here.
/// </summary>
public static partial class FlickrResponder
{
    /// <summary>
    /// Returns the string for the Authorisation header to be used for OAuth authentication.
    /// Parameters other than OAuth ones are ignored.
    /// </summary>
    /// <param name="parameters">OAuth and other parameters.</param>
    /// <returns></returns>
    public static string OAuthCalculateAuthHeader(Dictionary<string, string> parameters)
    {
        var sb = new StringBuilder();
        var parametersStartingWithOauth = parameters
            .Where(pair => pair.Key.StartsWith("oauth", StringComparison.Ordinal));
        foreach (var pair in parametersStartingWithOauth)
        {
            sb.Append(pair.Key + "=\"" + Uri.EscapeDataString(pair.Value) + "\",");
        }
        return sb.Remove(sb.Length - 1, 1).ToString();
    }
}