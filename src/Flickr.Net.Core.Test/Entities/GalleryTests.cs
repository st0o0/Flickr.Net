using System.Text;
using Flickr.Net.Core.Extensions;
using Flickr.Net.Core.Flickrs.Results;
using Flickr.Net.Core.Internals;
using Newtonsoft.Json;

namespace Flickr.Net.Core.Test.Entities;

public class GalleryTests
{
    [Fact]
    public void JsonStringToUserGalleries()
    {
        var json = /*lang=json,strict*/ """
            {
                "galleries": {
                    "total": 18,
                    "per_page": 18,
                    "user_id": "153496924@N03",
                    "page": 1,
                    "pages": 1,
                    "gallery": [
                        {
                            "id": "153473870-72157713236799741",
                            "gallery_id": "72157713236799741",
                            "url": "https:\/\/www.flickr.com\/photos\/kaauenwasser\/galleries\/72157713236799741",
                            "owner": "153496924@N03",
                            "username": "KaAuenwasser",
                            "iconserver": "7921",
                            "iconfarm": 8,
                            "primary_photo_id": "49552706988",
                            "date_create": "1582544300",
                            "date_update": "1678738529",
                            "count_photos": 342,
                            "count_videos": 0,
                            "count_total": 0,
                            "count_views": 241,
                            "count_comments": 10,
                            "title": {
                                "_content": "Besonderheiten 9"
                            },
                            "description": {
                                "_content": "Einfach alles wo Mir gef\u00e4llt !!!!"
                            },
                            "sort_group": null,
                            "primary_photo_server": "65535",
                            "primary_photo_farm": 66,
                            "primary_photo_secret": "b4136403b9"
                        },
                        {
                            "id": "153473870-72157711380699437",
                            "gallery_id": "72157711380699437",
                            "url": "https:\/\/www.flickr.com\/photos\/kaauenwasser\/galleries\/72157711380699437",
                            "owner": "153496924@N03",
                            "username": "KaAuenwasser",
                            "iconserver": "7921",
                            "iconfarm": 8,
                            "primary_photo_id": "49563346532",
                            "date_create": "1571332043",
                            "date_update": "1686420432",
                            "count_photos": 443,
                            "count_videos": 0,
                            "count_total": 0,
                            "count_views": 197,
                            "count_comments": 9,
                            "title": {
                                "_content": "Tiere 9"
                            },
                            "description": {
                                "_content": "Alle Tiere egal ob Luft,Wasser oder Land"
                            },
                            "sort_group": null,
                            "primary_photo_server": "65535",
                            "primary_photo_farm": 66,
                            "primary_photo_secret": "9fabf86be3"
                        },
                        {
                            "id": "153473870-72157711233220657",
                            "gallery_id": "72157711233220657",
                            "url": "https:\/\/www.flickr.com\/photos\/kaauenwasser\/galleries\/72157711233220657",
                            "owner": "153496924@N03",
                            "username": "KaAuenwasser",
                            "iconserver": "7921",
                            "iconfarm": 8,
                            "primary_photo_id": "48916748596",
                            "date_create": "1570460387",
                            "date_update": "1687713393",
                            "count_photos": 438,
                            "count_videos": 0,
                            "count_total": 0,
                            "count_views": 392,
                            "count_comments": 17,
                            "title": {
                                "_content": "Besonderheiten 8"
                            },
                            "description": {
                                "_content": "Einfach alles wo Mir gef\u00e4llt !!!!"
                            },
                            "sort_group": null,
                            "primary_photo_server": "65535",
                            "primary_photo_farm": 66,
                            "primary_photo_secret": "b8452e190e"
                        },
                        {
                            "id": "153473870-72157709151821793",
                            "gallery_id": "72157709151821793",
                            "url": "https:\/\/www.flickr.com\/photos\/kaauenwasser\/galleries\/72157709151821793",
                            "owner": "153496924@N03",
                            "username": "KaAuenwasser",
                            "iconserver": "7921",
                            "iconfarm": 8,
                            "primary_photo_id": "48856394946",
                            "date_create": "1560932178",
                            "date_update": "1687804420",
                            "count_photos": 454,
                            "count_videos": 0,
                            "count_total": 0,
                            "count_views": 335,
                            "count_comments": 19,
                            "title": {
                                "_content": "Tiere 8"
                            },
                            "description": {
                                "_content": "Alle Tiere egal ob Luft,Wasser oder Land"
                            },
                            "sort_group": null,
                            "primary_photo_server": "65535",
                            "primary_photo_farm": 66,
                            "primary_photo_secret": "ec8641e8d3"
                        },
                        {
                            "id": "153473870-72157690681919143",
                            "gallery_id": "72157690681919143",
                            "url": "https:\/\/www.flickr.com\/photos\/kaauenwasser\/galleries\/72157690681919143",
                            "owner": "153496924@N03",
                            "username": "KaAuenwasser",
                            "iconserver": "7921",
                            "iconfarm": 8,
                            "primary_photo_id": "48858102218",
                            "date_create": "1554068824",
                            "date_update": "1680425437",
                            "count_photos": 457,
                            "count_videos": 0,
                            "count_total": 0,
                            "count_views": 366,
                            "count_comments": 17,
                            "title": {
                                "_content": "Besonderheiten 7"
                            },
                            "description": {
                                "_content": "Einfach alles wo Mir gef\u00e4llt !!!!"
                            },
                            "sort_group": null,
                            "primary_photo_server": "65535",
                            "primary_photo_farm": 66,
                            "primary_photo_secret": "6f3bc8f2e0"
                        },
                        {
                            "id": "153473870-72157704341586372",
                            "gallery_id": "72157704341586372",
                            "url": "https:\/\/www.flickr.com\/photos\/kaauenwasser\/galleries\/72157704341586372",
                            "owner": "153496924@N03",
                            "username": "KaAuenwasser",
                            "iconserver": "7921",
                            "iconfarm": 8,
                            "primary_photo_id": "47638243571",
                            "date_create": "1554032810",
                            "date_update": "1688171422",
                            "count_photos": 442,
                            "count_videos": 0,
                            "count_total": 0,
                            "count_views": 193,
                            "count_comments": 10,
                            "title": {
                                "_content": "Tiere 7"
                            },
                            "description": {
                                "_content": "Alle Tiere egal ob Luft,Wasser oder Land"
                            },
                            "sort_group": null,
                            "primary_photo_server": "65535",
                            "primary_photo_farm": 66,
                            "primary_photo_secret": "a07438a36d"
                        },
                        {
                            "id": "153473870-72157705708824981",
                            "gallery_id": "72157705708824981",
                            "url": "https:\/\/www.flickr.com\/photos\/kaauenwasser\/galleries\/72157705708824981",
                            "owner": "153496924@N03",
                            "username": "KaAuenwasser",
                            "iconserver": "7921",
                            "iconfarm": 8,
                            "primary_photo_id": "32558866377",
                            "date_create": "1551576259",
                            "date_update": "1687618633",
                            "count_photos": 429,
                            "count_videos": 0,
                            "count_total": 0,
                            "count_views": 435,
                            "count_comments": 16,
                            "title": {
                                "_content": "Besonderheiten 6"
                            },
                            "description": {
                                "_content": "Einfach alles wo Mir gef\u00e4llt !!!!"
                            },
                            "sort_group": null,
                            "primary_photo_server": "7850",
                            "primary_photo_farm": 8,
                            "primary_photo_secret": "836fd07acc"
                        },
                        {
                            "id": "153473870-72157703776480372",
                            "gallery_id": "72157703776480372",
                            "url": "https:\/\/www.flickr.com\/photos\/kaauenwasser\/galleries\/72157703776480372",
                            "owner": "153496924@N03",
                            "username": "KaAuenwasser",
                            "iconserver": "7921",
                            "iconfarm": 8,
                            "primary_photo_id": "46782039234",
                            "date_create": "1551528456",
                            "date_update": "1687259308",
                            "count_photos": 433,
                            "count_videos": 0,
                            "count_total": 0,
                            "count_views": 296,
                            "count_comments": 12,
                            "title": {
                                "_content": "Tiere 6"
                            },
                            "description": {
                                "_content": "Alle Tiere egal ob Luft,Wasser oder Land"
                            },
                            "sort_group": null,
                            "primary_photo_server": "7919",
                            "primary_photo_farm": 8,
                            "primary_photo_secret": "5fca7e5e73"
                        },
                        {
                            "id": "153473870-72157679067509708",
                            "gallery_id": "72157679067509708",
                            "url": "https:\/\/www.flickr.com\/photos\/kaauenwasser\/galleries\/72157679067509708",
                            "owner": "153496924@N03",
                            "username": "KaAuenwasser",
                            "iconserver": "7921",
                            "iconfarm": 8,
                            "primary_photo_id": "47402516552",
                            "date_create": "1551479315",
                            "date_update": "1685473772",
                            "count_photos": 445,
                            "count_videos": 0,
                            "count_total": 0,
                            "count_views": 254,
                            "count_comments": 9,
                            "title": {
                                "_content": "Tiere 5"
                            },
                            "description": {
                                "_content": "Alle Tiere egal ob Luft,Wasser oder Land"
                            },
                            "sort_group": null,
                            "primary_photo_server": "7903",
                            "primary_photo_farm": 8,
                            "primary_photo_secret": "3c31352b7d"
                        },
                        {
                            "id": "153473870-72157707263881554",
                            "gallery_id": "72157707263881554",
                            "url": "https:\/\/www.flickr.com\/photos\/kaauenwasser\/galleries\/72157707263881554",
                            "owner": "153496924@N03",
                            "username": "KaAuenwasser",
                            "iconserver": "7921",
                            "iconfarm": 8,
                            "primary_photo_id": "40489406953",
                            "date_create": "1551477705",
                            "date_update": "1677261014",
                            "count_photos": 443,
                            "count_videos": 0,
                            "count_total": 0,
                            "count_views": 320,
                            "count_comments": 16,
                            "title": {
                                "_content": "Besonderheiten 5"
                            },
                            "description": {
                                "_content": "Einfach alles wo Mir gef\u00e4llt !!!!"
                            },
                            "sort_group": null,
                            "primary_photo_server": "7807",
                            "primary_photo_farm": 8,
                            "primary_photo_secret": "3b6a95c506"
                        },
                        {
                            "id": "153473870-72157703545282345",
                            "gallery_id": "72157703545282345",
                            "url": "https:\/\/www.flickr.com\/photos\/kaauenwasser\/galleries\/72157703545282345",
                            "owner": "153496924@N03",
                            "username": "KaAuenwasser",
                            "iconserver": "7921",
                            "iconfarm": 8,
                            "primary_photo_id": "47064007262",
                            "date_create": "1542117766",
                            "date_update": "1687698470",
                            "count_photos": 453,
                            "count_videos": 0,
                            "count_total": 0,
                            "count_views": 391,
                            "count_comments": 15,
                            "title": {
                                "_content": "Besonderheiten 4"
                            },
                            "description": {
                                "_content": "Einfach alles wo Mir gef\u00e4llt !!!!"
                            },
                            "sort_group": null,
                            "primary_photo_server": "7884",
                            "primary_photo_farm": 8,
                            "primary_photo_secret": "de69bbb5b0"
                        },
                        {
                            "id": "153473870-72157703545265845",
                            "gallery_id": "72157703545265845",
                            "url": "https:\/\/www.flickr.com\/photos\/kaauenwasser\/galleries\/72157703545265845",
                            "owner": "153496924@N03",
                            "username": "KaAuenwasser",
                            "iconserver": "7921",
                            "iconfarm": 8,
                            "primary_photo_id": "32513604827",
                            "date_create": "1542117738",
                            "date_update": "1682616243",
                            "count_photos": 446,
                            "count_videos": 0,
                            "count_total": 0,
                            "count_views": 312,
                            "count_comments": 11,
                            "title": {
                                "_content": "Tiere 4"
                            },
                            "description": {
                                "_content": "Alle Tiere egal ob Luft,Wasser oder Land"
                            },
                            "sort_group": null,
                            "primary_photo_server": "7901",
                            "primary_photo_farm": 8,
                            "primary_photo_secret": "377b658fc6"
                        },
                        {
                            "id": "153473870-72157702907061705",
                            "gallery_id": "72157702907061705",
                            "url": "https:\/\/www.flickr.com\/photos\/kaauenwasser\/galleries\/72157702907061705",
                            "owner": "153496924@N03",
                            "username": "KaAuenwasser",
                            "iconserver": "7921",
                            "iconfarm": 8,
                            "primary_photo_id": "47455166931",
                            "date_create": "1540723895",
                            "date_update": "1686345658",
                            "count_photos": 432,
                            "count_videos": 0,
                            "count_total": 0,
                            "count_views": 282,
                            "count_comments": 5,
                            "title": {
                                "_content": "Tiere 3"
                            },
                            "description": {
                                "_content": "Alle Tiere egal ob Luft,Wasser oder Land"
                            },
                            "sort_group": null,
                            "primary_photo_server": "7880",
                            "primary_photo_farm": 8,
                            "primary_photo_secret": "9b98293b19"
                        },
                        {
                            "id": "153473870-72157702731232674",
                            "gallery_id": "72157702731232674",
                            "url": "https:\/\/www.flickr.com\/photos\/kaauenwasser\/galleries\/72157702731232674",
                            "owner": "153496924@N03",
                            "username": "KaAuenwasser",
                            "iconserver": "7921",
                            "iconfarm": 8,
                            "primary_photo_id": "47120660191",
                            "date_create": "1540658080",
                            "date_update": "1681758312",
                            "count_photos": 449,
                            "count_videos": 0,
                            "count_total": 0,
                            "count_views": 406,
                            "count_comments": 15,
                            "title": {
                                "_content": "Besonderheiten 3"
                            },
                            "description": {
                                "_content": "Einfach alles wo Mir gef\u00e4llt !!!!"
                            },
                            "sort_group": null,
                            "primary_photo_server": "7901",
                            "primary_photo_farm": 8,
                            "primary_photo_secret": "b7bcdbd2a5"
                        },
                        {
                            "id": "153473870-72157672235612567",
                            "gallery_id": "72157672235612567",
                            "url": "https:\/\/www.flickr.com\/photos\/kaauenwasser\/galleries\/72157672235612567",
                            "owner": "153496924@N03",
                            "username": "KaAuenwasser",
                            "iconserver": "7921",
                            "iconfarm": 8,
                            "primary_photo_id": "46667376734",
                            "date_create": "1539315622",
                            "date_update": "1681326864",
                            "count_photos": 443,
                            "count_videos": 0,
                            "count_total": 0,
                            "count_views": 382,
                            "count_comments": 15,
                            "title": {
                                "_content": "Tiere 2"
                            },
                            "description": {
                                "_content": "Alle Tiere egal ob Luft,Wasser oder Land"
                            },
                            "sort_group": null,
                            "primary_photo_server": "7824",
                            "primary_photo_farm": 8,
                            "primary_photo_secret": "8d747826ab"
                        },
                        {
                            "id": "153473870-72157701837396424",
                            "gallery_id": "72157701837396424",
                            "url": "https:\/\/www.flickr.com\/photos\/kaauenwasser\/galleries\/72157701837396424",
                            "owner": "153496924@N03",
                            "username": "KaAuenwasser",
                            "iconserver": "7921",
                            "iconfarm": 8,
                            "primary_photo_id": "47206041892",
                            "date_create": "1538682969",
                            "date_update": "1686704653",
                            "count_photos": 456,
                            "count_videos": 0,
                            "count_total": 0,
                            "count_views": 506,
                            "count_comments": 13,
                            "title": {
                                "_content": "Besonderheiten 2"
                            },
                            "description": {
                                "_content": "Einfach alles wo Mir gef\u00e4llt !!!!"
                            },
                            "sort_group": null,
                            "primary_photo_server": "7826",
                            "primary_photo_farm": 8,
                            "primary_photo_secret": "3f3ca65467"
                        },
                        {
                            "id": "153473870-72157696092671380",
                            "gallery_id": "72157696092671380",
                            "url": "https:\/\/www.flickr.com\/photos\/kaauenwasser\/galleries\/72157696092671380",
                            "owner": "153496924@N03",
                            "username": "KaAuenwasser",
                            "iconserver": "7921",
                            "iconfarm": 8,
                            "primary_photo_id": "40489218633",
                            "date_create": "1538406483",
                            "date_update": "1677830438",
                            "count_photos": 442,
                            "count_videos": 0,
                            "count_total": 0,
                            "count_views": 371,
                            "count_comments": 7,
                            "title": {
                                "_content": "Tiere 1"
                            },
                            "description": {
                                "_content": "Alle Tiere egal ob Luft,Wasser oder Land"
                            },
                            "sort_group": null,
                            "primary_photo_server": "7904",
                            "primary_photo_farm": 8,
                            "primary_photo_secret": "2dd85bde0e"
                        },
                        {
                            "id": "153473870-72157698619148732",
                            "gallery_id": "72157698619148732",
                            "url": "https:\/\/www.flickr.com\/photos\/kaauenwasser\/galleries\/72157698619148732",
                            "owner": "153496924@N03",
                            "username": "KaAuenwasser",
                            "iconserver": "7921",
                            "iconfarm": 8,
                            "primary_photo_id": "47740876231",
                            "date_create": "1538167975",
                            "date_update": "1687060120",
                            "count_photos": 467,
                            "count_videos": 0,
                            "count_total": 0,
                            "count_views": 449,
                            "count_comments": 10,
                            "title": {
                                "_content": "Besonderheiten 1"
                            },
                            "description": {
                                "_content": "Einfach alles wo Mir gef\u00e4llt !!!!"
                            },
                            "sort_group": null,
                            "primary_photo_server": "65535",
                            "primary_photo_farm": 66,
                            "primary_photo_secret": "44c794c008"
                        }
                    ]
                },
                "stat": "ok"
            }
            """;

        using var ms = new MemoryStream(Encoding.UTF8.GetBytes(json));

        var result = FlickrConvert.DeserializeObject<FlickrResult<UserGalleries>>(ms);

        Assert.NotNull(result);
        Assert.False(result.HasError);
        Assert.IsType<UserGalleries>(result.Content);
        var items = result.Content;
        Assert.Equal("153496924@N03", items.UserId);
        Assert.NotEmpty(items.Values);
        Assert.IsType<Gallery>(items.Values[0]);
        Assert.Equal(items.Values.Count, items.Total);
        Assert.IsType<DateTime>(items.Values[0].UpdateDate);
        Assert.IsType<DateTime>(items.Values[0].CreateDate);
        Assert.NotEmpty(items.Values[0].ToBuddyIconUrl());
        Assert.NotEmpty(items.Values[0].ToSquareUrl());
        Assert.NotEmpty(items.Values[0].ToSmallUrl());
        Assert.NotEmpty(items.Values[0].ToMediumUrl());
        Assert.NotEmpty(items.Values[0].ToThumbnailUrl());
    }

