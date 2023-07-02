using Flickr.Net.Core.Flickrs.Results;
using Flickr.Net.Core.Internals;

namespace Flickr.Net.Core.Test.Entities;

public class PhotosetTests
{
    [Fact]
    public void JsonStringToPhotoset()
    {
        var json = /*lang=json,strict*/ """
            {
                "photoset": {
                    "id": "72177720308632074",
                    "owner": "192376927@N06",
                    "username": "st0o0",
                    "primary": "52931686554",
                    "secret": "b77aff865b",
                    "server": "65535",
                    "farm": 66,
                    "count_views": "2",
                    "count_comments": "0",
                    "count_photos": 2,
                    "count_videos": 0,
                    "title": {
                        "_content": "Vreden_13052022"
                    },
                    "description": {
                        "_content": ""
                    },
                    "can_comment": 1,
                    "date_create": "1685270589",
                    "date_update": "1685290674",
                    "photos": 2,
                    "visibility_can_see_set": 1,
                    "needs_interstitial": 0
                },
                "stat": "ok"
            }
            """;

        var result = FlickrConvert.DeserializeObject<FlickrResult<Photoset>>(json);

        Assert.NotNull(result);
        Assert.False(result.HasError);
        var items = result.Content;
        Assert.IsType<Photoset>(items);
        Assert.Equal(2, items.Photos);
        Assert.True(items.VisibilityCanSeeSet);
    }

