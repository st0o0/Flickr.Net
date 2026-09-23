using System.Text;
using Flickr.Net.Flickrs.Results;
using Flickr.Net.Internals;

namespace Flickr.Net.Test.Entities;

public class PhotoInfoPermissionsTests
{
    [Fact]
    public void PhotoInfoWithPermissions()
    {
        const string json = """
            {
                "photo": {
                    "id": "52931686549",
                    "secret": "9b203d4894",
                    "server": "65535",
                    "farm": 66,
                    "dateuploaded": "1695820800",
                    "isfavorite": 0,
                    "license": 0,
                    "safety_level": 0,
                    "rotation": 0,
                    "originalsecret": "abc123",
                    "originalformat": "jpg",
                    "owner": {
                        "nsid": "192376927@N06",
                        "username": "st0o0",
                        "realname": "Jan",
                        "location": "",
                        "iconserver": "65535",
                        "iconfarm": 66,
                        "path_alias": null
                    },
                    "title": { "_content": "Test Photo" },
                    "description": { "_content": "A test photo" },
                    "visibility": { "ispublic": 1, "isfriend": 0, "isfamily": 0 },
                    "permissions": {
                        "permcomment": 3,
                        "permaddmeta": 2
                    },
                    "dates": {
                        "posted": "1695820800",
                        "taken": "2024-03-15 14:30:00",
                        "takengranularity": "0",
                        "takenunknown": "0",
                        "lastupdate": "1695907200"
                    },
                    "views": "100",
                    "editability": { "cancomment": 1, "canaddmeta": 1 },
                    "publiceditability": { "cancomment": 1, "canaddmeta": 0 },
                    "usage": { "candownload": 1, "canblog": 1, "canprint": 1, "canshare": 1 },
                    "comments": { "_content": "5" },
                    "notes": { "note": [] },
                    "people": { "haspeople": 0 },
                    "tags": { "tag": [] },
                    "urls": { "url": [] },
                    "media": "photo"
                },
                "stat": "ok"
            }
            """;

        var result = FlickrConvert.DeserializeObject<FlickrResult<PhotoInfo>>(Encoding.UTF8.GetBytes(json));

        Assert.NotNull(result);
        Assert.False(result.HasError);
        var photo = result.Content;
        Assert.NotNull(photo.Permissions);
        Assert.Equal(3, photo.Permissions!.PermComment);
        Assert.Equal(2, photo.Permissions.PermAddMeta);
    }

    [Fact]
    public void PhotoInfoPermissionsNullForNonOwner()
    {
        const string json = """
            {
                "photo": {
                    "id": "52931686549",
                    "secret": "9b203d4894",
                    "server": "65535",
                    "farm": 66,
                    "dateuploaded": "1695820800",
                    "isfavorite": 0,
                    "license": 0,
                    "safety_level": 0,
                    "rotation": 0,
                    "owner": {
                        "nsid": "192376927@N06",
                        "username": "st0o0",
                        "realname": "Jan",
                        "location": "",
                        "iconserver": "65535",
                        "iconfarm": 66,
                        "path_alias": null
                    },
                    "title": { "_content": "Test Photo" },
                    "description": { "_content": "" },
                    "visibility": { "ispublic": 1, "isfriend": 0, "isfamily": 0 },
                    "dates": {
                        "posted": "1695820800",
                        "taken": "2024-03-15 14:30:00",
                        "takengranularity": "0",
                        "takenunknown": "0",
                        "lastupdate": "1695907200"
                    },
                    "views": "50",
                    "editability": { "cancomment": 0, "canaddmeta": 0 },
                    "publiceditability": { "cancomment": 1, "canaddmeta": 0 },
                    "usage": { "candownload": 1, "canblog": 0, "canprint": 0, "canshare": 1 },
                    "comments": { "_content": "0" },
                    "notes": { "note": [] },
                    "people": { "haspeople": 0 },
                    "tags": { "tag": [] },
                    "urls": { "url": [] },
                    "media": "photo"
                },
                "stat": "ok"
            }
            """;

        var result = FlickrConvert.DeserializeObject<FlickrResult<PhotoInfo>>(Encoding.UTF8.GetBytes(json));

        Assert.NotNull(result);
        Assert.False(result.HasError);
        var photo = result.Content;
        Assert.Null(photo.Permissions);
    }
}
