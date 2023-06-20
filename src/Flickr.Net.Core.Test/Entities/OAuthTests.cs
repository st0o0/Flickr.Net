using Flickr.Net.Core.Enums;
using Flickr.Net.Core.Flickrs.Results;
using Flickr.Net.Core.Internals;

namespace Flickr.Net.Core.Test.Entities;

public class OAuthTests
{
    [Fact]
    public void JsonStringToOAuth()
    {
        var json = /*lang=json,strict*/ """
            {
              "stat": "ok",
              "oauth": {
                "token": "72157627611980735-09e87c3024f733da",
                "perms": "write",
                "user": {
                  "nsid": "1121451801@N07",
                  "username": "jamalf",
                  "fullname": "Jamal F"
                }
              }
            }
            """;

        var result = FlickrConvert.DeserializeObject<FlickrResult<OAuth>>(json);

        Assert.NotNull(result);
        Assert.False(result.HasError);
        var items = result.Content;
        Assert.IsType<OAuth>(items);
        Assert.IsType<User>(items.User);
        Assert.IsType<AuthLevel>(items.Perms);
    }
}