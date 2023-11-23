using System.Text;
using Flickr.Net.Flickrs.Results;
using Flickr.Net.Internals;

namespace Flickr.Net.Test.Entities;

public class TicketTests
{
    [Fact]
    public void JsonStringToTickets()
    {
        var json = /*lang=json,strict*/ """
            {
              "stat": "ok",
              "uploader": {
                "ticket": [
                  {
                    "id": "128",
                    "complete": "1",
                    "photoid": "2995"
                  },
                  {
                    "id": "129",
                    "complete": "0"
                  },
                  {
                    "id": "130",
                    "complete": "2"
                  },
                  {
                    "id": "131",
                    "invalid": "1"
                  }
                ]
              }
            }
            """;

        using var ms = new MemoryStream(Encoding.UTF8.GetBytes(json));

        var result = FlickrConvert.DeserializeObject<FlickrResult<Tickets>>(ms);

        Assert.NotNull(result);
        Assert.False(result.HasError);
        var items = result.Content;
        Assert.IsType<Tickets>(items);
        Assert.NotEmpty(items.Values);
        Assert.IsType<Ticket>(items.Values[0]);
        Assert.Equal(4, items.Values.Count);
    }
}
