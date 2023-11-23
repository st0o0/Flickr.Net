using System.Text;
using System.Xml.Linq;
using Flickr.Net.Flickrs.Results;
using Flickr.Net.Internals;
using Newtonsoft.Json;

namespace Flickr.Net.Test.Entities;

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

        var doc = XDocument.Parse(xml);
        var json = JsonConvert.SerializeXNode(doc, Formatting.None, omitRootObject: true);

        var result = FlickrConvert.DeserializeObject<FlickrExtendedDataResult>(Encoding.UTF8.GetBytes(json));

        Assert.NotNull(result);
        Assert.False(result.HasError);
        Assert.True(result.Content.TryGetValue("photoid", out var value));
        Assert.Equal("1234", value.GetProperty("#text").GetString());
    }

    [Fact]
    public void UploadResponse()
    {
        var xml = """
            <rsp stat="ok">
            <photoid>1234</photoid>
            </rsp>
            """;

        var doc = XDocument.Parse(xml);
        var json = JsonConvert.SerializeXNode(doc, Formatting.None, omitRootObject: true);
        var result = FlickrConvert.DeserializeObject<FlickrExtendedDataResult>(Encoding.UTF8.GetBytes(json));

        Assert.NotNull(result);
        Assert.False(result.HasError);
        Assert.True(result.Content.TryGetValue("photoid", out var value));
        Assert.Equal("1234", value.GetString());
    }
}