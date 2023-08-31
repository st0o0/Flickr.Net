using System.Text;
using Flickr.Net.Core.Flickrs.Results;
using Flickr.Net.Core.Internals;

namespace Flickr.Net.Core.Test.Entities;

public class ViewsTests
{
    [Fact]
    public void JsonStringToViews()
    {
        var json = /*lang=json,strict*/ """
            {
              "stat": "ok",
              "stats": {
                "total": {
                  "views": "469"
                },
                "photos": {
                  "views": "386"
                },
                "photostream": {
                  "views": "72"
                },
                "sets": {
                  "views": "11"
                },
                "collections": {
                  "views": "0"
                }
              }
            }
            """;

        using var ms = new MemoryStream(Encoding.UTF8.GetBytes(json));

        var result = FlickrConvert.DeserializeObject<FlickrResult<Views>>(ms);

        Assert.NotNull(result);
        Assert.False(result.HasError);
        var items = result.Content;
        Assert.IsType<Views>(items);
        Assert.Equal(469, items.Total.Views);
        Assert.Equal(386, items.Photos.Views);
        Assert.Equal(72, items.Photostream.Views);
        Assert.Equal(11, items.Sets.Views);
        Assert.Equal(0, items.Collections.Views);
    }
}
