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
    public static string ToFlickrString(this MemberTypes memberTypes)
    {
        List<string> types = new();

        if ((memberTypes & MemberTypes.Narwhal) == MemberTypes.Narwhal)
        {
            types.Add("1");
        }

        if ((memberTypes & MemberTypes.Member) == MemberTypes.Member)
        {
            types.Add("2");
        }

        if ((memberTypes & MemberTypes.Moderator) == MemberTypes.Moderator)
        {
            types.Add("3");
        }

        if ((memberTypes & MemberTypes.Admin) == MemberTypes.Admin)
        {
            types.Add("4");
        }

        return string.Join(",", types.ToArray());
    }
}
