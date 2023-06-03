using Flickr.Net.Core.Configuration;

namespace Flickr.Net.Core.Test;

public class BlubTest
{
    [Fact]
    public void Test()
    {
        var t = new FlickrConfigurationSettings();
        Assert.NotNull(t);
    }
}