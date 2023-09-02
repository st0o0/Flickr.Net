using System.Text;
using System.Xml.Linq;
using Flickr.Net.Core.Flickrs.Results;
using Flickr.Net.Core.Internals;

namespace Flickr.Net.Core.Test.Entities;

public class FlickrExtendedDataResultTests
{
    [Fact]
    public void ReplaceReponse()
    {
        var xml = """
            <rsp stat="ok">
            <photoid secret="abcdef" originalsecret="abcdef">1234</photoid>
            </rsp>
            """;

        var json = FlickrConvert.XmlToJson(xml);
        using var ms = new MemoryStream(Encoding.UTF8.GetBytes(json));

        var result = FlickrConvert.DeserializeObject<FlickrExtendedDataResult>(ms);

        Assert.NotNull(result);
        Assert.False(result.HasError);
        Assert.True(result.TryGetContent(out var content));
        Assert.Equal("1234", content);
        Assert.Equal("1234", result.GetContent());
    }

    [Fact]
    public void UploadResponse()
    {
        var xml = """
            <rsp stat="ok">
            <photoid>1234</photoid>
            </rsp>
            """;

        var json = FlickrConvert.XmlToJson(xml);
        using var ms = new MemoryStream(Encoding.UTF8.GetBytes(json));

        var result = FlickrConvert.DeserializeObject<FlickrExtendedDataResult>(ms);

        Assert.NotNull(result);
        Assert.False(result.HasError);
        Assert.True(result.TryGetContent(out var content));
        Assert.Equal("1234", content);
        Assert.Equal("1234", result.GetContent());
    }
}