    [Fact]
    public void JsonStringToPhotoGalleries()
    {
        var json = /*lang=json,strict*/ """
            {
                "galleries": {
                    "total": "1",
                    "page": 1,
                    "pages": 1,
                    "per_page": 100,
                    "photo_id": "3448374524",
                    "gallery": [
                        {
                            "id": "6065-72157617483228192",
                            "gallery_id": "72157617483228192",
                            "url": "https:\/\/www.flickr.com\/photos\/straup\/galleries\/72157617483228192",
                            "owner": "35034348999@N01",
                            "username": "straup",
                            "iconserver": "1",
                            "iconfarm": 1,
                            "primary_photo_id": "292882708",
                            "date_create": "1241028772",
                            "date_update": "1673472286",
                            "count_photos": 13,
                            "count_videos": 0,
                            "count_total": 13,
                            "count_views": 1576,
                            "count_comments": 5,
                            "title": {
                                "_content": "Cat Pictures I've Sent To Kevin Collins"
                            },
                            "description": {
                                "_content": ""
                            },
                            "sort_group": null,
                            "primary_photo_server": "112",
                            "primary_photo_farm": 1,
                            "primary_photo_secret": "7f29861bc4"
                        }
                    ]
                },
                "stat": "ok"
            }
            """;

        using var ms = new MemoryStream(Encoding.UTF8.GetBytes(json));

        var result = FlickrConvert.DeserializeObject<FlickrResult<PhotoGalleries>>(ms);

        Assert.NotNull(result);
        Assert.False(result.HasError);
        Assert.IsType<PhotoGalleries>(result.Content);
        var items = result.Content;
        Assert.Equal("3448374524", items.PhotoId);
        Assert.NotEmpty(items.Values);
        Assert.IsType<Gallery>(items.Values[0]);
        Assert.Equal(items.Values.Count, items.Total);
        Assert.IsType<DateTime>(items.Values[0].UpdateDate);
        Assert.IsType<DateTime>(items.Values[0].CreateDate);
    }

