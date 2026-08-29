using System.Text;
using Flickr.Net.Internals;

namespace Flickr.Net.Exceptions;

/// <summary>
/// An OAuth error occurred when calling one of the OAuth authentication flow methods.
/// </summary>
public class OAuthException : Exception
{
    private readonly string _mess;

    /// <summary>
    /// The full response of the exception.
    /// </summary>
    public string FullResponse { get; set; }

    /// <summary>
    /// The list of error parameters returned by the OAuth exception.
    /// </summary>
    public Dictionary<string, string> OAuthErrorPameters { get; set; }

    /// <summary>
    /// Constructor for the OAuthException class.
    /// </summary>
    /// <param name="response"></param>
    /// <param name="innerException"></param>
    public OAuthException(string response, Exception innerException) : base("OAuth Exception", innerException)
    {
        FullResponse = response;

        try
        {
            OAuthErrorPameters = UtilityMethods.StringToDictionary(response);
        }
        catch (Exception)
        {
            OAuthErrorPameters = [];
        }

        _mess = "OAuth Exception occurred: " +
            (OAuthErrorPameters.TryGetValue("oauth_problem", out var problem) ? problem : FullResponse);
    }

    /// <summary>
    /// Constructor for the OAuthException class.
    /// </summary>
    /// <param name="response"></param>
    /// <param name="innerException"></param>
    public OAuthException(byte[] response, Exception innerException)
        : this(Encoding.UTF8.GetString(response), innerException)
    {
    }

    /// <summary>
    /// The message for the exception.
    /// </summary>
    public override string Message => _mess;
}
