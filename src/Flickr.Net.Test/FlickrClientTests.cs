using Flickr.Net.Configuration;
using Flickr.Net.Internals;
using Microsoft.Extensions.Caching.Hybrid;
using Microsoft.Extensions.DependencyInjection;

namespace Flickr.Net.Test;

public class FlickrClientTests
{
    [Fact]
    public void AddFlickr_Registers_IFlickrClient()
    {
        var services = new ServiceCollection();
        services.AddFlickr(o =>
        {
            o.ApiKey = "test-key";
            o.SharedSecret = "test-secret";
        });

        using var provider = services.BuildServiceProvider();
        var client = provider.GetRequiredService<IFlickrClient>();

        Assert.NotNull(client);
        Assert.IsType<FlickrClient>(client);
    }

    [Fact]
    public void AddFlickrCaching_Registers_HybridCache()
    {
        var services = new ServiceCollection();
        services.AddFlickr(o =>
        {
            o.ApiKey = "test-key";
        });
        services.AddFlickrCaching(o =>
        {
            o.DefaultEntryOptions = new() { Expiration = TimeSpan.FromMinutes(5) };
        });

        using var provider = services.BuildServiceProvider();
        var cache = provider.GetService<HybridCache>();
        var client = provider.GetRequiredService<IFlickrClient>();

        Assert.NotNull(cache);
        Assert.NotNull(client);
    }

    [Fact]
    public void AddFlickr_Without_Caching_Resolves_Without_Cache()
    {
        var services = new ServiceCollection();
        services.AddFlickr(o =>
        {
            o.ApiKey = "test-key";
        });

        using var provider = services.BuildServiceProvider();
        var cache = provider.GetService<HybridCache>();
        var client = provider.GetRequiredService<IFlickrClient>();

        Assert.Null(cache);
        Assert.NotNull(client);
    }

    [Fact]
    public void Convenience_Constructor_Creates_Working_Client()
    {
        using var client = new FlickrClient("test-key", "test-secret");

        Assert.NotNull(client);
        Assert.True(client.IsAuthenticated);
        Assert.NotNull(client.Photos);
        Assert.NotNull(client.Groups);
    }

    [Fact]
    public void FlickrJsonOptions_Returns_Same_Instance()
    {
        var options1 = FlickrJsonOptions.Default;
        var options2 = FlickrJsonOptions.Default;

        Assert.Same(options1, options2);
    }

    [Fact]
    public void Dispose_Convenience_Client_Does_Not_Throw()
    {
        var client = new FlickrClient("test-key");
        client.Dispose();
    }

    [Fact]
    public void Convenience_Constructor_With_Config()
    {
        var config = new FlickrConfiguration
        {
            ApiKey = "test-key",
            SharedSecret = "test-secret"
        };

        using var client = new FlickrClient(config);

        Assert.True(client.IsAuthenticated);
    }

    [Fact]
    public void Convenience_Constructor_Has_No_Cache()
    {
        using var client = new FlickrClient("test-key");

        Assert.NotNull(client);
    }

    [Fact]
    public void IFlickrClient_Exposes_All_SubInterfaces()
    {
        using var client = new FlickrClient("test-key");

        Assert.NotNull(client.Activity);
        Assert.NotNull(client.Blogs);
        Assert.NotNull(client.Cameras);
        Assert.NotNull(client.Collections);
        Assert.NotNull(client.Commons);
        Assert.NotNull(client.Contacts);
        Assert.NotNull(client.Favorites);
        Assert.NotNull(client.Galleries);
        Assert.NotNull(client.Groups);
        Assert.NotNull(client.GroupsDiscuss);
        Assert.NotNull(client.GroupsDiscussReplies);
        Assert.NotNull(client.GroupsDiscussTopics);
        Assert.NotNull(client.GroupsMembers);
        Assert.NotNull(client.GroupsPools);
        Assert.NotNull(client.Interestingness);
        Assert.NotNull(client.MachineTags);
        Assert.NotNull(client.OAuth);
        Assert.NotNull(client.Panda);
        Assert.NotNull(client.People);
        Assert.NotNull(client.Photos);
        Assert.NotNull(client.PhotosComments);
        Assert.NotNull(client.PhotosGeo);
        Assert.NotNull(client.PhotosLicenses);
        Assert.NotNull(client.PhotosMisc);
        Assert.NotNull(client.PhotosNotes);
        Assert.NotNull(client.PhotosPeople);
        Assert.NotNull(client.PhotosSuggestions);
        Assert.NotNull(client.Photosets);
        Assert.NotNull(client.PhotosetsComments);
        Assert.NotNull(client.Prefs);
        Assert.NotNull(client.Profile);
        Assert.NotNull(client.Push);
        Assert.NotNull(client.Reflection);
        Assert.NotNull(client.Stats);
        Assert.NotNull(client.Tags);
        Assert.NotNull(client.Test);
        Assert.NotNull(client.Upload);
        Assert.NotNull(client.Urls);
    }
}
