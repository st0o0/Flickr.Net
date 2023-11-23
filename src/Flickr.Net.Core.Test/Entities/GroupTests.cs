using System.Text;
using Flickr.Net.Core.Enums;
using Flickr.Net.Core.Extensions;
using Flickr.Net.Core.Flickrs.Results;
using Flickr.Net.Core.Internals;

namespace Flickr.Net.Core.Test.Entities;

public class GroupTests
{
    [Fact]
    public void JsonStringToGroupInfo()
    {
        var json = /*lang=json,strict*/ """
            {
              "stat": "ok",
              "group": {
                "id": "34427465497@N01",
                "iconserver": "1",
                "iconfarm": "1",
                "lang": "en-us",
                "ispoolmoderated": "0",
                "name": "GNEverybody",
                "description": "The group for GNE players",
                "members": "69",
                "privacy": "3",
                "throttle": {
                  "count": "10",
                  "mode": "month",
                  "remaining": "3"
                },
                "restrictions": {
                  "photos_ok": "1",
                  "videos_ok": "1",
                  "images_ok": "1",
                  "screens_ok": "1",
                  "art_ok": "1",
                  "safe_ok": "1",
                  "moderate_ok": "0",
                  "restricted_ok": "0",
                  "has_geo": "0"
                }
              }
            }
            """;

        using var ms = new MemoryStream(Encoding.UTF8.GetBytes(json));

        var result = FlickrConvert.DeserializeObject<FlickrResult<GroupInfo>>(ms);

        Assert.NotNull(result);
        Assert.False(result.HasError);
        var items = result.Content;
        Assert.IsType<GroupInfo>(items);
        Assert.Equal(69, items.Members);
        Assert.IsType<PoolPrivacy>(items.Privacy);
        Assert.Equal(PoolPrivacy.OpenPublic, items.Privacy);
        Assert.IsType<ThrottleMode>(items.Throttle.Mode);
        Assert.Equal(ThrottleMode.PerMonth, items.Throttle.Mode);
        Assert.True(items.Restrictions.PhotosOk);
        Assert.True(items.Restrictions.VideosOk);
        Assert.True(items.Restrictions.ImagesOk);
        Assert.True(items.Restrictions.ScreensOk);
        Assert.True(items.Restrictions.ArtOk);
        Assert.True(items.Restrictions.SafeOk);
        Assert.False(items.Restrictions.ModerateOk);
        Assert.False(items.Restrictions.RestrictedOk);
        Assert.False(items.Restrictions.HasGeo);
        Assert.NotEmpty(items.ToBuddyIconUrl());
    }

    [Fact]
    public void JsonStringToGroups()
    {
        var json = /*lang=json,strict*/ """
            {
              "stat": "ok",
              "groups": {
                "page": "1",
                "pages": "14",
                "perpage": "5",
                "total": "67",
                "group": [
                  {
                    "nsid": "3000@N02",
                    "name": "Frito's Test Group",
                    "eighteenplus": "1"
                  },
                  {
                    "nsid": "32825757@N00",
                    "name": "Free for All",
                    "eighteenplus": "0"
                  },
                  {
                    "nsid": "33335981560@N01",
                    "name": "joly's mothers",
                    "eighteenplus": "0"
                  },
                  {
                    "nsid": "33853651681@N01",
                    "name": "Wintermute tower",
                    "eighteenplus": "0"
                  },
                  {
                    "nsid": "33853651696@N01",
                    "name": "Art and Literature Hoedown",
                    "eighteenplus": "0"
                  }
                ]
              }
            }
            """;

        using var ms = new MemoryStream(Encoding.UTF8.GetBytes(json));

        var result = FlickrConvert.DeserializeObject<FlickrResult<Groups>>(ms);

        Assert.NotNull(result);
        Assert.False(result.HasError);
        var items = result.Content;
        Assert.IsType<Groups>(items);
        Assert.Equal(67, items.Total);
        Assert.True(items.Values[0].EighteenPlus);
        Assert.False(items.Values[1].EighteenPlus);
        Assert.False(items.Values[2].EighteenPlus);
        Assert.False(items.Values[3].EighteenPlus);
        Assert.NotEmpty(items.Values[0].ToBuddyIconUrl());
    }

