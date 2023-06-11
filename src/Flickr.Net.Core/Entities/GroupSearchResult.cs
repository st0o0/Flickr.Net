namespace Flickr.Net.Core.Entities;

/// <summary>
/// A class which encapsulates a single group search result.
/// </summary>
public sealed class GroupSearchResult : IFlickrParsable
{
    /// <summary>
    /// The group id for the result.
    /// </summary>
    public string GroupId { get; set; }

    /// <summary>
    /// The group name for the result.
    /// </summary>
    public string GroupName { get; set; }

    /// <summary>
    /// True if the group is an over eighteen (adult) group only.
    /// </summary>
    public bool EighteenPlus { get; set; }

    /// <summary>
    /// THe privacy setting for this groups photo pool.
    /// </summary>
    public PoolPrivacy Privacy { get; set; }

    /// <summary>
    /// Group icon server.
    /// </summary>
    public string IconServer { get; set; }

    /// <summary>
    /// Group icon farm.
    /// </summary>
    public string IconFarm { get; set; }

    /// <summary>
    /// Number of members in the group.
    /// </summary>
    public int Members { get; set; }

    /// <summary>
    /// The number of photos in this groups pool.
    /// </summary>
    public int PoolCount { get; set; }

    /// <summary>
    /// The number of topics in this groups discussion list.
    /// </summary>
    public int TopicCount { get; set; }

    /// <summary>
    /// The url for the group's icon.
    /// </summary>
    public string GroupIconUrl
    {
        get
        {
            return UtilityMethods.BuddyIcon(IconServer, IconFarm, GroupId);
        }
    }

    void IFlickrParsable.Load(XmlReader reader)
    {
        if (reader.LocalName != "group")
        {
            UtilityMethods.CheckParsingException(reader);
        }

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

                case "eighteenplus":
                    EighteenPlus = reader.Value == "1";
                    break;

                case "iconserver":
                    IconServer = reader.Value;
                    break;

                case "iconfarm":
                    IconFarm = reader.Value;
                    break;

                case "members":
                    Members = reader.ReadContentAsInt();
                    break;

                case "pool_count":
                    PoolCount = reader.ReadContentAsInt();
                    break;

                case "topic_count":
                    TopicCount = reader.ReadContentAsInt();
                    break;

                case "privacy":
                    Privacy = (PoolPrivacy)reader.ReadContentAsInt();
                    break;

                default:
                    UtilityMethods.CheckParsingException(reader);
                    break;
            }
        }

        reader.Skip();
    }
}