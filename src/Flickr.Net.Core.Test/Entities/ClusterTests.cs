using System.Text;
using Flickr.Net.Core.Flickrs.Results;
using Flickr.Net.Core.Internals;
using Newtonsoft.Json;

namespace Flickr.Net.Core.Test.Entities;

public class ClusterTests
{
    [Fact]
    public void JsonStringToClusters()
    {
        var json = /*lang=json,strict*/ """
            {
                "clusters": {
                    "source": "farm",
                    "total": 3,
                    "cluster": [
                        {
                            "total": 16,
                            "tag": [
                                {
                                    "_content": "barn"
                                },
                                {
                                    "_content": "rural"
                                },
                                {
                                    "_content": "old"
                                },
                                {
                                    "_content": "country"
                                },
                                {
                                    "_content": "abandoned"
                                },
                                {
                                    "_content": "house"
                                },
                                {
                                    "_content": "red"
                                },
                                {
                                    "_content": "winter"
                                },
                                {
                                    "_content": "decay"
                                },
                                {
                                    "_content": "countryside"
                                },
                                {
                                    "_content": "silo"
                                },
                                {
                                    "_content": "snow"
                                },
                                {
                                    "_content": "wood"
                                },
                                {
                                    "_content": "fall"
                                },
                                {
                                    "_content": "bw"
                                },
                                {
                                    "_content": "cold"
                                }
                            ]
                        },
                        {
                            "total": 23,
                            "tag": [
                                {
                                    "_content": "field"
                                },
                                {
                                    "_content": "landscape"
                                },
                                {
                                    "_content": "sky"
                                },
                                {
                                    "_content": "grass"
                                },
                                {
                                    "_content": "clouds"
                                },
                                {
                                    "_content": "trees"
                                },
                                {
                                    "_content": "green"
                                },
                                {
                                    "_content": "nature"
                                },
                                {
                                    "_content": "tree"
                                },
                                {
                                    "_content": "fence"
                                },
                                {
                                    "_content": "blue"
                                },
                                {
                                    "_content": "sunset"
                                },
                                {
                                    "_content": "nikon"
                                },
                                {
                                    "_content": "corn"
                                },
                                {
                                    "_content": "hay"
                                },
                                {
                                    "_content": "summer"
                                },
                                {
                                    "_content": "farming"
                                },
                                {
                                    "_content": "cloud"
                                },
                                {
                                    "_content": "yellow"
                                },
                                {
                                    "_content": "wheat"
                                },
                                {
                                    "_content": "storm"
                                },
                                {
                                    "_content": "canon"
                                },
                                {
                                    "_content": "tractor"
                                }
                            ]
                        },
                        {
                            "total": 10,
                            "tag": [
                                {
                                    "_content": "animal"
                                },
                                {
                                    "_content": "cow"
                                },
                                {
                                    "_content": "animals"
                                },
                                {
                                    "_content": "sheep"
                                },
                                {
                                    "_content": "horse"
                                },
                                {
                                    "_content": "cows"
                                },
                                {
                                    "_content": "horses"
                                },
                                {
                                    "_content": "cattle"
                                },
                                {
                                    "_content": "lamb"
                                },
                                {
                                    "_content": "goat"
                                }
                            ]
                        }
                    ]
                },
                "stat": "ok"
            }
            """;

        using var ms = new MemoryStream(Encoding.UTF8.GetBytes(json));

        var result = FlickrConvert.DeserializeObject<FlickrResult<Clusters>>(ms);

        Assert.NotNull(result);
        Assert.False(result.HasError);
        var items = result.Content;
        Assert.IsType<Clusters>(items);
        Assert.Equal(3, items.Total);
        Assert.NotEmpty(items.Values);
        Assert.Equal(16, items.Values[0].Total);
        Assert.NotEmpty(items.Values[0].Tags);
        Assert.Equal(16, items.Values[0].Tags.Count);
        Assert.Equal(23, items.Values[1].Total);
        Assert.NotEmpty(items.Values[1].Tags);
        Assert.Equal(23, items.Values[1].Tags.Count);
        Assert.Equal(10, items.Values[2].Total);
        Assert.NotEmpty(items.Values[2].Tags);
        Assert.Equal(10, items.Values[2].Tags.Count);
    }

