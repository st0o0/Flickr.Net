using Flickr.Net.Core.Enums;
using Flickr.Net.Core.Internals.Extensions;

namespace Flickr.Net.Core.Test;

public class MemberTypeTests
{
    [Fact]
    public void MemberType_Admin_Has_Member()
    {
        var result = MemberType.Admin | MemberType.None;
        Assert.True(result.Is(MemberType.Admin));
        Assert.True(result.Has(MemberType.Member));
    }

    [Fact]
    public void MemberType_Admin_Has_Moderator()
    {
        const MemberType result = MemberType.Admin | MemberType.None;
        Assert.True(result.Is(MemberType.Admin));
        Assert.True(result.Has(MemberType.Moderator));
    }

    [Fact]
    public void MemberType_Moderator_Has_Member()
    {
        var result = MemberType.Moderator | MemberType.None;
        Assert.True(result.Is(MemberType.Moderator));
        Assert.True(result.Has(MemberType.Member));
    }
}