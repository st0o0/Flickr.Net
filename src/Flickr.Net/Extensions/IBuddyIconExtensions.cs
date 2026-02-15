using Flickr.Net.Internals;

namespace Flickr.Net.Extensions;

/// <summary>
/// </summary>
public static class IBuddyIconExtensions
{
    /// <summary>
    /// </summary>
    public static string ToBuddyIconUrl(this IBuddyIcon value)
    {
        return value switch
        {
            Item item => UtilityMethods.BuddyIcon(item.OwnerServer, item.OwnerFarm, item.OwnerId),
            Contact contact => UtilityMethods.BuddyIcon(contact.IconServer, contact.IconFarm.ToString(), contact.Id),
            Gallery gallery => UtilityMethods.BuddyIcon(gallery.IconServer, gallery.IconFarm.ToString(), gallery.Owner),
            Group group => UtilityMethods.BuddyIcon(group.IconServer, group.IconFarm.ToString(), group.Id),
            GroupInfo groupInfo => UtilityMethods.BuddyIcon(groupInfo.IconServer, groupInfo.IconFarm.ToString(), groupInfo.Id),
            Member member => UtilityMethods.BuddyIcon(member.IconServer, member.IconFarm.ToString(), member.Id),
            Person person => UtilityMethods.BuddyIcon(person.IconServer, person.IconFarm.ToString(), person.Id),
            PhotoInfo photoInfo => UtilityMethods.BuddyIcon(photoInfo.Owner.IconServer, photoInfo.Owner.IconFarm.ToString(), photoInfo.Owner.Id),
            Comment comment => UtilityMethods.BuddyIcon(comment.IconServer, comment.IconFarm.ToString(), comment.Author),
            PhotoPerson photoPerson => UtilityMethods.BuddyIcon(photoPerson.IconServer, photoPerson.IconFarm.ToString(), photoPerson.Id),
            Topic topic => UtilityMethods.BuddyIcon(topic.AuthorIconServer, topic.AuthorIconFarm.ToString(), topic.Author),
            Reply reply => UtilityMethods.BuddyIcon(reply.IconServer, reply.IconFarm.ToString(), reply.Author),
            _ => string.Empty
        };
    }
}
