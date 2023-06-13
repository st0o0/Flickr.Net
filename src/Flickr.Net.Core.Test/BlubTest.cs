using Flickr.Net.Core.Configuration;
using Flickr.Net.Core.Entities;

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

    /// <summary>
    /// Tests the.
    /// </summary>
    [Fact]
    public void WoeId_Is_Type_String()
    {
        var id = "Test";
        var test = string.Join(",", new[] { new WoeId(id), new WoeId("KEKW") });
        Assert.Contains(id, test);
    }

    /// <summary>
    /// Tests the.
    /// </summary>
    [Fact]
    public void PlaceId_Is_Type_String()
    {
        var id = "Test";
        var test = string.Join(",", new[] { new PlaceId(id), new PlaceId("KEKW") });
        Assert.Contains(id, test);
    }

    private void TESTTEST()
    {
        var t = new Flickr(null, null);
        //t.
    }
}
