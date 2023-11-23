using System.Text;
using Flickr.Net.Flickrs.Results;
using Flickr.Net.Internals;

namespace Flickr.Net.Test.Entities;

public class PeoplePersonTests
{
    [Fact]
    public void JsonStringToPeoplePerson()
    {
        var json = /*lang=json,strict*/ """
            {
              "people": {
                "total": 0,
                  "person": [
                    {
                      "nsid": "87944415@N00",
                      "username": "hitherto",
                      "iconserver": "1",
                      "iconfarm": "1",
                      "realname": "Simon Batistoni",
                      "added_by": "12037949754@N01",
                      "x": "50",
                      "y": "50",
                      "w": "100",
                      "h": "100"
                    }
                  ],
                "photo_width": 500,
                "photo_height": 333
              },
              "stat": "ok"
            }
            """;

        using var ms = new MemoryStream(Encoding.UTF8.GetBytes(json));

        var result = FlickrConvert.DeserializeObject<FlickrResult<PeoplePersons>>(ms);

        Assert.NotNull(result);
        Assert.False(result.HasError);
        var items = result.Content;
        Assert.IsType<PeoplePersons>(items);
        Assert.NotEmpty(items.Values);
        Assert.IsType<PeoplePerson>(items.Values[0]);
        Assert.Single(items.Values);
    }
}