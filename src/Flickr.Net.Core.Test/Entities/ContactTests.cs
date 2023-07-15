using System.Text;
using Flickr.Net.Core.Flickrs.Results;
using Flickr.Net.Core.Internals;
using Newtonsoft.Json;

namespace Flickr.Net.Core.Test.Entities;

public class ContactTests
{
    [Fact]
    public void JsonStringToContacts()
    {
        var json = /*lang=json,strict*/ """
            {
                "contacts": {
                    "page": 1,
                    "pages": 1,
                    "per_page": 1000,
                    "perpage": 1000,
                    "total": 3,
                    "contact": [
                        {
                            "nsid": "66956608@N06",
                            "username": "Flickr",
                            "iconserver": "3741",
                            "iconfarm": 4,
                            "ignored": 0,
                            "rev_ignored": 0,
                            "realname": "Flickr",
                            "friend": 0,
                            "family": 0,
                            "path_alias": "flickr",
                            "location": ""
                        },
                        {
                            "nsid": "153496924@N03",
                            "username": "KaAuenwasser",
                            "iconserver": "7921",
                            "iconfarm": 8,
                            "ignored": 0,
                            "rev_ignored": 0,
                            "realname": "Stephan Gehrlein",
                            "friend": 0,
                            "family": 0,
                            "path_alias": "kaauenwasser",
                            "location": "Karlsruhe, Deutschland"
                        },
                        {
                            "nsid": "148774494@N04",
                            "username": "reipa59",
                            "iconserver": "4163",
                            "iconfarm": 5,
                            "ignored": 0,
                            "rev_ignored": 0,
                            "realname": "",
                            "friend": 0,
                            "family": 0,
                            "path_alias": "reinerpaul",
                            "location": ""
                        }
                    ]
                },
                "stat": "ok"
            }
            """;

        using var ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
        using var sr = new StreamReader(ms);
        using var reader = new JsonTextReader(sr);

        var result = FlickrConvert.DeserializeObject<FlickrResult<Contacts>>(reader);

        Assert.NotNull(result);
        Assert.False(result.HasError);
        var items = result.Content;
        Assert.IsType<Contacts>(items);
        Assert.IsType<Contact>(items.Values[0]);
        Assert.False(items.Values[0].Friend);
        Assert.False(items.Values[0].Family);
        Assert.False(items.Values[0].Ignored);
        Assert.Equal(items.Total, items.Values.Count);
    }
}