using System.Text;
using Flickr.Net.Flickrs.Results;
using Flickr.Net.Internals;

namespace Flickr.Net.Test.Entities;

public class RawTagTests
{
    [Fact]
    public void JsonStringToRawTags()
    {
        const string json = """
            {
                "tags": {
                    "tag": [
                        {
                            "clean": "sunset",
                            "raw": [
                                { "_content": "Sunset" },
                                { "_content": "SUNSET" },
                                { "_content": "sun set" }
                            ]
                        },
                        {
                            "clean": "landscape",
                            "raw": [
                                { "_content": "Landscape" }
                            ]
                        }
                    ]
                },
                "stat": "ok"
            }
            """;

        var result = FlickrConvert.DeserializeObject<FlickrResult<RawTags>>(Encoding.UTF8.GetBytes(json));

        Assert.NotNull(result);
        Assert.False(result.HasError);
        var rawTags = result.Content;
        Assert.IsType<RawTags>(rawTags);
        Assert.Equal(2, rawTags.Values.Count);

        var sunset = rawTags.Values[0];
        Assert.Equal("sunset", sunset.Clean);
        Assert.NotNull(sunset.Raw);
        Assert.Equal(3, sunset.Raw!.Count);
        Assert.Equal("Sunset", sunset.Raw[0].Content);
        Assert.Equal("SUNSET", sunset.Raw[1].Content);
        Assert.Equal("sun set", sunset.Raw[2].Content);

        var landscape = rawTags.Values[1];
        Assert.Equal("landscape", landscape.Clean);
        Assert.Single(landscape.Raw!);
    }
}
