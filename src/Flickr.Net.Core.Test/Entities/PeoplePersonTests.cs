using System.Text;
using Flickr.Net.Core.Flickrs.Results;
using Flickr.Net.Core.Internals;
using Newtonsoft.Json;

namespace Flickr.Net.Core.Test.Entities;

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
        using var sr = new StreamReader(ms);
        using var reader = new JsonTextReader(sr);

        var result = FlickrConvert.DeserializeObject<FlickrResult<PeoplePersons>>(reader);

        Assert.NotNull(result);
        Assert.False(result.HasError);
        var items = result.Content;
        Assert.IsType<PeoplePersons>(items);
        Assert.NotEmpty(items.Values);
        Assert.IsType<PeoplePerson>(items.Values[0]);
        Assert.Single(items.Values);
    }
}