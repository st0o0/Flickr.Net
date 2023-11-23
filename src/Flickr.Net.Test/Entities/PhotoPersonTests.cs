using System.Text;
using Flickr.Net.Flickrs.Results;
using Flickr.Net.Internals;

namespace Flickr.Net.Test.Entities;

public class PhotoPersonTests
{
    [Fact]
    public void JsonStringToPhotoPerson()
    {
        var json = /*lang=json,strict*/ """
            {
                            "photo": {
                                "person": [
                                    {
                                        "nsid": "32400437@N07",
                                        "ispro": 1,
                                        "is_deleted": 0,
                                        "iconserver": "3230",
                                        "iconfarm": 4,
                                        "path_alias": "mmm-yoso",
                                        "has_stats": 0,
                                        "pro_badge": "standard",
                                        "expire": "0",
                                        "gender": "M",
                                        "ignored": 0,
                                        "contact": 0,
                                        "friend": 0,
                                        "family": 0,
                                        "revcontact": 0,
                                        "revfriend": 0,
                                        "revfamily": 0,
                                        "username": "mmmyoso",
                                        "realname": "Kirk K",
                                        "location": "",
                                        "timezone": {
                                            "label": "Pacific Time (US & Canada); Tijuana",
                                            "offset": "-08:00",
                                            "timezone_id": "PST8PDT",
                                            "timezone": 5
                                        },
                                        "description": "mmm-yoso.typepad.com\/",
                                        "photosurl": "https:\/\/www.flickr.com\/photos\/mmm-yoso\/",
                                        "profileurl": "https:\/\/www.flickr.com\/people\/mmm-yoso\/",
                                        "mobileurl": "https:\/\/m.flickr.com\/photostream.gne?id=32379107",
                                        "photos": {
                                            "firstdatetaken": "2002-09-29 15:03:42",
                                            "firstdate": "1226622789",
                                            "count": 21187
                                        },
                                        "has_adfree": 0,
                                        "has_free_standard_shipping": 0,
                                        "has_free_educational_resources": 0,
                                        "favedate": "1687522687"
                                    },
                                    {
                                        "nsid": "51087017@N06",
                                        "ispro": 1,
                                        "is_deleted": 0,
                                        "iconserver": "4041",
                                        "iconfarm": 5,
                                        "path_alias": null,
                                        "has_stats": 0,
                                        "pro_badge": "standard",
                                        "expire": "0",
                                        "gender": "F",
                                        "ignored": 0,
                                        "contact": 0,
                                        "friend": 0,
                                        "family": 0,
                                        "revcontact": 0,
                                        "revfriend": 0,
                                        "revfamily": 0,
                                        "username": "fotocais",
                                        "location": "Concepci\u00f3n, Chile",
                                        "timezone": {
                                            "label": "Pacific Time (US & Canada); Tijuana",
                                            "offset": "-08:00",
                                            "timezone_id": "PST8PDT",
                                            "timezone": 5
                                        },
                                        "description": "",
                                        "photosurl": "https:\/\/www.flickr.com\/photos\/51087017@N06\/",
                                        "profileurl": "https:\/\/www.flickr.com\/people\/51087017@N06\/",
                                        "mobileurl": "https:\/\/m.flickr.com\/photostream.gne?id=51041695",
                                        "photos": {
                                            "firstdatetaken": "2005-04-22 22:34:48",
                                            "firstdate": "1276697867",
                                            "count": 1618
                                        },
                                        "has_adfree": 0,
                                        "has_free_standard_shipping": 0,
                                        "has_free_educational_resources": 0,
                                        "favedate": "1687522394"
                                    },
                                    {
                                        "nsid": "92698635@N00",
                                        "ispro": 1,
                                        "is_deleted": 0,
                                        "iconserver": "65535",
                                        "iconfarm": 66,
                                        "path_alias": "ragdaddy",
                                        "has_stats": 0,
                                        "pro_badge": "standard",
                                        "expire": "0",
                                        "gender": "M",
                                        "ignored": 0,
                                        "contact": 0,
                                        "friend": 0,
                                        "family": 0,
                                        "revcontact": 0,
                                        "revfriend": 0,
                                        "revfamily": 0,
                                        "username": "T. Knight",
                                        "realname": "Tim Knight",
                                        "location": "",
                                        "timezone": {
                                            "label": "Mountain Time (US & Canada)",
                                            "offset": "-07:00",
                                            "timezone_id": "US\/Mountain",
                                            "timezone": 8
                                        },
                                        "description": "Just an old guy taking pictures...",
                                        "photosurl": "https:\/\/www.flickr.com\/photos\/ragdaddy\/",
                                        "profileurl": "https:\/\/www.flickr.com\/people\/ragdaddy\/",
                                        "mobileurl": "https:\/\/m.flickr.com\/photostream.gne?id=3654965",
                                        "photos": {
                                            "firstdatetaken": "2003-11-19 19:52:53",
                                            "firstdate": "1150550676",
                                            "count": 2922
                                        },
                                        "has_adfree": 0,
                                        "has_free_standard_shipping": 0,
                                        "has_free_educational_resources": 0,
                                        "favedate": "1687521751"
                                    },
                                    {
                                        "nsid": "21806067@N08",
                                        "ispro": 0,
                                        "is_deleted": 0,
                                        "iconserver": "65535",
                                        "iconfarm": 66,
                                        "path_alias": "adamwessphotography",
                                        "has_stats": 0,
                                        "gender": "M",
                                        "ignored": 0,
                                        "contact": 0,
                                        "friend": 0,
                                        "family": 0,
                                        "revcontact": 0,
                                        "revfriend": 0,
                                        "revfamily": 0,
                                        "username": "Thiezar",
                                        "realname": "Thiezar Pitt",
                                        "location": "",
                                        "timezone": {
                                            "label": "Pacific Time (US & Canada); Tijuana",
                                            "offset": "-08:00",
                                            "timezone_id": "PST8PDT",
                                            "timezone": 5
                                        },
                                        "description": "",
                                        "photosurl": "https:\/\/www.flickr.com\/photos\/adamwessphotography\/",
                                        "profileurl": "https:\/\/www.flickr.com\/people\/adamwessphotography\/",
                                        "mobileurl": "https:\/\/m.flickr.com\/photostream.gne?id=21713254",
                                        "photos": {
                                            "firstdatetaken": "2009-08-07 14:09:47",
                                            "firstdate": "1564332294",
                                            "count": 276
                                        },
                                        "has_adfree": 0,
                                        "has_free_standard_shipping": 0,
                                        "has_free_educational_resources": 0,
                                        "favedate": "1687521410"
                                    },
                                    {
                                        "nsid": "142176890@N06",
                                        "ispro": 1,
                                        "is_deleted": 0,
                                        "iconserver": "1727",
                                        "iconfarm": 2,
                                        "path_alias": "marue_fotografie",
                                        "has_stats": 0,
                                        "pro_badge": "standard",
                                        "expire": "0",
                                        "gender": "M",
                                        "ignored": 0,
                                        "contact": 0,
                                        "friend": 0,
                                        "family": 0,
                                        "revcontact": 0,
                                        "revfriend": 0,
                                        "revfamily": 0,
                                        "username": "MaR\u00fc Fotografie",
                                        "realname": "Markus R\u00fc",
                                        "description": "Ich bin 44 Jahre alt und Hobby-Fotograf. Zur Fotografie bin ich \u00fcber das Multi-Copter-Fliegen gekommen, wobei die Luftaufnahmen nur noch einen Bruchteil meiner Bilder ausmachen.\nAm liebsten fotografiere ich, haupts\u00e4chlich im Umkreis meiner Heimatstadt Cottbus, St\u00e4dte und Landschaften, aber auch Tiere und Pflanzen sind vor mir nicht sicher.",
                                        "photosurl": "https:\/\/www.flickr.com\/photos\/marue_fotografie\/",
                                        "profileurl": "https:\/\/www.flickr.com\/people\/marue_fotografie\/",
                                        "mobileurl": "https:\/\/m.flickr.com\/photostream.gne?id=142131568",
                                        "photos": {
                                            "firstdatetaken": "1974-05-09 05:17:37",
                                            "firstdate": "1527762152",
                                            "count": 968
                                        },
                                        "has_adfree": 0,
                                        "has_free_standard_shipping": 0,
                                        "has_free_educational_resources": 0,
                                        "favedate": "1687520990"
                                    },
                                    {
                                        "nsid": "104656857@N06",
                                        "ispro": 1,
                                        "is_deleted": 0,
                                        "iconserver": "4620",
                                        "iconfarm": 5,
                                        "path_alias": null,
                                        "has_stats": 0,
                                        "pro_badge": "standard",
                                        "expire": "0",
                                        "gender": "X",
                                        "ignored": 0,
                                        "contact": 0,
                                        "friend": 0,
                                        "family": 0,
                                        "revcontact": 0,
                                        "revfriend": 0,
                                        "revfamily": 0,
                                        "username": "Ignacio Ferre",
                                        "realname": "Ignacio Ferre P\u00e9rez",
                                        "location": "Spain",
                                        "timezone": {
                                            "label": "GMT: Dublin, Edinburgh, Lisbon, London",
                                            "offset": "+00:00",
                                            "timezone_id": "Europe\/London",
                                            "timezone": 27
                                        },
                                        "description": "",
                                        "photosurl": "https:\/\/www.flickr.com\/photos\/104656857@N06\/",
                                        "profileurl": "https:\/\/www.flickr.com\/people\/104656857@N06\/",
                                        "mobileurl": "https:\/\/m.flickr.com\/photostream.gne?id=104611535",
                                        "photos": {
                                            "firstdatetaken": "2004-06-23 10:23:05",
                                            "firstdate": "1382628779",
                                            "count": 4159
                                        },
                                        "has_adfree": 0,
                                        "has_free_standard_shipping": 0,
                                        "has_free_educational_resources": 0,
                                        "favedate": "1687519359"
                                    },
                                    {
                                        "nsid": "13610400@N05",
                                        "ispro": 0,
                                        "is_deleted": 0,
                                        "iconserver": "8673",
                                        "iconfarm": 9,
                                        "path_alias": null,
                                        "has_stats": 0,
                                        "gender": "M",
                                        "ignored": 0,
                                        "contact": 0,
                                        "friend": 0,
                                        "family": 0,
                                        "revcontact": 0,
                                        "revfriend": 0,
                                        "revfamily": 0,
                                        "username": "fed1961",
                                        "realname": "Edward Nikiforov",
                                        "location": "Krasnodar, Russia",
                                        "timezone": {
                                            "label": "Moscow, St. Petersburg, Volgograd",
                                            "offset": "+03:00",
                                            "timezone_id": "Europe\/Moscow",
                                            "timezone": 41
                                        },
                                        "description": "Picture a very large number. Please see my albums.",
                                        "photosurl": "https:\/\/www.flickr.com\/photos\/13610400@N05\/",
                                        "profileurl": "https:\/\/www.flickr.com\/people\/13610400@N05\/",
                                        "mobileurl": "https:\/\/m.flickr.com\/photostream.gne?id=13605060",
                                        "photos": {
                                            "firstdatetaken": "0000-00-00 00:00:00",
                                            "firstdate": "1673698322",
                                            "count": 581
                                        },
                                        "has_adfree": 0,
                                        "has_free_standard_shipping": 0,
                                        "has_free_educational_resources": 0,
                                        "favedate": "1687519117"
                                    },
                                    {
                                        "nsid": "14528265@N08",
                                        "ispro": 0,
                                        "is_deleted": 0,
                                        "iconserver": "65535",
                                        "iconfarm": 66,
                                        "path_alias": null,
                                        "has_stats": 0,
                                        "gender": "M",
                                        "ignored": 0,
                                        "contact": 0,
                                        "friend": 0,
                                        "family": 0,
                                        "revcontact": 0,
                                        "revfriend": 0,
                                        "revfamily": 0,
                                        "username": "RVAM",
                                        "description":  "Just an old guy taking pictures...",
                                        "photosurl": "https:\/\/www.flickr.com\/photos\/14528265@N08\/",
                                        "profileurl": "https:\/\/www.flickr.com\/people\/14528265@N08\/",
                                        "mobileurl": "https:\/\/m.flickr.com\/photostream.gne?id=14435452",
                                        "photos": {
                                            "firstdatetaken": "2004-08-16 17:47:26",
                                            "firstdate": "1497580578",
                                            "count": 831
                                        },
                                        "has_adfree": 0,
                                        "has_free_standard_shipping": 0,
                                        "has_free_educational_resources": 0,
                                        "favedate": "1687518990"
                                    },
                                    {
                                        "nsid": "97186936@N07",
                                        "ispro": 0,
                                        "is_deleted": 0,
                                        "iconserver": "7427",
                                        "iconfarm": 8,
                                        "path_alias": null,
                                        "has_stats": 0,
                                        "gender": "X",
                                        "ignored": 0,
                                        "contact": 0,
                                        "friend": 0,
                                        "family": 0,
                                        "revcontact": 0,
                                        "revfriend": 0,
                                        "revfamily": 0,
                                        "username": "dwight.roby",
                                        "realname": "Dwight Roby",
                                        "location": "",
                                        "description": "",
                                        "photosurl": "https:\/\/www.flickr.com\/photos\/97186936@N07\/",
                                        "profileurl": "https:\/\/www.flickr.com\/people\/97186936@N07\/",
                                        "mobileurl": "https:\/\/m.flickr.com\/photostream.gne?id=97165606",
                                        "photos": {
                                            "firstdatetaken": "2006-05-21 10:31:27",
                                            "firstdate": "1370778270",
                                            "count": 360
                                        },
                                        "has_adfree": 0,
                                        "has_free_standard_shipping": 0,
                                        "has_free_educational_resources": 0,
                                        "favedate": "1687518858"
                                    },
                                    {
                                        "nsid": "66550674@N06",
                                        "ispro": 1,
                                        "is_deleted": 0,
                                        "iconserver": "65535",
                                        "iconfarm": 66,
                                        "path_alias": "shannonroseoshea",
                                        "has_stats": 0,
                                        "pro_badge": "standard",
                                        "expire": "0",
                                        "gender": "F",
                                        "ignored": 0,
                                        "contact": 0,
                                        "friend": 0,
                                        "family": 0,
                                        "revcontact": 0,
                                        "revfriend": 0,
                                        "revfamily": 0,
                                        "username": "Shannon Rose O'Shea",
                                        "realname": "Shannon O'Shea Wildlife Photography",
                                        "mbox_sha1sum": "cfa16a7eaedb8ed134ff90cdd2305587edc9fb06",
                                        "location": "Harrisburg, Pennsylvania, USA",
                                        "timezone": {
                                            "label": "Eastern Time (US & Canada)",
                                            "offset": "-05:00",
                                            "timezone_id": "EST5EDT",
                                            "timezone": 14
                                        },
                                        "description":  "Just an old guy taking pictures...",
                                        "photosurl": "https:\/\/www.flickr.com\/photos\/shannonroseoshea\/",
                                        "profileurl": "https:\/\/www.flickr.com\/people\/shannonroseoshea\/",
                                        "mobileurl": "https:\/\/m.flickr.com\/photostream.gne?id=66505352",
                                        "photos": {
                                            "firstdatetaken": "2012-07-19 12:54:38",
                                            "firstdate": "1342736648",
                                            "count": 3539
                                        },
                                        "has_adfree": 0,
                                        "has_free_standard_shipping": 0,
                                        "has_free_educational_resources": 0,
                                        "favedate": "1687518628"
                                    }
                                ],
                                "id": "52994165112",
                                "secret": "a5b5a571a6",
                                "server": "65535",
                                "farm": 66,
                                "page": 1,
                                "pages": 7,
                                "perpage": 10,
                                "total": 67
                            },
                            "stat": "ok"
                        }
            """;

        using var ms = new MemoryStream(Encoding.UTF8.GetBytes(json));

        var result = FlickrConvert.DeserializeObject<FlickrResult<PhotoPersons>>(ms);

        Assert.NotNull(result);
        Assert.False(result.HasError);
        var items = result.Content;
        Assert.IsType<PhotoPersons>(items);
        Assert.NotEmpty(items.Values);
        Assert.IsType<PhotoPerson>(items.Values[0]);
        Assert.Equal(10, result.Content.Values.Count);
    }
}
