namespace Flickr.Net.Core.Internals.Extensions;

/// <summary>
/// </summary>
public static class MemberTypeExtensions
{
    /// <summary>
    /// Members the type to string.
    /// </summary>
    /// <param name="memberTypes">The member types.</param>
    /// <returns>A string.</returns>
    public static string ToFlickrString(this MemberType memberTypes)
    {
        List<string> types = new();

        if (memberTypes.Has(MemberType.Narwhal))
        {
            types.Add("1");
        }

        if (memberTypes.Has(MemberType.Member))
        {
            types.Add("2");
        }

        if (memberTypes.Has(MemberType.Moderator))
        {
            types.Add("3");
        }

        if (memberTypes.Has(MemberType.Admin))
        {
            types.Add("4");
        }

        return string.Join(",", types.ToArray());
    }

    public static bool Has(this MemberType type, in MemberType value)
    {
        return value <= type;
    }

    public static bool Is(this MemberType type, MemberType value)
    {
        return type == value;
    }

    public static MemberType Add(this MemberType type, MemberType value)
    {
        return type | value;
    }

    public static MemberType Remove(this MemberType type, MemberType value)
    {
        return type & ~value;
    }
}