    [Fact]
    public void JsonStringToClusterPhotos()
    {
        var json = /*lang=json,strict*/ """
            {
                "photos": {
                    "photo": [
                        {
                            "id": "3034505563",
                            "secret": "efefe69a6a",
                            "server": "3145",
                            "farm": 4,
                            "owner": "9850270@N05",
                            "username": "Mathieu G.U.Y",
                            "title": "Les jumeaux",
                            "ispublic": 1,
                            "isfriend": 0,
                            "isfamily": 0
                        },
                        {
                            "id": "3665381452",
                            "secret": "b9369715af",
                            "server": "3657",
                            "farm": 4,
                            "owner": "42386231@N00",
                            "username": "axiepics",
                            "title": "aw mom!!",
                            "ispublic": 1,
                            "isfriend": 0,
                            "isfamily": 0
                        },
                        {
                            "id": "3545818558",
                            "secret": "6501ac53ae",
                            "server": "2431",
                            "farm": 3,
                            "owner": "70576947@N00",
                            "username": "Mascotinhos em Feltro",
                            "title": "Bichos de Fazenda!",
                            "ispublic": 1,
                            "isfriend": 0,
                            "isfamily": 0
                        },
                        {
                            "id": "3295188046",
                            "secret": "a7c69b13c8",
                            "server": "3112",
                            "farm": 4,
                            "owner": "15524285@N02",
                            "username": "Henny HR",
                            "title": "Funny horse named Lightning",
                            "ispublic": 1,
                            "isfriend": 0,
                            "isfamily": 0
                        },
                        {
                            "id": "3461826335",
                            "secret": "79475a1a62",
                            "server": "3488",
                            "farm": 4,
                            "owner": "39754418@N00",
                            "username": "k-ko",
                            "title": "Mooooo",
                            "ispublic": 1,
                            "isfriend": 0,
                            "isfamily": 0
                        },
                        {
                            "id": "3461863625",
                            "secret": "f4a5bebc10",
                            "server": "3482",
                            "farm": 4,
                            "owner": "7984890@N07",
                            "username": "jgg35",
                            "title": "Mr and Mrs",
                            "ispublic": 1,
                            "isfriend": 0,
                            "isfamily": 0
                        },
                        {
                            "id": "3499659571",
                            "secret": "62a8b09dd5",
                            "server": "3565",
                            "farm": 4,
                            "owner": "28723574@N07",
                            "username": "charlotte.morse",
                            "title": "No One Comes Near MY Baby!",
                            "ispublic": 1,
                            "isfriend": 0,
                            "isfamily": 0
                        },
                        {
                            "id": "3116249677",
                            "secret": "f4919a7a0d",
                            "server": "65535",
                            "farm": 66,
                            "owner": "26021670@N00",
                            "username": "Claude@Munich",
                            "title": "Round Sheep!",
                            "ispublic": 1,
                            "isfriend": 0,
                            "isfamily": 0
                        },
                        {
                            "id": "2993396614",
                            "secret": "8bc4499a58",
                            "server": "3068",
                            "farm": 4,
                            "owner": "25748398@N06",
                            "username": "Mari\u00ebtte Budel",
                            "title": "Scottish Highlander",
                            "ispublic": 1,
                            "isfriend": 0,
                            "isfamily": 0
                        },
                        {
                            "id": "2835732878",
                            "secret": "dc2e491d62",
                            "server": "3253",
                            "farm": 4,
                            "owner": "84477621@N00",
                            "username": "ineedathis, Everyday I get up, it's a great day!",
                            "title": "Grazing Beauty!",
                            "ispublic": 1,
                            "isfriend": 0,
                            "isfamily": 0
                        },
                        {
                            "id": "2789910272",
                            "secret": "86ec60131d",
                            "server": "3004",
                            "farm": 4,
                            "owner": "8650498@N05",
                            "username": "Kelvin Wong (Away)",
                            "title": "The Happy Farm",
                            "ispublic": 1,
                            "isfriend": 0,
                            "isfamily": 0
                        },
                        {
                            "id": "3622361664",
                            "secret": "b22798ceb0",
                            "server": "2480",
                            "farm": 3,
                            "owner": "71966152@N00",
                            "username": "stevenarens",
                            "title": "farm horse",
                            "ispublic": 1,
                            "isfriend": 0,
                            "isfamily": 0
                        },
                        {
                            "id": "2937875142",
                            "secret": "b4b3f7a5e9",
                            "server": "3243",
                            "farm": 4,
                            "owner": "56398280@N00",
                            "username": "dbarronoss",
                            "title": "Don't get my Goat Today",
                            "ispublic": 1,
                            "isfriend": 0,
                            "isfamily": 0
                        },
                        {
                            "id": "3971352751",
                            "secret": "9011faf0ff",
                            "server": "2606",
                            "farm": 3,
                            "owner": "28216401@N02",
                            "username": "lorakaram",
                            "title": "Getting pretty for the show",
                            "ispublic": 1,
                            "isfriend": 0,
                            "isfamily": 0
                        },
                        {
                            "id": "3347598883",
                            "secret": "3d10575c39",
                            "server": "3442",
                            "farm": 4,
                            "owner": "32171214@N00",
                            "username": "slight clutter",
                            "title": "springtime in texas",
                            "ispublic": 1,
                            "isfriend": 0,
                            "isfamily": 0
                        },
                        {
                            "id": "3286751654",
                            "secret": "289c58f550",
                            "server": "3468",
                            "farm": 4,
                            "owner": "9397119@N03",
                            "username": "vishnu rajan",
                            "title": "cow",
                            "ispublic": 1,
                            "isfriend": 0,
                            "isfamily": 0
                        },
                        {
                            "id": "2341099295",
                            "secret": "d261236def",
                            "server": "2035",
                            "farm": 3,
                            "owner": "22007853@N05",
                            "username": "takeite@sy",
                            "title": "french kiss",
                            "ispublic": 1,
                            "isfriend": 0,
                            "isfamily": 0
                        },
                        {
                            "id": "2243341475",
                            "secret": "b8c14cb9a9",
                            "server": "2176",
                            "farm": 3,
                            "owner": "11068823@N05",
                            "username": "slaker",
                            "title": "asino",
                            "ispublic": 1,
                            "isfriend": 0,
                            "isfamily": 0
                        }
                    ]
                },
                "stat": "ok"
            }
            """;

        using var ms = new MemoryStream(Encoding.UTF8.GetBytes(json));

        var result = FlickrConvert.DeserializeObject<FlickrResult<ClusterPhotos>>(ms);

        Assert.NotNull(result);
        Assert.False(result.HasError);
        var items = result.Content;
        Assert.IsType<ClusterPhotos>(items);
        Assert.NotEmpty(items.Values);
        Assert.Equal(18, items.Values.Count);

        Assert.All(items.Values, item =>
        {
            Assert.True(item.IsPublic);
            Assert.False(item.IsFriend);
            Assert.False(item.IsFamily);
        });
    }

