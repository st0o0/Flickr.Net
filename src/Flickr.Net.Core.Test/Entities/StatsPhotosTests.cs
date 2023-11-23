using System.Text;
using Flickr.Net.Core.Flickrs.Results;
using Flickr.Net.Core.Internals;

namespace Flickr.Net.Core.Test.Entities;

public class StatsPhotosTests
{
    [Fact]
    public void JsonStringToStatsPhotos()
    {
        var json = """
            {
              "stat": "ok",
              "photos": {
                "page": "2",
                "pages": "89",
                "perpage": "10",
                "total": "881",
                "photo": [
                  {
                    "id": "2636",
                    "owner": "47058503995@N01",
                    "secret": "a123456",
                    "server": "2",
                    "title": "test_04",
                    "ispublic": "1",
                    "isfriend": "0",
                    "isfamily": "0",
                    "stats": {
                      "views": "941",
                      "comments": "18",
                      "favorites": "2"
                    }
                  },
                  {
                    "id": "2635",
                    "owner": "47058503995@N01",
                    "secret": "b123456",
                    "server": "2",
                    "title": "test_03",
                    "ispublic": "0",
                    "isfriend": "1",
                    "isfamily": "1",
                    "stats": {
                      "views": "141",
                      "comments": "1",
                      "favorites": "2"
                    }
                  }
                ]
              }
            }
            """;

        using var ms = new MemoryStream(Encoding.UTF8.GetBytes(json));

        var result = FlickrConvert.DeserializeObject<FlickrResult<StatsPhotos>>(ms);

        Assert.NotNull(result);
        Assert.False(result.HasError);
        var items = result.Content;
        Assert.IsType<StatsPhotos>(items);
        Assert.Equal(881, items.Total);
        Assert.NotEmpty(items.Values);
        Assert.Equal(2, items.Values.Count);

        Assert.True(items.Values[0].IsPublic);
        Assert.False(items.Values[0].IsFriend);
        Assert.False(items.Values[0].IsFamily);
        Assert.Equal(941, items.Values[0].Stats.Views);
        Assert.Equal(18, items.Values[0].Stats.Comments);
        Assert.Equal(2, items.Values[0].Stats.Favorites);

        Assert.False(items.Values[1].IsPublic);
        Assert.True(items.Values[1].IsFriend);
        Assert.True(items.Values[1].IsFamily);
        Assert.Equal(141, items.Values[1].Stats.Views);
        Assert.Equal(1, items.Values[1].Stats.Comments);
        Assert.Equal(2, items.Values[1].Stats.Favorites);
    }
}
