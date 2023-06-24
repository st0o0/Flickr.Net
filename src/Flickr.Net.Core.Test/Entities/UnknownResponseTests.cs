using Flickr.Net.Core.Flickrs.Results;
using Flickr.Net.Core.Internals;

namespace Flickr.Net.Core.Test.Entities;

public class UnknownResponseTests
{
    [Fact]
    public void JsonStringToGroupUnknownResponse()
    {
        var json = """
            {
              "stat": "ok",
              "group": {
                "nsid": "48508120860@N01",
                "url": "http://www.flickr.com/groups/test1/"
              }
            }
            """;

        var result = FlickrConvert.DeserializeObject<FlickrUnknownResult<GroupUnknownResponse>>(json);

        Assert.NotNull(result);
        Assert.False(result.HasError);
        var items = result.Content;
        Assert.IsType<GroupUnknownResponse>(items);
        Assert.True(items.ContainsKey("nsid"));
        Assert.True(items.ContainsKey("url"));
    }

    [Fact]
    public void JsonStringToCommentUnknownResponse()
    {
        var json = /*lang=json,strict*/ """
            {
              "stat": "ok",
              "comment": {
                "id": "97777-72057594037941949-72057594037942602"
              }
            }
            """;

        var result = FlickrConvert.DeserializeObject<FlickrUnknownResult<CommentUnknownResponse>>(json);

        Assert.NotNull(result);
        Assert.False(result.HasError);
        var items = result.Content;
        Assert.IsType<CommentUnknownResponse>(items);
        Assert.True(items.ContainsKey("id"));
    }
}
