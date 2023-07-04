using Flickr.Net.Core.Enums;
using Flickr.Net.Core.Internals;

namespace Flickr.Net.Core.Test.SearchOptions;

public class SearchOptionTests
{
    [Fact]
    public void PartialSearchOptionsToDictionary()
    {
        var dateTimeNow = DateTime.Now;

        var options = new PartialSearchOptions()
        {
            Extras = PhotoSearchExtras.All,
            MaxTakenDate = DateTime.UnixEpoch,
            MinTakenDate = DateTime.UnixEpoch,
            MaxUploadDate = dateTimeNow,
            MinUploadDate = dateTimeNow,
            Page = 2,
            PerPage = 3,
            PrivacyFilter = PrivacyFilter.PublicPhotos,
            SortOrder = PhotoSearchSortOrder.Relevance,
        };

        var result = new Dictionary<string, string>();
        options.AddToDictionary(result);

        Assert.NotEmpty(result["min_uploaded_date"]);
        Assert.Equal(dateTimeNow.ToUnixTimestamp(), result["min_uploaded_date"]);
        Assert.NotEmpty(result["max_uploaded_date"]);
        Assert.Equal(dateTimeNow.ToUnixTimestamp(), result["max_uploaded_date"]);
        Assert.NotEmpty(result["min_taken_date"]);
        Assert.NotEmpty(result["max_taken_date"]);
        Assert.NotEmpty(result["extras"]);
        Assert.NotEmpty(result["sort"]);
        Assert.NotEmpty(result["per_page"]);
        Assert.Equal("3", result["per_page"]);
        Assert.NotEmpty(result["page"]);
        Assert.Equal("2", result["page"]);
        Assert.NotEmpty(result["privacy_filter"]);
    }

    [Fact]
    public void PhotoSearchOptionsToDictionary()
    {
        var dateTimeNow = DateTime.Now;

        var options = new PhotoSearchOptions()
        {
            Extras = PhotoSearchExtras.All,
            MaxTakenDate = DateTime.UnixEpoch,
            MinTakenDate = DateTime.UnixEpoch,
            MaxUploadDate = dateTimeNow,
            MinUploadDate = dateTimeNow,
            Page = 2,
            PerPage = 3,
            PrivacyFilter = PrivacyFilter.PublicPhotos,
            SortOrder = PhotoSearchSortOrder.Relevance,
        };

        var result = new Dictionary<string, string>();
        options.AddToDictionary(result);

        Assert.NotEmpty(result["min_upload_date"]);
        Assert.Equal(dateTimeNow.ToUnixTimestamp(), result["min_upload_date"]);
        Assert.NotEmpty(result["max_upload_date"]);
        Assert.Equal(dateTimeNow.ToUnixTimestamp(), result["max_upload_date"]);
        Assert.NotEmpty(result["min_taken_date"]);
        Assert.NotEmpty(result["max_taken_date"]);
        Assert.NotEmpty(result["extras"]);
        Assert.NotEmpty(result["sort"]);
        Assert.NotEmpty(result["per_page"]);
        Assert.Equal("3", result["per_page"]);
        Assert.NotEmpty(result["page"]);
        Assert.Equal("2", result["page"]);
        Assert.NotEmpty(result["privacy_filter"]);
    }

    [Fact]
    public void Tests()
    {
        var t = PhotoSearchExtras.DateUploaded;
        Assert.False(t.HasFlag(PhotoSearchExtras.License));
        Assert.True(PhotoSearchExtras.All.HasFlag(t));
    }
}
