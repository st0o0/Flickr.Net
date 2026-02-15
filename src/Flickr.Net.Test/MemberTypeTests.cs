using Flickr.Net.Enums;
using Flickr.Net.Internals.Extensions;
using Xunit;

namespace Flickr.Net.Test;

public class MemberTypeTests
{
    [Fact]
    public void MemberType_Admin_Has_Member()
    {
        const MemberType result = MemberType.Admin | MemberType.None;
        Assert.True(result.Is(MemberType.Admin));
        Assert.True(result.Has(MemberType.Admin));
        Assert.True(result.Has(MemberType.Member));
    }

    [Fact]
    public void MemberType_Admin_Has_Moderator()
    {
        const MemberType result = MemberType.Admin | MemberType.None;
        Assert.True(result.Is(MemberType.Admin));
        Assert.True(result.Has(MemberType.Admin));
        Assert.True(result.Has(MemberType.Moderator));
    }

    [Fact]
    public void MemberType_Moderator_Has_Member()
    {
        const MemberType result = MemberType.Moderator | MemberType.None;
        Assert.True(result.Is(MemberType.Moderator));
        Assert.True(result.Has(MemberType.Moderator));
        Assert.True(result.Has(MemberType.Member));
    }
}