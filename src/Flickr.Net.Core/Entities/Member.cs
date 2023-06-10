namespace Flickr.Net.Core.Entities;

/// <summary>
/// Details for a Flickr member, as returned by the <see
/// cref="IFlickrGroupsMembers.GetListAsync(string, MemberTypes, int, int, CancellationToken)"/> method.
/// </summary>
public sealed class Member : IFlickrParsable
{
    /// <summary>
    /// The user id for the member.
    /// </summary>
    public string MemberId { get; set; }

    /// <summary>
    /// The members name.
    /// </summary>
    public string UserName { get; set; }

    /// <summary>
    /// The icon server for the users buddy icon. See <see cref="IconUrl"/> for the complete URL.
    /// </summary>
    public string IconServer { get; set; }

    /// <summary>
    /// The icon farm for the users buddy icon. See <see cref="IconUrl"/> for the complete URL.
    /// </summary>
    public string IconFarm { get; set; }

    /// <summary>
    /// The type of the member (basic, moderator or administrator).
    /// </summary>
    public MemberTypes MemberType { get; set; }

    /// <summary>
    /// The icon URL for the users buddy icon. Calculated from the <see cref="IconFarm"/> and <see cref="IconServer"/>.
    /// </summary>
    public string IconUrl
    {
        get
        {
            return UtilityMethods.BuddyIcon(IconServer, IconFarm, MemberId);
        }
    }

    void IFlickrParsable.Load(System.Xml.XmlReader reader)
    {
        // To parse:
        // <member nsid="123456@N01" username="foo" iconserver="1" iconfarm="1" membertype="2"/>
        MemberId = reader.GetAttribute("nsid");
        UserName = reader.GetAttribute("username");
        IconServer = reader.GetAttribute("iconserver");
        IconFarm = reader.GetAttribute("iconfarm");
        MemberType = UtilityMethods.ParseIdToMemberType(reader.GetAttribute("membertype"));
    }
}