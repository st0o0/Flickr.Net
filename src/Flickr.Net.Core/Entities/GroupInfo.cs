﻿using System.Xml;

namespace Flickr.Net.Core.Entities;

/// <summary>
/// Information about public groups for a user.
/// </summary>
public sealed class GroupInfo : IFlickrParsable
{
    /// <summary>
    /// Property which returns the group id for the group.
    /// </summary>
    public string GroupId { get; set; }

    /// <summary>
    /// The group name.
    /// </summary>
    public string GroupName { get; set; }

    /// <summary>
    /// Server farm for the group buddy icon.
    /// </summary>
    public string IconFarm { get; set; }

    /// <summary>
    /// Server for the group buddy icon.
    /// </summary>
    public string IconServer { get; set; }

    /// <summary>
    /// Group buddy icon.
    /// </summary>
    public string GroupIconUrl
    {
        get
        {
            return UtilityMethods.BuddyIcon(IconServer, IconFarm, GroupId);
        }
    }

    /// <summary>
    /// True if the user is the admin for the group, false if they are not.
    /// </summary>
    public bool IsAdmin { get; set; }

    /// <summary>
    /// Is the authenticated user a moderator of the group.
    /// </summary>
    public bool? IsModerator { get; set; }

    /// <summary>
    /// Is the authenticated user a member of the group.
    /// </summary>
    public bool? IsMember { get; set; }

    /// <summary>
    /// Will contain 1 if the group is restricted to people who are 18 years old or over, 0 if it is not.
    /// </summary>
    public bool EighteenPlus { get; set; }

    /// <summary>
    /// Whether the group is invitation only.
    /// </summary>
    public bool InvitationOnly { get; set; }

    /// <summary>
    /// The number of members in a group.
    /// </summary>
    public int Members { get; set; }

    /// <summary>
    /// The total number of photos in the group.
    /// </summary>
    public long PoolCount { get; set; }

    /// <summary>
    /// The URL for the group web page.
    /// </summary>
    public string GroupUrl
    {
        get { return string.Format(System.Globalization.CultureInfo.InvariantCulture, "https://www.flickr.com/groups/{0}/", GroupId); }
    }

    void IFlickrParsable.Load(XmlReader reader)
    {
        while (reader.MoveToNextAttribute())
        {
            switch (reader.LocalName)
            {
                case "nsid":
                    GroupId = reader.Value;
                    break;

                case "name":
                    GroupName = reader.Value;
                    break;

                case "admin":
                case "is_admin":
                    IsAdmin = reader.Value == "1";
                    break;

                case "is_member":
                    IsMember = reader.Value == "1";
                    break;

                case "is_moderator":
                    IsModerator = reader.Value == "1";
                    break;

                case "eighteenplus":
                    EighteenPlus = reader.Value == "1";
                    break;

                case "invitation_only":
                    InvitationOnly = reader.Value == "1";
                    break;

                case "iconfarm":
                    IconFarm = reader.Value;
                    break;

                case "iconserver":
                    IconServer = reader.Value;
                    break;

                case "members":
                    Members = reader.ReadContentAsInt();
                    break;

                case "pool_count":
                    PoolCount = reader.ReadContentAsLong();
                    break;

                default:
                    UtilityMethods.CheckParsingException(reader);
                    break;
            }
        }

        reader.Read();
    }
}