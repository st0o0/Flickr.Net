using Flickr.Net.Core.Flickrs.Results;
using Flickr.Net.Core.Internals;

namespace Flickr.Net.Core.Test.Entities;

public class PhotoInfoTests
{
    [Fact]
    public void JsonStringToPhotoInfo()
    {
        var json = /*lang=json,strict*/ """
            {
                "photo": {
                    "id": "52992805950",
                    "secret": "034d512c5c",
                    "server": "65535",
                    "farm": 66,
                    "dateuploaded": "1687404528",
                    "isfavorite": 0,
                    "license": "0",
                    "safety_level": "0",
                    "rotation": 0,
                    "originalsecret": "41633ac73c",
                    "originalformat": "jpg",
                    "owner": {
                        "nsid": "153496924@N03",
                        "username": "KaAuenwasser",
                        "realname": "Stephan Gehrlein",
                        "location": "Karlsruhe, Deutschland",
                        "iconserver": "7921",
                        "iconfarm": 8,
                        "path_alias": "kaauenwasser",
                        "gift": {
                            "gift_eligible": true,
                            "eligible_durations": [
                                "year",
                                "month",
                                "week"
                            ],
                            "new_flow": true
                        }
                    },
                    "title": {
                        "_content": "Hier bin ich"
                    },
                    "description": {
                        "_content": "Der Teichfrosch schaut zwischen den Seerosenbl\u00e4ttern hervor"
                    },
                    "visibility": {
                        "ispublic": 1,
                        "isfriend": 0,
                        "isfamily": 0
                    },
                    "dates": {
                        "posted": "1687404528",
                        "taken": "2023-06-08 08:17:50",
                        "takengranularity": 0,
                        "takenunknown": "0",
                        "lastupdate": "1687412385"
                    },
                    "views": "112",
                    "editability": {
                        "cancomment": 1,
                        "canaddmeta": 1
                    },
                    "publiceditability": {
                        "cancomment": 1,
                        "canaddmeta": 1
                    },
                    "usage": {
                        "candownload": 1,
                        "canblog": 1,
                        "canprint": 0,
                        "canshare": 1
                    },
                    "comments": {
                        "_content": "0"
                    },
                    "notes": {
                        "note": []
                    },
                    "people": {
                        "haspeople": 0
                    },
                    "tags": {
                        "tag": [
                            {
                                "id": "153473870-52992805950-241",
                                "author": "153496924@N03",
                                "authorname": "KaAuenwasser",
                                "raw": "Wild",
                                "_content": "wild",
                                "machine_tag": false
                            },
                            {
                                "id": "153473870-52992805950-5833",
                                "author": "153496924@N03",
                                "authorname": "KaAuenwasser",
                                "raw": "Wildlife",
                                "_content": "wildlife",
                                "machine_tag": false
                            },
                            {
                                "id": "153473870-52992805950-4796",
                                "author": "153496924@N03",
                                "authorname": "KaAuenwasser",
                                "raw": "Bokeh",
                                "_content": "bokeh",
                                "machine_tag": false
                            },
                            {
                                "id": "153473870-52992805950-36208",
                                "author": "153496924@N03",
                                "authorname": "KaAuenwasser",
                                "raw": "Habitat",
                                "_content": "habitat",
                                "machine_tag": false
                            },
                            {
                                "id": "153473870-52992805950-791",
                                "author": "153496924@N03",
                                "authorname": "KaAuenwasser",
                                "raw": "Nature",
                                "_content": "nature",
                                "machine_tag": false
                            },
                            {
                                "id": "153473870-52992805950-5987",
                                "author": "153496924@N03",
                                "authorname": "KaAuenwasser",
                                "raw": "Tag",
                                "_content": "tag",
                                "machine_tag": false
                            },
                            {
                                "id": "153473870-52992805950-1114",
                                "author": "153496924@N03",
                                "authorname": "KaAuenwasser",
                                "raw": "Juni",
                                "_content": "juni",
                                "machine_tag": false
                            },
                            {
                                "id": "153473870-52992805950-1314496",
                                "author": "153496924@N03",
                                "authorname": "KaAuenwasser",
                                "raw": "2023",
                                "_content": "2023",
                                "machine_tag": false
                            },
                            {
                                "id": "153473870-52992805950-1905",
                                "author": "153496924@N03",
                                "authorname": "KaAuenwasser",
                                "raw": "Deutschland",
                                "_content": "deutschland",
                                "machine_tag": false
                            },
                            {
                                "id": "153473870-52992805950-5319643",
                                "author": "153496924@N03",
                                "authorname": "KaAuenwasser",
                                "raw": "Teichfrosch",
                                "_content": "teichfrosch",
                                "machine_tag": false
                            },
                            {
                                "id": "153473870-52992805950-42722",
                                "author": "153496924@N03",
                                "authorname": "KaAuenwasser",
                                "raw": "Frosch",
                                "_content": "frosch",
                                "machine_tag": false
                            },
                            {
                                "id": "153473870-52992805950-2116",
                                "author": "153496924@N03",
                                "authorname": "KaAuenwasser",
                                "raw": "See",
                                "_content": "see",
                                "machine_tag": false
                            },
                            {
                                "id": "153473870-52992805950-547122",
                                "author": "153496924@N03",
                                "authorname": "KaAuenwasser",
                                "raw": "Seerosen",
                                "_content": "seerosen",
                                "machine_tag": false
                            },
                            {
                                "id": "153473870-52992805950-1107377",
                                "author": "153496924@N03",
                                "authorname": "KaAuenwasser",
                                "raw": "Gew\u00e4sser",
                                "_content": "gew\u00e4sser",
                                "machine_tag": false
                            },
                            {
                                "id": "153473870-52992805950-26659",
                                "author": "153496924@N03",
                                "authorname": "KaAuenwasser",
                                "raw": "Gr\u00fcn",
                                "_content": "gr\u00fcn",
                                "machine_tag": false
                            },
                            {
                                "id": "153473870-52992805950-52429",
                                "author": "153496924@N03",
                                "authorname": "KaAuenwasser",
                                "raw": "Blick",
                                "_content": "blick",
                                "machine_tag": false
                            },
                            {
                                "id": "153473870-52992805950-47390",
                                "author": "153496924@N03",
                                "authorname": "KaAuenwasser",
                                "raw": "Spiegelung",
                                "_content": "spiegelung",
                                "machine_tag": false
                            }
                        ]
                    },
                    "location": {
                        "latitude": "49.016439",
                        "longitude": "8.404326",
                        "accuracy": "16",
                        "context": "0",
                        "locality": {
                            "_content": "Stadtkreis Karlsruhe"
                        },
                        "county": {
                            "_content": "Karlsruhe"
                        },
                        "region": {
                            "_content": "Baden-W\u00fcrttemberg"
                        },
                        "country": {
                            "_content": "Deutschland"
                        },
                        "neighbourhood": {
                            "_content": ""
                        }
                    },
                    "geoperms": {
                        "ispublic": 1,
                        "iscontact": 0,
                        "isfriend": 0,
                        "isfamily": 0
                    },
                    "urls": {
                        "url": [
                            {
                                "type": "photopage",
                                "_content": "https:\/\/www.flickr.com\/photos\/kaauenwasser\/52992805950\/"
                            }
                        ]
                    },
                    "media": "photo"
                },
                "stat": "ok"
            }
            """;

        var result = FlickrConvert.DeserializeObject<FlickrResult<PhotoInfo>>(json);

        Assert.NotNull(result);
        Assert.False(result.HasError);
        var items = result.Content;
        Assert.IsType<PhotoInfo>(items);
        Assert.IsType<Tags>(items.Tags);
        Assert.NotEmpty(items.Tags.Values);
        Assert.IsType<Urls>(items.Urls);
        Assert.NotEmpty(items.Urls.Values);
        Assert.IsType<Notes>(items.Notes);
        Assert.Empty(items.Notes.Values);
    }
}
