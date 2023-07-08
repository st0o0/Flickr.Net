using Flickr.Net.Core.Entities;

namespace Flickr.Net.Core.Test;

/// <summary>
/// The blub test.
/// </summary>
public class StringToIdTests
{
    /// <summary>
    /// Tests the.
    /// </summary>
    [Fact]
    public void WoeId_To_String()
    {
        var id = "Test";
        Assert.Equal(id, new WoeId(id));
    }

    /// <summary>
    /// Tests the.
    /// </summary>
    [Fact]
    public void PlaceId_To_String()
    {
        var id = "Test";
        Assert.Equal(id, new PlaceId(id));
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
}