    [Fact]
    public void JsonStringToGalleryPhotos()
    {
        var json = /*lang=json,strict*/ """
            {
              "stat": "ok",
              "photos": {
                "page": "1",
                "pages": "1",
                "perpage": "500",
                "total": "2",
                "photo": [
                  {
                    "id": "2822546461",
                    "owner": "78398753@N00",
                    "secret": "2dbcdb589f",
                    "server": "1",
                    "farm": "1",
                    "title": "FOO",
                    "ispublic": "1",
                    "isfriend": "0",
                    "isfamily": "0",
                    "is_primary": "1",
                    "has_comment": "1",
                    "comment": [
                      "best cat picture ever!",
                      "best cat picture ever!"
                    ]
                  },
                  {
                    "id": "2822544806",
                    "owner": "78398753@N00",
                    "secret": "bd93cbe917",
                    "server": "1",
                    "farm": "1",
                    "title": "OOK",
                    "ispublic": "1",
                    "isfriend": "0",
                    "isfamily": "0",
                    "is_primary": "0",
                    "has_comment": "0"
                  }
                ]
              }
            }
            """;

        using var ms = new MemoryStream(Encoding.UTF8.GetBytes(json));

        var result = FlickrConvert.DeserializeObject<FlickrResult<GalleryPhotos>>(ms);

        Assert.NotNull(result);
        Assert.False(result.HasError);
        Assert.IsType<GalleryPhotos>(result.Content);
        var items = result.Content;
        Assert.NotEmpty(items.Values);
        Assert.IsType<GalleryPhoto>(items.Values[0]);
        Assert.Equal(items.Values.Count, items.Total);
        Assert.True(items.Values[0].HasComments);
        Assert.True(items.Values[0].IsPrimary);
        Assert.True(items.Values[0].Comments.Any());
        Assert.False(items.Values[1].HasComments);
        Assert.False(items.Values[1].IsPrimary);
        Assert.False(items.Values[1].Comments.Any());
    }

