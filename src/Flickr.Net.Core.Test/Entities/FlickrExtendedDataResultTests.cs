using System.Xml.Linq;
using Flickr.Net.Core.Flickrs.Results;
using Flickr.Net.Core.Internals;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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

        var doc = XDocument.Parse(xml);
        var json = JsonConvert.SerializeXNode(doc, Formatting.None, omitRootObject: true);
        var result = FlickrConvert.DeserializeObject<FlickrExtendedDataResult>(json);

        Assert.NotNull(result);
        Assert.False(result.HasError);
        Assert.True(result.Content.TryGetValue("photoid", out var value));
        Assert.Equal("1234", value.Value<string>("#text"));
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
        var result = FlickrConvert.DeserializeObject<FlickrExtendedDataResult>(json);

        Assert.NotNull(result);
        Assert.False(result.HasError);
        Assert.True(result.Content.TryGetValue("photoid", out var value));
        Assert.Equal("1234", value.Value<string>());
    }
}
