using System.Text;
using Flickr.Net.Flickrs.Results;
using Flickr.Net.Internals;

namespace Flickr.Net.Test.Entities;

public class FlickrExtendedDataResultTests
{
    [Fact]
    public void ReplaceReponse()
    {
        const string xml = """
                           <rsp stat="ok">
                           <photoid secret="abcdef" originalsecret="abcdef">1234</photoid>
                           </rsp>
                           """;

        var json = FlickrConvert.XmlToJson(xml);
        var result = FlickrConvert.DeserializeObject<FlickrExtendedDataResult>(Encoding.UTF8.GetBytes(json));

        Assert.NotNull(result);
        Assert.False(result.HasError);
        Assert.True(result.Content.TryGetValue("photoid", out var value));
        Assert.Equal("1234", value.GetProperty("_content").GetString());
    }

    [Fact]
    public void UploadResponse()
    {
        const string xml = """
                           <rsp stat="ok">
                           <photoid>1234</photoid>
                           </rsp>
                           """;

        var json = FlickrConvert.XmlToJson(xml);
        var result = FlickrConvert.DeserializeObject<FlickrExtendedDataResult>(Encoding.UTF8.GetBytes(json));

        Assert.NotNull(result);
        Assert.False(result.HasError);
        Assert.True(result.Content.TryGetValue("photoid", out var value));
        Assert.Equal("1234", value.GetString());
    }
}
