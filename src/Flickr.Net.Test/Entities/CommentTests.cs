using System.Text;
using Flickr.Net.Extensions;
using Flickr.Net.Flickrs.Results;
using Flickr.Net.Internals;
using Xunit;

namespace Flickr.Net.Test.Entities;

public class CommentTests
{
    [Fact]
    public void JsonStringToComments()
    {
        const string json = """
                            {
                                "comments": {
                                    "photo_id": "52990598628",
                                    "comment": [
                                        {
                                            "id": "153473870-52990598628-72157720277929503",
                                            "author": "195953201@N08",
                                            "author_is_deleted": 0,
                                            "authorname": "mikkokantanen",
                                            "iconserver": "65535",
                                            "iconfarm": 66,
                                            "datecreate": "1687322647",
                                            "permalink": "https:\/\/www.flickr.com\/photos\/kaauenwasser\/52990598628\/#comment72157720277929503",
                                            "path_alias": null,
                                            "realname": "Mikko Kantanen",
                                            "_content": "Great shot!"
                                        },
                                        {
                                            "id": "153473870-52990598628-72157720277938116",
                                            "author": "146474332@N02",
                                            "author_is_deleted": 0,
                                            "authorname": "Bolle1111",
                                            "iconserver": "65535",
                                            "iconfarm": 66,
                                            "datecreate": "1687330145",
                                            "permalink": "https:\/\/www.flickr.com\/photos\/kaauenwasser\/52990598628\/#comment72157720277938116",
                                            "path_alias": null,
                                            "realname": "Bolle",
                                            "_content": "Wow! Was f\u00fcr ein geniales Bild! Ich liebe die Farbe, den starken Kontrast und die geringe Sch\u00e4rfentiefe. Und den schnellen Flieger muss man erst mal verfolgen und dann auch noch scharf ablichten. Das ist K\u00f6nnen."
                                        },
                                        {
                                            "id": "153473870-52990598628-72157720278001996",
                                            "author": "150904935@N04",
                                            "author_is_deleted": 0,
                                            "authorname": "marcbenezech",
                                            "iconserver": "65535",
                                            "iconfarm": 66,
                                            "datecreate": "1687349785",
                                            "permalink": "https:\/\/www.flickr.com\/photos\/kaauenwasser\/52990598628\/#comment72157720278001996",
                                            "path_alias": null,
                                            "realname": "Marc BENEZECH",
                                            "_content": "tres belle image\ud83d\udc4d"
                                        },
                                        {
                                            "id": "153473870-52990598628-72157720278065372",
                                            "author": "134654275@N08",
                                            "author_is_deleted": 0,
                                            "authorname": "PhilR1000",
                                            "iconserver": "4630",
                                            "iconfarm": 5,
                                            "datecreate": "1687355328",
                                            "permalink": "https:\/\/www.flickr.com\/photos\/kaauenwasser\/52990598628\/#comment72157720278065372",
                                            "path_alias": null,
                                            "realname": "Phil Rooney",
                                            "_content": "Wow!!"
                                        },
                                        {
                                            "id": "153473870-52990598628-72157720278118463",
                                            "author": "77428038@N00",
                                            "author_is_deleted": 0,
                                            "authorname": "haegar52002",
                                            "iconserver": "187",
                                            "iconfarm": 1,
                                            "datecreate": "1687380399",
                                            "permalink": "https:\/\/www.flickr.com\/photos\/kaauenwasser\/52990598628\/#comment72157720278118463",
                                            "path_alias": "haegar52002",
                                            "realname": "Stefan Unger",
                                            "_content": "sehr sch\u00f6n"
                                        },
                                        {
                                            "id": "153473870-52990598628-72157720278113061",
                                            "author": "15382330@N00",
                                            "author_is_deleted": 0,
                                            "authorname": "snbi71",
                                            "iconserver": "65535",
                                            "iconfarm": 66,
                                            "datecreate": "1687383194",
                                            "permalink": "https:\/\/www.flickr.com\/photos\/kaauenwasser\/52990598628\/#comment72157720278113061",
                                            "path_alias": null,
                                            "realname": "Sebastian",
                                            "_content": "tolle Flugaufnahme und ein wirklich perfekter Hintergrund mit dem goldgelben Kornfeld!"
                                        }
                                    ]
                                },
                                "stat": "ok"
                            }
                            """;

        var result = FlickrConvert.DeserializeObject<FlickrResult<PhotoComments>>(Encoding.UTF8.GetBytes(json));

        Assert.NotNull(result);
        Assert.False(result.HasError);
        var items = result.Content;
        Assert.IsType<PhotoComments>(items);
        Assert.NotEmpty(items.Values);
        Assert.IsType<Comment>(items.Values[0]);
        Assert.False(string.IsNullOrEmpty(items.Values[0].Id));
        Assert.IsType<DateTime>(items.Values[0].CreateDate);
        Assert.NotEmpty(items.Values[0].ToBuddyIconUrl());
    }
}
