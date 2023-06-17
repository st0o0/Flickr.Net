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
    public void WoeId_To_String()
    {
        var id = "Test";
        var test = string.Join(",", new[] { new WoeId(id), new WoeId("KEKW") });
        Assert.Contains(id, test);
    }

    /// <summary>
    /// Tests the.
    /// </summary>
    [Fact]
    public void PlaceId_To_String()
    {
        var id = "Test";
        var test = string.Join(",", new[] { new PlaceId(id), new PlaceId("KEKW") });
        Assert.Contains(id, test);
    }

    /// <summary>
    /// Tests the.
    /// </summary>
    [Fact]
    public void String_To_PlaceId()
    {
        var id = "Test";
        PlaceId placeId = id;

        Assert.Equal(id, placeId);
    }

    /// <summary>
    /// Tests the.
    /// </summary>
    [Fact]
    public void String_To_WoeId()
    {
        var id = "Test";
        WoeId woeId = id;

        Assert.Equal(id, woeId);
    }

    private void TESTTEST()
    {
        var t = new Flickr(null, null);
        //t.
    }
}