    [Fact]
    public void JsonStringToGalleryInfo()
    {
        var json = /*lang=json,strict*/ """
            {
              "gallery": {
                "id": "6065-72157617483228192",
                "gallery_id": "72157617483228192",
                "url": "https://www.flickr.com/photos/straup/galleries/72157617483228192",
                "owner": "35034348999@N01",
                "username": "straup",
                "iconserver": "1",
                "iconfarm": 1,
                "primary_photo_id": "292882708",
                "date_create": "1241028772",
                "date_update": "1673472286",
                "count_photos": 13,
                "count_videos": 0,
                "count_total": 13,
                "count_views": 1576,
                "count_comments": 5,
                "title": {
                  "_content": "Cat Pictures I've Sent To Kevin Collins"
                },
                "description": {
                  "_content": ""
                },
                "sort_group": null,
                "cover_photos": {
                  "photo": [
                    {
                      "url": "https://live.staticflickr.com/112/292882708_7f29861bc4_q.jpg",
                      "width": 150,
                      "height": 150,
                      "is_primary": 1,
                      "is_video": 0
                    },
                    {
                      "url": "https://live.staticflickr.com/3590/3448374524_c2f2186565_q.jpg",
                      "width": 150,
                      "height": 150,
                      "is_primary": 0,
                      "is_video": 0
                    },
                    {
                      "url": "https://live.staticflickr.com/99/314988630_1db5c18f15_q.jpg",
                      "width": 150,
                      "height": 150,
                      "is_primary": 0,
                      "is_video": 0
                    }
                  ]
                },
                "current_state": "5e441e28364c4722fcaa644c9fa00625",
                "primary_photo_server": "112",
                "primary_photo_farm": 1,
                "primary_photo_secret": "7f29861bc4"
              },
              "stat": "ok"
            }
            """;

        using var ms = new MemoryStream(Encoding.UTF8.GetBytes(json));

        var result = FlickrConvert.DeserializeObject<FlickrResult<GalleryInfo>>(ms);

        Assert.NotNull(result);
        Assert.False(result.HasError);
        Assert.IsType<GalleryInfo>(result.Content);
        var items = result.Content;
        Assert.Equal(13, items.PhotosCount);
        Assert.Equal(0, items.VideosCount);
        Assert.Equal(13, items.TotalCount);
        Assert.Equal(1576, items.ViewsCount);
        Assert.Equal(5, items.CommentsCount);
        Assert.NotEmpty(items.CoverPhotos.Values);

        Assert.All(items.CoverPhotos.Values, item =>
        {
            Assert.Equal(150, item.Width);
            Assert.Equal(150, item.Height);
            Assert.False(item.IsVideo);
        });
    }
}