using System.Text;
using Flickr.Net.Flickrs.Results;
using Flickr.Net.Internals;

namespace Flickr.Net.Test.Entities;

public class PersonTests
{
    [Fact]
    public void JsonStringToPerson()
    {
        const string json = """
                            {
                                "person": {
                                    "id": "192376927@N06",
                                    "nsid": "192376927@N06",
                                    "ispro": 0,
                                    "is_deleted": 0,
                                    "iconserver": "65535",
                                    "iconfarm": 66,
                                    "path_alias": null,
                                    "has_stats": 0,
                                    "username": {
                                        "_content": "st0o0"
                                    },
                                    "realname": {
                                        "_content": "Jan Schloots"
                                    },
                                    "mbox_sha1sum": {
                                        "_content": "2fbaa1035bb9ddd9789254c8db1d7ce56eb7e87f"
                                    },
                                    "location": {
                                        "_content": "L\u00f6rrach, Deutschland"
                                    },
                                    "description": {
                                        "_content": ""
                                    },
                                    "photosurl": {
                                        "_content": "https:\/\/www.flickr.com\/photos\/192376927@N06\/"
                                    },
                                    "profileurl": {
                                        "_content": "https:\/\/www.flickr.com\/people\/192376927@N06\/"
                                    },
                                    "mobileurl": {
                                        "_content": "https:\/\/m.flickr.com\/photostream.gne?id=192331605"
                                    },
                                    "photos": {
                                        "firstdatetaken": {
                                            "_content": "2021-05-15 09:46:21"
                                        },
                                        "firstdate": {
                                            "_content": "1621097181"
                                        },
                                        "count": {
                                            "_content": 487
                                        },
                                        "views": {
                                            "_content": "355"
                                        }
                                    },
                                    "upload_count": 487,
                                    "upload_limit": 1000,
                                    "upload_limit_status": "below_limit",
                                    "is_cognito_user": 1,
                                    "all_rights_reserved_photos_count": 0,
                                    "has_adfree": 0,
                                    "has_free_standard_shipping": 0,
                                    "has_free_educational_resources": 0
                                },
                                "stat": "ok"
                            }
                            """;

        var item = FlickrConvert.DeserializeObject<FlickrResult<Person>>(Encoding.UTF8.GetBytes(json));

        Assert.NotNull(item);
        Assert.False(item.HasError);
        var items = item.Content;
        Assert.IsType<Person>(items);
        Assert.False(items.IsPro);
        Assert.False(items.IsDeleted);
        Assert.False(items.HasStats);
        Assert.True(items.IsCognitoUser);
        Assert.False(items.HasAdfree);
        Assert.False(items.HasFreeStandardShipping);
        Assert.False(items.HasFreeEducationalResources);
    }

    [Fact]
    public void PersonPathAliasIsString()
    {
        const string json = """
            {
                "person": {
                    "id": "12345678@N00",
                    "nsid": "12345678@N00",
                    "ispro": 1,
                    "is_deleted": 0,
                    "iconserver": "65535",
                    "iconfarm": 66,
                    "path_alias": "janedoe",
                    "has_stats": 0,
                    "username": { "_content": "janedoe" },
                    "realname": { "_content": "Jane Doe" },
                    "photos": {
                        "firstdatetaken": { "_content": "2020-01-01 00:00:00" },
                        "firstdate": { "_content": "1577836800" },
                        "count": { "_content": 100 },
                        "views": { "_content": "500" }
                    }
                },
                "stat": "ok"
            }
            """;

        var result = FlickrConvert.DeserializeObject<FlickrResult<Person>>(Encoding.UTF8.GetBytes(json));

        Assert.NotNull(result);
        var person = result.Content!;
        Assert.Equal("janedoe", person.PathAlias);
        Assert.IsType<string>(person.PathAlias);
    }

    [Fact]
    public void PersonWithRelationshipFields()
    {
        const string json = """
            {
                "person": {
                    "id": "12345678@N00",
                    "nsid": "12345678@N00",
                    "ispro": 0,
                    "is_deleted": 0,
                    "iconserver": "65535",
                    "iconfarm": 66,
                    "path_alias": null,
                    "has_stats": 0,
                    "contact": 1,
                    "friend": 1,
                    "family": 0,
                    "revcontact": 1,
                    "revfriend": 0,
                    "revfamily": 0,
                    "username": { "_content": "bob" },
                    "realname": { "_content": "Bob Smith" },
                    "photos": {
                        "firstdatetaken": { "_content": "2021-01-01 00:00:00" },
                        "firstdate": { "_content": "1609459200" },
                        "count": { "_content": 50 },
                        "views": { "_content": "200" }
                    }
                },
                "stat": "ok"
            }
            """;

        var result = FlickrConvert.DeserializeObject<FlickrResult<Person>>(Encoding.UTF8.GetBytes(json));

        Assert.NotNull(result);
        var person = result.Content!;
        Assert.True(person.Contact);
        Assert.True(person.Friend);
        Assert.False(person.Family);
        Assert.True(person.RevContact);
        Assert.False(person.RevFriend);
        Assert.False(person.RevFamily);
    }

    [Fact]
    public void PersonRelationshipFieldsNullWhenUnauthenticated()
    {
        const string json = """
            {
                "person": {
                    "id": "12345678@N00",
                    "nsid": "12345678@N00",
                    "ispro": 0,
                    "is_deleted": 0,
                    "iconserver": "0",
                    "iconfarm": 0,
                    "path_alias": null,
                    "has_stats": 0,
                    "username": { "_content": "anonymous" },
                    "realname": { "_content": "" },
                    "photos": {
                        "firstdatetaken": { "_content": "" },
                        "firstdate": { "_content": "" },
                        "count": { "_content": 0 },
                        "views": { "_content": "0" }
                    }
                },
                "stat": "ok"
            }
            """;

        var result = FlickrConvert.DeserializeObject<FlickrResult<Person>>(Encoding.UTF8.GetBytes(json));

        Assert.NotNull(result);
        var person = result.Content!;
        Assert.Null(person.Contact);
        Assert.Null(person.Friend);
        Assert.Null(person.Family);
        Assert.Null(person.RevContact);
        Assert.Null(person.RevFriend);
        Assert.Null(person.RevFamily);
    }
}
