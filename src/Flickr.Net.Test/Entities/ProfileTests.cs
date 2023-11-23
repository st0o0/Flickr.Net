using System.Text;
using Flickr.Net.Flickrs.Results;
using Flickr.Net.Internals;

namespace Flickr.Net.Test.Entities;

public class ProfileTests
{
    [Fact]
    public void JsonStringToProfile()
    {
        var json = /*lang=json,strict*/ """
            {
                "profile": {
                    "id": "192376927@N06",
                    "nsid": "192376927@N06",
                    "join_date": "1616702870",
                    "occupation": "Fachinformatiker Anwendungsentwicklung",
                    "hometown": "",
                    "showcase_set": "72157718780105727",
                    "showcase_set_title": "Showcase",
                    "first_name": "Jan",
                    "last_name": "Schloots",
                    "email": "jan.schloots@magenta.de",
                    "profile_description": "",
                    "city": "L\u00f6rrach",
                    "country": "Deutschland",
                    "facebook": "",
                    "twitter": "",
                    "tumblr": "",
                    "instagram": "",
                    "pinterest": ""
                },
                "stat": "ok"
            }
            """;

        var result = FlickrConvert.DeserializeObject<FlickrResult<Profile>>(Encoding.UTF8.GetBytes(json));

        Assert.NotNull(result);
        Assert.False(result.HasError);
        var items = result.Content;
        Assert.NotNull(items);
        Assert.IsType<Profile>(items);
        Assert.Equal(UtilityMethods.UnixTimestampToDate("1616702870"), items.JoinDate);
        Assert.Equal("192376927@N06", items.Id);
    }
}
