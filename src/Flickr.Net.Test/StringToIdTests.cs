using Flickr.Net.Entities;
using Xunit;

namespace Flickr.Net.Test;

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
        const string id = "Test";
        Assert.Equal(id, new WoeId(id));
    }

    /// <summary>
    /// Tests the.
    /// </summary>
    [Fact]
    public void PlaceId_To_String()
    {
        const string id = "Test";
        Assert.Equal(id, new PlaceId(id));
    }

    /// <summary>
    /// Tests the.
    /// </summary>
    [Fact]
    public void String_To_PlaceId()
    {
        const string id = "Test";
        PlaceId placeId = id;

        Assert.Equal(id, placeId);
    }

    /// <summary>
    /// Tests the.
    /// </summary>
    [Fact]
    public void String_To_WoeId()
    {
        const string id = "Test";
        WoeId woeId = id;

        Assert.Equal(id, woeId);
    }
}