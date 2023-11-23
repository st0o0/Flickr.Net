namespace Flickr.Net.Internals.Extensions;

/// <summary>
/// </summary>
public static class MemberTypeExtensions
{
    /// <summary>
    /// Members the type to string.
    /// </summary>
    /// <param name="memberTypes">The member types.</param>
    /// <returns>A string.</returns>
    internal static string ToFlickrString(this MemberType memberTypes)
    {
        List<string> types = [];

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

    /// <summary>
    /// </summary>
    public static bool Has(this MemberType type, in MemberType value)
    {
        return value <= type;
    }

    /// <summary>
    /// </summary>
    public static bool Is(this MemberType type, MemberType value)
    {
        return type == value;
    }

    /// <summary>
    /// </summary>
    public static MemberType Add(this MemberType type, MemberType value)
    {
        return type | value;
    }

    /// <summary>
    /// </summary>
    public static MemberType Remove(this MemberType type, MemberType value)
    {
        return type & ~value;
    }
}