using System.Text;
using Flickr.Net.Exceptions;

namespace Flickr.Net.Test.Entities;

public class OAuthExceptionTests
{
    [Fact]
    public void Constructor_ParsesOAuthProblem_FromErrorResponse()
    {
        var response = "oauth_problem=signature_invalid&oauth_problem_advice=check%20the%20secret";

        var ex = new OAuthException(response, new InvalidOperationException());

        Assert.Equal("OAuth Exception occurred: signature_invalid", ex.Message);
        Assert.Equal("signature_invalid", ex.OAuthErrorPameters["oauth_problem"]);
        Assert.Equal("check the secret", ex.OAuthErrorPameters["oauth_problem_advice"]);
        Assert.Equal(response, ex.FullResponse);
    }

    [Fact]
    public void Constructor_FallsBackToRawResponse_WhenOAuthProblemMissing()
    {
        var ex = new OAuthException("{\"code\":100,\"message\":\"Invalid API Key\"}", new InvalidOperationException());

        Assert.Contains("Invalid API Key", ex.Message);
        Assert.False(ex.OAuthErrorPameters.ContainsKey("oauth_problem"));
    }

    [Fact]
    public void Constructor_EmptyResponse_DoesNotThrow()
    {
        var ex = new OAuthException("", new InvalidOperationException());

        Assert.Equal("OAuth Exception occurred: ", ex.Message);
    }

    [Fact]
    public void Constructor_MalformedResponse_DoesNotThrow()
    {
        // Duplicate keys make the parser throw ArgumentException; the constructor must
        // fall back to the raw response instead of crashing and masking the real error.
        var ex = new OAuthException("a=1&a=2", new InvalidOperationException());

        Assert.Contains("a=1&a=2", ex.Message);
    }

    [Fact]
    public void Constructor_ByteResponse_BehavesLikeStringResponse()
    {
        var ex = new OAuthException(Encoding.UTF8.GetBytes("oauth_problem=timestamp_refused"), new InvalidOperationException());

        Assert.Equal("OAuth Exception occurred: timestamp_refused", ex.Message);
        Assert.Equal("oauth_problem=timestamp_refused", ex.FullResponse);
    }
}
