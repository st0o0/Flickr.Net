using System.Text;
using Flickr.Net.Flickrs.Results;
using Flickr.Net.Internals;

namespace Flickr.Net.Test.Entities;

public class LicenseHistoryTests
{
    [Fact]
    public void JsonStringToLicenseHistory()
    {
        const string json = """
            {
                "licenses": {
                    "licensehistoryentry": [
                        {
                            "old_license": 0,
                            "new_license": 4,
                            "date_change": "2024-01-15 10:30:00"
                        },
                        {
                            "old_license": 4,
                            "new_license": 6,
                            "date_change": "2024-06-20 14:00:00"
                        }
                    ]
                },
                "stat": "ok"
            }
            """;

        var result = FlickrConvert.DeserializeObject<FlickrResult<LicenseHistoryEntries>>(Encoding.UTF8.GetBytes(json));

        Assert.NotNull(result);
        Assert.False(result.HasError);
        var entries = result.Content;
        Assert.IsType<LicenseHistoryEntries>(entries);
        Assert.Equal(2, entries.Values.Count);

        var first = entries.Values[0];
        Assert.Equal(0, first.OldLicense);
        Assert.Equal(4, first.NewLicense);
        Assert.Equal("2024-01-15 10:30:00", first.DateChange);

        var second = entries.Values[1];
        Assert.Equal(4, second.OldLicense);
        Assert.Equal(6, second.NewLicense);
    }
}
