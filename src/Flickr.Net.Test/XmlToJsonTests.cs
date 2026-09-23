using System.Text.Json;
using Flickr.Net.Internals;

namespace Flickr.Net.Test;

public class XmlToJsonTests
{
    [Fact]
    public void SimpleElementWithAttributes()
    {
        var json = FlickrConvert.XmlToJson("<person id=\"123\" username=\"test\"/>");
        using var doc = JsonDocument.Parse(json);

        Assert.Equal("123", doc.RootElement.GetProperty("id").GetString());
        Assert.Equal("test", doc.RootElement.GetProperty("username").GetString());
    }

    [Fact]
    public void ElementWithTextAndAttributes()
    {
        var json = FlickrConvert.XmlToJson("<title lang=\"en\">Hello</title>");
        using var doc = JsonDocument.Parse(json);

        Assert.Equal("en", doc.RootElement.GetProperty("lang").GetString());
        Assert.Equal("Hello", doc.RootElement.GetProperty("_content").GetString());
    }

    [Fact]
    public void NestedElements()
    {
        var json = FlickrConvert.XmlToJson("<rsp><person><username>test</username></person></rsp>");
        using var doc = JsonDocument.Parse(json);

        var person = doc.RootElement.GetProperty("person");
        Assert.Equal("test", person.GetProperty("username").GetString());
    }

    [Fact]
    public void MultipleChildrenBecomeArray()
    {
        var json = FlickrConvert.XmlToJson("<photos><photo id=\"1\"/><photo id=\"2\"/></photos>");
        using var doc = JsonDocument.Parse(json);

        var photoArray = doc.RootElement.GetProperty("photo");
        Assert.Equal(JsonValueKind.Array, photoArray.ValueKind);
        Assert.Equal(2, photoArray.GetArrayLength());
        Assert.Equal("1", photoArray[0].GetProperty("id").GetString());
        Assert.Equal("2", photoArray[1].GetProperty("id").GetString());
    }

    [Fact]
    public void SingleChildRemainsObject()
    {
        var json = FlickrConvert.XmlToJson("<photos><photo id=\"1\"/></photos>");
        using var doc = JsonDocument.Parse(json);

        var photo = doc.RootElement.GetProperty("photo");
        Assert.Equal(JsonValueKind.Object, photo.ValueKind);
        Assert.Equal("1", photo.GetProperty("id").GetString());
    }

    [Fact]
    public void TextOnlyElement()
    {
        var json = FlickrConvert.XmlToJson("<root><name>John</name></root>");
        using var doc = JsonDocument.Parse(json);

        Assert.Equal("John", doc.RootElement.GetProperty("name").GetString());
    }

    [Fact]
    public void EmptyElement()
    {
        var json = FlickrConvert.XmlToJson("<empty/>");
        using var doc = JsonDocument.Parse(json);

        Assert.Equal(JsonValueKind.Object, doc.RootElement.ValueKind);
    }

    [Fact]
    public void MixedAttributesAndChildElements()
    {
        var json = FlickrConvert.XmlToJson(
            "<rsp stat=\"ok\"><photoid secret=\"abc\">1234</photoid></rsp>");
        using var doc = JsonDocument.Parse(json);

        Assert.Equal("ok", doc.RootElement.GetProperty("stat").GetString());
        var photoid = doc.RootElement.GetProperty("photoid");
        Assert.Equal("abc", photoid.GetProperty("secret").GetString());
        Assert.Equal("1234", photoid.GetProperty("_content").GetString());
    }

    [Fact]
    public void MultipleTextOnlyChildrenBecomeStringArray()
    {
        var json = FlickrConvert.XmlToJson(
            "<tags><tag>landscape</tag><tag>sunset</tag><tag>ocean</tag></tags>");
        using var doc = JsonDocument.Parse(json);

        var tagArray = doc.RootElement.GetProperty("tag");
        Assert.Equal(JsonValueKind.Array, tagArray.ValueKind);
        Assert.Equal(3, tagArray.GetArrayLength());
        Assert.Equal("landscape", tagArray[0].GetString());
        Assert.Equal("sunset", tagArray[1].GetString());
        Assert.Equal("ocean", tagArray[2].GetString());
    }

    [Fact]
    public void DeeplyNestedStructure()
    {
        var xml = "<rsp><photos><photo id=\"1\"><owner nsid=\"abc\"/></photo></photos></rsp>";
        var json = FlickrConvert.XmlToJson(xml);
        using var doc = JsonDocument.Parse(json);

        var owner = doc.RootElement
            .GetProperty("photos")
            .GetProperty("photo")
            .GetProperty("owner");
        Assert.Equal("abc", owner.GetProperty("nsid").GetString());
    }
}
