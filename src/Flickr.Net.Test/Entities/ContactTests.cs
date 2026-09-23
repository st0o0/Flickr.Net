using System.Text;
using Flickr.Net.Flickrs.Results;
using Flickr.Net.Internals;

namespace Flickr.Net.Test.Entities;

public class ContactTests
{
    [Fact]
    public void JsonStringToContacts()
    {
        const string json = """
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

        var result = FlickrConvert.DeserializeObject<FlickrResult<Contacts>>(Encoding.UTF8.GetBytes(json));

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

    [Fact]
    public void ContactWithReverseRelationshipFields()
    {
        const string json = """
            {
                "contacts": {
                    "page": 1,
                    "pages": 1,
                    "per_page": 10,
                    "perpage": 10,
                    "total": 1,
                    "contact": [
                        {
                            "nsid": "66956608@N06",
                            "username": "Flickr",
                            "iconserver": "3741",
                            "iconfarm": 4,
                            "ignored": 0,
                            "rev_ignored": 0,
                            "realname": "Flickr",
                            "friend": 1,
                            "family": 1,
                            "path_alias": "flickr",
                            "location": "",
                            "rev_contact": 1,
                            "rev_friend": 0,
                            "rev_family": 1
                        }
                    ]
                },
                "stat": "ok"
            }
            """;

        var result = FlickrConvert.DeserializeObject<FlickrResult<Contacts>>(Encoding.UTF8.GetBytes(json));

        Assert.NotNull(result);
        Assert.False(result.HasError);
        var contact = result.Content.Values[0];
        Assert.True(contact.Friend);
        Assert.True(contact.Family);
        Assert.True(contact.RevContact);
        Assert.False(contact.RevFriend);
        Assert.True(contact.RevFamily);
    }
}