    [Fact]
    public void JsonStringToHottags()
    {
        var json = """
            {
                "period": "day",
                "count": 100,
                "hottags": {
                    "tag": [
                        {
                            "_content": "green",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "31585016356",
                                            "secret": "02019367b3",
                                            "server": "255",
                                            "farm": 1,
                                            "owner": "87185102@N00",
                                            "username": null,
                                            "title": ".",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "himmel",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "22690726319",
                                            "secret": "fabc2e51b5",
                                            "server": "5805",
                                            "farm": 6,
                                            "owner": "75169299@N02",
                                            "username": null,
                                            "title": "Boats...",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "lago",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "24537754760",
                                            "secret": "ce9c51144f",
                                            "server": "1507",
                                            "farm": 2,
                                            "owner": "97019005@N08",
                                            "username": null,
                                            "title": "Aspettando la primavera ...",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "umbrella",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "30493195905",
                                            "secret": "22a3ac9246",
                                            "server": "5477",
                                            "farm": 6,
                                            "owner": "44991205@N03",
                                            "username": null,
                                            "title": "Today at the lake Uklei",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "namibia",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "31276917984",
                                            "secret": "4c72f438a6",
                                            "server": "442",
                                            "farm": 1,
                                            "owner": "126616561@N08",
                                            "username": null,
                                            "title": "Swakopmund's pier at sunset",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "lights",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "31668038186",
                                            "secret": "5454306970",
                                            "server": "621",
                                            "farm": 1,
                                            "owner": "65416880@N00",
                                            "username": null,
                                            "title": "Merry Christmas",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "animals",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "24190573589",
                                            "secret": "8c6ecdc4dc",
                                            "server": "1641",
                                            "farm": 2,
                                            "owner": "77206281@N07",
                                            "username": null,
                                            "title": "Ice Skating on the Lake .",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "fox",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "26707240303",
                                            "secret": "7490d5289e",
                                            "server": "7308",
                                            "farm": 8,
                                            "owner": "52232377@N08",
                                            "username": null,
                                            "title": "Fox on the move in the snow",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "chat",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "31011024630",
                                            "secret": "34407cdca9",
                                            "server": "5771",
                                            "farm": 6,
                                            "owner": "23187053@N04",
                                            "username": null,
                                            "title": "Jasmijn in sepia.",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "largeformat",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "25985734604",
                                            "secret": "26eaa526f4",
                                            "server": "1490",
                                            "farm": 2,
                                            "owner": "48308113@N04",
                                            "username": null,
                                            "title": "Lost In Translation",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "colorado",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "31480201640",
                                            "secret": "de49d2374c",
                                            "server": "674",
                                            "farm": 1,
                                            "owner": "40907113@N03",
                                            "username": null,
                                            "title": "Crystal Mill on Color select!!",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "naturephotography",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "29329497061",
                                            "secret": "f176c7bef3",
                                            "server": "8548",
                                            "farm": 9,
                                            "owner": "35303070@N02",
                                            "username": null,
                                            "title": "Roseate Spoonbill In Flight Over Rookery",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "panorama",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "24315995590",
                                            "secret": "4f7d133dae",
                                            "server": "1467",
                                            "farm": 2,
                                            "owner": "139470948@N08",
                                            "username": null,
                                            "title": "Manarola, typical view",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "galicia",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "24717091199",
                                            "secret": "e7453356a9",
                                            "server": "1589",
                                            "farm": 2,
                                            "owner": "31704300@N05",
                                            "username": null,
                                            "title": "Peinando la arena",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "portugal",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "31669879034",
                                            "secret": "5300a3fc51",
                                            "server": "437",
                                            "farm": 1,
                                            "owner": "44086533@N00",
                                            "username": null,
                                            "title": "DRAMATIC STORM AT THE SEA(FELGUEIRAS\/PORTO\/PORTUGAL)",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "seaside",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "30964367852",
                                            "secret": "a44378724f",
                                            "server": "5639",
                                            "farm": 6,
                                            "owner": "133981559@N08",
                                            "username": null,
                                            "title": "Sunrise by the bay",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "cloudscape",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "27082337706",
                                            "secret": "e32722b5d3",
                                            "server": "7749",
                                            "farm": 8,
                                            "owner": "51376865@N08",
                                            "username": null,
                                            "title": "Wheatfields",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "travel",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "30138847155",
                                            "secret": "369361e714",
                                            "server": "5290",
                                            "farm": 6,
                                            "owner": "70192309@N03",
                                            "username": null,
                                            "title": "Lightroom-307",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "algarve",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "28867579242",
                                            "secret": "2e0f9222c2",
                                            "server": "8664",
                                            "farm": 9,
                                            "owner": "117410045@N05",
                                            "username": null,
                                            "title": "Perfect spot to relax",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "br\u00fccke",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "27005238810",
                                            "secret": "ceabf61fa3",
                                            "server": "7293",
                                            "farm": 8,
                                            "owner": "139523059@N02",
                                            "username": null,
                                            "title": "Ein magisches Tor - a magic gate (Rakotzbr\u00fccke, Teufelbr\u00fccke - Rakotzbridge, Devilsbridge)",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "odc",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "32625927475",
                                            "secret": "2c32723346",
                                            "server": "431",
                                            "farm": 1,
                                            "owner": "64549732@N02",
                                            "username": null,
                                            "title": "... the view ...",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "tomb",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "23203661705",
                                            "secret": "001963975e",
                                            "server": "623",
                                            "farm": 1,
                                            "owner": "24990828@N04",
                                            "username": null,
                                            "title": "Honoring Our Deceased",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "ford",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "22511069274",
                                            "secret": "6fefe42028",
                                            "server": "5820",
                                            "farm": 6,
                                            "owner": "61522587@N02",
                                            "username": null,
                                            "title": "Behind The Barn  ....HTT",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "atlanticcoast",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "30626735393",
                                            "secret": "205d84812a",
                                            "server": "5553",
                                            "farm": 6,
                                            "owner": "143492618@N03",
                                            "username": null,
                                            "title": "Sunset on St. Augustine, Florida",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "reversalfilm",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "11624470526",
                                            "secret": "3c4205607b",
                                            "server": "5547",
                                            "farm": 6,
                                            "owner": "52197692@N05",
                                            "username": null,
                                            "title": "island 018",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "hengelo",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "32040194260",
                                            "secret": "d6c65b49a6",
                                            "server": "567",
                                            "farm": 1,
                                            "owner": "77278093@N03",
                                            "username": null,
                                            "title": "Winter colors",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "skiathostown",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "52247045700",
                                            "secret": "fb2ddbb7d7",
                                            "server": "65535",
                                            "farm": 66,
                                            "owner": "96654411@N02",
                                            "username": null,
                                            "title": "Greek Architecture",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "tempestade",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "31669879034",
                                            "secret": "5300a3fc51",
                                            "server": "437",
                                            "farm": 1,
                                            "owner": "44086533@N00",
                                            "username": null,
                                            "title": "DRAMATIC STORM AT THE SEA(FELGUEIRAS\/PORTO\/PORTUGAL)",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "lpa",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "27167399224",
                                            "secret": "c01db181de",
                                            "server": "7320",
                                            "farm": 8,
                                            "owner": "128956256@N08",
                                            "username": null,
                                            "title": "rumbo al cielo",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "cobreces",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "31737648165",
                                            "secret": "c35e3e856e",
                                            "server": "5615",
                                            "farm": 6,
                                            "owner": "31704300@N05",
                                            "username": null,
                                            "title": "Un dia en el Bolao",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "\u8036\u9ebb\u90e1",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "53013680064",
                                            "secret": "e2a9c08a18",
                                            "server": "65535",
                                            "farm": 66,
                                            "owner": "83802319@N00",
                                            "username": null,
                                            "title": "Ripples of rain",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "cachoeira",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "16209042550",
                                            "secret": "2da0176c07",
                                            "server": "8633",
                                            "farm": 9,
                                            "owner": "11049058@N03",
                                            "username": null,
                                            "title": "WONDERFUL SUMMER DAY",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "aidenoise",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "52947573177",
                                            "secret": "e9f6efacd8",
                                            "server": "65535",
                                            "farm": 66,
                                            "owner": "8946089@N04",
                                            "username": null,
                                            "title": "Great Tit",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "livermore",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "23989555136",
                                            "secret": "1882a7c05c",
                                            "server": "1494",
                                            "farm": 2,
                                            "owner": "127316562@N07",
                                            "username": null,
                                            "title": "Clean Energy Revolution or Is It?",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "pearls",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "27349737725",
                                            "secret": "f4d9dc4ae4",
                                            "server": "7499",
                                            "farm": 8,
                                            "owner": "141877194@N02",
                                            "username": null,
                                            "title": "SECRET INLOVE",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "halalfejes",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "53014972096",
                                            "secret": "7fe38a4f5c",
                                            "server": "65535",
                                            "farm": 66,
                                            "owner": "157543065@N06",
                                            "username": null,
                                            "title": "Beauty of my day...",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "schildwants",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "48398216066",
                                            "secret": "afc3289fc5",
                                            "server": "65535",
                                            "farm": 66,
                                            "owner": "24832955@N02",
                                            "username": null,
                                            "title": "The Old World swallowtail and the shieldbug",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "multan",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "52979343781",
                                            "secret": "412b313abd",
                                            "server": "65535",
                                            "farm": 66,
                                            "owner": "194833720@N04",
                                            "username": null,
                                            "title": "Enjoy The Sweetness Of Clouds!!!",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "cafe",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "26803860403",
                                            "secret": "cdde600c89",
                                            "server": "7377",
                                            "farm": 8,
                                            "owner": "24544649@N06",
                                            "username": null,
                                            "title": "F\u00f6nster i ett sommarcafe",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "urbex",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "26783476573",
                                            "secret": "0915cb3edf",
                                            "server": "7324",
                                            "farm": 8,
                                            "owner": "79233265@N07",
                                            "username": null,
                                            "title": "Ob das mal sein Teddyb\u00e4r war?",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "schleswighollstein",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "52818015017",
                                            "secret": "e53c4fb03d",
                                            "server": "65535",
                                            "farm": 66,
                                            "owner": "92998878@N04",
                                            "username": null,
                                            "title": "Sylt",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "sunlight",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "30927416960",
                                            "secret": "791c90b4d3",
                                            "server": "5693",
                                            "farm": 6,
                                            "owner": "28429128@N05",
                                            "username": null,
                                            "title": "The glorious, golden glow of Autumn light.",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "diamond",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "24234192606",
                                            "secret": "09ae9f5101",
                                            "server": "1663",
                                            "farm": 2,
                                            "owner": "120552517@N03",
                                            "username": null,
                                            "title": "Crystal Blue Persuasion",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "powerplant",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "27856020070",
                                            "secret": "034306afe0",
                                            "server": "7300",
                                            "farm": 8,
                                            "owner": "67534619@N02",
                                            "username": null,
                                            "title": "Kraftwerk Reuter (West) - Berlin Panorama",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "astypalaia",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "52265426098",
                                            "secret": "5676060bd5",
                                            "server": "65535",
                                            "farm": 66,
                                            "owner": "152491010@N07",
                                            "username": null,
                                            "title": "Astypalaia Sunset",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "ojoscolorselectivo",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "53012693473",
                                            "secret": "3debf5cf3c",
                                            "server": "65535",
                                            "farm": 66,
                                            "owner": "134385668@N03",
                                            "username": null,
                                            "title": "Luminous eyes...",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "schwarzmilan",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "49145766111",
                                            "secret": "26ed04201e",
                                            "server": "65535",
                                            "farm": 66,
                                            "owner": "25572396@N04",
                                            "username": null,
                                            "title": "Black Kite (Milvus migrans)",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "etatsunis",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "47978696138",
                                            "secret": "c4639f4f2a",
                                            "server": "65535",
                                            "farm": 66,
                                            "owner": "54788905@N00",
                                            "username": null,
                                            "title": "Glacier Bay, Alaska, AK, USA - 0837",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "primavera",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "26199226286",
                                            "secret": "e24b4e55d6",
                                            "server": "1616",
                                            "farm": 2,
                                            "owner": "16854222@N05",
                                            "username": null,
                                            "title": "Just A Little Bit Of Blues",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "us",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "22049392640",
                                            "secret": "6f0f9c0a53",
                                            "server": "748",
                                            "farm": 1,
                                            "owner": "95823068@N06",
                                            "username": null,
                                            "title": "Fall colors and reflections",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "karst",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "53014559894",
                                            "secret": "760a6fbd2e",
                                            "server": "65535",
                                            "farm": 66,
                                            "owner": "192381020@N03",
                                            "username": null,
                                            "title": "Imotski, Modro Jezero (Croatia)",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "cromer",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "52994754782",
                                            "secret": "6b61bf65af",
                                            "server": "65535",
                                            "farm": 66,
                                            "owner": "39129723@N00",
                                            "username": null,
                                            "title": "Sunset over the North Sea",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "mosaic",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "30870508982",
                                            "secret": "47a517561f",
                                            "server": "5522",
                                            "farm": 6,
                                            "owner": "40121274@N03",
                                            "username": null,
                                            "title": "Coeur Defense reflected in Fontaine Agam -  La Defense  (2136)",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "birdsofcolombia",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "52564388240",
                                            "secret": "4538c4210d",
                                            "server": "65535",
                                            "farm": 66,
                                            "owner": "61316002@N02",
                                            "username": null,
                                            "title": "BLABILMOUTOU spilorhynchus 8049",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "haroldcazneaux",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "52498701823",
                                            "secret": "6acdc0e71a",
                                            "server": "65535",
                                            "farm": 66,
                                            "owner": "34279292@N04",
                                            "username": null,
                                            "title": "Tree of Endurance",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "valico",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "50928374786",
                                            "secret": "6e69c03974",
                                            "server": "65535",
                                            "farm": 66,
                                            "owner": "149409629@N08",
                                            "username": null,
                                            "title": "silenziosi rintocchi",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "theperfectphotographer",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "28392183841",
                                            "secret": "e2f0972fd1",
                                            "server": "8238",
                                            "farm": 9,
                                            "owner": "93515708@N07",
                                            "username": null,
                                            "title": "Red steps",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "lynxrufus",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "52736253792",
                                            "secret": "4bd82213d9",
                                            "server": "65535",
                                            "farm": 66,
                                            "owner": "53477149@N02",
                                            "username": null,
                                            "title": "Hot Bobcat",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "landscapephotography",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "21456642814",
                                            "secret": "cb5d406eb7",
                                            "server": "5798",
                                            "farm": 6,
                                            "owner": "77176980@N06",
                                            "username": null,
                                            "title": "Whatcom Falls, Washington",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "ngc",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "31032376416",
                                            "secret": "d845081204",
                                            "server": "5458",
                                            "farm": 6,
                                            "owner": "23187053@N04",
                                            "username": null,
                                            "title": "Yummie, een tor op kleverig koraalzwammetje.",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "rokinon35mm",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "49711967338",
                                            "secret": "554bca55dd",
                                            "server": "65535",
                                            "farm": 66,
                                            "owner": "148035666@N06",
                                            "username": null,
                                            "title": "Layers Of Petals...",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "zwiefalten",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "51687131568",
                                            "secret": "cc52e60665",
                                            "server": "65535",
                                            "farm": 66,
                                            "owner": "140611598@N07",
                                            "username": null,
                                            "title": "Baden-W\u00fcrttemberg, Zwiefalten",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "window",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "23664261139",
                                            "secret": "7d332dd193",
                                            "server": "5730",
                                            "farm": 6,
                                            "owner": "23187053@N04",
                                            "username": null,
                                            "title": "Kinderwinkel Leiden  - Childrenshop in Leiden",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "skiathos",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "52141201560",
                                            "secret": "23ce27581c",
                                            "server": "65535",
                                            "farm": 66,
                                            "owner": "136526699@N04",
                                            "username": null,
                                            "title": "Skiathos Sunset",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "aulacorhynchusprasinusalbivitta",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "40268942574",
                                            "secret": "32b315daa1",
                                            "server": "796",
                                            "farm": 1,
                                            "owner": "26590455@N05",
                                            "username": null,
                                            "title": "Tucancito Esmeralda-Aulacorhynchus albivitta-White-throated Toucanet.",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "greathornedowl",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "32601018155",
                                            "secret": "78e2da790a",
                                            "server": "408",
                                            "farm": 1,
                                            "owner": "89801733@N07",
                                            "username": null,
                                            "title": "Great Horned Owl",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "d810",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "29373708354",
                                            "secret": "2cc396df65",
                                            "server": "8313",
                                            "farm": 9,
                                            "owner": "138752302@N05",
                                            "username": null,
                                            "title": "*September light*",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "streetscene",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "32625745366",
                                            "secret": "c683d8ffaa",
                                            "server": "611",
                                            "farm": 1,
                                            "owner": "41558538@N02",
                                            "username": null,
                                            "title": "Times Square",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "fertig",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "51815195072",
                                            "secret": "0ec4f79865",
                                            "server": "65535",
                                            "farm": 66,
                                            "owner": "136995773@N04",
                                            "username": null,
                                            "title": "Januar an der Elbe ...",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "basque",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "28858508614",
                                            "secret": "8ae854244a",
                                            "server": "8116",
                                            "farm": 9,
                                            "owner": "67534619@N02",
                                            "username": null,
                                            "title": "Gaztelugatxe",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "experimentallandscapes",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "52922114905",
                                            "secret": "61554f3922",
                                            "server": "65535",
                                            "farm": 66,
                                            "owner": "65513951@N03",
                                            "username": null,
                                            "title": "Smoky landscape",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "graphics",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "49937565196",
                                            "secret": "d265e7e56c",
                                            "server": "65535",
                                            "farm": 66,
                                            "owner": "48646584@N00",
                                            "username": null,
                                            "title": "Munich - Georg-Brauchle-Ring",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "dusk",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "30167290522",
                                            "secret": "8258571040",
                                            "server": "5648",
                                            "farm": 6,
                                            "owner": "138752302@N05",
                                            "username": null,
                                            "title": "*Nightfall in Oia*",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "border",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "25014460992",
                                            "secret": "13718ec771",
                                            "server": "1531",
                                            "farm": 2,
                                            "owner": "7156765@N05",
                                            "username": null,
                                            "title": "Sonnenberg Gardens & Mansion Historic Park ~ Canandaigua NY",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "adriatic",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "31121185495",
                                            "secret": "7e7f132021",
                                            "server": "5327",
                                            "farm": 6,
                                            "owner": "145860313@N08",
                                            "username": null,
                                            "title": "Makarska",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "daisies",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "27836002230",
                                            "secret": "09d775d589",
                                            "server": "7354",
                                            "farm": 8,
                                            "owner": "29400538@N04",
                                            "username": null,
                                            "title": "Daisies in the Breeze",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "castelluccio",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "22718155796",
                                            "secret": "a00ed367ce",
                                            "server": "577",
                                            "farm": 1,
                                            "owner": "81855657@N08",
                                            "username": null,
                                            "title": "Nuove albe sorgeranno",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "canpubphoto",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "52695367678",
                                            "secret": "b2af21ab45",
                                            "server": "65535",
                                            "farm": 66,
                                            "owner": "188924430@N02",
                                            "username": null,
                                            "title": "Urban Fragments",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "israel",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "25098611591",
                                            "secret": "c8a3107aae",
                                            "server": "1482",
                                            "farm": 2,
                                            "owner": "126965123@N02",
                                            "username": null,
                                            "title": "Morning",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "westpier",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "30195177536",
                                            "secret": "ba4d94cd8e",
                                            "server": "7551",
                                            "farm": 8,
                                            "owner": "96705257@N08",
                                            "username": null,
                                            "title": "West Pier",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "doughnut",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "48108964386",
                                            "secret": "ccaec5a6cc",
                                            "server": "65535",
                                            "farm": 66,
                                            "owner": "96195739@N08",
                                            "username": null,
                                            "title": "Macro Mondays...Styling Food on a Fork",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "nagoya",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "52293381539",
                                            "secret": "376e392da6",
                                            "server": "65535",
                                            "farm": 66,
                                            "owner": "147061930@N04",
                                            "username": null,
                                            "title": "A tiny visitor",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "bears",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "52809869374",
                                            "secret": "96ec08f2bd",
                                            "server": "65535",
                                            "farm": 66,
                                            "owner": "52232377@N08",
                                            "username": null,
                                            "title": "Mama and the three bears",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "nikkor18300mm",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "26058324996",
                                            "secret": "ae7e08dbf5",
                                            "server": "1556",
                                            "farm": 2,
                                            "owner": "62425933@N04",
                                            "username": null,
                                            "title": "How's The View?",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "stitched",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "28302175982",
                                            "secret": "43ff6373ce",
                                            "server": "8829",
                                            "farm": 9,
                                            "owner": "15145314@N06",
                                            "username": null,
                                            "title": "The Path To Dawn",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "meropsapiaster",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "28395769635",
                                            "secret": "04f9417e7c",
                                            "server": "8591",
                                            "farm": 9,
                                            "owner": "54695128@N04",
                                            "username": null,
                                            "title": "Flores y colores",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "\u00e1vila",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "31265050952",
                                            "secret": "62312abaff",
                                            "server": "5823",
                                            "farm": 6,
                                            "owner": "144636388@N08",
                                            "username": null,
                                            "title": "Mirador de los 4 postes",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "belunivers",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "52656125601",
                                            "secret": "299396a4f3",
                                            "server": "65535",
                                            "farm": 66,
                                            "owner": "163993098@N03",
                                            "username": null,
                                            "title": "Bleu, blanc, brume ...",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "touristicdestinations",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "48476563512",
                                            "secret": "a8dc55c50f",
                                            "server": "65535",
                                            "farm": 66,
                                            "owner": "50085251@N05",
                                            "username": null,
                                            "title": "Cascais Porutgal",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "rahmen",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "32238653752",
                                            "secret": "f315cc2d2c",
                                            "server": "315",
                                            "farm": 1,
                                            "owner": "89197537@N05",
                                            "username": null,
                                            "title": "Fensterbank Breiten",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "mier",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "52187336902",
                                            "secret": "d4f34c8647",
                                            "server": "65535",
                                            "farm": 66,
                                            "owner": "87185102@N00",
                                            "username": null,
                                            "title": "summer daisy.........",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "leipzig",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "31205952274",
                                            "secret": "d48c444973",
                                            "server": "619",
                                            "farm": 1,
                                            "owner": "130255457@N03",
                                            "username": null,
                                            "title": "Last Sunrise in 2016 as Panorama",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "scenic",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "21456642814",
                                            "secret": "cb5d406eb7",
                                            "server": "5798",
                                            "farm": 6,
                                            "owner": "77176980@N06",
                                            "username": null,
                                            "title": "Whatcom Falls, Washington",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "music",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "30292181441",
                                            "secret": "366d8b2e46",
                                            "server": "8552",
                                            "farm": 9,
                                            "owner": "54834349@N08",
                                            "username": null,
                                            "title": "Aria ... Lascia ch'io pianga ...",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "extras",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "46826379824",
                                            "secret": "910d96287c",
                                            "server": "7914",
                                            "farm": 8,
                                            "owner": "127791273@N03",
                                            "username": null,
                                            "title": "Hummingbird Moth",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "berge",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "26619836592",
                                            "secret": "fdce37fcf5",
                                            "server": "1449",
                                            "farm": 2,
                                            "owner": "47290259@N06",
                                            "username": null,
                                            "title": "Der  Klaussee in 2.162 m  H\u00f6he  im  Ahrntal \/ S\u00fcdtirol",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "pond",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "23341040592",
                                            "secret": "12d5b6d49b",
                                            "server": "576",
                                            "farm": 1,
                                            "owner": "129084494@N04",
                                            "username": null,
                                            "title": "Lavender Pond",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "softlight",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "24356600161",
                                            "secret": "bfa010e6b8",
                                            "server": "1697",
                                            "farm": 2,
                                            "owner": "123220137@N06",
                                            "username": null,
                                            "title": "The little red barn...",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "frontyardbugs",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "52318149057",
                                            "secret": "8b0a97128e",
                                            "server": "65535",
                                            "farm": 66,
                                            "owner": "67120745@N06",
                                            "username": null,
                                            "title": "Eufala Skipper -- Life bug!",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        },
                        {
                            "_content": "redcuillin",
                            "thm_data": {
                                "photos": {
                                    "photo": [
                                        {
                                            "id": "50045408568",
                                            "secret": "45b51dbca3",
                                            "server": "65535",
                                            "farm": 66,
                                            "owner": "124783264@N02",
                                            "username": null,
                                            "title": "Broadford Red Hills at sunset ( Isle of Skye)",
                                            "ispublic": 1,
                                            "isfriend": 0,
                                            "isfamily": 0
                                        }
                                    ]
                                }
                            }
                        }
                    ]
                },
                "stat": "ok"
            }
            """;

        using var ms = new MemoryStream(Encoding.UTF8.GetBytes(json));

        var result = FlickrConvert.DeserializeObject<FlickrStatsResult<Hottags>>(ms);

        Assert.NotNull(result);
        Assert.False(result.HasError);
        Assert.Equal(100, result.Count);
        var items = result.Content;
        Assert.IsType<Hottags>(items);
        Assert.NotEmpty(items.Values);

        Assert.All(items.Values, item =>
        {
            Assert.NotEmpty(item.ThmData.Photos.Values);
            Assert.All(item.ThmData.Photos.Values, value =>
            {
                Assert.True(value.IsPublic);
                Assert.False(value.IsFriend);
                Assert.False(value.IsFamily);
            });
        });
    }
}