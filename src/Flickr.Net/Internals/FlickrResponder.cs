using System.Text;

namespace Flickr.Net.Internals;

internal partial class FlickrResponder
{
    private readonly HttpClient _httpClient;

    internal FlickrResponder(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    internal static string OAuthCalculateAuthHeader(Dictionary<string, string> parameters)
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
