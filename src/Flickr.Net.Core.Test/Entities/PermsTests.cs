using Flickr.Net.Core.Enums;
using Flickr.Net.Core.Flickrs.Results;
using Flickr.Net.Core.Internals;

namespace Flickr.Net.Core.Test.Entities;

public class PermsTests
{
    [Fact]
    public void JsonStringToPerms()
    {
        var json = """
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

        var result = FlickrConvert.DeserializeObject<FlickrResult<Perms>>(json);

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
