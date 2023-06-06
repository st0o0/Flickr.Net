using FlickrNet.Core.Configuration;

namespace Flickr.Net.Core.Test;

public class BlubTest
{
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
