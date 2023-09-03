namespace Flickr.Net.Core.Extensions;

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
            Item item => UtilityMethods.BuddyIcon(item.OwnerServer, item.OwnerFarm.ToString(), item.OwnerId),
            Contact contact => UtilityMethods.BuddyIcon(contact.IconServer, contact.IconFarm.ToString(), contact.Id),
            Gallery gallery => UtilityMethods.BuddyIcon(gallery.IconServer, gallery.IconFarm.ToString(), gallery.Owner),
            Group group => UtilityMethods.BuddyIcon(group.IconServer, group.IconFarm.ToString(), group.Id),
            GroupInfo groupInfo => UtilityMethods.BuddyIcon(groupInfo.IconServer, groupInfo.IconFarm.ToString(), groupInfo.Id),
            Member member => UtilityMethods.BuddyIcon(member.IconServer, member.IconFarm.ToString(), member.Id),
            Person person => UtilityMethods.BuddyIcon(person.IconServer, person.IconFarm.ToString(), person.Id),
            PhotoInfo photoInfo => photoInfo.Owner.ToBuddyIconUrl(),
            Comment comment => UtilityMethods.BuddyIcon(comment.IconServer, comment.IconFarm.ToString(), comment.Author),
            PhotoPerson photoPerson => UtilityMethods.BuddyIcon(photoPerson.IconServer, photoPerson.IconFarm.ToString(), photoPerson.Id),
            Topic topic => UtilityMethods.BuddyIcon(topic.AuthorIconServer, topic.AuthorIconFarm.ToString(), topic.Author),
            Reply reply => UtilityMethods.BuddyIcon(reply.IconServer, reply.IconFarm.ToString(), reply.Author),
            Owner owner => UtilityMethods.BuddyIcon(owner.IconServer, owner.IconFarm.ToString(), owner.Id),
            _ => string.Empty
        };
    }
}
