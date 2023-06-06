using FlickrNet.Core.Configuration;

namespace Flickr.Net.Core.Test;
/// <summary>
/// The blub test.
/// </summary>

public class BlubTest
{
    /// <summary>
    /// Tests the.
    /// </summary>
    [Fact]
    public void Test()
    {
        var t = new FlickrConfiguration();
        Assert.NotNull(t);
    }

    private void TESTTEST()
    {
        //var t = new Flickr(null, null);
        //t.
    }
}
