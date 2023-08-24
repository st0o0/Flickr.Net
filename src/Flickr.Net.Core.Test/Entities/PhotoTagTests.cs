using System.Text;
using Flickr.Net.Core.Flickrs.Results;
using Flickr.Net.Core.Internals;
using Newtonsoft.Json;

namespace Flickr.Net.Core.Test.Entities;

public class PhotoTagTests
{
    [Fact]
    public void JsonStringToPhotoTags()
    {
        var json = /*lang=json,strict*/ """
            {
                "photo": {
                    "id": "2619",
                    "tags": {
                        "tag": [
                            {
                                "id": "6335-2619-14731",
                                "author": "35034351963@N01",
                                "authorname": "RodBegbie",
                                "raw": "sfa",
                                "_content": "sfa",
                                "machine_tag": 0
                            },
                            {
                                "id": "6335-2619-2757",
                                "author": "35034351963@N01",
                                "authorname": "RodBegbie",
                                "raw": "concert",
                                "_content": "concert",
                                "machine_tag": 0
                            },
                            {
                                "id": "6335-2619-19582",
                                "author": "35034351963@N01",
                                "authorname": "RodBegbie",
                                "raw": "superfurryanimals",
                                "_content": "superfurryanimals",
                                "machine_tag": 0
                            }
                        ]
                    }
                },
                "stat": "ok"
            }
            """;

        using var ms = new MemoryStream(Encoding.UTF8.GetBytes(json));

        var result = FlickrConvert.DeserializeObject<FlickrResult<PhotoTags>>(ms);

        Assert.NotNull(result);
        Assert.False(result.HasError);
        var items = result.Content;
        Assert.IsType<PhotoTags>(items);
        Assert.NotEmpty(items.Tags.Values);
        Assert.Equal(3, items.Tags.Values.Count);
    }
}
