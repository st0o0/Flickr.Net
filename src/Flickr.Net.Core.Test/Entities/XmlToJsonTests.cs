using System.Xml.Linq;
using Flickr.Net.Core.Flickrs.Results;
using Flickr.Net.Core.Internals;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Flickr.Net.Core.Test.Entities;

public class XmlToJsonTests
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
        var result = FlickrConvert.DeserializeObject<Dictionary<string, JToken>>(json);

        Assert.NotNull(result);
        Assert.True(result.ContainsKey("@stat"));
        Assert.True(result.ContainsKey("photoid"));
        var t = result.GetValueOrDefault("photoid");
        Assert.Equal(1234, t.Value<int>("#text"));
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
        var result = FlickrConvert.DeserializeObject<Dictionary<string, JToken>>(json);

        Assert.NotNull(result);
        Assert.True(result.ContainsKey("@stat"));
        Assert.True(result.ContainsKey("photoid"));
    }
}
