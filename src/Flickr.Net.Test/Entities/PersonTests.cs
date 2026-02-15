using System.Text;
using Flickr.Net.Flickrs.Results;
using Flickr.Net.Internals;
using Xunit;

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
}
