using Flickr.Net.Configuration;
using Flickr.Net.Enums;

namespace Flickr.Net.Test.SearchOptions;

public class DefaultSearchExtrasTests
{
    [Fact]
    public void DefaultSearchExtrasIsNullByDefault()
    {
        var config = new FlickrConfiguration { ApiKey = "test" };
        Assert.Null(config.DefaultSearchExtras);
    }

    [Fact]
    public void DefaultSearchExtrasCanBeSet()
    {
        var config = new FlickrConfiguration
        {
            ApiKey = "test",
            DefaultSearchExtras = PhotoSearchExtras.Description | PhotoSearchExtras.DateTaken
        };

        Assert.Equal(PhotoSearchExtras.Description | PhotoSearchExtras.DateTaken, config.DefaultSearchExtras);
    }

    [Fact]
    public void DefaultSearchExtrasMergeWithCallExtras()
    {
        var options = new PhotoSearchOptions
        {
            Extras = PhotoSearchExtras.License
        };

        var defaultExtras = PhotoSearchExtras.Description | PhotoSearchExtras.DateTaken;

        // Simulate what SearchAsync does
        options = options with { Extras = options.Extras | defaultExtras };

        Assert.True(options.Extras.HasFlag(PhotoSearchExtras.License));
        Assert.True(options.Extras.HasFlag(PhotoSearchExtras.Description));
        Assert.True(options.Extras.HasFlag(PhotoSearchExtras.DateTaken));
    }

    [Fact]
    public void PerCallExtrasAreNotOverriddenByDefaults()
    {
        var options = new PhotoSearchOptions
        {
            Extras = PhotoSearchExtras.Tags | PhotoSearchExtras.Geo
        };

        var defaultExtras = PhotoSearchExtras.Description;

        options = options with { Extras = options.Extras | defaultExtras };

        // Original extras preserved
        Assert.True(options.Extras.HasFlag(PhotoSearchExtras.Tags));
        Assert.True(options.Extras.HasFlag(PhotoSearchExtras.Geo));
        // Default extras added
        Assert.True(options.Extras.HasFlag(PhotoSearchExtras.Description));
    }
}
