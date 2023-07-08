using Flickr.Net.Core.Flickrs.Results;
using Flickr.Net.Core.Internals;

namespace Flickr.Net.Core.Test.Entities;

public class PandaTests
{
    [Fact]
    public void JsonStringToPandas()
    {
        var json = /*lang=json,strict*/ """
            {
                "pandas": {
                    "panda": [
                        {
                            "_content": "ling ling"
                        },
                        {
                            "_content": "hsing hsing"
                        },
                        {
                            "_content": "wang wang"
                        }
                    ]
                },
                "stat": "ok"
            }
            """;

        var result = FlickrConvert.DeserializeObject<FlickrResult<Pandas>>(json);

        Assert.NotNull(result);
        Assert.False(result.HasError);
        var items = result.Content;
        Assert.IsType<Pandas>(items);
        Assert.IsType<Panda>(items.Values[0]);
        Assert.Equal("ling ling", items.Values[0].Content);
    }

    [Fact]
    public void JsonStringToPandaPhotos()
    {
        var json = /*lang=json*/ """
            {
              "stat": "ok",
              "photos": {
                "interval": "60000",
                "lastupdate": "1287089858",
                "total": "120",
                "panda": "ling ling",
                "photo": [
                  {
                    "title": "Shorebirds at Pillar Point",
                    "id": "3313428913",
                    "secret": "2cd3cb44cb",
                    "server": "3609",
                    "farm": "4",
                    "owner": "72442527@N00",
                    "ownername": "Pat Ulrich"
                  },
                  {
                    "title": "Battle of the sky",
                    "id": "3313713993",
                    "secret": "3f7f51500f",
                    "server": "3382",
                    "farm": "4",
                    "owner": "10459691@N05",
                    "ownername": "Sven Ericsson"
                  }
                ]
              }
            }
            """;

        var result = FlickrConvert.DeserializeObject<FlickrResult<PandaPhotos>>(json);

        Assert.NotNull(result);
        Assert.False(result.HasError);
        var items = result.Content;
        Assert.IsType<PandaPhotos>(items);
        Assert.NotEmpty(items.Values);
        Assert.Equal(120, items.Total);
        Assert.IsType<PandaPhoto>(items.Values[0]);
        Assert.Equal("4", items.Values[0].Farm);
    }
}