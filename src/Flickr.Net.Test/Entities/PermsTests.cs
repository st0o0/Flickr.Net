using System.Text;
using Flickr.Net.Enums;
using Flickr.Net.Flickrs.Results;
using Flickr.Net.Internals;
using Xunit;

namespace Flickr.Net.Test.Entities;

public class PermsTests
{
    [Fact]
    public void JsonStringToPerms()
    {
        const string json = """
                            {
                                "perms": {
                                    "id": "52989763352",
                                    "ispublic": 1,
                                    "isfriend": 0,
                                    "isfamily": 0,
                                    "permcomment": 3,
                                    "permaddmeta": 2,
                                    "permprint": 0
                                },
                                "stat": "ok"
                            }
                            """;

        var result = FlickrConvert.DeserializeObject<FlickrResult<Perms>>(Encoding.UTF8.GetBytes(json));

        Assert.NotNull(result);
        Assert.False(result.HasError);
        var items = result.Content;
        Assert.IsType<Perms>(items);
        Assert.True(items.IsPublic);
        Assert.False(items.IsFriend);
        Assert.False(items.IsFamily);

        Assert.Equal(PermissionComment.Everybody, items.PermComment);
        Assert.Equal(PermissionAddMeta.Contacts, items.PermAddMeta);
    }
}
