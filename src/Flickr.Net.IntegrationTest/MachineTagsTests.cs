using Flickr.Net.IntegrationTest.Fixtures;

namespace Flickr.Net.IntegrationTest;

public class MachineTagsTests(WireMockFixture fixture) : IClassFixture<WireMockFixture>
{
    [Fact]
    public async Task GetNamespacesAsync_ReturnsNamespaces()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.machinetags.getNamespaces",
            """{"stat":"ok","namespaces":{"page":1,"pages":1,"perpage":10,"total":1,"namespace":[{"_content":"dc","predicates":"5","usage":"100"}]}}""");

        using var client = fixture.CreateClient();
        var result = await client.MachineTags.GetNamespacesAsync();

        Assert.NotNull(result);
        Assert.Single(result.Values);
    }

    [Fact]
    public async Task GetPairsAsync_ReturnsPairs()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.machinetags.getPairs",
            """{"stat":"ok","pairs":{"page":1,"pages":1,"perpage":10,"total":1,"pair":[{"_content":"dc:subject","usage":"50","namespace":"dc","predicate":"subject"}]}}""");

        using var client = fixture.CreateClient();
        var result = await client.MachineTags.GetPairsAsync();

        Assert.NotNull(result);
        Assert.Single(result.Values);
    }

    [Fact]
    public async Task GetPredicatesAsync_ReturnsPredicates()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.machinetags.getPredicates",
            """{"stat":"ok","predicates":{"page":1,"pages":1,"perpage":10,"total":1,"predicate":[{"_content":"subject","namespaces":"3","usage":"80"}]}}""");

        using var client = fixture.CreateClient();
        var result = await client.MachineTags.GetPredicatesAsync();

        Assert.NotNull(result);
        Assert.Single(result.Values);
    }

    [Fact]
    public async Task GetValuesAsync_ReturnsValues()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.machinetags.getValues",
            """{"stat":"ok","values":{"page":1,"pages":1,"perpage":10,"total":1,"namespace":"dc","predicate":"subject","value":[{"_content":"landscape","usage":"20"}]}}""");

        using var client = fixture.CreateClient();
        var result = await client.MachineTags.GetValuesAsync("dc", "subject");

        Assert.NotNull(result);
        Assert.Single(result.Values);
        Assert.Equal("dc", result.Namespace);
        Assert.Equal("subject", result.Predicate);
    }
}