    [Fact]
    public void JsonStringToPhotosets()
    {
        var json = /*lang=json,strict*/ """
            {
                "photosets": {
                    "cancreate": 1,
                    "page": 1,
                    "pages": 1,
                    "perpage": 500,
                    "total": 87,
                    "photoset": [
                        {
                            "id": "72177720308632074",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "52931686554",
                            "secret": "b77aff865b",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "2",
                            "count_comments": "0",
                            "count_photos": 2,
                            "count_videos": 0,
                            "title": {
                                "_content": "Vreden_13052022"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1685270589",
                            "date_update": "1685290674",
                            "photos": 2,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72177720308619902",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "52931924910",
                            "secret": "d151c6e956",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "1",
                            "count_comments": "0",
                            "count_photos": 3,
                            "count_videos": 0,
                            "title": {
                                "_content": "Vreden_28042022"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1685270537",
                            "date_update": "1685290674",
                            "photos": 3,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72177720308620385",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "52931521611",
                            "secret": "28acddacc2",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "1",
                            "count_comments": "0",
                            "count_photos": 3,
                            "count_videos": 0,
                            "title": {
                                "_content": "Rheininsel_17042022"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1685270248",
                            "date_update": "1685290674",
                            "photos": 3,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72177720295449826",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51765002162",
                            "secret": "e2e04231a7",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "17",
                            "count_comments": "0",
                            "count_photos": 10,
                            "count_videos": 0,
                            "title": {
                                "_content": "Wiese_06112021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1640198530",
                            "date_update": "1685290674",
                            "photos": 10,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72177720295448916",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51765666861",
                            "secret": "217cd728c9",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "7",
                            "count_comments": "0",
                            "count_photos": 3,
                            "count_videos": 0,
                            "title": {
                                "_content": "BurgRoetteln_31102021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1640195842",
                            "date_update": "1685290674",
                            "photos": 3,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72177720295436925",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51764425480",
                            "secret": "e4e8e7f21b",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "7",
                            "count_comments": "0",
                            "count_photos": 5,
                            "count_videos": 0,
                            "title": {
                                "_content": "Wyhlen_24102021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1640153555",
                            "date_update": "1685290674",
                            "photos": 5,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72177720295428382",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51761968043",
                            "secret": "93fd308b3e",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "5",
                            "count_comments": "0",
                            "count_photos": 3,
                            "count_videos": 0,
                            "title": {
                                "_content": "K12_16102021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1640114457",
                            "date_update": "1685290674",
                            "photos": 3,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157720001198745",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51544072762",
                            "secret": "9b15d609ab",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "16",
                            "count_comments": "0",
                            "count_photos": 9,
                            "count_videos": 0,
                            "title": {
                                "_content": "K12_01102021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1633250075",
                            "date_update": "1685290674",
                            "photos": 9,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719926446763",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51532025461",
                            "secret": "193e1308ee",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "14",
                            "count_comments": "0",
                            "count_photos": 7,
                            "count_videos": 0,
                            "title": {
                                "_content": "Aare_17092021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1632937577",
                            "date_update": "1685290674",
                            "photos": 7,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719931884626",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51531157602",
                            "secret": "9db8a53798",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "7",
                            "count_comments": "0",
                            "count_photos": 2,
                            "count_videos": 0,
                            "title": {
                                "_content": "Vechigen_14092021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1632936629",
                            "date_update": "1685290674",
                            "photos": 2,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719907858991",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51514967722",
                            "secret": "810fffa5a4",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "14",
                            "count_comments": "0",
                            "count_photos": 7,
                            "count_videos": 0,
                            "title": {
                                "_content": "DieSchweiz_13092021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1632593239",
                            "date_update": "1685290674",
                            "photos": 7,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719956845860",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51515494596",
                            "secret": "fcfc55417d",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "11",
                            "count_comments": "0",
                            "count_photos": 5,
                            "count_videos": 0,
                            "title": {
                                "_content": "Chuderhuesi_12092021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1632588150",
                            "date_update": "1685290674",
                            "photos": 5,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719805065752",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51437956075",
                            "secret": "fb2bef96da",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "4",
                            "count_comments": "0",
                            "count_photos": 6,
                            "count_videos": 0,
                            "title": {
                                "_content": "DieWiese_05092021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1631122258",
                            "date_update": "1685290674",
                            "photos": 6,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719784180174",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51430041557",
                            "secret": "e6cbb31c8e",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "12",
                            "count_comments": "0",
                            "count_photos": 6,
                            "count_videos": 0,
                            "title": {
                                "_content": "DieWiese_04092021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1630957979",
                            "date_update": "1685290674",
                            "photos": 6,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719777956884",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51427158893",
                            "secret": "f907d0a71d",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "9",
                            "count_comments": "0",
                            "count_photos": 2,
                            "count_videos": 0,
                            "title": {
                                "_content": "K12_02092021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1630861578",
                            "date_update": "1685290674",
                            "photos": 2,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719701911376",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51387708785",
                            "secret": "c7f2fdf334",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "12",
                            "count_comments": "0",
                            "count_photos": 6,
                            "count_videos": 0,
                            "title": {
                                "_content": "K12_14082021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1629309809",
                            "date_update": "1685290674",
                            "photos": 6,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719696269283",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51387613675",
                            "secret": "d2acc3a48e",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "5",
                            "count_comments": "0",
                            "count_photos": 5,
                            "count_videos": 0,
                            "title": {
                                "_content": "K12_12082021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1629306666",
                            "date_update": "1685290674",
                            "photos": 5,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719693810329",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51385453629",
                            "secret": "37e19bdc30",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "5",
                            "count_comments": "0",
                            "count_photos": 3,
                            "count_videos": 0,
                            "title": {
                                "_content": "DieWiese_23072021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1629226572",
                            "date_update": "1685290674",
                            "photos": 3,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719669362707",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51368436854",
                            "secret": "9f35bc5594",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "7",
                            "count_comments": "0",
                            "count_photos": 6,
                            "count_videos": 0,
                            "title": {
                                "_content": "Maulburg_18072021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1628532996",
                            "date_update": "1685290674",
                            "photos": 6,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719553938263",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51317772177",
                            "secret": "1e5b2d7522",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "12",
                            "count_comments": "0",
                            "count_photos": 5,
                            "count_videos": 0,
                            "title": {
                                "_content": "DieWiese_10072021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1626587843",
                            "date_update": "1685290674",
                            "photos": 5,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719525946959",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51304707079",
                            "secret": "caa654fa06",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "20",
                            "count_comments": "0",
                            "count_photos": 5,
                            "count_videos": 0,
                            "title": {
                                "_content": "Maulburg_09072021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1626006428",
                            "date_update": "1685290674",
                            "photos": 5,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719531028882",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51301679138",
                            "secret": "50f460f822",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "7",
                            "count_comments": "0",
                            "count_photos": 6,
                            "count_videos": 0,
                            "title": {
                                "_content": "Nonnenmattweiher_BadBellingen_02072021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1625888617",
                            "date_update": "1685290674",
                            "photos": 6,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719515923201",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51296945652",
                            "secret": "e24c33c30a",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "6",
                            "count_comments": "0",
                            "count_photos": 5,
                            "count_videos": 0,
                            "title": {
                                "_content": "K12_02072021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1625726706",
                            "date_update": "1685290674",
                            "photos": 5,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719546951945",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51289389385",
                            "secret": "cf83899995",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "21",
                            "count_comments": "0",
                            "count_photos": 6,
                            "count_videos": 0,
                            "title": {
                                "_content": "BurgRoetteln_01072021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1625377113",
                            "date_update": "1685290674",
                            "photos": 6,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719468624069",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51276309513",
                            "secret": "8d6c17fc46",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "9",
                            "count_comments": "0",
                            "count_photos": 5,
                            "count_videos": 0,
                            "title": {
                                "_content": "K12_28062021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1624880062",
                            "date_update": "1685290674",
                            "photos": 5,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719468854911",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51275430635",
                            "secret": "a5cde1e0ff",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "4",
                            "count_comments": "0",
                            "count_photos": 3,
                            "count_videos": 0,
                            "title": {
                                "_content": "Maulburg_26062021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1624814920",
                            "date_update": "1685290674",
                            "photos": 3,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719426933509",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51256240809",
                            "secret": "574b5f5fb0",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "21",
                            "count_comments": "0",
                            "count_photos": 4,
                            "count_videos": 0,
                            "title": {
                                "_content": "K12_16062021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1624040289",
                            "date_update": "1685290674",
                            "photos": 4,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719426597396",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51254294794",
                            "secret": "509cef58d8",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "3",
                            "count_comments": "0",
                            "count_photos": 6,
                            "count_videos": 0,
                            "title": {
                                "_content": "K12_15062021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1623955918",
                            "date_update": "1685290674",
                            "photos": 6,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719433739902",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51253535481",
                            "secret": "1721e14ea1",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "2",
                            "count_comments": "0",
                            "count_photos": 2,
                            "count_videos": 0,
                            "title": {
                                "_content": "K12_14062021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1623955455",
                            "date_update": "1685290674",
                            "photos": 2,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719422986434",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51253532041",
                            "secret": "cb2fac1938",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "3",
                            "count_comments": "0",
                            "count_photos": 4,
                            "count_videos": 0,
                            "title": {
                                "_content": "DieWiese_13062021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1623955334",
                            "date_update": "1685290674",
                            "photos": 4,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719342635208",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51225717934",
                            "secret": "573f4f19c6",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "11",
                            "count_comments": "0",
                            "count_photos": 5,
                            "count_videos": 0,
                            "title": {
                                "_content": "DieWiese_03062021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1622833415",
                            "date_update": "1685290674",
                            "photos": 5,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719328038994",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51220800033",
                            "secret": "72916780e2",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "27",
                            "count_comments": "0",
                            "count_photos": 10,
                            "count_videos": 0,
                            "title": {
                                "_content": "K12_02062021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1622654721",
                            "date_update": "1685290674",
                            "photos": 10,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719302177773",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51214369015",
                            "secret": "64defbc4a0",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "17",
                            "count_comments": "0",
                            "count_photos": 9,
                            "count_videos": 0,
                            "title": {
                                "_content": "K12_30052021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1622400851",
                            "date_update": "1685290674",
                            "photos": 9,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719308028316",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51213297666",
                            "secret": "1909646c74",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "3",
                            "count_comments": "0",
                            "count_photos": 4,
                            "count_videos": 0,
                            "title": {
                                "_content": "K12_29052021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1622400556",
                            "date_update": "1685290674",
                            "photos": 4,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719300349892",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51209257498",
                            "secret": "2ff76f2218",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "7",
                            "count_comments": "0",
                            "count_photos": 4,
                            "count_videos": 0,
                            "title": {
                                "_content": "K12_27052021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1622228575",
                            "date_update": "1685290674",
                            "photos": 4,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719275030819",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51205774359",
                            "secret": "1198989931",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "2",
                            "count_comments": "0",
                            "count_photos": 4,
                            "count_videos": 0,
                            "title": {
                                "_content": "K12_25052021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1622055728",
                            "date_update": "1685290674",
                            "photos": 4,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719328013705",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51205207483",
                            "secret": "12ba51d05c",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "1",
                            "count_comments": "0",
                            "count_photos": 3,
                            "count_videos": 0,
                            "title": {
                                "_content": "Maulburg_23052021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1622055583",
                            "date_update": "1685290674",
                            "photos": 3,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719311743765",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51199823312",
                            "secret": "880f775452",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "13",
                            "count_comments": "0",
                            "count_photos": 7,
                            "count_videos": 0,
                            "title": {
                                "_content": "K12_22052021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1621879872",
                            "date_update": "1685290674",
                            "photos": 7,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719204269364",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51185601098",
                            "secret": "f63cac5aa3",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "17",
                            "count_comments": "0",
                            "count_photos": 6,
                            "count_videos": 0,
                            "title": {
                                "_content": "Maulburg_13052021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1621271499",
                            "date_update": "1685290674",
                            "photos": 6,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719257272860",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51186160144",
                            "secret": "9a5ba808f3",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "10",
                            "count_comments": "0",
                            "count_photos": 2,
                            "count_videos": 0,
                            "title": {
                                "_content": "Maulburg_Steinen_03052021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1621271275",
                            "date_update": "1685290674",
                            "photos": 2,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719207921346",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51186152379",
                            "secret": "d60f8c31ac",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "2",
                            "count_comments": "0",
                            "count_photos": 4,
                            "count_videos": 0,
                            "title": {
                                "_content": "Maulburg_09052021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1621270989",
                            "date_update": "1685290674",
                            "photos": 4,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719204344086",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51183709237",
                            "secret": "c2d4dff749",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "5",
                            "count_comments": "0",
                            "count_photos": 7,
                            "count_videos": 0,
                            "title": {
                                "_content": "Wieslet_08052021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1621233900",
                            "date_update": "1685290674",
                            "photos": 7,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719200556514",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51185466125",
                            "secret": "c862464fae",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "0",
                            "count_comments": "0",
                            "count_photos": 2,
                            "count_videos": 0,
                            "title": {
                                "_content": "Steinen_Maulburg_27042021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1621233694",
                            "date_update": "1685290674",
                            "photos": 2,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719253623530",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51185463180",
                            "secret": "a7c00720bf",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "1",
                            "count_comments": "0",
                            "count_photos": 2,
                            "count_videos": 0,
                            "title": {
                                "_content": "K12_25042021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1621233603",
                            "date_update": "1685290674",
                            "photos": 2,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719253613765",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51183695782",
                            "secret": "efdcb04a9a",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "1",
                            "count_comments": "0",
                            "count_photos": 11,
                            "count_videos": 0,
                            "title": {
                                "_content": "K12_24042021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1621233487",
                            "date_update": "1685290674",
                            "photos": 11,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719211218232",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51184588758",
                            "secret": "f081f2af6b",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "2",
                            "count_comments": "0",
                            "count_photos": 8,
                            "count_videos": 0,
                            "title": {
                                "_content": "Maulburg_Schopfheim_23042021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1621233066",
                            "date_update": "1685290674",
                            "photos": 8,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719204254406",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51183681032",
                            "secret": "6deb540bc7",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "0",
                            "count_comments": "0",
                            "count_photos": 8,
                            "count_videos": 0,
                            "title": {
                                "_content": "Steinen_Maulburg_Schopfheim_21042021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1621232818",
                            "date_update": "1685290674",
                            "photos": 8,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719211176502",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51183676167",
                            "secret": "32a817a9f9",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "1",
                            "count_comments": "0",
                            "count_photos": 7,
                            "count_videos": 0,
                            "title": {
                                "_content": "K12_16042021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1621232564",
                            "date_update": "1685290674",
                            "photos": 7,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719249456035",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51182475747",
                            "secret": "fe694064ed",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "3",
                            "count_comments": "0",
                            "count_photos": 3,
                            "count_videos": 0,
                            "title": {
                                "_content": "Rostgans_10042021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1621190300",
                            "date_update": "1685290674",
                            "photos": 3,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719249442710",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51183156111",
                            "secret": "2a4a5d840b",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "0",
                            "count_comments": "0",
                            "count_photos": 4,
                            "count_videos": 0,
                            "title": {
                                "_content": "Rehe_13042021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1621190196",
                            "date_update": "1685290674",
                            "photos": 4,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719206979547",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51183151641",
                            "secret": "7b769bfd04",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "2",
                            "count_comments": "0",
                            "count_photos": 1,
                            "count_videos": 0,
                            "title": {
                                "_content": "Graureiher_08042021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1621190021",
                            "date_update": "1685290674",
                            "photos": 1,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719194180748",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51183149051",
                            "secret": "817a2fd3bb",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "1",
                            "count_comments": "0",
                            "count_photos": 2,
                            "count_videos": 0,
                            "title": {
                                "_content": "Eichhoernchen_11042021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1621189956",
                            "date_update": "1685290674",
                            "photos": 2,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719206885967",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51183337663",
                            "secret": "7cbdc4d07d",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "1",
                            "count_comments": "0",
                            "count_photos": 6,
                            "count_videos": 0,
                            "title": {
                                "_content": "Steinen_Maulburg_05042021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1621189285",
                            "date_update": "1685290674",
                            "photos": 6,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719195969809",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51182410092",
                            "secret": "6fa2ebd879",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "2",
                            "count_comments": "0",
                            "count_photos": 17,
                            "count_videos": 0,
                            "title": {
                                "_content": "Maulburg_04042021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1621188779",
                            "date_update": "1685290674",
                            "photos": 17,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719199031601",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51182169782",
                            "secret": "da888219fe",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "3",
                            "count_comments": "0",
                            "count_photos": 8,
                            "count_videos": 0,
                            "title": {
                                "_content": "K12_31032021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1621182058",
                            "date_update": "1685290674",
                            "photos": 8,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719193104128",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51182155467",
                            "secret": "77d8997d5a",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "3",
                            "count_comments": "0",
                            "count_photos": 13,
                            "count_videos": 0,
                            "title": {
                                "_content": "Steinen_Maulburg_30032021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1621181810",
                            "date_update": "1685290674",
                            "photos": 13,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719248215795",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51183028613",
                            "secret": "d07795512b",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "4",
                            "count_comments": "0",
                            "count_photos": 11,
                            "count_videos": 0,
                            "title": {
                                "_content": "DieWiese_28032021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1621180802",
                            "date_update": "1685290674",
                            "photos": 11,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719198816916",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51183574559",
                            "secret": "73f13936c1",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "1",
                            "count_comments": "0",
                            "count_photos": 8,
                            "count_videos": 0,
                            "title": {
                                "_content": "DieWiese_24032021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1621180354",
                            "date_update": "1685290674",
                            "photos": 8,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719205621332",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51182982703",
                            "secret": "8180ae4fdc",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "2",
                            "count_comments": "0",
                            "count_photos": 3,
                            "count_videos": 0,
                            "title": {
                                "_content": "DerWaldlaeufer_09032021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1621179587",
                            "date_update": "1685290674",
                            "photos": 3,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719205598447",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51183544754",
                            "secret": "53c1638bbe",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "5",
                            "count_comments": "0",
                            "count_photos": 4,
                            "count_videos": 0,
                            "title": {
                                "_content": "Rehe_07032021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1621179380",
                            "date_update": "1685290674",
                            "photos": 4,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719192796868",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51182969783",
                            "secret": "6c63b3f73d",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "1",
                            "count_comments": "0",
                            "count_photos": 5,
                            "count_videos": 0,
                            "title": {
                                "_content": "Blaumeise_06032021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1621179175",
                            "date_update": "1685290675",
                            "photos": 5,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719193218219",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51181630187",
                            "secret": "4b850b1975",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "1",
                            "count_comments": "0",
                            "count_photos": 4,
                            "count_videos": 0,
                            "title": {
                                "_content": "Buchfink_04032021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1621165494",
                            "date_update": "1685290675",
                            "photos": 4,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719246416600",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51182308716",
                            "secret": "9f8fa07e10",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "2",
                            "count_comments": "0",
                            "count_photos": 3,
                            "count_videos": 0,
                            "title": {
                                "_content": "Nilgaense_02032021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1621165136",
                            "date_update": "1685290675",
                            "photos": 3,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719193158769",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51181612812",
                            "secret": "17fd24c797",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "8",
                            "count_comments": "0",
                            "count_photos": 8,
                            "count_videos": 0,
                            "title": {
                                "_content": "Eisvogel_28022021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1621165005",
                            "date_update": "1685290675",
                            "photos": 8,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719193086614",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51183060869",
                            "secret": "2b6b0887c1",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "2",
                            "count_comments": "0",
                            "count_photos": 11,
                            "count_videos": 0,
                            "title": {
                                "_content": "VieleSpechte_27022021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1621164139",
                            "date_update": "1685290675",
                            "photos": 11,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719202579352",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51182158898",
                            "secret": "c18964b296",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "1",
                            "count_comments": "0",
                            "count_photos": 9,
                            "count_videos": 0,
                            "title": {
                                "_content": "DieWiese_24022021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1621148663",
                            "date_update": "1685290675",
                            "photos": 9,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719192849786",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51181233893",
                            "secret": "b0c2e7d705",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "6",
                            "count_comments": "0",
                            "count_photos": 4,
                            "count_videos": 0,
                            "title": {
                                "_content": "Specht_21022021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1621110883",
                            "date_update": "1685290675",
                            "photos": 4,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719186956843",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51180327207",
                            "secret": "757067201a",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "2",
                            "count_comments": "0",
                            "count_photos": 7,
                            "count_videos": 0,
                            "title": {
                                "_content": "Specht_20022021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1621110718",
                            "date_update": "1685290675",
                            "photos": 7,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719242178360",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51181005741",
                            "secret": "4dc6382fc6",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "3",
                            "count_comments": "0",
                            "count_photos": 6,
                            "count_videos": 0,
                            "title": {
                                "_content": "Eisvogel_19022021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1621110504",
                            "date_update": "1685290675",
                            "photos": 6,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719199650317",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51180987291",
                            "secret": "c7c1176c62",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "2",
                            "count_comments": "0",
                            "count_photos": 8,
                            "count_videos": 0,
                            "title": {
                                "_content": "DieInsel_14022021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1621109893",
                            "date_update": "1685290675",
                            "photos": 8,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719192685811",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51181755764",
                            "secret": "7a5e62f38b",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "3",
                            "count_comments": "0",
                            "count_photos": 7,
                            "count_videos": 0,
                            "title": {
                                "_content": "SchneebruchMaulburg_15012021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1621109071",
                            "date_update": "1685290675",
                            "photos": 7,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719242021330",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51182047850",
                            "secret": "5d95aa59fd",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "1",
                            "count_comments": "0",
                            "count_photos": 6,
                            "count_videos": 0,
                            "title": {
                                "_content": "DieWiese_13022021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1621108808",
                            "date_update": "1685290675",
                            "photos": 6,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719186758638",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51180266162",
                            "secret": "429c52777c",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "1",
                            "count_comments": "0",
                            "count_photos": 5,
                            "count_videos": 0,
                            "title": {
                                "_content": "K12_12022021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1621108535",
                            "date_update": "1685290675",
                            "photos": 5,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719186739458",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51182032565",
                            "secret": "e08dd01380",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "3",
                            "count_comments": "0",
                            "count_photos": 7,
                            "count_videos": 0,
                            "title": {
                                "_content": "Storch_09022021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1621108357",
                            "date_update": "1685290675",
                            "photos": 7,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719186713523",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51180934376",
                            "secret": "c89e6e7dd2",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "1",
                            "count_comments": "0",
                            "count_photos": 9,
                            "count_videos": 0,
                            "title": {
                                "_content": "ZweiterSchneebruchMaulburg_10022021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1621108089",
                            "date_update": "1685290675",
                            "photos": 9,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719188676449",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51181716399",
                            "secret": "fc82fbd984",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "1",
                            "count_comments": "0",
                            "count_photos": 9,
                            "count_videos": 0,
                            "title": {
                                "_content": "Maulburg_Schopfheim_06022021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1621107770",
                            "date_update": "1685290675",
                            "photos": 9,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719192531636",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51182010930",
                            "secret": "85a177314d",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "2",
                            "count_comments": "0",
                            "count_photos": 5,
                            "count_videos": 0,
                            "title": {
                                "_content": "HochwasserWiese_31012021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1621107459",
                            "date_update": "1685290675",
                            "photos": 5,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719191855211",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51181504964",
                            "secret": "3322b9bbea",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "1",
                            "count_comments": "0",
                            "count_photos": 6,
                            "count_videos": 0,
                            "title": {
                                "_content": "Specht_09012021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1621099886",
                            "date_update": "1685290675",
                            "photos": 6,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719185913438",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51181780340",
                            "secret": "0a4b1f78bc",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "1",
                            "count_comments": "0",
                            "count_photos": 3,
                            "count_videos": 0,
                            "title": {
                                "_content": "Wald_08012021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1621099229",
                            "date_update": "1685290675",
                            "photos": 3,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719198668142",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51180000652",
                            "secret": "3f2f274fdf",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "5",
                            "count_comments": "0",
                            "count_photos": 3,
                            "count_videos": 0,
                            "title": {
                                "_content": "Steinen_07012021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1621099046",
                            "date_update": "1685290675",
                            "photos": 3,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719191713751",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51180886643",
                            "secret": "5051de9215",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "6",
                            "count_comments": "0",
                            "count_photos": 5,
                            "count_videos": 0,
                            "title": {
                                "_content": "Eichhoernchen_06012021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1621098446",
                            "date_update": "1685290675",
                            "photos": 5,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719198587657",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51181452079",
                            "secret": "940e067233",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "1",
                            "count_comments": "0",
                            "count_photos": 6,
                            "count_videos": 0,
                            "title": {
                                "_content": "Eisvogel_04012021"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1621098238",
                            "date_update": "1685290675",
                            "photos": 6,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719185789068",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51179967747",
                            "secret": "1ced69f71a",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "1",
                            "count_comments": "0",
                            "count_photos": 3,
                            "count_videos": 0,
                            "title": {
                                "_content": "Regenbecken_05122020"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1621097980",
                            "date_update": "1685290675",
                            "photos": 3,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719198548677",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51181738855",
                            "secret": "cdf8e81d61",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "6",
                            "count_comments": "0",
                            "count_photos": 4,
                            "count_videos": 0,
                            "title": {
                                "_content": "KraftwerkSteinen_03122020"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1621097857",
                            "date_update": "1685290675",
                            "photos": 4,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719185758418",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51181434774",
                            "secret": "2a6d096cae",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "3",
                            "count_comments": "0",
                            "count_photos": 4,
                            "count_videos": 0,
                            "title": {
                                "_content": "EiskalterSonnenaufgang_21112020"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1621097681",
                            "date_update": "1685290675",
                            "photos": 4,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719198500272",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51179946792",
                            "secret": "e11fc68997",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "33",
                            "count_comments": "0",
                            "count_photos": 3,
                            "count_videos": 0,
                            "title": {
                                "_content": "K12_14112020"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1621097365",
                            "date_update": "1685290675",
                            "photos": 3,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        },
                        {
                            "id": "72157719240954135",
                            "owner": "192376927@N06",
                            "username": "st0o0",
                            "primary": "51180846033",
                            "secret": "8ea6cc136b",
                            "server": "65535",
                            "farm": 66,
                            "count_views": "15",
                            "count_comments": "0",
                            "count_photos": 4,
                            "count_videos": 0,
                            "title": {
                                "_content": "Maulburg_07112020"
                            },
                            "description": {
                                "_content": ""
                            },
                            "can_comment": 1,
                            "date_create": "1621097252",
                            "date_update": "1685290675",
                            "photos": 4,
                            "videos": 0,
                            "visibility_can_see_set": 1,
                            "needs_interstitial": 0
                        }
                    ]
                },
                "stat": "ok"
            }
            """;

        var result = FlickrConvert.DeserializeObject<FlickrResult<Photosets>>(json);

        Assert.NotNull(result);
        Assert.False(result.HasError);
        var items = result.Content;
        Assert.IsType<Photosets>(items);
        Assert.Equal(87, items.Total);
        Assert.True(items.CanCreate);
        Assert.NotEmpty(items.Values);
        Assert.Equal(87, items.Values.Count);
    }
}