    [Fact]
    public void JsonStringToGroups_LongJson()
    {
        var json = /*lang=json,strict*/ """
            {
                "groups": {
                    "page": 1,
                    "pages": 84,
                    "perpage": 100,
                    "total": 8351,
                    "group": [
                        {
                            "nsid": "1456145@N22",
                            "name": "Test group999",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "15",
                            "pool_count": "15",
                            "topic_count": "6",
                            "privacy": "3"
                        },
                        {
                            "nsid": "2967934@N22",
                            "name": "Test - Dace Karklina",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "2",
                            "pool_count": "2",
                            "topic_count": "0",
                            "privacy": "2"
                        },
                        {
                            "nsid": "1112352@N22",
                            "name": "test customer",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "5",
                            "pool_count": "1",
                            "topic_count": "0",
                            "privacy": "3"
                        },
                        {
                            "nsid": "1299624@N24",
                            "name": "Test-aappma",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "2",
                            "pool_count": "1",
                            "topic_count": "0",
                            "privacy": "3"
                        },
                        {
                            "nsid": "827441@N23",
                            "name": "Test Mules - Erlk\u00f6nige - Prototypes",
                            "eighteenplus": 0,
                            "iconserver": "3164",
                            "iconfarm": 4,
                            "members": "177",
                            "pool_count": "900",
                            "topic_count": "6",
                            "privacy": "3"
                        },
                        {
                            "nsid": "2047826@N21",
                            "name": "test 20120801",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "2",
                            "pool_count": "0",
                            "topic_count": "0",
                            "privacy": "3"
                        },
                        {
                            "nsid": "52240590759@N01",
                            "name": "_testing_please ignore",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "9",
                            "pool_count": "26",
                            "topic_count": "33",
                            "privacy": "2"
                        },
                        {
                            "nsid": "1367547@N20",
                            "name": "Test strips",
                            "eighteenplus": 0,
                            "iconserver": "2788",
                            "iconfarm": 3,
                            "members": "11",
                            "pool_count": "37",
                            "topic_count": "0",
                            "privacy": "3"
                        },
                        {
                            "nsid": "1660975@N22",
                            "name": "modholly test",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "2",
                            "pool_count": "2",
                            "topic_count": "1",
                            "privacy": "3"
                        },
                        {
                            "nsid": "1313660@N25",
                            "name": "TravelStore Test Group",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "2",
                            "pool_count": "1",
                            "topic_count": "0",
                            "privacy": "2"
                        },
                        {
                            "nsid": "1755511@N20",
                            "name": "Devise Test Group",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "1",
                            "pool_count": "7",
                            "topic_count": "0",
                            "privacy": "3"
                        },
                        {
                            "nsid": "1938034@N21",
                            "name": "ewtto-test",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "1",
                            "pool_count": "1",
                            "topic_count": "0",
                            "privacy": "2"
                        },
                        {
                            "nsid": "1568034@N22",
                            "name": "Tom's New Test Group",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "1",
                            "pool_count": "4",
                            "topic_count": "0",
                            "privacy": "3"
                        },
                        {
                            "nsid": "2141314@N25",
                            "name": "Tested Photo Pool",
                            "eighteenplus": 0,
                            "iconserver": "5488",
                            "iconfarm": 6,
                            "members": "247",
                            "pool_count": "722",
                            "topic_count": "13",
                            "privacy": "3"
                        },
                        {
                            "nsid": "69858435@N00",
                            "name": "Test Cricket Photographs",
                            "eighteenplus": 0,
                            "iconserver": "94",
                            "iconfarm": 1,
                            "members": "437",
                            "pool_count": "3646",
                            "topic_count": "63",
                            "privacy": "3"
                        },
                        {
                            "nsid": "1814819@N22",
                            "name": "Test Drive Unlimited Photograhers",
                            "eighteenplus": 0,
                            "iconserver": "6135",
                            "iconfarm": 7,
                            "members": "1",
                            "pool_count": "6",
                            "topic_count": "0",
                            "privacy": "3"
                        },
                        {
                            "nsid": "2079893@N20",
                            "name": "boattest.com",
                            "eighteenplus": 0,
                            "iconserver": "8038",
                            "iconfarm": 9,
                            "members": "6",
                            "pool_count": "6005",
                            "topic_count": "0",
                            "privacy": "3"
                        },
                        {
                            "nsid": "952430@N20",
                            "name": "Test shot",
                            "eighteenplus": 0,
                            "iconserver": "3303",
                            "iconfarm": 4,
                            "members": "14",
                            "pool_count": "105",
                            "topic_count": "0",
                            "privacy": "3"
                        },
                        {
                            "nsid": "2798102@N23",
                            "name": "Test Trains in the UK",
                            "eighteenplus": 0,
                            "iconserver": "4209",
                            "iconfarm": 5,
                            "members": "615",
                            "pool_count": "17325",
                            "topic_count": "5",
                            "privacy": "3"
                        },
                        {
                            "nsid": "1540563@N25",
                            "name": "test test test 33",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "3",
                            "pool_count": "0",
                            "topic_count": "1",
                            "privacy": "3"
                        },
                        {
                            "nsid": "2041971@N23",
                            "name": "Test of Time Photo BRONX ZOO PHOTO TOUR",
                            "eighteenplus": 0,
                            "iconserver": "8431",
                            "iconfarm": 9,
                            "members": "11",
                            "pool_count": "76",
                            "topic_count": "0",
                            "privacy": "3"
                        },
                        {
                            "nsid": "587377@N22",
                            "name": "Test Tubes and Eppies",
                            "eighteenplus": 0,
                            "iconserver": "2089",
                            "iconfarm": 3,
                            "members": "82",
                            "pool_count": "237",
                            "topic_count": "0",
                            "privacy": "3"
                        },
                        {
                            "nsid": "1230951@N22",
                            "name": "Test test test test testing",
                            "eighteenplus": 0,
                            "iconserver": "2629",
                            "iconfarm": 3,
                            "members": "6",
                            "pool_count": "2",
                            "topic_count": "1",
                            "privacy": "3"
                        },
                        {
                            "nsid": "1790515@N21",
                            "name": "Testing Testing Testing 123",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "1",
                            "pool_count": "0",
                            "topic_count": "0",
                            "privacy": "3"
                        },
                        {
                            "nsid": "3514399@N23",
                            "name": "TEST TEST TEST 12",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "0",
                            "pool_count": "1",
                            "topic_count": "0",
                            "privacy": "2"
                        },
                        {
                            "nsid": "10943022@N00",
                            "name": "Camera Store Test Shots",
                            "eighteenplus": 0,
                            "iconserver": "30",
                            "iconfarm": 1,
                            "members": "46",
                            "pool_count": "110",
                            "topic_count": "0",
                            "privacy": "3"
                        },
                        {
                            "nsid": "967252@N20",
                            "name": "Standardized Tests",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "7",
                            "pool_count": "22",
                            "topic_count": "0",
                            "privacy": "3"
                        },
                        {
                            "nsid": "1656950@N21",
                            "name": "Test Test Test Test",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "1",
                            "pool_count": "0",
                            "topic_count": "0",
                            "privacy": "2"
                        },
                        {
                            "nsid": "2684594@N23",
                            "name": "Test Flickr1 Test Group",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "1",
                            "pool_count": "0",
                            "topic_count": "0",
                            "privacy": "2"
                        },
                        {
                            "nsid": "1810049@N22",
                            "name": "Test test test group",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "1",
                            "pool_count": "2",
                            "topic_count": "0",
                            "privacy": "2"
                        },
                        {
                            "nsid": "2126866@N25",
                            "name": "Test Site Test Site Test Site",
                            "eighteenplus": 0,
                            "iconserver": "8376",
                            "iconfarm": 9,
                            "members": "1",
                            "pool_count": "12",
                            "topic_count": "0",
                            "privacy": "3"
                        },
                        {
                            "nsid": "1618225@N21",
                            "name": "Tests tests tests",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "1",
                            "pool_count": "0",
                            "topic_count": "0",
                            "privacy": "3"
                        },
                        {
                            "nsid": "1421836@N25",
                            "name": "testing testing testing group",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "2",
                            "pool_count": "3",
                            "topic_count": "0",
                            "privacy": "3"
                        },
                        {
                            "nsid": "1735076@N25",
                            "name": "Test Group Test Test",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "1",
                            "pool_count": "0",
                            "topic_count": "0",
                            "privacy": "3"
                        },
                        {
                            "nsid": "1405845@N22",
                            "name": "TEST - almuhairi",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "2",
                            "pool_count": "0",
                            "topic_count": "0",
                            "privacy": "3"
                        },
                        {
                            "nsid": "1077198@N20",
                            "name": "testing_testing_testing",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "1",
                            "pool_count": "2",
                            "topic_count": "0",
                            "privacy": "3"
                        },
                        {
                            "nsid": "1440642@N25",
                            "name": "Testing the groups upload",
                            "eighteenplus": 0,
                            "iconserver": "4113",
                            "iconfarm": 5,
                            "members": "2",
                            "pool_count": "26",
                            "topic_count": "0",
                            "privacy": "3"
                        },
                        {
                            "nsid": "1504474@N24",
                            "name": "Testing the testing field",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "1",
                            "pool_count": "0",
                            "topic_count": "0",
                            "privacy": "3"
                        },
                        {
                            "nsid": "14635670@N24",
                            "name": "Testing_Testing 123",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "1",
                            "pool_count": "0",
                            "topic_count": "0",
                            "privacy": "3"
                        },
                        {
                            "nsid": "4570450@N22",
                            "name": "test group conall",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "1",
                            "pool_count": "0",
                            "topic_count": "0",
                            "privacy": "3"
                        },
                        {
                            "nsid": "1882939@N24",
                            "name": "Test Shares",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "1",
                            "pool_count": "0",
                            "topic_count": "0",
                            "privacy": "2"
                        },
                        {
                            "nsid": "2836593@N23",
                            "name": "test trash",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "1",
                            "pool_count": "0",
                            "topic_count": "0",
                            "privacy": "2"
                        },
                        {
                            "nsid": "2178000@N23",
                            "name": "Test Group 2013",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "1",
                            "pool_count": "2",
                            "topic_count": "0",
                            "privacy": "2"
                        },
                        {
                            "nsid": "2916745@N24",
                            "name": "test my group flix test",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "1",
                            "pool_count": "4",
                            "topic_count": "0",
                            "privacy": "3"
                        },
                        {
                            "nsid": "1144784@N25",
                            "name": "Test Test Alison",
                            "eighteenplus": 0,
                            "iconserver": "2627",
                            "iconfarm": 3,
                            "members": "1",
                            "pool_count": "0",
                            "topic_count": "0",
                            "privacy": "3"
                        },
                        {
                            "nsid": "3044183@N23",
                            "name": "Test gropup 123654",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "1",
                            "pool_count": "0",
                            "topic_count": "0",
                            "privacy": "3"
                        },
                        {
                            "nsid": "1119006@N24",
                            "name": "Test Student Design Contest",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "1",
                            "pool_count": "0",
                            "topic_count": "0",
                            "privacy": "3"
                        },
                        {
                            "nsid": "1238199@N23",
                            "name": "test test 1234",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "1",
                            "pool_count": "0",
                            "topic_count": "0",
                            "privacy": "3"
                        },
                        {
                            "nsid": "2095606@N25",
                            "name": "Test Test DIS",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "1",
                            "pool_count": "0",
                            "topic_count": "0",
                            "privacy": "3"
                        },
                        {
                            "nsid": "14638006@N23",
                            "name": "Test Party",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "0",
                            "pool_count": "0",
                            "topic_count": "0",
                            "privacy": "2"
                        },
                        {
                            "nsid": "1394167@N25",
                            "name": "new test",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "1",
                            "pool_count": "2",
                            "topic_count": "0",
                            "privacy": "2"
                        },
                        {
                            "nsid": "2362749@N22",
                            "name": "Test Luscyn",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "1",
                            "pool_count": "0",
                            "topic_count": "0",
                            "privacy": "2"
                        },
                        {
                            "nsid": "996823@N24",
                            "name": "Test_002",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "2",
                            "pool_count": "0",
                            "topic_count": "0",
                            "privacy": "2"
                        },
                        {
                            "nsid": "14701576@N25",
                            "name": "test group public",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "1",
                            "pool_count": "0",
                            "topic_count": "0",
                            "privacy": "3"
                        },
                        {
                            "nsid": "2344538@N20",
                            "name": "Test_123321",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "1",
                            "pool_count": "0",
                            "topic_count": "0",
                            "privacy": "2"
                        },
                        {
                            "nsid": "1745687@N21",
                            "name": "test atolcd",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "1",
                            "pool_count": "6",
                            "topic_count": "0",
                            "privacy": "3"
                        },
                        {
                            "nsid": "1257966@N24",
                            "name": "Testing 123 Group",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "1",
                            "pool_count": "1",
                            "topic_count": "0",
                            "privacy": "3"
                        },
                        {
                            "nsid": "2832111@N22",
                            "name": "test-tring",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "1",
                            "pool_count": "0",
                            "topic_count": "0",
                            "privacy": "2"
                        },
                        {
                            "nsid": "3061899@N24",
                            "name": "test-flickr-template",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "1",
                            "pool_count": "2",
                            "topic_count": "0",
                            "privacy": "3"
                        },
                        {
                            "nsid": "2226678@N21",
                            "name": "test new flickr",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "1",
                            "pool_count": "2",
                            "topic_count": "0",
                            "privacy": "3"
                        },
                        {
                            "nsid": "2098938@N21",
                            "name": "test_2000",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "1",
                            "pool_count": "0",
                            "topic_count": "0",
                            "privacy": "3"
                        },
                        {
                            "nsid": "1706334@N21",
                            "name": "Test ding Group",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "2",
                            "pool_count": "0",
                            "topic_count": "0",
                            "privacy": "3"
                        },
                        {
                            "nsid": "2513430@N22",
                            "name": "Test  1",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "1",
                            "pool_count": "0",
                            "topic_count": "0",
                            "privacy": "2"
                        },
                        {
                            "nsid": "2699382@N24",
                            "name": "Testing Jetah",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "1",
                            "pool_count": "0",
                            "topic_count": "0",
                            "privacy": "2"
                        },
                        {
                            "nsid": "1788441@N21",
                            "name": "Test Group RCA",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "1",
                            "pool_count": "0",
                            "topic_count": "0",
                            "privacy": "2"
                        },
                        {
                            "nsid": "3753499@N20",
                            "name": "Test GSDJ",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "2",
                            "pool_count": "0",
                            "topic_count": "0",
                            "privacy": "2"
                        },
                        {
                            "nsid": "3704813@N24",
                            "name": "Test - public",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "1",
                            "pool_count": "0",
                            "topic_count": "0",
                            "privacy": "2"
                        },
                        {
                            "nsid": "1103172@N21",
                            "name": "test website",
                            "eighteenplus": 0,
                            "iconserver": "3361",
                            "iconfarm": 4,
                            "members": "1",
                            "pool_count": "2",
                            "topic_count": "1",
                            "privacy": "3"
                        },
                        {
                            "nsid": "1743290@N21",
                            "name": "Test Hattie",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "1",
                            "pool_count": "0",
                            "topic_count": "0",
                            "privacy": "3"
                        },
                        {
                            "nsid": "1563510@N23",
                            "name": "Test public WnW",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "2",
                            "pool_count": "2",
                            "topic_count": "0",
                            "privacy": "3"
                        },
                        {
                            "nsid": "1658911@N23",
                            "name": "Test Group Ictinus",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "1",
                            "pool_count": "0",
                            "topic_count": "0",
                            "privacy": "3"
                        },
                        {
                            "nsid": "1067255@N24",
                            "name": "Test Page",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "1",
                            "pool_count": "0",
                            "topic_count": "0",
                            "privacy": "3"
                        },
                        {
                            "nsid": "2875782@N24",
                            "name": "Test Ester",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "1",
                            "pool_count": "0",
                            "topic_count": "0",
                            "privacy": "2"
                        },
                        {
                            "nsid": "2776374@N23",
                            "name": "Test jht",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "2",
                            "pool_count": "0",
                            "topic_count": "0",
                            "privacy": "3"
                        },
                        {
                            "nsid": "3871261@N22",
                            "name": "Test Photo8827",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "1",
                            "pool_count": "0",
                            "topic_count": "0",
                            "privacy": "2"
                        },
                        {
                            "nsid": "1960676@N23",
                            "name": "test living",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "1",
                            "pool_count": "0",
                            "topic_count": "0",
                            "privacy": "3"
                        },
                        {
                            "nsid": "4170887@N23",
                            "name": "Test_delete",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "1",
                            "pool_count": "0",
                            "topic_count": "0",
                            "privacy": "3"
                        },
                        {
                            "nsid": "1424762@N24",
                            "name": "test group riz",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "1",
                            "pool_count": "0",
                            "topic_count": "0",
                            "privacy": "3"
                        },
                        {
                            "nsid": "2460975@N25",
                            "name": "Test 20JAN14",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "1",
                            "pool_count": "6",
                            "topic_count": "0",
                            "privacy": "2"
                        },
                        {
                            "nsid": "1798306@N23",
                            "name": "test tate group",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "1",
                            "pool_count": "0",
                            "topic_count": "0",
                            "privacy": "3"
                        },
                        {
                            "nsid": "2841009@N23",
                            "name": "TEST Public\/Safe Decembre2",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "1",
                            "pool_count": "0",
                            "topic_count": "0",
                            "privacy": "3"
                        },
                        {
                            "nsid": "1166834@N25",
                            "name": "Test - Karate",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "3",
                            "pool_count": "25",
                            "topic_count": "0",
                            "privacy": "3"
                        },
                        {
                            "nsid": "3086368@N23",
                            "name": "test-0106",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "2",
                            "pool_count": "0",
                            "topic_count": "3",
                            "privacy": "3"
                        },
                        {
                            "nsid": "4026026@N21",
                            "name": "Test groups (public)",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "3",
                            "pool_count": "1",
                            "topic_count": "1",
                            "privacy": "3"
                        },
                        {
                            "nsid": "1137436@N25",
                            "name": "Test Group Kevin Blake",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "1",
                            "pool_count": "0",
                            "topic_count": "0",
                            "privacy": "3"
                        },
                        {
                            "nsid": "2896844@N20",
                            "name": "test-106748",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "2",
                            "pool_count": "3",
                            "topic_count": "3",
                            "privacy": "2"
                        },
                        {
                            "nsid": "1879546@N23",
                            "name": "test_2",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "1",
                            "pool_count": "2",
                            "topic_count": "0",
                            "privacy": "3"
                        },
                        {
                            "nsid": "1350235@N21",
                            "name": "Test Group JKLSDHARF",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "1",
                            "pool_count": "0",
                            "topic_count": "0",
                            "privacy": "2"
                        },
                        {
                            "nsid": "1468082@N22",
                            "name": "Test dBU",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "1",
                            "pool_count": "0",
                            "topic_count": "0",
                            "privacy": "2"
                        },
                        {
                            "nsid": "1241373@N20",
                            "name": "Test Group123abc",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "1",
                            "pool_count": "3",
                            "topic_count": "0",
                            "privacy": "3"
                        },
                        {
                            "nsid": "2613229@N21",
                            "name": "test public invite only",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "2",
                            "pool_count": "2",
                            "topic_count": "0",
                            "privacy": "2"
                        },
                        {
                            "nsid": "2131251@N25",
                            "name": "Testing-Alfred",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "1",
                            "pool_count": "1",
                            "topic_count": "0",
                            "privacy": "2"
                        },
                        {
                            "nsid": "1251017@N24",
                            "name": "Test Fringe",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "1",
                            "pool_count": "3",
                            "topic_count": "1",
                            "privacy": "3"
                        },
                        {
                            "nsid": "3277067@N24",
                            "name": "test_api",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "1",
                            "pool_count": "0",
                            "topic_count": "0",
                            "privacy": "3"
                        },
                        {
                            "nsid": "1188076@N22",
                            "name": "Test-1009",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "1",
                            "pool_count": "0",
                            "topic_count": "0",
                            "privacy": "3"
                        },
                        {
                            "nsid": "1586896@N23",
                            "name": "test-123-00",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "1",
                            "pool_count": "0",
                            "topic_count": "0",
                            "privacy": "3"
                        },
                        {
                            "nsid": "14787290@N21",
                            "name": "testing photo",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "1",
                            "pool_count": "4",
                            "topic_count": "0",
                            "privacy": "3"
                        },
                        {
                            "nsid": "2907787@N24",
                            "name": "Test Group 1234554321",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "1",
                            "pool_count": "0",
                            "topic_count": "0",
                            "privacy": "2"
                        },
                        {
                            "nsid": "1753572@N25",
                            "name": "Test Competition Group",
                            "eighteenplus": 0,
                            "iconserver": "6100",
                            "iconfarm": 7,
                            "members": "2",
                            "pool_count": "1",
                            "topic_count": "0",
                            "privacy": "3"
                        },
                        {
                            "nsid": "2737651@N24",
                            "name": "Test group122",
                            "eighteenplus": 0,
                            "iconserver": "0",
                            "iconfarm": 0,
                            "members": "1",
                            "pool_count": "0",
                            "topic_count": "0",
                            "privacy": "3"
                        }
                    ],
                    "adj_search_args": null
                },
                "stat": "ok"
            }
            """;

        using var ms = new MemoryStream(Encoding.UTF8.GetBytes(json));

        var result = FlickrConvert.DeserializeObject<FlickrResult<Groups>>(ms);

        Assert.NotNull(result);
        Assert.False(result.HasError);
        var items = result.Content;
        Assert.IsType<Groups>(items);

        Assert.All(items.Values, item =>
        {
            Assert.IsType<Group>(item);
            Assert.NotNull(item);
            Assert.IsType<PoolPrivacy>(item.Privacy);
        });
    }
}