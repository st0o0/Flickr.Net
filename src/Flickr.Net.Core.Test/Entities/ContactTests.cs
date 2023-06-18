using Flickr.Net.Core.Flickrs.Results;
using Flickr.Net.Core.Internals.ContractResolver;
using Flickr.Net.Core.NewEntities.Collections;
using Flickr.Net.Core.NewEntities;
using Newtonsoft.Json;

namespace Flickr.Net.Core.Test.Entities;

public class ContactTests
{
    [Fact]
    public void JsonStringToContacts()
    {
        var json = /*lang=json,strict*/ """
            {
              "stat": "ok",
              "contacts": {
                "page": "1",
                "pages": "1",
                "perpage": "1000",
                "total": "3",
                "contact": [
                  {
                    "nsid": "12037949629@N01",
                    "username": "Eric",
                    "iconserver": "1",
                    "realname": "Eric Costello",
                    "friend": "1",
                    "family": "0",
                    "ignored": "1"
                  },
                  {
                    "nsid": "12037949631@N01",
                    "username": "neb",
                    "iconserver": "1",
                    "realname": "Ben Cerveny",
                    "friend": "0",
                    "family": "0",
                    "ignored": "0"
                  },
                  {
                    "nsid": "41578656547@N01",
                    "username": "cal_abc",
                    "iconserver": "1",
                    "realname": "Cal Henderson",
                    "friend": "1",
                    "family": "1",
                    "ignored": "0"
                  }
                ]
              }
            }
            """;

        var result = JsonConvert.DeserializeObject<FlickrResult<Contacts>>(json, new JsonSerializerSettings
        {
            ContractResolver = new GenericJsonPropertyNameContractResolver()
        });

        Assert.NotNull(result);
        Assert.False(result.HasError);
        var items = result.Content;
        Assert.IsType<Contacts>(items);
        Assert.IsType<Contact>(items.Values[0]);
        Assert.True(items.Values[0].Friend);
        Assert.False(items.Values[0].Family);
        Assert.True(items.Values[0].Ignored);
        Assert.Equal(items.Total, items.Values.Count);
    }
}
